using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace SE_iteration1
{
    public partial class opening : Form
    {
        public opening()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            welcome a = new welcome();
            a.Show();
     
        }

        private void button2_Click(object sender, EventArgs e)
        {
            EClogin ec = new EClogin();
            ec.Show();
        }
    }
}
