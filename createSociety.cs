using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Xml.Linq;

namespace SE_iteration1
{
    public partial class createSociety : Form
    {
        public createSociety()
        {
            InitializeComponent();
        }
        public void GetData()
        {
            string qry = "select * from Society  ";
            ListBox lb = new ListBox();
            lb.Items.Add(ID);
            lb.Items.Add(Name);
            lb.Items.Add(Description);

            lb.Items.Add(Location);

            lb.Items.Add(Contact);
            lb.Items.Add(Category);
            start.loadingData(qry, dataGridView1, lb);
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            GetData();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddSociety ad = new AddSociety();
            ad.Show();
            this.Hide();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            dataGridView1.Refresh();
            if (e.RowIndex >= 0) // Make sure the clicked cell is in a valid row
            {
                string columnName = dataGridView1.Columns[e.ColumnIndex].Name;
                AddSociety editForm = new AddSociety();

                DataGridViewRow selectedRow = dataGridView1.CurrentRow;

                if (selectedRow != null)
                {
                    int id = Convert.ToInt32(selectedRow.Cells["ID"].Value);
                    string name = Convert.ToString(selectedRow.Cells["Name"].Value);
                    string des = Convert.ToString(selectedRow.Cells["Description"].Value);
                    string loc = Convert.ToString(selectedRow.Cells["Location"].Value);
                    string contact = Convert.ToString(selectedRow.Cells["Contact"].Value);
                    string cat = Convert.ToString(selectedRow.Cells["Category"].Value);
                    editForm.id = id;
                    editForm.textBox1.Text = name;
                    editForm.textBox2.Text = des;
                    editForm.textBox3.Text = loc;
                    editForm.textBox4.Text = contact;

                    editForm.comboBox1.Text = cat;

                    editForm.ShowDialog();
                    GetData();
                }
            }
        }

        private void createSociety_Load(object sender, EventArgs e)
        {
            GetData();
        }
    }
}
