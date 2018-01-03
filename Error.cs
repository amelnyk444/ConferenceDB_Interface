using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConferenceDB_Interface
{
    public partial class Error : Form
    {
        public Error()
        {
            InitializeComponent();
            textBox1.Text = "Неправильний пароль";
        }

        public void setError(string er)
        {
            textBox1.Text = er;
        }
    }
}
