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
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
namespace SheetsPlugin
{
    /// <summary>
    /// Interaction logic for Viewer.xaml
    /// </summary>
    public partial class Viewer : Page,IDockablePaneProvider
    {
        //fields
        public Document doc = null;
        public ExternalCommandData eData = null;
        public UIDocument uidoc = null;
         

        // IDockablePanelProvider abstract method
        public void SetupDockablePane(DockablePaneProviderData data) 
        {
            // wpf object with pane's interface
            data.FrameworkElement = this as FrameworkElement;
            //initial state position
            data.InitialState = new DockablePaneState 
            {
                DockPosition = DockPosition.Tabbed,
                TabBehind = DockablePanes.BuiltInDockablePanes.ProjectBrowser
            };

        }
        public Viewer()
        {
            // assign avalue to field

            InitializeComponent();
            
        }
        // custom initiator
        public void CustomInitiator(ExternalCommandData e)
        {
            // ExternalCommandData and Doc
            eData = e;
            doc = e.Application.ActiveUIDocument.Document;
            uidoc = eData.Application.ActiveUIDocument;

            // get the current document name
            docName.Text = doc.PathName.ToString().Split('\\').Last();
            // get the active view name
            viewName.Text = doc.ActiveView.Name;
            // call the treeview display method
            DisplayTreeViewItem();
        }

        
        
        public void DisplayTreeViewItem() 
        {
            // viewtypename and treeviewitem dictionary
            SortedDictionary<string, TreeViewItem> ViewTypeDictionary = new SortedDictionary<string, TreeViewItem>();
            // viewtypename
            List<string> viewTypenames = new List<string>();

            // Collect View Type
            List<Element> elements = new FilteredElementCollector(doc).OfClass(typeof(View)).ToList();

            foreach (Element element in elements)
            {
                //view
                View view = element as View;
                // view typename    
                viewTypenames.Add(view.ViewType.ToString());
            }
            // create treeviewitem for viewtype
            foreach (string viewTypename in viewTypenames.Distinct().OrderBy(name => name).ToList())
            {
                // create viewtype treeviewitem
                TreeViewItem viewTypeItem  = new TreeViewItem() { Header = viewTypename };
                ViewTypeDictionary[viewTypename] = viewTypeItem;
                treeview.Items.Add(viewTypeItem);
            }
            foreach (Element element in elements)
            {
                //view
                View view = element as View;
                // viewname
                string viewName = view.Name;
                // view typename
                string viewTypename = view.ViewType.ToString(); 
                // create view treeviewitem
                TreeViewItem viewItem = new TreeViewItem() { Header = viewName };
                // view item add to view type
                ViewTypeDictionary[viewTypename].Items.Add(viewItem);
            }
        }


        private void PickObject_Click(object sender, RoutedEventArgs e)

        {
            UIDocument uidoc = eData.Application.ActiveUIDocument;
            Selection pick = uidoc.Selection;

            

            var pickedElements = uidoc.Selection.PickElementsByRectangle("Select");


            if (pickedElements.Count > 0)
            {
                var idsToSelect = new List<Element>(pickedElements.Count);
                foreach (Element element in pickedElements)

                {
                    idsToSelect.Add(element);
                    pickedListBox.ItemsSource = idsToSelect;

                }
            }
        }
    }
}
