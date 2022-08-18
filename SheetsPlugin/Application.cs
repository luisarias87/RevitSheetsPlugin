using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.Attributes;


namespace SheetsPlugin
{



    public class Application :IExternalApplication

    {

        public Result OnStartup(UIControlledApplication application) 
        {
            createRibbonPanel(application);

            return Result.Succeeded;
           

        }
        public Result OnShutdown(UIControlledApplication application) 
        {
            return Result.Succeeded; 
            
        }

        public RibbonPanel createRibbonPanel(UIControlledApplication app) 
        {
            string tabName = "Sheets";
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
