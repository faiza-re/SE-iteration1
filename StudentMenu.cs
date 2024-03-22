using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SE_iteration1
{
    public partial class StudentMenu : Form
    {
        public StudentMenu()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            viewSociety cs = new viewSociety();
            cs.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            JoinSociety j = new JoinSociety();
            j.Show();
            this.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            opening o=new opening();
            o.Show();
            this.Hide();
        }
    }
}
