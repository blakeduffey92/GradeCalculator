using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GradeCalculator
{
    public partial class Form1 : Form
    {
        DBConnect dbcon = new DBConnect();
        string initVal; //initial value of txtWeight on enter

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            populateSections();                        //populate sections
            lstViewSections.Items[0].Selected = true;  //select first section
            Calculate();                               //initialize calculation
            
        }

        private void lstViewSections_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            if (e.IsSelected) //if statement to ignore item unselect change
            {
                populateAssignments(); 
            }
        }

        private void lstViewAssignments_AfterLabelEdit(object sender, LabelEditEventArgs e)
        {
            //
            //TODO update records 
            if (e.Label == null)
                return;

            MessageBox.Show("idk");
        }

        private void lstViewAssignments_DoubleClick(object sender, EventArgs e)
        {
            //
            //  TODO FIX LOCATION OF TEXTBOX
            Control ctrl = (Control)sender;
            //get index of clicked column
            Point mousePos = lstViewAssignments.PointToClient(Control.MousePosition);
            ListViewHitTestInfo hitTest = lstViewAssignments.HitTest(mousePos);
            int columnIndex = hitTest.Item.SubItems.IndexOf(hitTest.SubItem);

            //get selected columns location and dimensions
            int itemLeft = lstViewAssignments.GetItemRect(lstViewAssignments.SelectedIndices[0]).Left;
            int itemBottom = lstViewAssignments.GetItemRect(lstViewAssignments.SelectedIndices[0]).Bottom;
            int itemWidth = lstViewAssignments.Columns[columnIndex].Width;   //using GetItemRect here will get width of both columns combined instead of only 1
            int itemHeight = lstViewAssignments.GetItemRect(lstViewAssignments.SelectedIndices[0]).Height;

            //set txtEdit's location and size to the same as the clicked item
            Point itemLoc = this.PointToClient(new Point(itemLeft, itemBottom)); 
            txtEdit.Location = itemLoc;
            txtEdit.Size = new Size(itemWidth, itemHeight);
            txtEdit.Visible = true;
            txtEdit.BringToFront();

            
        }

        private void populateSections()
        {
            List<string> list = dbcon.SelectSectionList();

            for (int i = 0; i < list.Count(); i++)
            {
                lstViewSections.Items.Add(list[i]);
            }

            lstViewSections.Columns[0].Width = 124;
        }

        private void populateAssignments()
        {
            string section = lstViewSections.SelectedItems[0].Text;
            List<Assignment> list = dbcon.SelectAssignList(section);
            string query = "SELECT S_Weight FROM tblSection " +
                           "WHERE S_Name='" + section + "'";

            txtWeight.Text = dbcon.Select(query);

            lstViewAssignments.Items.Clear(); //clear any previous listview items before populating listview

            lblSection.Text = section;

            for (int i = 0; i <  list.Count; i++)
            {
                
                string[] row = { list[i].assignName, list[i].assignGrade.ToString() };
                ListViewItem lvItem = new ListViewItem(row);
                lstViewAssignments.Items.Add(lvItem);

                lstViewAssignments.Columns[0].Width = 370;
                lstViewAssignments.Columns[1].Width = 40;
            }

        }
        
        private void Calculate()
        {
            //Formula --- sum of (avg of grades per section * (section weight / 100) )
            string querySumOfWeight = "SELECT SUM(S_Weight) FROM tblSection";

            if (dbcon.Select(querySumOfWeight) == "100") //check if sum of section weights = 100
            {
                List<double> list = new List<double>();
                string queryGradeAvg;
                string queryWeight;

                for (int i = 0; i < lstViewSections.Items.Count; i++)
                {
                    queryGradeAvg = "SELECT AVG(A_Grade) FROM tblAssignment " +
                                        "WHERE A_Section='" + lstViewSections.Items[i].Text + "'";

                    queryWeight = "SELECT S_Weight FROM tblSection " +
                                  "WHERE S_Name='" + lstViewSections.Items[i].Text + "'";
                    
                    list.Add(Convert.ToDouble(dbcon.Select(queryGradeAvg)) * Convert.ToDouble(dbcon.Select(queryWeight)) / 100); //Add avg of A_Grade * ( section weight / 100)
                }

                lblAverage.Text = list.Sum().ToString(); //get average from the sum of all list elements(section scores)
            }
            else
            {
                lblAverage.Text = "The sum of all section weights must equal 100.";
            }
        }

        private void btnAddSection_Click(object sender, EventArgs e)
        {

            string section = "Section " + (lstViewSections.Items.Count + 1);
            string weight = (100 / (lstViewSections.Items.Count + 1)).ToString();
            string query = "INSERT INTO tblSection ('S_Name', 'S_Weight') VALUES('" + section + "', '" + weight + "')";

            dbcon.QueryDB(query);
            lstViewSections.Items.Add(section);
            lstViewSections.Items[lstViewSections.Items.Count - 1].Selected = true;
        }

        private void btnAddAssignment_Click(object sender, EventArgs e)
        {
            string assignName = "Assignment " + (lstViewAssignments.Items.Count + 1);
            string assignGrade = "100";
            string section = lstViewSections.SelectedItems[0].Text;
            string[] row = { assignName, assignGrade };
            string query = "INSERT INTO tblAssignment ('A_Name', 'A_Grade', 'A_Section') VALUES('" + assignName + "', '" + assignGrade + "', '" + section + "')";

            dbcon.QueryDB(query);

            ListViewItem lvItem = new ListViewItem(row);
            lstViewAssignments.Items.Add(lvItem);
        }

        private void btnDeleteSection_Click(object sender, EventArgs e)
        {
            string section = lstViewSections.SelectedItems[0].Text;

            //delete section in tblSection and cascade deletes tblAssignment records containing the deleted foreign key from tblSection
            string query = "DELETE FROM tblSection " +
                           "WHERE S_Name='" + section + "'";

            dbcon.QueryDB(query);
            lstViewSections.SelectedItems[0].Remove();
            lstViewSections.Items[0].Selected = true; //reset assignment page after section deleted
        }

        private void btnDeleteAssignment_Click(object sender, EventArgs e)
        {
            string assignName = lstViewAssignments.SelectedItems[0].Text;
            string section = lstViewSections.SelectedItems[0].Text;

            string query = "DELETE FROM tblAssignment " +
                           "WHERE A_Name='" + assignName + "' AND A_Section='" + section + "'";
            dbcon.QueryDB(query);
            lstViewAssignments.SelectedItems[0].Remove();
        }

        private void txtWeight_Enter(object sender, EventArgs e)
        {
            initVal = txtWeight.Text;
        }

        private void txtWeight_Validated(object sender, EventArgs e)
        {
            if (initVal != txtWeight.Text)
            {
                string section = lstViewSections.SelectedItems[0].Text;
                string query = "UPDATE tblSection " +
                               "SET S_Weight='" + txtWeight.Text + "' " +
                               "WHERE S_Name='" + section + "'";

                dbcon.QueryDB(query);
                Calculate();
            }
        }

        public string queryGradeSum { get; set; }
    }

    public struct Assignment
    {
        //used to populate assignmentListView
        public string assignName;
        public int assignGrade;
    }
}
