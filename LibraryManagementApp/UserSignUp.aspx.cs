using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace LibraryManagementApp
{
    public partial class UserSignUp : System.Web.UI.Page
    {
        private readonly string connStr = ConfigurationManager.ConnectionStrings["con"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        // Sign Up Button
        protected void Button1_Click(object sender, EventArgs e)
        {
            if (IsMemberExists())
                Response.Write($"<script>alert('Member Already Exists!')</script>");
            else SignUpNewMember();
        }

        private void SignUpNewMember()
        {
            try
            {
                SqlConnection sqlConnection = new SqlConnection(connStr);
                if (sqlConnection.State == System.Data.ConnectionState.Closed) sqlConnection.Open();
                
                SqlCommand sqlCommand = new SqlCommand("INSERT INTO [member_master_tbl]([full_name], [dob], [contact_no], [email], [state], [city], [pincode], [full_address], [member_id], [password], [account_status]) VALUES (@full_name, @dob, @contact_no, @email, @state, @city, @pincode, @full_address, @member_id, @password, @account_status)", sqlConnection);
                sqlCommand.Parameters.AddWithValue("@full_name", TextBox1.Text.Trim());
                sqlCommand.Parameters.AddWithValue("@dob", TextBox2.Text.Trim());
                sqlCommand.Parameters.AddWithValue("@contact_no", TextBox3.Text.Trim());
                sqlCommand.Parameters.AddWithValue("@email", TextBox4.Text.Trim());
                sqlCommand.Parameters.AddWithValue("@state", DropDownList1.SelectedItem.Value);
                sqlCommand.Parameters.AddWithValue("@city", TextBox6.Text.Trim());
                sqlCommand.Parameters.AddWithValue("@pincode", TextBox7.Text.Trim());
                sqlCommand.Parameters.AddWithValue("@full_address", TextBox5.Text.Trim());
                sqlCommand.Parameters.AddWithValue("@member_id", TextBox8.Text.Trim());
                sqlCommand.Parameters.AddWithValue("@password", TextBox9.Text.Trim());
                sqlCommand.Parameters.AddWithValue("@account_status", "pending");

                sqlCommand.ExecuteNonQuery();
                sqlConnection.Close();
                Response.Write("<script>alert('Sign Up Successfull. Now go to Login and Authorize yourself.')</script>");
            }
            catch (Exception ex)
            {
                Response.Write($"<script>alert('{ex.Message}')</script>");
            }
        }

        private bool IsMemberExists()
        {
            try
            {
                SqlConnection sqlConnection = new SqlConnection(connStr);
                if (sqlConnection.State == System.Data.ConnectionState.Closed) sqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand($"SELECT * FROM [member_master_tbl] WHERE [member_id] = '{TextBox8.Text.Trim()}'", sqlConnection);
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                DataTable dataTable = new DataTable();
                sqlDataAdapter.Fill(dataTable);
                sqlCommand.ExecuteNonQuery();
                sqlConnection.Close();
                Response.Write("<script>alert('Sign Up Successfull. Now go to Login and Authorize yourself.')</script>");

                return dataTable.Rows.Count >= 1;
            }
            catch (Exception ex)
            {
                Response.Write($"<script>alert('{ex.Message}')</script>");
                return false;
            }
        }
    }
}