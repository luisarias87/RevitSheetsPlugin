using System;
using System.IO;
using System.Reflection;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Events;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB.Events;

namespace SheetsPlugin
{
    public class CommandAvailability : IExternalCommandAvailability

    {
        // interface memeber method
        public bool IsCommandAvailable(UIApplication app, CategorySet cate)
        {
            if (app.ActiveUIDocument == null)
            {
                // disable register btn
                return true;
            }
            // enable register btn
            return false;
        }
    }

    [Transaction(TransactionMode.Manual)]
    [Regeneration(RegenerationOption.Manual)]
    public class MainClass : IExternalApplication
    {


        Result IExternalApplication.OnShutdown(UIControlledApplication application)
        {
            return Result.Succeeded;
        }

        Result IExternalApplication.OnStartup(UIControlledApplication application)
        {
            // create a ribbon panel 
            RibbonPanel ribbonPanel = application.CreateRibbonPanel(Tab.AddIns, "Twenty Two Sample");
            // assembly
            Assembly assembly = Assembly.GetExecutingAssembly();
            // assembly path
            string assemblypath = assembly.Location;

            // Create register button
            PushButton registerButton = ribbonPanel.AddItem(new PushButtonData("Register Window", "Register", assemblypath, "SheetsPlugin.Register")
            {
                AvailabilityClassName = "SheetsPlugin.CommandAvailability"
            }) as PushButton;
            // btn tooltip 
            registerButton.ToolTip = "Register dockable window at the zero document state.";

            // register button icon images
            registerButton.LargeImage = GetResourceImage(assembly, "SheetsPlugin.Resources.register32.png");
            registerButton.Image = GetResourceImage(assembly, "SheetsPlugin.Resources.register16.png");

            // Show register button
            PushButton showButton = ribbonPanel.AddItem(new PushButtonData("Show Window", "Show", assemblypath, "SheetsPlugin.Show")) as PushButton;
            // btn tooltip 
            showButton.ToolTip = "Show the registered dockable window.";

            // Show button icon images
            showButton.LargeImage = GetResourceImage(assembly, "SheetsPlugin.Resources.show32.png");
            showButton.Image = GetResourceImage(assembly, "SheetsPlugin.Resources.show16.png");



            return Result.Succeeded;
        }



        // Get embeded images from assembly resources
        public ImageSource GetResourceImage(Assembly assembly, string imageName)
        {
            try
            { // bitmap stream to construct bitpmap frame
                Stream resource = assembly.GetManifestResourceStream(imageName);
                return BitmapFrame.Create(resource);

            }
            catch (Exception)
            {

                return null;
            }

        }
    }
    // external command availability
    //public class CommandAvailability : IExternalCommandAvailability

    //{
    //    // interface memeber method
    //    public bool IsCommandAvailable(UIApplication app, CategorySet cate)
    //    {
    //        if (app.ActiveUIDocument == null)
    //        {
    //            // disable register btn
    //            return true;
    //        }
    //        // enable register btn
    //        return false;
    //    }
    //}       

    [Transaction(TransactionMode.Manual)]
    public class Register : IExternalCommand
    {
        Viewer dockableWindow = null;
        ExternalCommandData  edata =null;
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {

            
            // dockable window                      
            edata = commandData;
            DockablePaneProviderData data = new DockablePaneProviderData();
            Viewer dock = new Viewer();
            dockableWindow = dock;

            // dockableWindow Setup
            data.FrameworkElement = dock as System.Windows.FrameworkElement;       
            DockablePaneState state = new DockablePaneState
            {
                DockPosition = DockPosition.Tabbed
            };
            
            
            // create a new dockable pane id
            DockablePaneId id = new DockablePaneId(new Guid("{0cd3cfc5-100d-433c-8b81-f16278eeb1ab}"));
            try
            {
                // register dockable pane
                commandData.Application.RegisterDockablePane(id, "TwentyTwo Dockable Sample", dock as IDockablePaneProvider);
                TaskDialog.Show("Info Message","Dockable window has registered!");

            }
            catch (Exception ex)
            {
                // show error info dialog 
                TaskDialog.Show("Info Message", ex.Message);                
                
            }
            
            // subscribe document opened event 
            commandData.Application.ViewActivated += new EventHandler<ViewActivatedEventArgs>(Application_ViewActivated);

            // subscribe to the document opened event 
            commandData.Application.Application.DocumentOpened += new EventHandler<Autodesk.Revit.DB.Events.DocumentOpenedEventArgs>(Application_DocumentOpened);
            return Result.Succeeded;
        }

        // view activated event
        public void Application_ViewActivated(object sender, ViewActivatedEventArgs e)
        {
            // provide ExternalCommandData object to dockable page
            dockableWindow.CustomInitiator(edata);

        }
        // document opened event
        private void Application_DocumentOpened(object sender, Autodesk.Revit.DB.Events.DocumentOpenedEventArgs e)
        {
            // provide ExternalCommandData object to dockable page
            dockableWindow.CustomInitiator(edata);
        }


    }

    [Transaction(TransactionMode.ReadOnly)]
    public class Show : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            try
            {
                // dockable window id 
                DockablePaneId id = new DockablePaneId(new Guid("{0cd3cfc5-100d-433c-8b81-f16278eeb1ab}"));
                DockablePane dockableWindow = commandData.Application.GetDockablePane(id);
                dockableWindow.Show();
                
            }
            catch (Exception ex)
            {
                // show error info dialog
                TaskDialog.Show("Info Message",ex.Message);

                
            }

            return Result.Succeeded;

        }



    }
    
}


 