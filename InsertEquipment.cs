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
    public partial class InsertEquipment : Form
    {
        public InsertEquipment()
        {
            InitializeComponent();
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            textBox1.Text = string.Empty;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection myConnection = new SqlConnection();
                myConnection.ConnectionString = Utility._connectionString;
                myConnection.Open();
                string query = string.Format("Insert Into Equipment" +
                       " Values(@eqName)");
                SqlCommand cmd = new SqlCommand(query, myConnection);
                cmd.Parameters.AddWithValue("@eqName", textBox1.Text);
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
