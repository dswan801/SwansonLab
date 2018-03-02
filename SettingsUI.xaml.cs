using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Architecture;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.Attributes;
using System.Collections.ObjectModel;
using System.IO;
using System.Reflection;
using System.Collections;
using System.Diagnostics;


namespace swanson.FilterLab
{
    /// <summary>
    /// Interaction logic for SettingsUI.xaml
    /// </summary>
    public partial class SettingsUI : Window
    {
        Document doc;
        List<Category> categories;
        FilteredElementCollector catCollector;
        IList<Element> elements;
        List<ElementId> elementsId = new List<ElementId>();
        List<ElementId> FilteredElementsId = new List<ElementId>();
        UIDocument uiDoc;

        public SettingsUI(ExternalCommandData commandData)
        {
            doc = commandData.Application.ActiveUIDocument.Document;
            InitializeComponent();
            catCollector = new FilteredElementCollector(doc);
            uiDoc = new UIDocument(doc);
            //CreateCategoryList();                          

        }

        private void button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void textbox2_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void textbox3_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void textbox4_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}


   