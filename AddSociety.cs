﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SE_iteration1
{
    public partial class AddSociety : Form
    {
        public AddSociety()
        {
            InitializeComponent();
        }
       
        public int id = 0;
        public int cid = 0;
        private string filepath;
        private byte[] imageByteArray;

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string query = "";
            if (id == 0)
            {
                query = "INSERT INTO Society(Name,Description,Location,Contact,Category)Values(@Name,@Description,@Location,@Contact,@Category)";
            }
            else
            {
                query = "UPDATE Society SET Name = @Name, Description = @Description, Location = @Location, Contact=@Contact, pic=@pic,Category=@Category WHERE ID = @id";
            }
            Image temp = new Bitmap(pictureBox1.Image);
            using (MemoryStream ms = new MemoryStream())
            {
                temp.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                imageByteArray = ms.ToArray();
            }
            try
            {
                int rowsAffected = start.SQL(query,
                    new SqlParameter("@id", id),
                    new SqlParameter("@Name", textBox1.Text),
                    new SqlParameter("@Description", textBox2.Text),
                    new SqlParameter("@Location", textBox3.Text),
                     new SqlParameter("@Contact", textBox4.Text),
                      new SqlParameter("@pic", imageByteArray),
                      new SqlParameter("@Category", comboBox1.Text)
                );

                if (rowsAffected > 0)
                {
                    MessageBox.Show("Saved data");

                    // Reset id only after a successful insert
                    if (id == 0)
                    {
                        id = 0;
                        textBox1.Text = "";
                        textBox2.Text = "";
                        textBox3.Text = "";
                        textBox4.Text = "";
                        comboBox1.SelectedIndex = -1;
                        textBox1.Focus();
                       // pictureBox2.Image = SE_iteration1.Properties.Resources.;
                    }
                }
                else
                {
                    MessageBox.Show("Failed to save data");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Images(.jpg, .png)|*.png;*.jpg";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                filepath = openFileDialog.FileName;
                pictureBox2.Image = new Bitmap(filepath);
            }
        }


    }
}
