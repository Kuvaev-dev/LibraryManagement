using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;

namespace LibraryManagementApp
{
    public partial class AdminBookIssuing : System.Web.UI.Page
    {
        private readonly string connStr = ConfigurationManager.ConnectionStrings["con"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            GridView1.DataBind();
        }

        // Issue
        protected void Button1_Click(object sender, EventArgs e)
        {
            if (IsBookExists() && IsMemberExists())
            {
                if (IsIssuedEntryExists())
                {
                    Response.Write("<script>alert('This Member already Has This Book!')</script>");
                }
                else IssueBook();
            }
            else Response.Write("<script>alert('Wrong Member ID or Book ID!')</script>");
        }

        // Return
        protected void Button3_Click(object sender, EventArgs e)
        {
            if (IsBookExists() && IsMemberExists())
            {
                if (IsIssuedEntryExists())
                {
                    ReturnBook();
                }
                else Response.Write("<script>alert('This Entry Does Not Exist!')</script>");
            }
            else Response.Write("<script>alert('Wrong Member ID or Book ID!')</script>");
        }

        // Go
        protected void Button4_Click(object sender, EventArgs e)
        {
            GetBookAndMemberNames();
        }

        private void GetBookAndMemberNames()
        {
            try
            {
                SqlConnection sqlConnection = new SqlConnection(connStr);
                if (sqlConnection.State == System.Data.ConnectionState.Closed) sqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand($"SELECT [book_name] FROM [book_master_tbl] WHERE [book_id] = '{TextBox1.Text.Trim()}'", sqlConnection);
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                DataTable dataTable = new DataTable();
                sqlDataAdapter.Fill(dataTable);
                if (dataTable.Rows.Count >= 1)
                    TextBox4.Text = dataTable.Rows[0]["book_name"].ToString();
                else Response.Write("<script>alert('Wrong Book ID!')</script>");

                sqlCommand = new SqlCommand($"SELECT [full_name] FROM [member_master_tbl] WHERE [member_id] = '{TextBox2.Text.Trim()}'", sqlConnection);
                sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                dataTable = new DataTable();
                sqlDataAdapter.Fill(dataTable);
                if (dataTable.Rows.Count >= 1)
                    TextBox4.Text = dataTable.Rows[0]["full_name"].ToString();
                else Response.Write("<script>alert('Wrong User ID!')</script>");
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
                SqlCommand sqlCommand = new SqlCommand($"SELECT * FROM [book_master_tbl] WHERE [book_id] = '{TextBox1.Text.Trim()}' AND [current_stock] > 0;", sqlConnection);
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                DataTable dataTable = new DataTable();
                sqlDataAdapter.Fill(dataTable);
                if (dataTable.Rows.Count >= 1) return true;
                else return false;
            }
            catch (Exception)
            {
                return false;
            }
        }

        private bool IsMemberExists()
        {
            try
            {
                SqlConnection sqlConnection = new SqlConnection(connStr);
                if (sqlConnection.State == System.Data.ConnectionState.Closed) sqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand($"SELECT [full_name] FROM [member_master_tbl] WHERE [member_id] = '{TextBox2.Text.Trim()}';", sqlConnection);
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                DataTable dataTable = new DataTable();
                sqlDataAdapter.Fill(dataTable);
                if (dataTable.Rows.Count >= 1) return true;
                else return false;
            }
            catch (Exception)
            {
                return false;
            }
        }

        private bool IsIssuedEntryExists()
        {
            try
            {
                SqlConnection sqlConnection = new SqlConnection(connStr);
                if (sqlConnection.State == System.Data.ConnectionState.Closed) sqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand($"SELECT * FROM [book_issue_tbl] WHERE [member_id] = '{TextBox2.Text.Trim()}' AND [book_id] = {TextBox1.Text.Trim()};", sqlConnection);
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                DataTable dataTable = new DataTable();
                sqlDataAdapter.Fill(dataTable);
                if (dataTable.Rows.Count >= 1) return true;
                else return false;
            }
            catch (Exception)
            {
                return false;
            }
        }

        private void IssueBook()
        {
            try
            {
                SqlConnection sqlConnection = new SqlConnection(connStr);
                if (sqlConnection.State == System.Data.ConnectionState.Closed) sqlConnection.Open();

                SqlCommand sqlCommand = new SqlCommand("INSERT INTO [book_issue_tbl]([member_id], [member_name], [book_id], [book_name], [issue_date], [due_date]) VALUES (@member_id, @member_name, @book_id, @book_name, @issue_date, @due_date)", sqlConnection);
                sqlCommand.Parameters.AddWithValue("@member_id", TextBox2.Text.Trim());
                sqlCommand.Parameters.AddWithValue("@member_name", TextBox3.Text.Trim());
                sqlCommand.Parameters.AddWithValue("@book_id", TextBox1.Text.Trim());
                sqlCommand.Parameters.AddWithValue("@book_name", TextBox4.Text.Trim());
                sqlCommand.Parameters.AddWithValue("@issue_date", TextBox5.Text.Trim());
                sqlCommand.Parameters.AddWithValue("@due_date", TextBox6.Text.Trim());
                sqlCommand.ExecuteNonQuery();

                sqlCommand = new SqlCommand($"UPDATE [book_master_tbl] SET [current_stock] = [current_stock] - 1 WHERE [book_id] = {TextBox1.Text.Trim()}", sqlConnection);
                sqlCommand.ExecuteNonQuery();

                sqlConnection.Close();
                Response.Write("<script>alert('Book Issued Successfully!')</script>");
                GridView1.DataBind();
            }
            catch (Exception ex)
            {
                Response.Write($"<script>alert('{ex.Message}')</script>");
            }
        }

        private void ReturnBook()
        {
            try
            {
                SqlConnection sqlConnection = new SqlConnection(connStr);
                if (sqlConnection.State == System.Data.ConnectionState.Closed) sqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand($"DELETE FROM [book_issue_tbl] WHERE [book_id] = '{TextBox1.Text.Trim()}' AND [member_id] = '{TextBox2.Text.Trim()}'", sqlConnection);
                int result = sqlCommand.ExecuteNonQuery();
                if (result > 0)
                {
                    sqlCommand = new SqlCommand($"UPDATE [book_master_tbl] SET [current_stock] = [current_stock] - 1 WHERE [book_id] = '{TextBox1.Text.Trim()}'", sqlConnection);
                    sqlCommand.ExecuteNonQuery();
                    Response.Write("<script>alert('Book Returned Successfully!')</script>");
                    GridView1.DataBind();
                    sqlConnection.Close();
                } else Response.Write("<script>alert('Invalid Details!')</script>");
            }
            catch (Exception)
            {

                throw;
            }

        }

        protected void GridView1_RowDataBound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == System.Web.UI.WebControls.DataControlRowType.DataRow)
                {
                    DateTime dateTime = Convert.ToDateTime(e.Row.Cells[5].Text);
                    DateTime today = DateTime.Today;
                    if (today > dateTime)
                        e.Row.BackColor = Color.PaleVioletRed;
                }
            }
            catch (Exception ex)
            {
                Response.Write($"<script>alert('{ex.Message}')</script>");
            }
        }
    }
}