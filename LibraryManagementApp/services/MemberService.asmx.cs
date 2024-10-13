using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.Services;

namespace LibraryManagementApp.services
{
    /// <summary>
    /// Сводное описание для MemberService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Чтобы разрешить вызывать веб-службу из скрипта с помощью ASP.NET AJAX, раскомментируйте следующую строку. 
    // [System.Web.Script.Services.ScriptService]
    public class MemberService : WebService
    {
        private readonly string connStr = ConfigurationManager.ConnectionStrings["con"].ConnectionString;

        [WebMethod]
        public bool IsMemberExists(string memberId)
        {
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(connStr))
                {
                    sqlConnection.Open();
                    using (SqlCommand sqlCommand = new SqlCommand("SELECT COUNT(*) FROM [member_master_tbl] WHERE [member_id] = @member_id", sqlConnection))
                    {
                        sqlCommand.Parameters.AddWithValue("@member_id", memberId);
                        int count = (int)sqlCommand.ExecuteScalar();
                        return count > 0;
                    }
                }
            }
            catch
            {
                return false;
            }
        }

        [WebMethod]
        public Dictionary<string, string> GetMemberByID(string memberId)
        {
            Dictionary<string, string> memberDetails = new Dictionary<string, string>();
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
                            if (reader.HasRows)
                            {
                                while (reader.Read())
                                {
                                    memberDetails["full_name"] = reader["full_name"].ToString();
                                    memberDetails["account_status"] = reader["account_status"].ToString();
                                    memberDetails["dob"] = reader["dob"].ToString();
                                    memberDetails["contact_no"] = reader["contact_no"].ToString();
                                    memberDetails["email"] = reader["email"].ToString();
                                    memberDetails["state"] = reader["state"].ToString();
                                    memberDetails["city"] = reader["city"].ToString();
                                    memberDetails["pin_code"] = reader["pin_code"].ToString();
                                    memberDetails["postal_address"] = reader["postal_address"].ToString();
                                }
                            }
                        }
                    }
                }
            }
            catch
            {
                // Handle exceptions 
            }
            return memberDetails;
        }

        [WebMethod]
        public bool UpdateMemberStatusByID(string memberId, string status)
        {
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(connStr))
                {
                    sqlConnection.Open();
                    using (SqlCommand sqlCommand = new SqlCommand("UPDATE [member_master_tbl] SET [account_status] = @status WHERE [member_id] = @member_id", sqlConnection))
                    {
                        sqlCommand.Parameters.AddWithValue("@status", status);
                        sqlCommand.Parameters.AddWithValue("@member_id", memberId);
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
        public bool DeleteMemberByID(string memberId)
        {
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(connStr))
                {
                    sqlConnection.Open();
                    using (SqlCommand sqlCommand = new SqlCommand("DELETE FROM [member_master_tbl] WHERE [member_id] = @member_id", sqlConnection))
                    {
                        sqlCommand.Parameters.AddWithValue("@member_id", memberId);
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
    }
}
