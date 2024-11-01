using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Web.Services;

namespace LibraryManagementApp.services
{
    public interface IBookService
    {
        bool IsBookExists(string bookId, string bookName);
        bool AddNewBook(Dictionary<string, string> bookDetails, string filePath);
        bool UpdateBook(Dictionary<string, string> bookDetails, string filePath);
        bool DeleteBook(string bookId);
        Dictionary<string, string> GetBookByID(string bookId);
    }

    /// <summary>
    /// Сводное описание для BookService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Чтобы разрешить вызывать веб-службу из скрипта с помощью ASP.NET AJAX, раскомментируйте следующую строку. 
    // [System.Web.Script.Services.ScriptService]
    public class BookService : WebService, IBookService
    {
        private readonly string connStr = ConfigurationManager.ConnectionStrings["elibraryDBhosted"].ConnectionString;

        [WebMethod]
        public bool IsBookExists(string bookId, string bookName)
        {
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(connStr))
                {
                    sqlConnection.Open();
                    SqlCommand sqlCommand = new SqlCommand("SELECT * FROM [book_master_tbl] WHERE [book_id] = @book_id OR [book_name] = @book_name;", sqlConnection);
                    sqlCommand.Parameters.AddWithValue("@book_id", bookId);
                    sqlCommand.Parameters.AddWithValue("@book_name", bookName);
                    SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                    DataTable dataTable = new DataTable();
                    sqlDataAdapter.Fill(dataTable);

                    return dataTable.Rows.Count >= 1;
                }
            }
            catch
            {
                return false;
            }
        }

        [WebMethod]
        public bool AddNewBook(Dictionary<string, string> bookDetails, string filePath)
        {
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(connStr))
                {
                    sqlConnection.Open();
                    SqlCommand sqlCommand = new SqlCommand("INSERT INTO [book_master_tbl](book_id, book_name, genre, author_name, publisher_name, publish_date, language, edition, book_cost, no_of_pages, book_description, actual_stock, current_stock, book_img_link) VALUES (@book_id, @book_name, @genre, @author_name, @publisher_name, @publish_date, @language, @edition, @book_cost, @no_of_pages, @book_description, @actual_stock, @current_stock, @book_img_link);", sqlConnection);
                    sqlCommand.Parameters.AddWithValue("@book_id", bookDetails["book_id"]);
                    sqlCommand.Parameters.AddWithValue("@book_name", bookDetails["book_name"]);
                    sqlCommand.Parameters.AddWithValue("@genre", bookDetails["genre"]);
                    sqlCommand.Parameters.AddWithValue("@author_name", bookDetails["author_name"]);
                    sqlCommand.Parameters.AddWithValue("@publisher_name", bookDetails["publisher_name"]);
                    sqlCommand.Parameters.AddWithValue("@publish_date", bookDetails["publish_date"]);
                    sqlCommand.Parameters.AddWithValue("@language", bookDetails["language"]);
                    sqlCommand.Parameters.AddWithValue("@edition", bookDetails["edition"]);
                    sqlCommand.Parameters.AddWithValue("@book_cost", bookDetails["book_cost"]);
                    sqlCommand.Parameters.AddWithValue("@no_of_pages", bookDetails["no_of_pages"]);
                    sqlCommand.Parameters.AddWithValue("@book_description", bookDetails["book_description"]);
                    sqlCommand.Parameters.AddWithValue("@actual_stock", bookDetails["actual_stock"]);
                    sqlCommand.Parameters.AddWithValue("@current_stock", bookDetails["current_stock"]);
                    sqlCommand.Parameters.AddWithValue("@book_img_link", filePath);

                    sqlCommand.ExecuteNonQuery();
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }

        [WebMethod]
        public bool UpdateBook(Dictionary<string, string> bookDetails, string filePath)
        {
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(connStr))
                {
                    sqlConnection.Open();
                    SqlCommand sqlCommand = new SqlCommand("UPDATE [book_master_tbl] SET book_name = @book_name, genre = @genre, author_name = @author_name, publisher_name = @publisher_name, publish_date = @publish_date, language = @language, edition = @edition, book_cost = @book_cost, no_of_pages = @no_of_pages, book_description = @book_description, actual_stock = @actual_stock, current_stock = @current_stock, book_img_link = @book_img_link WHERE book_id = @book_id", sqlConnection);
                    sqlCommand.Parameters.AddWithValue("@book_id", bookDetails["book_id"]);
                    sqlCommand.Parameters.AddWithValue("@book_name", bookDetails["book_name"]);
                    sqlCommand.Parameters.AddWithValue("@genre", bookDetails["genre"]);
                    sqlCommand.Parameters.AddWithValue("@author_name", bookDetails["author_name"]);
                    sqlCommand.Parameters.AddWithValue("@publisher_name", bookDetails["publisher_name"]);
                    sqlCommand.Parameters.AddWithValue("@publish_date", bookDetails["publish_date"]);
                    sqlCommand.Parameters.AddWithValue("@language", bookDetails["language"]);
                    sqlCommand.Parameters.AddWithValue("@edition", bookDetails["edition"]);
                    sqlCommand.Parameters.AddWithValue("@book_cost", bookDetails["book_cost"]);
                    sqlCommand.Parameters.AddWithValue("@no_of_pages", bookDetails["no_of_pages"]);
                    sqlCommand.Parameters.AddWithValue("@book_description", bookDetails["book_description"]);
                    sqlCommand.Parameters.AddWithValue("@actual_stock", bookDetails["actual_stock"]);
                    sqlCommand.Parameters.AddWithValue("@current_stock", bookDetails["current_stock"]);
                    sqlCommand.Parameters.AddWithValue("@book_img_link", filePath);

                    sqlCommand.ExecuteNonQuery();
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }

        [WebMethod]
        public bool DeleteBook(string bookId)
        {
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(connStr))
                {
                    sqlConnection.Open();
                    SqlCommand sqlCommand = new SqlCommand("DELETE FROM [book_master_tbl] WHERE [book_id] = @book_id", sqlConnection);
                    sqlCommand.Parameters.AddWithValue("@book_id", bookId);

                    sqlCommand.ExecuteNonQuery();
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }

        [WebMethod]
        public Dictionary<string, string> GetBookByID(string bookId)
        {
            Dictionary<string, string> bookDetails = new Dictionary<string, string>();
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(connStr))
                {
                    sqlConnection.Open();
                    SqlCommand sqlCommand = new SqlCommand("SELECT * FROM [book_master_tbl] WHERE [book_id] = @book_id", sqlConnection);
                    sqlCommand.Parameters.AddWithValue("@book_id", bookId);
                    SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                    DataTable dataTable = new DataTable();
                    sqlDataAdapter.Fill(dataTable);

                    if (dataTable.Rows.Count > 0)
                    {
                        DataRow row = dataTable.Rows[0];
                        bookDetails["book_name"] = row["book_name"].ToString();
                        bookDetails["genre"] = row["genre"].ToString();
                        bookDetails["author_name"] = row["author_name"].ToString();
                        bookDetails["publisher_name"] = row["publisher_name"].ToString();
                        bookDetails["publish_date"] = row["publish_date"].ToString();
                        bookDetails["language"] = row["language"].ToString();
                        bookDetails["edition"] = row["edition"].ToString();
                        bookDetails["book_cost"] = row["book_cost"].ToString();
                        bookDetails["no_of_pages"] = row["no_of_pages"].ToString();
                        bookDetails["book_description"] = row["book_description"].ToString();
                        bookDetails["actual_stock"] = row["actual_stock"].ToString();
                        bookDetails["current_stock"] = row["current_stock"].ToString();
                        bookDetails["book_img_link"] = row["book_img_link"].ToString();
                    }
                }
            }
            catch
            {
                // Handle exceptions
            }
            return bookDetails;
        }
    }
}
