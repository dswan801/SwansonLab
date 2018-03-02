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

    /// <summary>
    /// Revit external command.
    /// </summary>	
	[Transaction(TransactionMode.Manual)]
    sealed partial class SettingsCommand
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

            try
            {
                #region Stuff        
                SettingsUI settingui1 = new SettingsUI(commandData);
                if (settingui1.ShowDialog() == false)                    
                    return Result.Cancelled;


                #endregion
            }
            catch (Exception e)
            {
                message = e.Message;
                return Autodesk.Revit.UI.Result.Failed;
            }




            return Result.Succeeded;
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
