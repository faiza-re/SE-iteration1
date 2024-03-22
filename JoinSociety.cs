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
    public partial class JoinSociety : Form
    {
        public JoinSociety()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        public void button1_Click(object sender, EventArgs e)
        {
            /* comboBox1.DataSource = start.populateSociety(comboBox1);
             comboBox1.DisplayMember = "Name";*/
            if (comboBox1.Text == "")
            {
                MessageBox.Show("Select a Society to join.");
                return;
            }
            else if(start.InSociety(comboBox1.Text))
            {
                MessageBox.Show("You ahve joined the society!!!");
                NewSociety n=new NewSociety();
                this.Hide();
                n.Show();
                return;

            }
            else
            {
                MessageBox.Show("You are Already in this society!!!");
                return;
            }
        }

        public void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            /* comboBox1.DataSource = start.populateSociety(comboBox1);
             comboBox1.DisplayMember = "Name";*/
           

        }

        private void JoinSociety_Load(object sender, EventArgs e)
        {
            start.populateSociety(comboBox1);
        }
    
    }
}
