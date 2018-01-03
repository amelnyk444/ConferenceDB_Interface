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
    public partial class ConfAndSect : Form
    {
        public ConfAndSect()
        {
            InitializeComponent();
            switch(Utility._userName)
            {
                case "Reader":
                    {
                        button1.Enabled = false;
                        button2.Enabled = false;
                        button3.Enabled = false;
                        button5.Enabled = false;
                        button6.Enabled = false;
                        button7.Enabled = false;
                        break;
                    }
                case "Moderator":
                    {
                        button1.Enabled = false;
                        button3.Enabled = false;
                        button5.Enabled = false;
                        button7.Enabled = false;
                        break;
                    }
                case "ContentManager":
                    {
                        button2.Enabled = false;
                        button3.Enabled = false;
                        button6.Enabled = false;
                        button7.Enabled = false;
                        break;
                    }
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Speeches f = new Speeches();
            f.Show();
        }

        private void ConfAndSect_Load(object sender, EventArgs e)
        {
            LoadConfData();
            LoadSectData();
        }

        private void LoadConfData()
        {            
            SqlConnection myConnection = new SqlConnection();
            myConnection.ConnectionString = Utility._connectionString;
            myConnection.Open();

            string query = "SELECT * FROM Conferences ";

            SqlCommand command = new SqlCommand(query, myConnection);

            SqlDataReader reader = command.ExecuteReader();

            List<string[]> data = new List<string[]>();

            while (reader.Read())
            {
                data.Add(new string[5]);

                data[data.Count - 1][0] = reader[0].ToString();
                data[data.Count - 1][1] = reader[1].ToString();
                data[data.Count - 1][2] = reader[2].ToString();
                data[data.Count - 1][3] = reader[3].ToString();
                data[data.Count - 1][4] = reader[4].ToString();
            }

            reader.Close();

            myConnection.Close();

            foreach (string[] s in data)
                dataGridView1.Rows.Add(s);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {           
            Utility._confId = Convert.ToInt32(this.dataGridView1.CurrentRow.Cells[0].Value);
            dataGridView2.Rows.Clear();
            LoadSectData();
        }

        private void LoadSectData()
        {
            SqlConnection myConnection = new SqlConnection();
            myConnection.ConnectionString = Utility._connectionString;
            myConnection.Open();
            string query = "SELECT * FROM Sections";
            if (Utility._confId != -1)
                query = "SELECT * FROM Sections WHERE confID = " + Utility._confId.ToString();

            SqlCommand command = new SqlCommand(query, myConnection);

            SqlDataReader reader = command.ExecuteReader();

            List<string[]> data = new List<string[]>();

            while (reader.Read())
            {
                data.Add(new string[4]);

                data[data.Count - 1][0] = reader[0].ToString();
                data[data.Count - 1][1] = reader[1].ToString();
                data[data.Count - 1][2] = reader[2].ToString();
                data[data.Count - 1][3] = reader[3].ToString();
            }

            reader.Close();

            myConnection.Close();

            foreach (string[] s in data)
                dataGridView2.Rows.Add(s);
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            Utility._sectID = Convert.ToInt32(this.dataGridView2.CurrentRow.Cells[0].Value);       
        }

        private void button1_Click(object sender, EventArgs e)
        {
            InsertConf ic = new InsertConf();
            ic.ShowDialog();
            dataGridView1.Rows.Clear();
            LoadConfData();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            InsertSect iS = new InsertSect();
            iS.ShowDialog();
            dataGridView2.Rows.Clear();
            LoadSectData();
        }

        private void ConfAndSect_FormClosing(Object sender, FormClosingEventArgs e)
        {
            Utility._confId = -1;
            Utility._sectID = -1;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Participants p = new Participants();
            p.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if(-1==Utility._sectID)
            {
                Error er = new Error();
                er.setError("Введіть секцію");
                er.Show();
            }
            else
            {
                int temp = Utility._speechID;
                Utility._speechID = -1;
                speakersList sp = new speakersList();
                sp.Show();
                Utility._speechID = temp;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DeleteConf dc = new DeleteConf();
            dc.ShowDialog();
            dataGridView1.Rows.Clear();
            LoadConfData();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Update up = new Update();
            up.ShowDialog();
            dataGridView1.Rows.Clear();
            LoadConfData();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Update upS = new Update();
            upS.ShowDialog();
            dataGridView2.Rows.Clear();
            LoadSectData();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            DeleteSect ds = new DeleteSect();
            ds.ShowDialog();
            dataGridView2.Rows.Clear();
            LoadSectData();
        }
    }
}
