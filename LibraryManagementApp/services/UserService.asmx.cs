using LibraryManagementApp.helpers;
using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Web.Services;

namespace LibraryManagementApp.services
{
    /// <summary>
    /// Сводное описание для UserService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Чтобы разрешить вызывать веб-службу из скрипта с помощью ASP.NET AJAX, раскомментируйте следующую строку. 
    // [System.Web.Script.Services.ScriptService]
    public class UserService : WebService
    {
        private readonly string connStr = ConfigurationManager.ConnectionStrings["con"].ConnectionString;

        [WebMethod]
        public UserLoginResult VerifyUserCredentials(string memberId, string password)
        {
            UserLoginResult result = new UserLoginResult();
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(connStr))
                {
                    sqlConnection.Open();
                    using (SqlCommand sqlCommand = new SqlCommand("SELECT [password_hash], [password_salt], [full_name], [status] FROM [member_master_tbl] WHERE [member_id] = @member_id", sqlConnection))
                    {
                        sqlCommand.Parameters.AddWithValue("@member_id", memberId);

                        using (SqlDataReader reader = sqlCommand.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                string storedHash = reader["password_hash"].ToString();
                                string storedSalt = reader["password_salt"].ToString();

                                if (PasswordHelper.VerifyPassword(password, storedHash, storedSalt))
                                {
                                    result.IsSuccess = true;
                                    result.FullName = reader["full_name"].ToString();
                                    result.Status = reader["status"].ToString();
                                }
                                else
                                {
                                    result.IsSuccess = false;
                                    result.ErrorMessage = "Invalid Credentials!";
                                }
                            }
                            else
                            {
                                result.IsSuccess = false;
                                result.ErrorMessage = "Invalid Credentials!";
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.ErrorMessage = $"Error: {ex.Message}";
            }
            return result;
        }

        [WebMethod]
        public bool IsMemberExists(string memberId)
        {
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(connStr))
                {
                    sqlConnection.Open();
                    using (SqlCommand sqlCommand = new SqlCommand("SELECT * FROM [member_master_tbl] WHERE [member_id] = @member_id", sqlConnection))
                    {
                        sqlCommand.Parameters.AddWithValue("@member_id", memberId);
                        using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand))
                        {
                            DataTable dataTable = new DataTable();
                            sqlDataAdapter.Fill(dataTable);
                            return dataTable.Rows.Count >= 1;
                        }
                    }
                }
            }
            catch
            {
                return false;
            }
        }

        [WebMethod]
        public bool SignUpNewMember(Member member)
        {
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(connStr))
                {
                    sqlConnection.Open();
                    using (SqlCommand sqlCommand = new SqlCommand("INSERT INTO [member_master_tbl]([full_name], [dob], [contact_no], [email], [state], [city], [pincode], [full_address], [member_id], [password_hash], [password_salt], [account_status]) VALUES (@full_name, @dob, @contact_no, @email, @state, @city, @pincode, @full_address, @member_id, @password_hash, @password_salt, @account_status)", sqlConnection))
                    {
                        string salt;
                        string hashedPassword = PasswordHelper.HashPassword(member.Password, out salt);

                        sqlCommand.Parameters.AddWithValue("@full_name", member.FullName);
                        sqlCommand.Parameters.AddWithValue("@dob", member.DOB);
                        sqlCommand.Parameters.AddWithValue("@contact_no", member.ContactNo);
                        sqlCommand.Parameters.AddWithValue("@email", member.Email);
                        sqlCommand.Parameters.AddWithValue("@state", member.State);
                        sqlCommand.Parameters.AddWithValue("@city", member.City);
                        sqlCommand.Parameters.AddWithValue("@pincode", member.Pincode);
                        sqlCommand.Parameters.AddWithValue("@full_address", member.FullAddress);
                        sqlCommand.Parameters.AddWithValue("@member_id", member.MemberId);
                        sqlCommand.Parameters.AddWithValue("@password_hash", hashedPassword);
                        sqlCommand.Parameters.AddWithValue("@password_salt", salt);
                        sqlCommand.Parameters.AddWithValue("@account_status", "pending");

                        sqlCommand.ExecuteNonQuery();
                        return true;
                    }
                }
            }
            catch
            {
                return false;
            }
        }

        [WebMethod]
        public Member GetUserPersonalDetails(string memberId)
        {
            Member member = null;
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(connStr))
                {
                    sqlConnection.Open();
                    using (SqlCommand sqlCommand = new SqlCommand("SELECT * FROM [member_master_tbl] WHERE [member_id] = @member_id", sqlConnection))
                    {
                        sqlCommand.Parameters.AddWithValue("@member_id", memberId);
                        using (SqlDataReader reader = sqlCommand.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                member = new Member
                                {
                                    FullName = reader["full_name"].ToString(),
                                    DOB = reader["dob"].ToString(),
                                    ContactNo = reader["contact_no"].ToString(),
                                    Email = reader["email"].ToString(),
                                    State = reader["state"].ToString(),
                                    City = reader["city"].ToString(),
                                    Pincode = reader["pincode"].ToString(),
                                    FullAddress = reader["full_address"].ToString(),
                                    MemberId = reader["member_id"].ToString(),
                                    Password = reader["password"].ToString(),
                                    AccountStatus = reader["account_status"].ToString()
                                };
                            }
                        }
                    }
                }
            }
            catch
            {
                // Handle exceptions
            }
            return member;
        }

        [WebMethod]
        public bool UpdateUserPersonalDetails(Member member)
        {
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(connStr))
                {
                    sqlConnection.Open();
                    using (SqlCommand sqlCommand = new SqlCommand("UPDATE [member_master_tbl] SET [full_name] = @full_name, [dob] = @dob, [contact_no] = @contact_no, [email] = @email, [state] = @state, [city] = @city, [pincode] = @pincode, [full_address] = @full_address, [password] = @password, [account_status] = @account_status WHERE [member_id] = @member_id", sqlConnection))
                    {
                        sqlCommand.Parameters.AddWithValue("@full_name", member.FullName);
                        sqlCommand.Parameters.AddWithValue("@dob", member.DOB);
                        sqlCommand.Parameters.AddWithValue("@contact_no", member.ContactNo);
                        sqlCommand.Parameters.AddWithValue("@email", member.Email);
                        sqlCommand.Parameters.AddWithValue("@state", member.State);
                        sqlCommand.Parameters.AddWithValue("@city", member.City);
                        sqlCommand.Parameters.AddWithValue("@pincode", member.Pincode);
                        sqlCommand.Parameters.AddWithValue("@full_address", member.FullAddress);
                        sqlCommand.Parameters.AddWithValue("@password", member.Password);
                        sqlCommand.Parameters.AddWithValue("@account_status", "pending");
                        sqlCommand.Parameters.AddWithValue("@member_id", member.MemberId);

                        int result = sqlCommand.ExecuteNonQuery();
                        return result > 0;
                    }
                }
            }
            catch
            {
                return false;
            }
        }

        [WebMethod]
        public DataTable GetUserBookData(string memberId)
        {
            DataTable dataTable = new DataTable();
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(connStr))
                {
                    sqlConnection.Open();
                    using (SqlCommand sqlCommand = new SqlCommand("SELECT * FROM [book_issue_tbl] WHERE [member_id] = @member_id", sqlConnection))
                    {
                        sqlCommand.Parameters.AddWithValue("@member_id", memberId);
                        using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand))
                        {
                            sqlDataAdapter.Fill(dataTable);
                        }
                    }
                }
            }
            catch
            {
                // Handle exceptions
            }
            return dataTable;
        }
    }

    public class UserLoginResult
    {
        public bool IsSuccess { get; set; }
        public string FullName { get; set; }
        public string Status { get; set; }
        public string ErrorMessage { get; set; }
    }

    public class Member
    {
        public string FullName { get; set; }
        public string DOB { get; set; }
        public string ContactNo { get; set; }
        public string Email { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string Pincode { get; set; }
        public string FullAddress { get; set; }
        public string MemberId { get; set; }
        public string Password { get; set; }
        public string AccountStatus { get; set; }
    }
}
