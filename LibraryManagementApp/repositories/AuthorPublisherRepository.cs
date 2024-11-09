using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace LibraryManagementApp.repositories
{
    public interface IAuthorPublisherRepository
    {
        (DataTable authors, DataTable publishers) GetAuthorPublisherData();
    }

    public class AuthorPublisherRepository : IAuthorPublisherRepository
    {
        private readonly string _connStr = ConfigurationManager.ConnectionStrings["elibraryDBhosted"].ConnectionString;

        public (DataTable authors, DataTable publishers) GetAuthorPublisherData()
        {
            DataTable authorsTable = new DataTable();
            DataTable publishersTable = new DataTable();

            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(_connStr))
                {
                    sqlConnection.Open();

                    // Завантаження авторів
                    using (SqlCommand sqlCommand = new SqlCommand("SELECT [author_name] FROM [author_master_tbl];", sqlConnection))
                    using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand))
                    {
                        sqlDataAdapter.Fill(authorsTable);
                    }

                    // Завантаження видавців
                    using (SqlCommand sqlCommand = new SqlCommand("SELECT [publisher_name] FROM [publisher_master_tbl];", sqlConnection))
                    using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand))
                    {
                        sqlDataAdapter.Fill(publishersTable);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error retrieving author and publisher data: {ex.Message}");
            }

            return (authorsTable, publishersTable);
        }
    }
}