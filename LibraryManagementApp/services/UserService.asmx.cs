using LibraryManagementApp.helpers;
using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Web.Services;
using LibraryManagementApp.models;

namespace LibraryManagementApp.services
{
    public interface IUserService
    {
        bool IsMemberExists(string memberId, string email);
        bool SignUpNewMember(Member member);
        Member GetUserPersonalDetails(string memberId);
        bool UpdateUserPersonalDetails(Member member, int member_id);
        DataTable GetUserBookData(string memberId);
    }

    /// <summary>
    /// Сводное описание для UserService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Чтобы разрешить вызывать веб-службу из скрипта с помощью ASP.NET AJAX, раскомментируйте следующую строку. 
    // [System.Web.Script.Services.ScriptService]
    public class UserService : WebService, IUserService
    {
        private readonly string connStr = ConfigurationManager.ConnectionStrings["con"].ConnectionString;

        [WebMethod]
        public bool IsMemberExists(string username, string email)
        {
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(connStr))
                {
                    sqlConnection.Open();
                    using (SqlCommand sqlCommand = new SqlCommand("SELECT * FROM [member_master_tbl] WHERE [username] = @username AND [email] = @email;", sqlConnection))
                    {
                        sqlCommand.Parameters.AddWithValue("@username", username);
                        sqlCommand.Parameters.AddWithValue("@email", email);
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
                    using (SqlCommand sqlCommand = new SqlCommand("INSERT INTO [member_master_tbl]([username], [full_name], [dob], [contact_no], [email], [state], [city], [pincode], [full_address], [password_hash], [password_salt], [account_status]) VALUES (@username, @full_name, @dob, @contact_no, @email, @state, @city, @pincode, @full_address, @password_hash, @password_salt, @account_status)", sqlConnection))
                    {
                        string salt;
                        string hashedPassword = PasswordHelper.HashPassword(member.Password, out salt);

                        sqlCommand.Parameters.AddWithValue("@username", member.Username);
                        sqlCommand.Parameters.AddWithValue("@full_name", member.FullName);
                        sqlCommand.Parameters.AddWithValue("@dob", member.DOB);
                        sqlCommand.Parameters.AddWithValue("@contact_no", member.ContactNo);
                        sqlCommand.Parameters.AddWithValue("@email", member.Email);
                        sqlCommand.Parameters.AddWithValue("@state", member.State);
                        sqlCommand.Parameters.AddWithValue("@city", member.City);
                        sqlCommand.Parameters.AddWithValue("@pincode", member.Pincode);
                        sqlCommand.Parameters.AddWithValue("@full_address", member.FullAddress);
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
        public Member GetUserPersonalDetails(string member_id)
        {
            Member member = null;
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(connStr))
                {
                    sqlConnection.Open();
                    using (SqlCommand sqlCommand = new SqlCommand("SELECT * FROM [member_master_tbl] WHERE [member_id] = @member_id", sqlConnection))
                    {
                        sqlCommand.Parameters.AddWithValue("@member_id", member_id);
                        using (SqlDataReader reader = sqlCommand.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                member = new Member
                                {
                                    Username = reader["username"].ToString(),
                                    FullName = reader["full_name"].ToString(),
                                    DOB = reader["dob"].ToString(),
                                    ContactNo = reader["contact_no"].ToString(),
                                    Email = reader["email"].ToString(),
                                    State = reader["state"].ToString(),
                                    City = reader["city"].ToString(),
                                    Pincode = reader["pincode"].ToString(),
                                    FullAddress = reader["full_address"].ToString(),
                                    Password = null,
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
        public bool UpdateUserPersonalDetails(Member member, int member_id)
        {
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(connStr))
                {
                    sqlConnection.Open();
                    using (SqlCommand sqlCommand = new SqlCommand($"UPDATE [member_master_tbl] SET [username] = @username, [full_name] = @full_name, [dob] = @dob, [contact_no] = @contact_no, [email] = @email, [state] = @state, [city] = @city, [pincode] = @pincode, [full_address] = @full_address, [password] = @password, [account_status] = @account_status WHERE [member_id] = {member_id}", sqlConnection))
                    {
                        sqlCommand.Parameters.AddWithValue("@username", member.Username);
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
                    using (SqlCommand sqlCommand = new SqlCommand("SELECT [book_name] AS [Book Name], [issue_date] AS [Issue Date], [due_date] AS [Due Date] FROM [book_issue_tbl] WHERE [member_id] = @member_id", sqlConnection))
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
}
