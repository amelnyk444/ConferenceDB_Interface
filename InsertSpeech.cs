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
    public partial class InsertSpeech : Form
    {
        public InsertSpeech()
        {
            InitializeComponent();
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            textBox1.Text = string.Empty;
        }

        private void textBox2_Enter(object sender, EventArgs e)
        {
            textBox2.Text = string.Empty;
        }

        private void textBox3_Enter(object sender, EventArgs e)
        {
            textBox3.Text = string.Empty;
        }

        private void textBox4_Enter(object sender, EventArgs e)
        {
            textBox3.Text = string.Empty;
        }

        private void textBox5_Enter(object sender, EventArgs e)
        {
            if (-1 != Utility._sectID)
            {
                textBox5.Text = Utility._sectID.ToString();
            }
            else { textBox5.Text = string.Empty; }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection myConnection = new SqlConnection();
                myConnection.ConnectionString = Utility._connectionString;
                myConnection.Open();
                string query = string.Format("Insert Into Speeches" +
                       " Values(@topic, @spDate, @incTime, @finTime,@confID)");
                SqlCommand cmd = new SqlCommand(query, myConnection);
                cmd.Parameters.AddWithValue("@topic", textBox1.Text);
                cmd.Parameters.AddWithValue("@spDate", textBox2.Text);
                cmd.Parameters.AddWithValue("@incTime", textBox3.Text);
                cmd.Parameters.AddWithValue("@finTime", textBox4.Text);
                cmd.Parameters.AddWithValue("@confID", textBox5.Text);
                cmd.ExecuteNonQuery();
                myConnection.Close();
            }
            catch (SqlException ex)
            {
                Error ie = new Error();
                ie.setError("Неправильний ввід");
                ie.Show();
            }
        }
    }
}
