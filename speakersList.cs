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
    public partial class speakersList : Form
    {
        public speakersList()
        {
            InitializeComponent();
            LoadSpeakersData();
        }

        private void LoadSpeakersData()
        {
            SqlConnection myConnection = new SqlConnection();
            myConnection.ConnectionString = Utility._connectionString;
            myConnection.Open();
            string query = "SELECT Speakers.* FROM ((Sections Sc JOIN Speeches Sp ON Sc.ID = Sp.sectID) JOIN SpeakersAtSpeech SaS ON SaS.speechID = Sp.ID)JOIN Speakers ON SaS.speakerID = Speakers.ID WHERE Sc.ID =" + Utility._sectID;
            if (-1 != Utility._speechID)
            { query = "SELECT S.* FROM Speakers S JOIN SpeakersAtSpeech SaS ON S.ID =SaS.speakerID WHERE SaS.speechID=" + Utility._speechID; }                     

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

        private void speakersList_Load(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();         
            LoadSpeakersData();
        }
    }
}
