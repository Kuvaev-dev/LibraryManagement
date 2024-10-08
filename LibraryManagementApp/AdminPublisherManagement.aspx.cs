using System;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace LibraryManagementApp
{
    public partial class AdminPublisherManagement : System.Web.UI.Page
    {
        private readonly string connStr = ConfigurationManager.ConnectionStrings["con"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            GridView1.DataBind();
        }

        // Add
        protected void Button1_Click(object sender, EventArgs e)
        {
            if (IsPublisherExists())
                Response.Write($"<script>alert('Publisher with this ID already exists!')</script>");
            else AddNewPublisher();
        }

        // Update
        protected void Button2_Click(object sender, EventArgs e)
        {
            if (IsPublisherExists()) UpdatePublisher();
            else Response.Write($"<script>alert('Publisher Does Not Exist!')</script>");
        }

        // Delete
        protected void Button3_Click(object sender, EventArgs e)
        {
            if (IsPublisherExists()) DeletePublisher();
            else Response.Write($"<script>alert('Publisher Does Not Exist!')</script>");
        }

        // Go
        protected void Unnamed1_Click(object sender, EventArgs e)
        {
            GetPublisherByID();
        }

        private bool IsPublisherExists()
        {
            try
            {
                SqlConnection sqlConnection = new SqlConnection(connStr);
                if (sqlConnection.State == System.Data.ConnectionState.Closed) sqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand($"SELECT * FROM [publisher_master_tbl] WHERE [publisher_id] = '{TextBox1.Text.Trim()}'", sqlConnection);
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

        private void AddNewPublisher()
        {
            try
            {
                SqlConnection sqlConnection = new SqlConnection(connStr);
                if (sqlConnection.State == System.Data.ConnectionState.Closed) sqlConnection.Open();

                SqlCommand sqlCommand = new SqlCommand("INSERT INTO [publisher_master_tbl]([publisher_id], [publisher_name]) VALUES (@publisher_id, @publisher_name)", sqlConnection);
                sqlCommand.Parameters.AddWithValue("@publisher_id", TextBox1.Text.Trim());
                sqlCommand.Parameters.AddWithValue("@publisher_name", TextBox2.Text.Trim());

                sqlCommand.ExecuteNonQuery();
                sqlConnection.Close();
                Response.Write("<script>alert('publisher Added Successfully!')</script>");
                ClearForm();
                GridView1.DataBind();
            }
            catch (Exception ex)
            {
                Response.Write($"<script>alert('{ex.Message}')</script>");
            }
        }

        private void UpdatePublisher()
        {
            try
            {
                SqlConnection sqlConnection = new SqlConnection(connStr);
                if (sqlConnection.State == System.Data.ConnectionState.Closed) sqlConnection.Open();

                SqlCommand sqlCommand = new SqlCommand($"UPDATE [publisher_master_tbl] SET [publisher_name] = @publisher_name WHERE [publisher_id] = '{TextBox1.Text.Trim()}'", sqlConnection);
                sqlCommand.Parameters.AddWithValue("@publisher_name", TextBox2.Text.Trim());

                sqlCommand.ExecuteNonQuery();
                sqlConnection.Close();
                Response.Write("<script>alert('Publisher Updated Successfully!')</script>");
                ClearForm();
                GridView1.DataBind();
            }
            catch (Exception ex)
            {
                Response.Write($"<script>alert('{ex.Message}')</script>");
            }
        }

        private void DeletePublisher()
        {
            try
            {
                SqlConnection sqlConnection = new SqlConnection(connStr);
                if (sqlConnection.State == System.Data.ConnectionState.Closed) sqlConnection.Open();

                SqlCommand sqlCommand = new SqlCommand($"DELETE FROM [publisher_master_tbl] WHERE [publisher_id] = '{TextBox1.Text.Trim()}'", sqlConnection);

                sqlCommand.ExecuteNonQuery();
                sqlConnection.Close();
                Response.Write("<script>alert('Publisher Deleted Successfully!')</script>");
                ClearForm();
                GridView1.DataBind();
            }
            catch (Exception ex)
            {
                Response.Write($"<script>alert('{ex.Message}')</script>");
            }
        }

        private void GetPublisherByID()
        {
            try
            {
                SqlConnection sqlConnection = new SqlConnection(connStr);
                if (sqlConnection.State == System.Data.ConnectionState.Closed) sqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand($"SELECT * FROM [publisher_master_tbl] WHERE [publisher_id] = '{TextBox1.Text.Trim()}'", sqlConnection);
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                DataTable dataTable = new DataTable();
                sqlDataAdapter.Fill(dataTable);
                sqlCommand.ExecuteNonQuery();
                sqlConnection.Close();

                if (dataTable.Rows.Count >= 1)
                    TextBox2.Text = dataTable.Rows[0][1].ToString();
                else Response.Write("<script>alert('Invalid Publisher ID!')</script>");
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