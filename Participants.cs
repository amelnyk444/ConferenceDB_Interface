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
    public partial class Participants : Form
    {
        public Participants()
        {
            InitializeComponent();
            LoadParticipantsData();
            switch (Utility._userName)
            {
                case "Reader":
                    {
                        button1.Enabled = false;
                        button2.Enabled = false;
                        button3.Enabled = false;
                        button4.Enabled = false;
                        button5.Enabled = false;                        
                        break;
                    }
                case "Moderator":
                    {
                        button1.Enabled = false;
                        button3.Enabled = false;
                        button4.Enabled = false;
                        break;
                    }
                case "ContentManager":
                    {
                        button2.Enabled = false;
                        button3.Enabled = false;
                        button5.Enabled = false;
                        break;
                    }
            }
        }

        private void LoadParticipantsData()
        {
            SqlConnection myConnection = new SqlConnection();
            myConnection.ConnectionString = Utility._connectionString;
            myConnection.Open();

            string query = "SELECT * FROM Speakers";
            if(Utility._confId!=-1)
               query = "SELECT Speakers.* FROM Speakers JOIN ConferenceParticipants ON Speakers.ID = ConferenceParticipants.participantID WHERE ConferenceParticipants.ConferenceID=" + Utility._confId;
                

            SqlCommand command = new SqlCommand(query, myConnection);

            SqlDataReader reader = command.ExecuteReader();

            List<string[]> data = new List<string[]>();

            while (reader.Read())
            {
                data.Add(new string[8]);

                data[data.Count - 1][0] = reader[0].ToString();
                data[data.Count - 1][1] = reader[1].ToString();
                data[data.Count - 1][2] = reader[2].ToString();
                data[data.Count - 1][3] = reader[3].ToString();
                data[data.Count - 1][4] = reader[4].ToString();
                data[data.Count - 1][5] = reader[5].ToString();
                data[data.Count - 1][6] = reader[6].ToString();
                data[data.Count - 1][7] = reader[7].ToString();
            }

            reader.Close();

            myConnection.Close();

            foreach (string[] s in data)
                dataGridView1.Rows.Add(s);
        }

        private void Participants_Load(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            LoadParticipantsData();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SpeakerAtSpeech SaS = new SpeakerAtSpeech();
            SaS.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Update up = new Update();
            up.ShowDialog();
            dataGridView1.Rows.Clear();
            LoadParticipantsData();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DeleteParticipant dp = new DeleteParticipant();
            dp.ShowDialog();
            dataGridView1.Rows.Clear();
            LoadParticipantsData();
        }
    }
}
