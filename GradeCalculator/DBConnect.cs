using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.IO;
using System.Diagnostics;
using System.Windows.Forms;

namespace GradeCalculator
{
    class DBConnect
    {
        private SQLiteConnection connection;
        private string filepath;
        public DBConnect()
        {
            try
            {
                filepath = (Path.GetDirectoryName(Process.GetCurrentProcess().MainModule.FileName) + "\\DBGrades.db;");
                connection = new SQLiteConnection("Data Source=" + filepath + "Version=3;foreign keys=true");
            }
            catch (Exception)
            {
                MessageBox.Show("File not Found.");
            }
        }

        private bool OpenConnection()
        {
            try
            {
                connection.Open();
                return true;
            }
            catch (SQLiteException ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }

        }

        private bool CloseConnection()
        {
            try
            {
                connection.Close();
                return true;
            }
            catch (SQLiteException ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        public void QueryDB(string query)
        {

            if (this.OpenConnection() == true)
            {
                SQLiteCommand cmd = new SQLiteCommand(query, connection);

                cmd.ExecuteNonQuery();

                this.CloseConnection();
            }
        }

        public string Select(string query)
        {
            string var = "";

            if (this.OpenConnection() == true)
            {
                SQLiteCommand cmd = new SQLiteCommand(query, connection);
                //Create a data reader and Execute the command
                SQLiteDataReader dataReader = cmd.ExecuteReader();

                //Read the data and store them in the list
                while (dataReader.Read())
                {
                    var = dataReader[0].ToString();
                }

                this.CloseConnection();
            }
            return var;
        }

        public List<string> SelectSectionList()
        {
            string query = "SELECT S_Name FROM tblSection " +
                           "ORDER BY S_Name";

            List<string> list = new List<string>();

            //Open connection
            if (this.OpenConnection() == true)
            {
                //Create Command
                SQLiteCommand cmd = new SQLiteCommand(query, connection);
                //Create a data reader and Execute the command
                SQLiteDataReader dataReader = cmd.ExecuteReader();

                //Read the data and store them in the list
                while (dataReader.Read())
                {
                    list.Add(dataReader["S_Name"].ToString());
                }

                //close Data Reader
                dataReader.Close();

                //close Connection
                this.CloseConnection();

                //return list to be displayed

            }

            return list;
        }
        
        public List<Assignment> SelectAssignList(string section)
        {
            string query = "SELECT * FROM tblAssignment " +
                           "WHERE A_Section='" + section + "' " +
                           "ORDER BY A_Name";

            List<Assignment> list = new List<Assignment>();
            //Open connection
            if (this.OpenConnection() == true)
            {
                //Create Command
                SQLiteCommand cmd = new SQLiteCommand(query, connection);
                //Create a data reader and Execute the command
                SQLiteDataReader dataReader = cmd.ExecuteReader();

                //Read the data and store them in the list
                while (dataReader.Read())
                {
                    Assignment newStruct = new Assignment();
                    newStruct.assignName = dataReader["A_Name"].ToString();
                    newStruct.assignGrade = Convert.ToInt32(dataReader["A_Grade"]);
                    list.Add(newStruct);
                }

                //close Data Reader
                dataReader.Close();

                //close Connection
                this.CloseConnection();

                //return list to be displayed

            }

            return list;
        }
    }
}