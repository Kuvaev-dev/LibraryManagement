using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Web.Services;
using LibraryManagementApp.models;

namespace LibraryManagementApp.services
{

    public interface IAuthorService
    {
        List<Author> GetAuthors();
        Author GetAuthorByID(string authorId);
        string AddNewAuthor(string authorId, string authorName);
        string UpdateAuthor(string authorId, string authorName);
        string DeleteAuthor(string authorId);
        bool IsAuthorExists(string authorId);
    }

    /// <summary>
    /// Сводное описание для AuthorService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Чтобы разрешить вызывать веб-службу из скрипта с помощью ASP.NET AJAX, раскомментируйте следующую строку. 
    // [System.Web.Script.Services.ScriptService]
    public class AuthorService : System.Web.Services.WebService, IAuthorService
    {
        private readonly string connStr = ConfigurationManager.ConnectionStrings["con"].ConnectionString;

        [WebMethod]
        public List<Author> GetAuthors()
        {
            var authors = new List<Author>();
            using (SqlConnection sqlConnection = new SqlConnection(connStr))
            {
                sqlConnection.Open();
                using (SqlCommand sqlCommand = new SqlCommand("SELECT * FROM [author_master_tbl]", sqlConnection))
                {
                    using (SqlDataReader reader = sqlCommand.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            authors.Add(new Author
                            {
                                AuthorId = reader.GetString(0),
                                AuthorName = reader.GetString(1)
                            });
                        }
                    }
                }
            }
            return authors;
        }

        [WebMethod]
        public Author GetAuthorByID(string authorId)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connStr))
            {
                sqlConnection.Open();
                using (SqlCommand sqlCommand = new SqlCommand("SELECT * FROM [author_master_tbl] WHERE [author_id] = @AuthorID", sqlConnection))
                {
                    sqlCommand.Parameters.AddWithValue("@AuthorID", authorId);
                    using (SqlDataReader reader = sqlCommand.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Author
                            {
                                AuthorId = reader.GetString(0),
                                AuthorName = reader.GetString(1)
                            };
                        }
                        else
                        {
                            return null;
                        }
                    }
                }
            }
        }

        [WebMethod]
        public string AddNewAuthor(string authorId, string authorName)
        {
            if (IsAuthorExists(authorId))
            {
                return "Author with this ID already exists!";
            }

            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(connStr))
                {
                    sqlConnection.Open();
                    using (SqlCommand sqlCommand = new SqlCommand("INSERT INTO [author_master_tbl]([author_id], [author_name]) VALUES (@AuthorID, @AuthorName)", sqlConnection))
                    {
                        sqlCommand.Parameters.AddWithValue("@AuthorID", authorId);
                        sqlCommand.Parameters.AddWithValue("@AuthorName", authorName);

                        sqlCommand.ExecuteNonQuery();
                        return "Author Added Successfully!";
                    }
                }
            }
            catch
            {
                return "An error occurred while adding new author.";
            }
        }

        [WebMethod]
        public string UpdateAuthor(string authorId, string authorName)
        {
            if (!IsAuthorExists(authorId))
            {
                return "Author Does Not Exist!";
            }

            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(connStr))
                {
                    sqlConnection.Open();
                    using (SqlCommand sqlCommand = new SqlCommand("UPDATE [author_master_tbl] SET [author_name] = @AuthorName WHERE [author_id] = @AuthorID", sqlConnection))
                    {
                        sqlCommand.Parameters.AddWithValue("@AuthorID", authorId);
                        sqlCommand.Parameters.AddWithValue("@AuthorName", authorName);

                        sqlCommand.ExecuteNonQuery();
                        return "Author Updated Successfully!";
                    }
                }
            }
            catch
            {
                return "An error occurred while updating author.";
            }
        }

        [WebMethod]
        public string DeleteAuthor(string authorId)
        {
            if (!IsAuthorExists(authorId))
            {
                return "Author Does Not Exist!";
            }

            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(connStr))
                {
                    sqlConnection.Open();
                    using (SqlCommand sqlCommand = new SqlCommand("DELETE FROM [author_master_tbl] WHERE [author_id] = @AuthorID", sqlConnection))
                    {
                        sqlCommand.Parameters.AddWithValue("@AuthorID", authorId);

                        sqlCommand.ExecuteNonQuery();
                        return "Author Deleted Successfully!";
                    }
                }
            }
            catch
            {
                return "An error occurred while deleting author.";
            }
        }

        public bool IsAuthorExists(string authorId)
        {
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(connStr))
                {
                    sqlConnection.Open();
                    using (SqlCommand sqlCommand = new SqlCommand("SELECT * FROM [author_master_tbl] WHERE [author_id] = @AuthorID", sqlConnection))
                    {
                        sqlCommand.Parameters.AddWithValue("@AuthorID", authorId);
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
    }
}
