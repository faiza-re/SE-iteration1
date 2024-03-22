﻿using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Windows.Forms;

namespace SE_iteration1
{
    internal partial class start
    {
        public static readonly string con_string = "Data Source=.;Initial Catalog=DBnew;Integrated Security=True;Encrypt=False";
        public static SqlConnection conn = new SqlConnection(con_string);
        public static string USER = "";

        public static bool IsValid(string user, string pass)
        {
            bool isValid = false;

            try
            {
                
                using (SqlConnection conn = new SqlConnection(con_string))
                {
                    conn.Open();

               
                    string query = "SELECT * FROM Admin WHERE AdminUsername = @user AND password = @pass";

                    using (SqlCommand command = new SqlCommand(query, conn))
                    {
                        command.Parameters.AddWithValue("@user", user);
                        command.Parameters.AddWithValue("@pass", pass);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                isValid = true;
                                USER = user;
                            }
                        }
                    }
                } 
            }
            catch (Exception ex)
            {
                // Log the exception to a file
                LogException(ex);
            }

            return isValid;
        }

        private static void LogException(Exception ex)
        {
            string logPath = "log.txt";
            string logMessage = $"[{DateTime.Now}] Error: {ex.Message}\n";
            if (ex.InnerException != null)
            {
                logMessage += $"Inner Exception: {ex.InnerException.Message}\n";
            }
            File.AppendAllText(logPath, logMessage);
            Console.WriteLine("An error occurred. See log.txt for details.");
        }

        public static bool IsValid2(string user, string pass)
        {
            bool isValid = false;

            try
            {
                using (SqlConnection conn = new SqlConnection(con_string))
                {
                    conn.Open();

                   
                   

                    string query = "SELECT * FROM Student WHERE Studentusername = @user AND password = @pass";
                    using (SqlCommand command = new SqlCommand(query, conn))
                    {
                        command.Parameters.AddWithValue("@user", user);
                        command.Parameters.AddWithValue("@pass", pass);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                isValid = true;
                                USER = user; 
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
              
                LogException(ex);
            }

            return isValid;
        }
        public static int SQL(string query, params SqlParameter[] parameters)
        {
            int result = 0;

            try
            {

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.CommandType = CommandType.Text;

                    if (parameters != null && parameters.Length > 0)
                    {
                        cmd.Parameters.AddRange(parameters);
                    }

                    if (conn.State == ConnectionState.Closed)
                    {
                        conn.Open();
                    }

                    result = cmd.ExecuteNonQuery();
                }

            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }

            return result;
        }
        public static void loadingData(string query, DataGridView dv, ListBox lb)
         {
             try
             {
                 if (conn.State == ConnectionState.Closed)
                 {
                     conn.Open();
                 }
                 SqlCommand cmd = new SqlCommand(query, conn);
                 cmd.CommandType = CommandType.Text;

                 // Use SqlDataReader for better performance
                 using (SqlDataReader reader = cmd.ExecuteReader())
                 {
                     DataTable dt = new DataTable();
                     dt.Load(reader);
                     Console.WriteLine(lb.Items.Count);
                     for (int i = 0; i < lb.Items.Count; i++)
                     {
                         string colName1 = ((DataGridViewColumn)lb.Items[i]).Name;

                         if (dt.Columns.Count > i)
                         {
                             dv.Columns[colName1].DataPropertyName = dt.Columns[i].ColumnName;
                         }
                         else
                         {
                             MessageBox.Show($"Not enough columns in the DataTable for ListBox item {i + 1}");
                         }
                     }

                     dv.DataSource = dt;
                 }
             }
             catch (Exception e)
             {
                 MessageBox.Show(e.ToString());
                 conn.Close();
             }
         }

      
    }


}

