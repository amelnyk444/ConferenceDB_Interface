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
    public partial class Entry : Form
    {
        public Entry()
        {
            InitializeComponent();
        }


        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Utility._userName = comboBox1.SelectedItem.ToString();
            if (comboBox1.SelectedItem.ToString() == "Reader")
            {
                button1.Enabled = true;
                textBox1.Enabled = false;
            }
            else
            {
                textBox1.Enabled = true;
                button1.Enabled = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection conn = new SqlConnection();
                conn.ConnectionString = Utility.CreateConnectionString();
                conn.Open();
                ConfAndSect f = new ConfAndSect();
                this.Hide();
                f.ShowDialog();
                this.Show();
            }
            catch (SqlException ex)
            {
                Error Le = new Error();
                Le.setError("Неправильний ввід");
                Le.Show();
            }
           
        }

        private void Entry_Load(object sender, EventArgs e)
        {
            button1.Enabled = false;
            textBox1.Enabled = false;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            Utility._password = textBox1.Text;
            button1.Enabled = true;
        }
    }
}
