// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++ and C#: http://www.viva64.com

/* FilterLab
 * ExternalApplication.cs
 
 * © Swanson Labs, 2018
 *
 * The external application. This is the entry point of the
 * 'FilterLab' (Revit add-in).
 */
#region Namespaces
using System;
using System.IO;
using System.Collections.Generic;
using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System.Resources;
using System.Reflection;
using System.Drawing;
using System.Windows.Media.Imaging;
using System.Windows.Interop;
using WPF = System.Windows;
using System.Linq;
using swanson.FilterLab.Properties;
using Bushman.RevitDevTools;
using System.Xml.Linq;
using System.Windows.Media;
using System.Windows;
#endregion

namespace swanson.FilterLab
{

    /// <summary>
    /// Revit external application.
    /// </summary>  
    public sealed partial class ExternalApplication
        : IExternalApplication
    {

        /// <summary>
        /// This method will be executed when Autodesk Revit 
        /// will be started.
        /// 
        /// WARNING
        /// Don't use the RevitDevTools.dll features directly 
        /// in this method. You are to call other methods which
        /// do it instead of.
        /// </summary>
        /// <param name="uic_app">A handle to the application 
        /// being started.</param>
        /// <returns>Indicates if the external application 
        /// completes its work successfully.</returns>
        Result IExternalApplication.OnStartup(
            UIControlledApplication uic_app)
        {

           
            Result result = Result.Succeeded;
            string tabName = "Filter Lab";
            string panelName = "Filter Tools";
            string panelName2 = "Settings";
            string buttonfiltername = "Selection Filter";
            string buttonfilternametype = "Selection" + Environment.NewLine + "Filter";
            string buttonfilternamehelp = "This tool is used to Filter selected elements.";
            string buttonfiltername2 = "Pre-Selection Filter";
            string buttonfiltername2type = "Pre-Selection" + Environment.NewLine + "Filter";
            string buttonfilternamehelp2 = "This tool is used to Filter elements before selecting.";
            string button2Name = "Sheets";
            string button3Name = "Strand";
            string buttonsplitName = "Extra Tools";

            try
            {
                List<RibbonPanel> panels = uic_app.GetRibbonPanels(
                  tabName);
            }
            catch
            {
                uic_app.CreateRibbonTab(tabName);
            }

            RibbonPanel panelViewExport = uic_app.CreateRibbonPanel(
              tabName, panelName);

            panelViewExport.Name = panelName;
            panelViewExport.Title = panelName;

            PushButtonData buttonfilter = new PushButtonData(
              buttonfiltername, buttonfilternametype,
              Assembly.GetExecutingAssembly().Location,
              typeof(SelectedCommand).FullName);

            buttonfilter.ToolTip = buttonfilternamehelp;
            ImageSource iconfilter = GetIconSource(Resources.Button_image_17);
            buttonfilter.LargeImage = iconfilter;
            buttonfilter.Image = Thumbnail(iconfilter);
            panelViewExport.AddItem(buttonfilter);

            panelViewExport.AddSeparator();

            PushButtonData buttonfilter2 = new PushButtonData(
              buttonfiltername2, buttonfiltername2type,
              Assembly.GetExecutingAssembly().Location,
              typeof(PreSelectionCommand).FullName);

            buttonfilter2.ToolTip = buttonfilternamehelp2;
            ImageSource iconfilter2 = GetIconSource(Resources.Button_image_24);
            buttonfilter2.LargeImage = iconfilter2;
            buttonfilter2.Image = Thumbnail(iconfilter2);
            panelViewExport.AddItem(buttonfilter2);

            panelViewExport.AddSeparator();

            PushButtonData button2 = new PushButtonData(
              button2Name, button2Name,
              Assembly.GetExecutingAssembly().Location,
              typeof(FilterCommand).FullName);

            button2.ToolTip = button2Name;
            ImageSource icon2 = GetIconSource(Resources.Button_image_20);
            button2.LargeImage = icon2;
            button2.Image = Thumbnail(icon2);



            PushButtonData button3 = new PushButtonData(
              button3Name, button3Name,
              Assembly.GetExecutingAssembly().Location,
              typeof(FilterCommand).FullName);

            button3.ToolTip = button3Name;
            ImageSource icon3 = GetIconSource(Resources.Button_image_18);
            button3.LargeImage = icon3;
            button3.Image = Thumbnail(icon3);


            SplitButtonData sb1 = new SplitButtonData(buttonsplitName, buttonsplitName);
            SplitButton sb = panelViewExport.AddItem(sb1) as SplitButton;
            sb.AddPushButton(button2);
            sb.AddPushButton(button3);
            
            

            RibbonPanel panelViewExport2 = uic_app.CreateRibbonPanel(
              tabName, panelName2);

            panelViewExport2.Name = panelName2;
            panelViewExport2.Title = panelName2;

            PushButtonData buttonsettings = new PushButtonData(
              "Settings", "Settings",
              Assembly.GetExecutingAssembly().Location,
              typeof(SettingsCommand).FullName);

            buttonsettings.ToolTip = "To change settings for Filters.";
            ImageSource iconsettings = GetIconSource(Resources.Button_image_13);
            buttonsettings.LargeImage = iconsettings;
            buttonsettings.Image = Thumbnail(iconsettings);
            panelViewExport2.AddItem(buttonsettings);

            panelViewExport2.AddSeparator();

            PushButtonData buttonweb = new PushButtonData(
              "Web Help", "Web Help",
              Assembly.GetExecutingAssembly().Location,
              typeof(WebHelp).FullName);

            buttonweb.ToolTip = "Why not Google It!!!!";
            ImageSource iconweb = GetIconSource(Resources.Button_image_21);
            buttonweb.LargeImage = iconweb;
            buttonweb.Image = Thumbnail(iconweb);
            panelViewExport2.AddItem(buttonweb);

            panelViewExport2.AddSeparator();

            PushButtonData buttonabout = new PushButtonData(
              "About", "About",
              Assembly.GetExecutingAssembly().Location,
              typeof(AboutCommand).FullName);

            buttonabout.ToolTip = "Learn About Filter Labs";
            ImageSource iconabout = GetIconSource(Resources.Button_image_23);
            buttonabout.LargeImage = iconabout;
            buttonabout.Image = Thumbnail(iconabout);
            panelViewExport2.AddItem(buttonabout);

            return result;
        }

        void Initialize(UIControlledApplication uic_app)
        {
            // Fix the bug of Revit 2017.1.1
            // More info read here:
            // https://revit-addins.blogspot.ru/2017/01/revit-201711.html
            RevitPatches.PatchCultures(uic_app
                .ControlledApplication.Language);



            // Create the tabs, panels, and buttons
            UIBuilder.BuildUI(uic_app, Assembly
                .GetExecutingAssembly(), typeof(Resources))
                ;
        }

        /// <summary>
        /// This method will be executed when Autodesk Revit 
        /// shuts down.</summary>
        /// <param name="uic_app">A handle to the application 
        /// being shut down.</param>
        /// <returns>Indicates if the external application 
        /// completes its work successfully.</returns>
        Result IExternalApplication.OnShutdown(
            UIControlledApplication uic_app)
        {

            ResourceManager res_mng = new ResourceManager(
                  GetType());
            ResourceManager def_res_mng = new ResourceManager(
                typeof(Properties.Resources));

            Result result = Result.Succeeded;

            try
            {

                AppDomain.CurrentDomain.AssemblyResolve -=
                CurDom_AssemblyResolve;

            }
            catch (Exception ex)
            {

                TaskDialog.Show(def_res_mng.GetString("_Error")
                    , ex.Message);

                result = Result.Failed;
            }
            finally
            {

                res_mng.ReleaseAllResources();
                def_res_mng.ReleaseAllResources();
            }

            return result;
        }

        // It contains info from the AssemblyResolves.xml file.
        static Dictionary<string, string> asm_dict =
            GetResolves();

        /// <summary>
        /// This method reads info from the 
        /// AssemblyResolves.xml file.
        /// </summary>
        /// <returns>It returns a dictionary.</returns>
        private static Dictionary<string, string> GetResolves(
            )
        {

            string asm_dir = Path.GetDirectoryName(Assembly
                .GetExecutingAssembly().Location);

            string xml_file = Path.Combine(asm_dir,
                "AssemblyResolves.xml");

            XElement xml = null;

            if (!File.Exists(xml_file) ||
                (xml = XElement.Load(xml_file)) == null)
            {

                RecoveryFile(xml_file);
                xml = XElement.Load(xml_file);
            }

            Dictionary<string, string> dict =
                new Dictionary<string, string>();

            foreach (var item in xml.Elements("Assembly"))
            {

                string key = item.Attribute("Name").Value;
                string value = Environment
                    .ExpandEnvironmentVariables(item.Attribute(
                        "Location").Value);

                if (!dict.ContainsKey(key))
                {

                    dict.Add(key, value);
                }
            }

            return dict;
        }

        /// <summary>
        /// Recover the AssemblyResolves.xml file.
        /// </summary>
        /// <param name="xml_file"></param>
        private static void RecoveryFile(string xml_file)
        {

            if (string.IsNullOrEmpty(xml_file))
            {
                throw new ArgumentException(nameof(xml_file));
            }

            string data =
@"<?xml version='1.0' encoding='utf-8' ?>
<!-- This file contains info about location of assemblies. -->
<Assemblies>
  <Assembly Name='Revit2017DevTools'
            Location='%AppData%\Bushman\Revit\2017\RevitDevTools\RevitDevTools.dll'/>
</Assemblies>";

            XElement xml = XElement.Parse(data);
            xml.Save(xml_file);
        }

        private Assembly CurDom_AssemblyResolve(object sender,
            ResolveEventArgs args)
        {

            string name = args.Name.Split(',').First();

            if (!asm_dict.ContainsKey(name))
            {

                return null;
            }

            Assembly result = Assembly.LoadFrom(asm_dict[name])
                ;

            return result;
        }
        public static ImageSource Thumbnail(
     ImageSource source)
        {
            Rect rect = new Rect(0, 0, 16, 16);
            DrawingVisual drawingVisual = new DrawingVisual();

            using (DrawingContext drawingContext
              = drawingVisual.RenderOpen())
            {
                drawingContext.DrawImage(source, rect);
            }

            RenderTargetBitmap resizedImage
              = new RenderTargetBitmap(
                (int)rect.Width, (int)rect.Height, 96, 96,
                PixelFormats.Default);

            resizedImage.Render(drawingVisual);

            return resizedImage;
        }

        public static ImageSource GetIconSource(Bitmap bmp)
        {
            BitmapSource icon
              = Imaging.CreateBitmapSourceFromHBitmap(
              bmp.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty,
              System.Windows.Media.Imaging.BitmapSizeOptions.FromEmptyOptions());

            return (System.Windows.Media.ImageSource)icon;
        }
    }
}
