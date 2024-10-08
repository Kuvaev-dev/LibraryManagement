using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace LibraryManagementApp
{
    public partial class AdminAuthorManagement : System.Web.UI.Page
    {
        private readonly string connStr = ConfigurationManager.ConnectionStrings["con"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            GridView1.DataBind();
        }

        // Add
        protected void Button1_Click(object sender, EventArgs e)
        {
            if (IsAuthorExists())
                Response.Write($"<script>alert('Author with this ID already exists!')</script>");
            else AddNewAuthor();
        }

        // Update
        protected void Button2_Click(object sender, EventArgs e)
        {
            if (IsAuthorExists()) UpdateAuthor();
            else Response.Write($"<script>alert('Author Does Not Exist!')</script>");
        }

        // Delete
        protected void Button3_Click(object sender, EventArgs e)
        {
            if (IsAuthorExists()) DeleteAuthor();
            else Response.Write($"<script>alert('Author Does Not Exist!')</script>");
        }

        // Go
        protected void Unnamed1_Click(object sender, EventArgs e)
        {
            GetAuthorByID();
        }

        private bool IsAuthorExists()
        {
            try
            {
                SqlConnection sqlConnection = new SqlConnection(connStr);
                if (sqlConnection.State == System.Data.ConnectionState.Closed) sqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand($"SELECT * FROM [author_master_tbl] WHERE [author_id] = '{TextBox1.Text.Trim()}'", sqlConnection);
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

        private void AddNewAuthor()
        {
            try
            {
                SqlConnection sqlConnection = new SqlConnection(connStr);
                if (sqlConnection.State == System.Data.ConnectionState.Closed) sqlConnection.Open();

                SqlCommand sqlCommand = new SqlCommand("INSERT INTO [author_master_tbl]([author_id], [author_name]) VALUES (@author_id, @author_name)", sqlConnection);
                sqlCommand.Parameters.AddWithValue("@author_id", TextBox1.Text.Trim());
                sqlCommand.Parameters.AddWithValue("@author_name", TextBox2.Text.Trim());

                sqlCommand.ExecuteNonQuery();
                sqlConnection.Close();
                Response.Write("<script>alert('Author Added Successfully!')</script>");
                ClearForm();
                GridView1.DataBind();
            }
            catch (Exception ex)
            {
                Response.Write($"<script>alert('{ex.Message}')</script>");
            }
        }

        private void UpdateAuthor()
        {
            try
            {
                SqlConnection sqlConnection = new SqlConnection(connStr);
                if (sqlConnection.State == System.Data.ConnectionState.Closed) sqlConnection.Open();

                SqlCommand sqlCommand = new SqlCommand($"UPDATE [author_master_tbl] SET [author_name] = @author_name WHERE [author_id] = {TextBox1.Text.Trim()}", sqlConnection);
                sqlCommand.Parameters.AddWithValue("@author_name", TextBox2.Text.Trim());

                sqlCommand.ExecuteNonQuery();
                sqlConnection.Close();
                Response.Write("<script>alert('Author Updated Successfully!')</script>");
                ClearForm();
                GridView1.DataBind();
            }
            catch (Exception ex)
            {
                Response.Write($"<script>alert('{ex.Message}')</script>");
            }
        }

        private void DeleteAuthor()
        {
            try
            {
                SqlConnection sqlConnection = new SqlConnection(connStr);
                if (sqlConnection.State == System.Data.ConnectionState.Closed) sqlConnection.Open();

                SqlCommand sqlCommand = new SqlCommand($"DELETE FROM [author_master_tbl] WHERE [author_id] = {TextBox1.Text.Trim()}", sqlConnection);

                sqlCommand.ExecuteNonQuery();
                sqlConnection.Close();
                Response.Write("<script>alert('Author Deleted Successfully!')</script>");
                ClearForm();
                GridView1.DataBind();
            }
            catch (Exception ex)
            {
                Response.Write($"<script>alert('{ex.Message}')</script>");
            }
        }

        private void GetAuthorByID()
        {
            try
            {
                SqlConnection sqlConnection = new SqlConnection(connStr);
                if (sqlConnection.State == System.Data.ConnectionState.Closed) sqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand($"SELECT * FROM [author_master_tbl] WHERE [author_id] = '{TextBox1.Text.Trim()}'", sqlConnection);
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                DataTable dataTable = new DataTable();
                sqlDataAdapter.Fill(dataTable);
                sqlCommand.ExecuteNonQuery();
                sqlConnection.Close();

                if (dataTable.Rows.Count >= 1)
                    TextBox2.Text = dataTable.Rows[0][1].ToString();
                else Response.Write("<script>alert('Invalid Author ID!')</script>");
            }
            catch (Exception ex)
            {
                Response.Write($"<script>alert('{ex.Message}')</script>");
            }
        }

        private void ClearForm()
        {
            TextBox1.Text = "";
            TextBox2.Text = "";
        }
    }
}