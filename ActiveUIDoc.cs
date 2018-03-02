using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;

namespace swanson.FilterLab
{
    public class ActiveDoc
    {
        private static UIApplication m_uiApp;
        public static Autodesk.Revit.UI.UIApplication UIApp
        {
            set { m_uiApp = value; }
        }
        public static Autodesk.Revit.DB.Document Doc
        {
            get { return m_uiApp.ActiveUIDocument.Document; }
        }
    }
}
