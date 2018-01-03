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
    public partial class Speeches : Form
    {
        public Speeches()
        {
            InitializeComponent();
            LoadSpeechData();
            switch (Utility._userName)
            {
                case "Reader":
                    {
                        button1.Enabled = false;
                        button2.Enabled = false;
                        button3.Enabled = false;                        
                        button6.Enabled = false;
                        button7.Enabled = false;
                        break;
                    }
                case "Moderator":
                    {
                        button1.Enabled = false;
                        button3.Enabled = false;
                        button6.Enabled = false;
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

        private void button5_Click(object sender, EventArgs e)
        {
            Equipment f = new Equipment();
            f.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            InsertSpeech iS = new InsertSpeech();
            iS.Show();
            dataGridView1.Rows.Clear();
            LoadSpeechData();
        }

        private void LoadSpeechData()
        {
            SqlConnection myConnection = new SqlConnection();
            myConnection.ConnectionString = Utility._connectionString;
            myConnection.Open();
            string query = "SELECT * FROM Speeches";
            if (Utility._sectID != -1)
            {
                //query = "SELECT Sp.* FROM (Conferences C JOIN Sections S ON c.ID = S.confID) JOIN Speeches Sp ON Sp.sectID = S.ID WHERE C.ID = " + Utility._confId + " AND S.ID = " + Utility._sectID;
                query = "SELECT * FROM Speeches WHERE sectID = " + Utility._sectID;
            }
            else
            {
                if (Utility._confId != -1) { query = "SELECT Sp.* FROM (Conferences C JOIN Sections S ON c.ID = S.confID) JOIN Speeches Sp ON Sp.sectID = S.ID WHERE C.ID = " + Utility._confId; }
            }

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
            Utility._speechID = Convert.ToInt32(this.dataGridView1.CurrentRow.Cells[0].Value);
        }

        private void Speeches_Load(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            LoadSpeechData();
        }

        private void Speeches_FormClosing(Object sender, FormClosingEventArgs e)
        {
            Utility._speechID = -1;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            SpeakerAtSpeech SaS = new SpeakerAtSpeech();
            SaS.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if(Utility._speechID==-1)
            {
                Error er = new Error();
                er.Text = "Виберіть виступ";
                er.Show();
            }
            else
            {
                speakersList sl = new speakersList();
                sl.Show();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Update up = new Update();
            up.ShowDialog();
            dataGridView1.Rows.Clear();
            LoadSpeechData();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            EquipmentForSpeech EfS = new EquipmentForSpeech();
            EfS.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DeleteSpeech ds = new DeleteSpeech();
            ds.ShowDialog();
            dataGridView1.Rows.Clear();
            LoadSpeechData();
        }
    }
}
