using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.Services;

namespace LibraryManagementApp.services
{
    public interface IPublisherService
    {
        bool IsPublisherExists(string publisherId);
        bool AddNewPublisher(string publisherId, string publisherName);
        bool UpdatePublisher(string publisherId, string publisherName);
        bool DeletePublisher(string publisherId);
        Dictionary<string, string> GetPublisherByID(string publisherId);
    }

    /// <summary>
    /// Сводное описание для PublisherService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Чтобы разрешить вызывать веб-службу из скрипта с помощью ASP.NET AJAX, раскомментируйте следующую строку. 
    // [System.Web.Script.Services.ScriptService]
    public class PublisherService : WebService, IPublisherService
    {
        private readonly string connStr = ConfigurationManager.ConnectionStrings["elibraryDBhosted"].ConnectionString;

        [WebMethod]
        public bool IsPublisherExists(string publisherId)
        {
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(connStr))
                {
                    sqlConnection.Open();
                    using (SqlCommand sqlCommand = new SqlCommand("SELECT COUNT(*) FROM [publisher_master_tbl] WHERE [publisher_id] = @publisher_id", sqlConnection))
                    {
                        sqlCommand.Parameters.AddWithValue("@publisher_id", publisherId);
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
        public bool AddNewPublisher(string publisherId, string publisherName)
        {
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(connStr))
                {
                    sqlConnection.Open();
                    using (SqlCommand sqlCommand = new SqlCommand("INSERT INTO [publisher_master_tbl]([publisher_id], [publisher_name]) VALUES (@publisher_id, @publisher_name)", sqlConnection))
                    {
                        sqlCommand.Parameters.AddWithValue("@publisher_id", publisherId);
                        sqlCommand.Parameters.AddWithValue("@publisher_name", publisherName);
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
        public bool UpdatePublisher(string publisherId, string publisherName)
        {
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(connStr))
                {
                    sqlConnection.Open();
                    using (SqlCommand sqlCommand = new SqlCommand("UPDATE [publisher_master_tbl] SET [publisher_name] = @publisher_name WHERE [publisher_id] = @publisher_id", sqlConnection))
                    {
                        sqlCommand.Parameters.AddWithValue("@publisher_name", publisherName);
                        sqlCommand.Parameters.AddWithValue("@publisher_id", publisherId);
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
        public bool DeletePublisher(string publisherId)
        {
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(connStr))
                {
                    sqlConnection.Open();
                    using (SqlCommand sqlCommand = new SqlCommand("DELETE FROM [publisher_master_tbl] WHERE [publisher_id] = @publisher_id", sqlConnection))
                    {
                        sqlCommand.Parameters.AddWithValue("@publisher_id", publisherId);
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
        public Dictionary<string, string> GetPublisherByID(string publisherId)
        {
            Dictionary<string, string> publisherDetails = new Dictionary<string, string>();
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(connStr))
                {
                    sqlConnection.Open();
                    using (SqlCommand sqlCommand = new SqlCommand("SELECT * FROM [publisher_master_tbl] WHERE [publisher_id] = @publisher_id", sqlConnection))
                    {
                        sqlCommand.Parameters.AddWithValue("@publisher_id", publisherId);
                        using (SqlDataReader reader = sqlCommand.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                while (reader.Read())
                                {
                                    publisherDetails["publisher_name"] = reader["publisher_name"].ToString();
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
            return publisherDetails;
        }
    }
}
