// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++ and C#: http://www.viva64.com

/* WebHelp.cs
 * © SwansonLabs, 2018
 *
 * The external command.
 */
#region Namespaces
using System;
using System.IO;
using System.Collections.Generic;
using System.Diagnostics;
using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
using System.Resources;
using System.Reflection;
using System.Drawing;
using System.Windows.Media.Imaging;
using System.Windows.Interop;
using WPF = System.Windows;
using System.Linq;
using Bushman.RevitDevTools;
using swanson.FilterLab.Properties;
using System.Windows.Media;
using System.Windows;
using System.Windows.Forms;


#endregion

namespace swanson.FilterLab
{

    public class Selectionfitler : ISelectionFilter
    {

        public bool AllowElement(Element element)
        {
            if (preSelectionUI.cat.Contains(element.GetType().Name) || preSelectionUI.cat.Contains(element.Category.Name))
            {
                return true;
            }
            return false;
        }
        public bool AllowReference(Reference refer, XYZ point)
        {
            return false;
        }
        
    }

    /// <summary>
    /// Revit external command.
    /// </summary>	
	[Transaction(TransactionMode.Manual)]
    sealed partial class PreSelectionCommand
        : IExternalCommand
    {
        public Result Execute(
                ExternalCommandData commandData,
                ref string message,
                ElementSet elements)
        {
            UIApplication uiapp = commandData.Application;
            UIDocument uidoc = uiapp.ActiveUIDocument;
            Autodesk.Revit.ApplicationServices.Application app = uiapp.Application;
            Document doc = uidoc.Document;

            preSelectionUI.cancel_form = false;

            preSelectionUI form = new preSelectionUI();
            form.ShowDialog();

            if (preSelectionUI.cancel_form == true)
            {
                return Result.Cancelled;
            }



            IList<Reference> refs = new List<Reference>();
            IList<ElementId> ids = new List<ElementId>();
            Selectionfitler selfilter = new Selectionfitler();
            // prompt user to add to selection or remove from it
            Selection sel = uidoc.Selection;



            try
            {
                #region Stuff      
                ICollection<ElementId> preSelectedElemIds = sel.GetElementIds();
                foreach (ElementId id in preSelectedElemIds)
                {
                    Reference elemRef = new Reference(doc.GetElement(id));
                    refs.Add(elemRef);
                }

                refs = sel.PickObjects(ObjectType.Element, selfilter, "Please pick element.", refs);
                foreach (Reference r in refs)
                {
                    ids.Add(r.ElementId);
                }
                sel.SetElementIds(ids);
                return Result.Succeeded;
                #endregion
            }
            catch (OperationCanceledException)
            {
                return Result.Cancelled;
            }
            catch (Exception)
            {
                return Result.Failed;
            }

            
        }


        #region Helpers
        public static ImageSource GetIconSource(Bitmap bmp)
        {
            BitmapSource icon
              = Imaging.CreateBitmapSourceFromHBitmap(
              bmp.GetHbitmap(), IntPtr.Zero, System.Windows.Int32Rect.Empty,
              System.Windows.Media.Imaging.BitmapSizeOptions.FromEmptyOptions());

            return (System.Windows.Media.ImageSource)icon;
        }


        

        #endregion
    }
}
