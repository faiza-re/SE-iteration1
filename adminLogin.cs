using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//TESTING!!
namespace SE_iteration1
{
    public partial class welcome : Form
    {
        public welcome()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Console.WriteLine("hello c#");
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (start.IsValid(textBox1.Text, textBox2.Text) == false)
            {
                MessageBox.Show("invalid username or password");
                return;
            }

            {
                mainMenu m = new mainMenu();
                m.Show();
                this.Close();
            }
        }
    }
}
