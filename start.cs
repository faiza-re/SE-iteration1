using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Windows.Forms;

namespace SE_iteration1
{
    internal partial class start
    {
        //public static readonly string con_string = "Data Source=.;Initial Catalog=DBnew;Integrated Security=True;Encrypt=False";
        public static readonly string con_string = "Data Source=DESKTOP-RNIE8AN\\SQLEXPRESS;Initial Catalog=Software_Engineering;Integrated Security=True";
        public static SqlConnection conn = new SqlConnection(con_string);
        public static string USER = "";
        static string id;
        static string password;
        public static bool IsAdmin(string user, string pass)
        {
            bool isValid = false;

            try
            {
                
                using (SqlConnection conn = new SqlConnection(con_string))
                {
                    conn.Open();

               
                    string query = "SELECT * FROM Adminn WHERE AdminUsername = @user AND password = @pass";

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
            id = user;
            password= pass;
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

        public static bool IsUser(string user, string pass)
        {
            bool isValid = false;

            try
            {
                using (SqlConnection conn = new SqlConnection(con_string))
                {
                    conn.Open();

                   
                   

                    string query = "SELECT * FROM Student WHERE RollNumber = @user AND Password = @pass";
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
            id = user;
            password = pass;
            return isValid;
        }
        public static string IsMember(string user, string pass)
        {
            string position = "none"; // Default position

            try
            {
                using (SqlConnection conn = new SqlConnection(con_string))
                {
                    conn.Open();

                    string query = "SELECT Position FROM Student WHERE RollNumber = @user AND Password = @pass";
                    using (SqlCommand command = new SqlCommand(query, conn))
                    {
                        command.Parameters.AddWithValue("@user", user);
                        command.Parameters.AddWithValue("@pass", pass);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                position = reader["Position"].ToString();
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

            return position;
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
        public static DataTable populateSociety(ComboBox j)
        {
            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(con_string))
            {
                using(SqlCommand cmd =new SqlCommand("getSocieties", con))
                {
                    con.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataReader reader = cmd.ExecuteReader();
                    dt.Load(reader);
                    con.Close();
                }
                j.DataSource = dt;
                j.DisplayMember = "Name";
            }

                return dt;
        }
        public static bool InSociety(string society)
        {
            bool isValid = false;

            try
            {
                using (SqlConnection conn = new SqlConnection(con_string))
                {
                    conn.Open();

                    // Check if the person is already in the society
                    string queryCheck = "SELECT COUNT(*) FROM student_society WHERE RollNumber = @id AND Society_Name = @society";
                    using (SqlCommand commandCheck = new SqlCommand(queryCheck, conn))
                    {
                        commandCheck.Parameters.AddWithValue("@id", USER); // Assuming USER is already set somewhere
                        commandCheck.Parameters.AddWithValue("@society", society);

                        int count = Convert.ToInt32(commandCheck.ExecuteScalar());
                        if (count > 0)
                        {
                            // Person is already in the society, return false
                            return false;
                        }
                    }

                    // If not already in the society, update the student_society table
                    string queryUpdate = "INSERT INTO student_society (RollNumber, Society_Name) VALUES (@id, @society)";
                    using (SqlCommand commandUpdate = new SqlCommand(queryUpdate, conn))
                    {
                        commandUpdate.Parameters.AddWithValue("@id", USER); // Assuming USER is already set somewhere
                        commandUpdate.Parameters.AddWithValue("@society", society);

                        int rowsAffected = commandUpdate.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            // Successfully updated the table
                            isValid = true;
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



    }


}

