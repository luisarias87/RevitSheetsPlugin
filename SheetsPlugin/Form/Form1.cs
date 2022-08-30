using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;

namespace SheetsPlugin.Form
{
    public partial class Form1 : System.Windows.Forms.Form
    {
        Document Doc;

        DataTable dgSheets = new DataTable();
        public Form1(Document doc)
        {
            InitializeComponent();
            Doc = doc;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            SetViews();
            AddHeaderCheckBox();
            HeaderCheckBox.MouseClick += new MouseEventHandler(HeaderCheckBox_MouseClick);


        }
        // Method to add a headercheckbox 
        CheckBox HeaderCheckBox = null;
        bool IsHeaderCheckBoxClicked = false;

        private void AddHeaderCheckBox()
        {

            HeaderCheckBox = new CheckBox();
            HeaderCheckBox.Size = new Size(15, 15);
            System.Drawing.Rectangle rect =DuplicateViewsDataGridView.GetCellDisplayRectangle(0, -1, true);
            // set checkbox header to center of header cell. +1 pixel to position 
            rect.Y = 3;
            rect.X = rect.Location.X + (rect.Width / 4);
            HeaderCheckBox.Location = rect.Location;
            //Add the CheckBox into the DataGridView
            this.DuplicateViewsDataGridView.Controls.Add(HeaderCheckBox);

        }
        // Header checkbox clickevent
        private void HeaderCheckBoxClicked(CheckBox HCheckBox)
        {
            IsHeaderCheckBoxClicked = true;

            foreach (DataGridViewRow Row in DuplicateViewsDataGridView.Rows)
            {
                ((DataGridViewCheckBoxCell)Row.Cells["colcheck"]).Value = HCheckBox.Checked;
            }

            DuplicateViewsDataGridView.RefreshEdit();
            IsHeaderCheckBoxClicked = false;

        }

        // Method for the mouse click event
        private void HeaderCheckBox_MouseClick(object sender, MouseEventArgs e)
        {
            HeaderCheckBoxClicked((CheckBox)sender);
        }
        private void SetViews()
        {
            // Check to see if the DataTable has had columns created not. If not (first time) then create columns with the correct type of storage element
            if (dgSheets.Columns.Count == 0)
            {
                // Add Sheet Name and Number column
                dgSheets.Columns.Add(new DataColumn("Levels", typeof(string)));

            }

            // Get all levels
            FilteredElementCollector levelsCollector = new FilteredElementCollector(Doc);

            levelsCollector.OfClass(typeof(Level));

            List<Level> levelNames = levelsCollector.Cast<Level>().ToList();

            foreach (Level view in levelNames)
            {
                dgSheets.Rows.Add(view.Name);
            }

            DuplicateViewsDataGridView.DataSource = dgSheets;
            // Change the AutoSize mode to fill the width of the DataGridView as it resizes
            DuplicateViewsDataGridView.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            DuplicateViewsDataGridView.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

        }

    }
}
