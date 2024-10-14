using LibraryManagementApp.helpers;
using LibraryManagementApp.models;
using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.Services;

namespace LibraryManagementApp.services
{
    public interface IAuthenticationService
    {
        AuthenticationResult VerifyUserCredentials(string username, string password);
        AuthenticationResult VerifyAdminCredentials(string username, string password);
    }

    /// <summary>
    /// Сводное описание для AuthenticationService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Чтобы разрешить вызывать веб-службу из скрипта с помощью ASP.NET AJAX, раскомментируйте следующую строку. 
    // [System.Web.Script.Services.ScriptService]
    public class AuthenticationService : System.Web.Services.WebService, IAuthenticationService
    {

        private readonly string connStr = ConfigurationManager.ConnectionStrings["con"].ConnectionString;

        public AuthenticationResult VerifyUserCredentials(string username, string password)
        {
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(connStr))
                {
                    sqlConnection.Open();
                    using (SqlCommand sqlCommand = new SqlCommand("SELECT [member_id], [password_hash], [password_salt], [full_name], [account_status] FROM [member_master_tbl] WHERE [username] = @username", sqlConnection))
                    {
                        sqlCommand.Parameters.AddWithValue("@username", username);

                        using (SqlDataReader reader = sqlCommand.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                string storedHash = reader["password_hash"].ToString();
                                string storedSalt = reader["password_salt"].ToString();

                                if (PasswordHelper.VerifyPassword(password, storedHash, storedSalt))
                                {
                                    return new AuthenticationResult
                                    {
                                        IsSuccess = true,
                                        FullName = reader["full_name"].ToString(),
                                        Status = reader["account_status"].ToString(),
                                        MemberId = Convert.ToInt32(reader["member_id"].ToString())
                                    };
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                return new AuthenticationResult { IsSuccess = false, ErrorMessage = $"Error: {ex.Message}" };
            }

            return new AuthenticationResult { IsSuccess = false, ErrorMessage = "Invalid Credentials!" };
        }

        public AuthenticationResult VerifyAdminCredentials(string username, string password)
        {
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(connStr))
                {
                    sqlConnection.Open();
                    using (SqlCommand sqlCommand = new SqlCommand("SELECT * FROM [admin_tbl] WHERE [username] = @username", sqlConnection))
                    {
                        sqlCommand.Parameters.AddWithValue("@username", username);

                        using (SqlDataReader reader = sqlCommand.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                string storedHash = reader["password_hash"].ToString();
                                string storedSalt = reader["password_salt"].ToString();

                                if (PasswordHelper.VerifyPassword(password, storedHash, storedSalt))
                                {
                                    return new AuthenticationResult
                                    {
                                        IsSuccess = true,
                                        FullName = reader["full_name"].ToString()
                                    };
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                return new AuthenticationResult { IsSuccess = false, ErrorMessage = $"Error: {ex.Message}" };
            }

            return new AuthenticationResult { IsSuccess = false, ErrorMessage = "Invalid Credentials!" };
        }
    }
}
