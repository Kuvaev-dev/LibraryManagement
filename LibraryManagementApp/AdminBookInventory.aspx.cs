using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LibraryManagementApp
{
    public partial class AdminBookInventory : System.Web.UI.Page
    {
        private readonly string connStr = ConfigurationManager.ConnectionStrings["con"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            FillAuthorPublisherValues();
            GridView1.DataBind();
        }

        // Add
        protected void Button2_Click(object sender, EventArgs e)
        {
            if (IsBookExists())
                Response.Write($"<script>alert('Book Already Exists!')</script>");
            else AddNewBook();
        }

        // Update
        protected void Button3_Click(object sender, EventArgs e)
        {

        }

        // Delete
        protected void Button1_Click(object sender, EventArgs e)
        {

        }

        // Go
        protected void Unnamed_Click(object sender, EventArgs e)
        {

        }

        private void FillAuthorPublisherValues()
        {
            try
            {
                SqlConnection sqlConnection = new SqlConnection(connStr);
                if (sqlConnection.State == System.Data.ConnectionState.Closed) sqlConnection.Open();
                
                SqlCommand sqlCommand = new SqlCommand($"SELECT [author_name] FROM [author_master_tbl];", sqlConnection);
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                DataTable dataTable = new DataTable();
                sqlDataAdapter.Fill(dataTable);
                DropDownList3.DataSource = dataTable;
                DropDownList3.DataValueField = "author_name";
                DropDownList3.DataBind();

                sqlCommand = new SqlCommand($"SELECT [publisher_name] FROM [publisher_master_tbl];", sqlConnection);
                sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                dataTable = new DataTable();
                sqlDataAdapter.Fill(dataTable);
                DropDownList2.DataSource = dataTable;
                DropDownList2.DataValueField = "publisher_name";
                DropDownList2.DataBind();
            }
            catch (Exception)
            {

                throw;
            }
        }

        private bool IsBookExists()
        {
            try
            {
                SqlConnection sqlConnection = new SqlConnection(connStr);
                if (sqlConnection.State == System.Data.ConnectionState.Closed) sqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand($"SELECT * FROM [book_master_tbl] WHERE [book_id] = '{TextBox1.Text.Trim()}' OR [book_name] = '{TextBox2.Text.Trim()}';", sqlConnection);
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                DataTable dataTable = new DataTable();
                sqlDataAdapter.Fill(dataTable);
                sqlCommand.ExecuteNonQuery();
                sqlConnection.Close();

                return dataTable.Rows.Count >= 1;
            }
            catch (Exception ex)
            {
                Response.Write($"<script>alert('{ex.Message}')</script>");
                return false;
            }
        }

        private void AddNewBook()
        {
            try
            {
                string genres = "";
                foreach (var item in ListBox1.GetSelectedIndices())
                {
                    genres += ListBox1.Items[item] + ",";
                }
                // genres = "..."
                genres=genres.Remove(genres.Length - 1);

                string filePath = "~/book_inventory/book1.png";
                string fileName = Path.GetFileName(FileUpload1.PostedFile.FileName);
                FileUpload1.SaveAs(Server.MapPath("book_inventory/" + fileName));
                filePath = "~/book_inventory/" + fileName;

                SqlConnection sqlConnection = new SqlConnection(connStr);
                if (sqlConnection.State == System.Data.ConnectionState.Closed) sqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand("INSERT INTO [book_master_tbl](book_id, book_name, genre, author_name, publisher_name, publish_date, language, edition, book_cost, no_of_pages, book_description, actual_stock, current_stock, book_img_link) VALUES (@book_id, @book_name, @genre, @author_name, @publisher_name, @publish_date, @language, @edition, @book_cost, @no_of_pages, @book_description, @actual_stock, @current_stock, @book_img_link);", sqlConnection);
                sqlCommand.Parameters.AddWithValue("@book_id", TextBox1.Text.Trim());
                sqlCommand.Parameters.AddWithValue("@book_name", TextBox2.Text.Trim());
                sqlCommand.Parameters.AddWithValue("@genre", genres);
                sqlCommand.Parameters.AddWithValue("@author_name", DropDownList3.SelectedItem.Value);
                sqlCommand.Parameters.AddWithValue("@publisher_name", DropDownList2.SelectedItem.Value);
                sqlCommand.Parameters.AddWithValue("@publish_date", TextBox3.Text.Trim());
                sqlCommand.Parameters.AddWithValue("@language", DropDownList1.SelectedItem.Value);
                sqlCommand.Parameters.AddWithValue("@edition", TextBox9.Text.Trim());
                sqlCommand.Parameters.AddWithValue("@book_cost", TextBox10.Text.Trim());
                sqlCommand.Parameters.AddWithValue("@no_of_pages", TextBox11.Text.Trim());
                sqlCommand.Parameters.AddWithValue("@book_description", TextBox6.Text.Trim());
                sqlCommand.Parameters.AddWithValue("@actual_stock", TextBox1.Text.Trim());
                sqlCommand.Parameters.AddWithValue("@current_stock", TextBox5.Text.Trim());
                sqlCommand.Parameters.AddWithValue("@book_img_link", filePath);

                sqlCommand.ExecuteNonQuery();
                sqlConnection.Close();
                Response.Write($"<script>alert('Book Added Successfully!')</script>");
                GridView1.DataBind();
            }
            catch (Exception ex)
            {
                Response.Write($"<script>alert('{ex.Message}')</script>");
            }
        }
    }
}