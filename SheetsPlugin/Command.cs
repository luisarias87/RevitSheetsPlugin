using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.Attributes;
using System.Windows.Forms;

namespace SheetsPlugin
{      [Transaction(TransactionMode.Manual)]
    internal class Command : IExternalCommand
    {

        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIDocument uidoc = commandData.Application.ActiveUIDocument;
            Document doc = commandData.Application.ActiveUIDocument.Document;

            //message = "Please note the highlighted Walls.";

            using (System.Windows.Forms.Form form = new SheetsPlugin.Form.Form1(doc))
            {
                //Checks to see if the DialogResult of the form is OK and resturn the correct result as needed.
                if (form.ShowDialog() == DialogResult.OK)
                {
                    //Let Revit know it executed successfully.
                    return Result.Succeeded;
                }
                else
                {
                    //Let Revit know the Execute method did not finish successfully.All modifications to the Document will be rolled back based on the TransactionMode
                    return Result.Cancelled;
                }
            }

            
        }
    }
}
