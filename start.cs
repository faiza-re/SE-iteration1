using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;

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

                   
                   

                    string query = "SELECT * FROM EC WHERE ECusername = @user AND ECpassword = @pass";
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

      
    }


}

