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
            this.Hide();
        
        }

        private void button2_Click(object sender, EventArgs e)
        {
            StudentLogin el = new StudentLogin();
            el.Show(this);
        this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
