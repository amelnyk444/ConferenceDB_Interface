using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace ConferenceDB_Interface
{
    public partial class Equipment : Form
    {
        public Equipment()
        {
            InitializeComponent();
            LoadEquipment();
            switch (Utility._userName)
            {
                case "Reader":
                    {
                        button1.Enabled = false;
                        button2.Enabled = false;
                        button3.Enabled = false;
                        button4.Enabled = false;                       
                        break;
                    }
                case "Moderator":
                    {
                        button1.Enabled = false;
                        button2.Enabled = false;
                        button4.Enabled = false;
                        break;
                    }
                case "ContentManager":
                    {
                        button2.Enabled = false;
                        button3.Enabled = false;
                        break;
                    }
            }
        }

        private void LoadEquipment()
        {
            SqlConnection myConnection = new SqlConnection();
            myConnection.ConnectionString = Utility._connectionString;
            myConnection.Open();
            string query = "SELECT * FROM Equipment";
            if (Utility._speechID != -1)
                query = "SELECT * FROM Equipment JOIN EquipmentForSpeech ON eqName = equipmentName WHERE speechID =" + Utility._speechID;
            SqlCommand command = new SqlCommand(query, myConnection);
            SqlDataReader reader = command.ExecuteReader();
            List<string[]> data = new List<string[]>();
            while (reader.Read())
            {
                data.Add(new string[1]);

                data[data.Count - 1][0] = reader[0].ToString();
            }
            reader.Close();
            myConnection.Close();
            foreach (string[] s in data)
                dataGridView1.Rows.Add(s);
        }

        private void Equipment_Load(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            LoadEquipment();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            InsertEquipment ie = new InsertEquipment();
            ie.Show();
            dataGridView1.Rows.Clear();
            LoadEquipment();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            EquipmentForSpeech EfS = new EquipmentForSpeech();
            EfS.Show();
            dataGridView1.Rows.Clear();
            LoadEquipment();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Update up = new Update();
            up.Show();
            dataGridView1.Rows.Clear();
            LoadEquipment();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DeleteEquipment de = new DeleteEquipment();
            de.ShowDialog();
            dataGridView1.Rows.Clear();
            LoadEquipment();
        }
    }
}
