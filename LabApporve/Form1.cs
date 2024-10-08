
using MySql.Data.MySqlClient;
using Org.BouncyCastle.Asn1.Cmp;
using System.Drawing;
using static System.ComponentModel.Design.ObjectSelectorEditor;

namespace LabApporve
{

    public partial class Form1 : Form
    {
        public static string lastLabID = string.Empty;
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
        public Form1()
        {

            InitializeComponent();
        }
        private void importResultLap(object sender, EventArgs e)
        {

        }
        private void ImportInfo(object sender, EventArgs e)
        {
            string LabID = LabID_input.Text;
            string procedure = "GetPatientInfoByLabID";
            using (MySqlCommand cmd = new MySqlCommand(procedure, con))
            {
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("labID", LabID);
                con.Open();
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        HN_text.Text = reader["HN"].ToString();
                        PBC_text.Text = reader["RBC"].ToString();
                        Name_text.Text = reader["PINITIAL"].ToString() + " " + reader["PNAME"] + " " + reader["PSUR"] + " " + reader["Age"] + " " + "ปี";
                        Clinic_text.Text = reader["N_WARD"].ToString();
                        Diagnosis_text.Text = reader["Diagnosis"].ToString();
                        Specimen_text.Text = reader["Specimen"].ToString();
                        patchtime_text.Text = reader["Date_log"].ToString();
                        recive_text.Text = reader["Doctor_Name"].ToString() + " " + reader["Date_rq"];
                        Rep_text.Text = reader["C_UNIT"].ToString() + " " + reader["Date_lab"];
                        checkedListBox1.Items.Add(reader["TEST_NAME"].ToString() + reader["TestCode"]);

                    }

                }
            }
            con.Close();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            InitializeConnection();

            string query = @"SELECT labr.labID FROM labresult labr JOIN Request_log req on req.LabID = labr.LabID WHERE labr.ApproveID = """" ";
            MySqlCommand cmd = new MySqlCommand(query, con);
            con.Open();
            MySqlDataReader reader = cmd.ExecuteReader();
            HashSet<string> uniqueLabIDs = new HashSet<string>();
            AutoCompleteStringCollection autocom = new AutoCompleteStringCollection();
            while (reader.Read())
            {
                string LabIDL = reader.GetString(0);
                if (LabIDL.Length > 1)
                    uniqueLabIDs.Add(LabIDL);
            }
            foreach (string labID in uniqueLabIDs)
            {
                autocom.Add(labID);
            }
            LabID_input.AutoCompleteMode = AutoCompleteMode.Suggest;
            LabID_input.AutoCompleteSource = AutoCompleteSource.CustomSource;
            LabID_input.AutoCompleteCustomSource = autocom;
            con.Close();
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {
        }

        private void LabID_input_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                string currentLabID = LabID_input.Text;
                if (currentLabID != lastLabID)
                {
                    checkedListBox1.Items.Clear();
                    HN_text.ResetText();
                    PBC_text.ResetText();
                    Name_text.ResetText();
                    Clinic_text.ResetText();
                    Diagnosis_text.ResetText();
                    Specimen_text.ResetText();
                    patchtime_text.ResetText();
                    recive_text.ResetText();
                    Rep_text.ResetText();
                    lastLabID = currentLabID;
                    ImportInfo(sender, e);
                }
                e.SuppressKeyPress = true;
            }
        }

        private void Approve(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Show();
        }
    }
}

