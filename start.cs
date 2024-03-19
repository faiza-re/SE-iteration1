using System;
using System.Data;
using System.Data.SqlClient;

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
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("INSERT INTO Admin (AdminId, AdminName, AdminUsername, [password]) VALUES (@adminId, @adminName, @AdminUsername, @password)", conn);
                    cmd.Parameters.AddWithValue("@adminId", 1);
                    cmd.Parameters.AddWithValue("@adminName", "faiza Rehman");
                    cmd.Parameters.AddWithValue("@AdminUsername", "faiza_re");
                    cmd.Parameters.AddWithValue("@password", "qwerty");
                    cmd.ExecuteNonQuery(); // Execute the INSERT query
                }

                // Use parameterized query to prevent SQL injection
                string query = "SELECT * FROM Admin WHERE AdminUsername = @user AND [password] = @pass";
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
            catch (Exception ex)
            {
                // Handle the exception, log it, or throw it as needed
                Console.WriteLine("Error: " + ex.Message);
            }

            return isValid;
        }
    }
}
