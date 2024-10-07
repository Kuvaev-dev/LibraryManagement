using System;
using System.Configuration;
using System.Data.SqlClient;

namespace LibraryManagementApp
{
    public partial class AdminLogin : System.Web.UI.Page
    {
        private readonly string connStr = ConfigurationManager.ConnectionStrings["con"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection sqlConnection = new SqlConnection(connStr);
                if (sqlConnection.State == System.Data.ConnectionState.Closed) sqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand($"SELECT * FROM [admin_tbl] WHERE [username] = {TextBox1.Text.Trim()} AND [password] = {TextBox2.Text.Trim()}", sqlConnection);
                SqlDataReader reader = sqlCommand.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Response.Write($"<script>alert('{reader.GetValue(0)}')</script>");

                        Session["username"] = reader.GetValue(0);
                        Session["fullname"] = reader.GetValue(2);
                        Session["role"] = "admin";
                        //Session["status"] = reader.GetValue(10);
                    }
                    Response.Redirect("Home.aspx");
                }
                else Response.Write("<script>alert('Invalid Credentials!')</script>");
            }
            catch (Exception ex)
            {
                Response.Write($"<script>alert('{ex.Message}')</script>");
            }
        }
    }
}