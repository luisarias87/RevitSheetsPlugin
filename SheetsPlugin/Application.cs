using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.Attributes;
using System.Reflection;
using System.IO;
using System.Windows.Media.Imaging;


namespace SheetsPlugin
{



    public class Application :IExternalApplication

    {

        public Result OnStartup(UIControlledApplication application) 
        {
            
            RibbonPanel panel = createRibbonPanel(application);

            string thisAssemblyPath = Assembly.GetExecutingAssembly().Location;
            // BUTTON FOR THE SINGLE-THREADED WPF OPTION
            if (panel.AddItem(
                new PushButtonData("WPFforms", "WPF\nforms", thisAssemblyPath,
                    "SheetsPlugin.Command")) is PushButton button)
            {
                // defines the tooltip displayed when the button is hovered over in Revit's ribbon
                button.ToolTip = "WPF Form Example";
                // defines the icon for the button in Revit's ribbon - note the string formatting
                Uri uriImage = new Uri(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "Resources", "Sheets.png"));
                BitmapImage largeImage = new BitmapImage(uriImage);
                button.LargeImage = largeImage;
            }



            return Result.Succeeded;
           

        }
        public Result OnShutdown(UIControlledApplication application) 
        {
            return Result.Succeeded; 
            
        }

        public RibbonPanel createRibbonPanel(UIControlledApplication app) 
        {
            string tabName = "My Tools";
            RibbonPanel ribbonPanel = null;

            try
            {
                app.CreateRibbonTab(tabName);

            }
            catch (Exception)
            {

                throw;
            }
            try
            {
                app.CreateRibbonPanel(tabName,"Sheets Panel");

            }
            catch (Exception)
            {

                throw;
            }

            List<RibbonPanel> panels = app.GetRibbonPanels(tabName);

            foreach (RibbonPanel item in panels.Where(p => p.Name == "Sheets Panel") )
            {
                ribbonPanel = item;


            }
            return ribbonPanel;

        
        }
        


        




    }
}
