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
    public partial class EClogin : Form
    {
        public EClogin()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (start.IsValid2(textBox1.Text, textBox2.Text) == false)
            {
                MessageBox.Show("invalid username or password");
                return;
            }
            ECmenu m = new ECmenu();
            m.Show();
           
        }
    }
}
