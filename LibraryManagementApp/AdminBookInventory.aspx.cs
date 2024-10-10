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
        private static string global_filepath;
        private static int global_actual_stock, global_current_stock, global_issued_books;

        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
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
            UpdateBookByID();
        }

        // Delete
        protected void Button1_Click(object sender, EventArgs e)
        {
            DeleteBook();
        }

        // Go
        protected void Button4_Click(object sender, EventArgs e)
        {
            GetBookByID();
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

        private void GetBookByID()
        {
            try
            {
                SqlConnection sqlConnection = new SqlConnection(connStr);
                if (sqlConnection.State == System.Data.ConnectionState.Closed) sqlConnection.Open();

                SqlCommand sqlCommand = new SqlCommand($"SELECT * FROM [book_master_tbl] WHERE [book_id] = {TextBox1.Text.Trim()}", sqlConnection);
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                DataTable dataTable = new DataTable();
                sqlDataAdapter.Fill(dataTable);
                if (dataTable.Rows.Count >= 1)
                {
                    TextBox2.Text = dataTable.Rows[0]["book_name"].ToString();
                    TextBox3.Text = dataTable.Rows[0]["publish_date"].ToString();
                    TextBox9.Text = dataTable.Rows[0]["edition"].ToString();
                    TextBox10.Text = dataTable.Rows[0]["book_cost"].ToString().Trim();
                    TextBox11.Text = dataTable.Rows[0]["no_of_pages"].ToString().Trim();
                    TextBox4.Text = dataTable.Rows[0]["actual_stock"].ToString().Trim();
                    TextBox5.Text = dataTable.Rows[0]["current_stock"].ToString().Trim();
                    TextBox6.Text = dataTable.Rows[0]["book_description"].ToString();
                    TextBox7.Text = "" + (Convert.ToInt32(dataTable.Rows[0]["actual_stock"].ToString()) - Convert.ToInt32(dataTable.Rows[0]["current_stock"].ToString()));
                    DropDownList1.SelectedValue = dataTable.Rows[0]["language"].ToString().Trim();
                    DropDownList2.SelectedValue = dataTable.Rows[0]["publisher_name"].ToString().Trim();
                    DropDownList3.SelectedValue = dataTable.Rows[0]["author_name"].ToString().Trim();

                    string[] genre = dataTable.Rows[0]["genre"].ToString().Trim().Split(',');
                    ListBox1.ClearSelection();
                    for (int i = 0; i < genre.Length; i++)
                    {
                        for (int j = 0; j < ListBox1.Items.Count; j++)
                        {
                            if (ListBox1.Items[j].ToString() == genre[i])
                                ListBox1.Items[j].Selected = true;
                        }
                    }

                    global_actual_stock= Convert.ToInt32(dataTable.Rows[0]["actual_stock"].ToString().Trim());
                    global_current_stock = Convert.ToInt32(dataTable.Rows[0]["current_stock"].ToString().Trim());
                    global_issued_books = global_actual_stock - global_current_stock;
                    global_filepath = dataTable.Rows[0]["book_img_link"].ToString();
                }
                else
                {
                    Response.Write($"<script>alert('Invalid Book ID!')</script>");
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void UpdateBookByID()
        {
            if (IsBookExists())
            {
                try
                {
                    int actual_stock = Convert.ToInt32(TextBox4.Text.Trim());
                    int current_stock = Convert.ToInt32(TextBox5.Text.Trim());
                    if (global_actual_stock == actual_stock)
                    {

                    }
                    else
                    {
                        if (actual_stock < global_issued_books)
                        {
                            Response.Write($"<script>alert('Actual Stock Value cannot be less than the Issued Books')</script>");
                        }
                        else
                        {
                            current_stock = actual_stock - global_issued_books;
                            TextBox5.Text = "" + current_stock;
                        }
                    }

                    string genres = "";
                    foreach (var item in ListBox1.GetSelectedIndices())
                    {
                        genres += ListBox1.Items[item] + ",";
                    }
                    genres = genres.Remove(genres.Length - 1);

                    string filePath = "~/book_inventory/books1";
                    string fileName = Path.GetFileName(FileUpload1.PostedFile.FileName);
                    if (fileName == "" || fileName == null)
                    {
                        filePath = global_filepath;
                    }
                    else
                    {
                        FileUpload1.SaveAs(Server.MapPath("book_inventory/" + fileName));
                        filePath = "~/book_inventory/" + fileName;
                    }

                    SqlConnection sqlConnection = new SqlConnection(connStr);
                    if (sqlConnection.State == System.Data.ConnectionState.Closed) sqlConnection.Open();
                    SqlCommand sqlCommand = new SqlCommand($"UPDATE [book_master_tbl] SET book_name = @book_name, genre = @genre, author_name = @author_name, publisher_name = @publisher_name, publish_date = @publish_date, language = @language, edition = @edition, book_cost = @book_cost, no_of_pages = @no_of_pages, book_description = @book_description, actual_stock = @actual_stock, current_stock = @current_stock, book_img_link = @book_img_link WHERE book_id = '{TextBox1.Text.Trim()}'", sqlConnection);
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
                    sqlCommand.Parameters.AddWithValue("@actual_stock", actual_stock.ToString());
                    sqlCommand.Parameters.AddWithValue("@current_stock", current_stock.ToString());
                    sqlCommand.Parameters.AddWithValue("@book_img_link", filePath);

                    sqlCommand.ExecuteNonQuery();
                    sqlConnection.Close();
                    GridView1.DataBind();
                    Response.Write("<script>alert('Book Updated!')</script>");
                }
                catch (Exception ex)
                {
                    Response.Write($"<script>alert('{ex.Message}')</script>");
                }
            }
            else
            {
                Response.Write("<script>alert('Invalid Book ID!')</script>");
            }
        }

        private void DeleteBook()
        {
            if (IsBookExists())
            {
                try
                {
                    SqlConnection sqlConnection = new SqlConnection(connStr);
                    if (sqlConnection.State == System.Data.ConnectionState.Closed) sqlConnection.Open();

                    SqlCommand sqlCommand = new SqlCommand($"DELETE FROM [book_master_tbl] WHERE [book_id] = {TextBox1.Text.Trim()}", sqlConnection);

                    sqlCommand.ExecuteNonQuery();
                    sqlConnection.Close();
                    Response.Write("<script>alert('Book Deleted Successfully!')</script>");
                    GridView1.DataBind();
                }
                catch (Exception ex)
                {
                    Response.Write($"<script>alert('{ex.Message}')</script>");
                }
            }
            else
            {
                Response.Write("<script>alert('Invalid Book ID!')</script>");
            }
        }
    }
}