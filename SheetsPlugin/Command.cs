//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using Autodesk.Revit.DB;
//using Autodesk.Revit.UI;
//using Autodesk.Revit.Attributes;
//using System.Windows.Forms;

//namespace SheetsPlugin
//{      [Transaction(TransactionMode.Manual)]
//    internal class Command : IExternalCommand
//    {

//        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
//        {
//            UIDocument uidoc = commandData.Application.ActiveUIDocument;
//            Document doc = commandData.Application.ActiveUIDocument.Document;

//            // the current document
//            Document document = commandData.Application.ActiveUIDocument.Document;

//            // wpf viewer form
//            Viewer viewer = new Viewer();
            
//            //return result
//            return Result.Succeeded;


            
//        }
//    }
//}
