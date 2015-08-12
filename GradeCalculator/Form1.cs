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
            try
            {
                populateSections();                        //populate sections
                lstViewSections.Items[0].Selected = true;  //select first section
                Calculate();                               //initialize grade average calculation
            }
            catch (System.ArgumentOutOfRangeException eArgs) 
            {
                //catch exception if no sections exist
            }
          
        }

        private void lstViewSections_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            if (e.IsSelected) //if statement to ignore item unselect change
            {
                populateAssignments(); 
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
            string assignName = "Assignment " + (dgvAssignments.Rows.Count + 1);
            string assignGrade = "100";
            string section = lstViewSections.SelectedItems[0].Text;
            string query = "INSERT INTO tblAssignment ('A_Name', 'A_Grade', 'A_Section') VALUES('" + assignName + "', '" + assignGrade + "', '" + section + "')";

            dbcon.QueryDB(query);

            dgvAssignments.Rows.Add(assignName, assignGrade);
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
            string assignName = dgvAssignments.CurrentRow.Cells[0].Value.ToString();
            string section = lstViewSections.SelectedItems[0].Text;

            string query = "DELETE FROM tblAssignment " +
                           "WHERE A_Name='" + assignName + "' AND A_Section='" + section + "'";
            dbcon.QueryDB(query);
            dgvAssignments.Rows.RemoveAt(dgvAssignments.CurrentRow.Index);
        }

        private void dgvAssignments_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            string oldValue = dgvAssignments[e.ColumnIndex, e.RowIndex].Value.ToString(); //cell value before change
            string newValue = e.FormattedValue.ToString(); //cell value after change
            string assignName;  //assignment name for query
            string assignGrade; //assignment grade for query
            string section = lstViewSections.SelectedItems[0].Text; // section name for query
            string whereName = dgvAssignments[0, e.RowIndex].Value.ToString(); //WHERE value in query
            

            if (newValue != oldValue)
            {
                if (!string.IsNullOrEmpty(newValue.ToString()))
                {
                    if (dgvAssignments.CurrentCell.ColumnIndex == 0) //set assignName to newValue and assignGrade to it's cell value if name cell being edited
                    {
                        assignName = newValue;
                        assignGrade = dgvAssignments[1, e.RowIndex].Value.ToString();

                    }
                    else   //set assignGrade to newValue and assignName to it's cell value if grade cell being edited
                    {
                        assignName = dgvAssignments[0, e.RowIndex].Value.ToString();
                        assignGrade = newValue;
                    }

                    string query = "UPDATE tblAssignment " +
                                   "SET A_Name='" + assignName + "', A_Grade='" + assignGrade + "', A_Section='" + section + "' " +
                                   "WHERE A_Name='" + whereName + "' " +
                                   "AND A_Section='" + section + "'";

                    dbcon.QueryDB(query);
                    Calculate();
                }
                else
                {
                    MessageBox.Show("Cell cannot be null.");
                    e.Cancel = true;
                }
            }
            
        }

        private void txtWeight_Enter(object sender, EventArgs e)
        {
            initVal = txtWeight.Text;
        }

        private void txtWeight_Validating(object sender, CancelEventArgs e)
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

            dgvAssignments.Rows.Clear(); //clear any previous listview items before populating listview

            lblSection.Text = section;

            for (int i = 0; i < list.Count; i++)
            {
                dgvAssignments.Rows.Add(list[i].assignName, list[i].assignGrade);

                //lstViewAssignments.Columns[0].Width = 370;
                //lstViewAssignments.Columns[1].Width = 40;
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

                lblAverage.Text = "Grade Average: " + list.Sum().ToString(); //get average from the sum of all list elements(section scores)
            }
            else
            {
                lblAverage.Text = "Grade Average: The sum of all section weights must equal 100.";
            }
        }
    }

    public struct Assignment
    {
        //used to populate assignmentListView
        public string assignName;
        public int assignGrade;
    }
}
