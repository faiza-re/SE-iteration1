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
    public partial class StudentLogin : Form
    {
        public StudentLogin()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
            if (start.IsValid2(textBox1.Text, textBox2.Text) == false)
            {
                MessageBox.Show("invalid username or password");
                return;
            }
            StudentMenu sm = new StudentMenu();
            sm.Show(this);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            opening o=new opening();
            o.Show(this);
            this.Close();
        }
    }
}
