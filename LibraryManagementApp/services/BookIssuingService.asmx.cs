using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Web.Caching;
using System.Web.Services;
using System.Web;

namespace LibraryManagementApp.services
{
    public interface IBookIssuingService
    {
        bool IsBookExists(string bookId);
        bool IsMemberExists(string memberId);
        bool IsIssuedEntryExists(string bookId, string memberId);
        void IssueBook(string bookId, string bookName, string memberId, string memberName, DateTime issueDate, DateTime dueDate);
        void ReturnBook(string bookId, string memberId);
        (string bookName, string memberName) GetBookAndMemberNames(string bookId, string memberId);
    }

    /// <summary>
    /// Сводное описание для BookIssuingService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Чтобы разрешить вызывать веб-службу из скрипта с помощью ASP.NET AJAX, раскомментируйте следующую строку. 
    // [System.Web.Script.Services.ScriptService]
    public class BookIssuingService : System.Web.Services.WebService, IBookIssuingService
    {
        private readonly string _connStr = ConfigurationManager.ConnectionStrings["con"].ConnectionString;

        public bool IsBookExists(string bookId)
        {
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(_connStr))
                {
                    sqlConnection.Open();
                    using (SqlCommand sqlCommand = new SqlCommand("SELECT * FROM [book_master_tbl] WHERE [book_id] = @book_id AND [current_stock] > 0", sqlConnection))
                    {
                        sqlCommand.Parameters.AddWithValue("@book_id", bookId);
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

        public bool IsMemberExists(string memberId)
        {
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(_connStr))
                {
                    sqlConnection.Open();
                    using (SqlCommand sqlCommand = new SqlCommand("SELECT [full_name] FROM [member_master_tbl] WHERE [member_id] = @member_id", sqlConnection))
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

        public bool IsIssuedEntryExists(string bookId, string memberId)
        {
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(_connStr))
                {
                    sqlConnection.Open();
                    using (SqlCommand sqlCommand = new SqlCommand("SELECT * FROM [book_issue_tbl] WHERE [member_id] = @member_id AND [book_id] = @book_id", sqlConnection))
                    {
                        sqlCommand.Parameters.AddWithValue("@member_id", memberId);
                        sqlCommand.Parameters.AddWithValue("@book_id", bookId);
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

        public void IssueBook(string bookId, string bookName, string memberId, string memberName, DateTime issueDate, DateTime dueDate)
        {
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(_connStr))
                {
                    sqlConnection.Open();

                    using (SqlCommand sqlCommand = new SqlCommand("INSERT INTO [book_issue_tbl]([member_id], [member_name], [book_id], [book_name], [issue_date], [due_date]) VALUES (@member_id, @member_name, @book_id, @book_name, @issue_date, @due_date)", sqlConnection))
                    {
                        sqlCommand.Parameters.AddWithValue("@member_id", memberId);
                        sqlCommand.Parameters.AddWithValue("@member_name", memberName);
                        sqlCommand.Parameters.AddWithValue("@book_id", bookId);
                        sqlCommand.Parameters.AddWithValue("@book_name", bookName);
                        sqlCommand.Parameters.AddWithValue("@issue_date", issueDate);
                        sqlCommand.Parameters.AddWithValue("@due_date", dueDate);
                        sqlCommand.ExecuteNonQuery();
                    }

                    using (SqlCommand sqlCommand = new SqlCommand("UPDATE [book_master_tbl] SET [current_stock] = [current_stock] - 1 WHERE [book_id] = @book_id", sqlConnection))
                    {
                        sqlCommand.Parameters.AddWithValue("@book_id", bookId);
                        sqlCommand.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error issuing book: {ex.Message}");
            }
        }

        public void ReturnBook(string bookId, string memberId)
        {
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(_connStr))
                {
                    sqlConnection.Open();

                    using (SqlCommand sqlCommand = new SqlCommand("DELETE FROM [book_issue_tbl] WHERE [book_id] = @book_id AND [member_id] = @member_id", sqlConnection))
                    {
                        sqlCommand.Parameters.AddWithValue("@book_id", bookId);
                        sqlCommand.Parameters.AddWithValue("@member_id", memberId);
                        int result = sqlCommand.ExecuteNonQuery();

                        if (result > 0)
                        {
                            using (SqlCommand updateCommand = new SqlCommand("UPDATE [book_master_tbl] SET [current_stock] = [current_stock] + 1 WHERE [book_id] = @book_id", sqlConnection))
                            {
                                updateCommand.Parameters.AddWithValue("@book_id", bookId);
                                updateCommand.ExecuteNonQuery();
                            }
                        }
                        else
                        {
                            throw new Exception("Invalid details for return.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error returning book: {ex.Message}");
            }
        }

        public (string bookName, string memberName) GetBookAndMemberNames(string bookId, string memberId)
        {
            string bookNameCacheKey = $"BookName_{bookId}";
            string memberNameCacheKey = $"MemberName_{memberId}";

            Cache cache = HttpContext.Current.Cache;
            string bookName = cache[bookNameCacheKey] as string;
            string memberName = cache[memberNameCacheKey] as string;

            if (bookName == null || memberName == null)
            {
                using (SqlConnection sqlConnection = new SqlConnection(_connStr))
                {
                    sqlConnection.Open();

                    if (bookName == null)
                    {
                        using (SqlCommand sqlCommand = new SqlCommand("SELECT [book_name] FROM [book_master_tbl] WHERE [book_id] = @book_id", sqlConnection))
                        {
                            sqlCommand.Parameters.AddWithValue("@book_id", bookId);
                            using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand))
                            {
                                DataTable dataTable = new DataTable();
                                sqlDataAdapter.Fill(dataTable);
                                if (dataTable.Rows.Count >= 1)
                                {
                                    bookName = dataTable.Rows[0]["book_name"].ToString();
                                    cache.Insert(bookNameCacheKey, bookName, null, DateTime.Now.AddMinutes(10), Cache.NoSlidingExpiration);
                                }
                                else
                                {
                                    throw new Exception("Wrong Book ID!");
                                }
                            }
                        }
                    }

                    if (memberName == null)
                    {
                        using (SqlCommand sqlCommand = new SqlCommand("SELECT [full_name] FROM [member_master_tbl] WHERE [member_id] = @member_id", sqlConnection))
                        {
                            sqlCommand.Parameters.AddWithValue("@member_id", memberId);
                            using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand))
                            {
                                DataTable dataTable = new DataTable();
                                sqlDataAdapter.Fill(dataTable);
                                if (dataTable.Rows.Count >= 1)
                                {
                                    memberName = dataTable.Rows[0]["full_name"].ToString();
                                    cache.Insert(memberNameCacheKey, memberName, null, DateTime.Now.AddMinutes(10), Cache.NoSlidingExpiration);
                                }
                                else
                                {
                                    throw new Exception("Wrong User ID!");
                                }
                            }
                        }
                    }
                }
            }

            return (bookName, memberName);
        }
    }
}
