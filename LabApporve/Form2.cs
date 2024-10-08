using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LabApporve
{
    public partial class Form2 : Form
    {
        string labID = LabApporve.Form1.lastLabID;
        private string server = "localhost";
        private string database = "test";
        private string username = "root";
        private string password = "";
        private string constring;
        private MySqlConnection con;
        private void InitializeConnection()
        {
            constring = "SERVER=" + server + ";" + "DATABASE=" + database + ";" + "UID=" + username + ";" + "PASSWORD=" + password + ";";
            con = new MySqlConnection(constring);

        }
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            InitializeConnection();
        }
        private void saveApprove(object sender, EventArgs e)
        {
            string uid = UID_input.Text;
            string pin = PIN.ToString();
            string query = "UPDATE LabResult SET ApproveID = @UID WHERE LabID = @LabID";
            string 
            con.Open();
            using (MySqlCommand cmd = new MySqlCommand(query,con))
            {
                cmd.Parameters.AddWithValue("@UID", uid);
                cmd.Parameters.AddWithValue("@LabID", labID);
                int success = cmd.ExecuteNonQuery();
                if(success > 0)
                {
                    MessageBox.Show("Approve Successfully","Complete",MessageBoxButtons.OK,MessageBoxIcon.Information);
                    con.Close();
                    Close();
                }
                else
                {
                    MessageBox.Show("Your UID OR PIN IS INCORRECT", "Uncomplete", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    con.Close();
                }

            }
            
        }
    }
}
