using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;

namespace LibraryManagementApp
{
    public partial class UserProfile : System.Web.UI.Page
    {
        private readonly string connStr = ConfigurationManager.ConnectionStrings["con"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["username"].ToString() == ""|| Session["username"] == null)
                {
                    Response.Write("<script>alert('Session Expired! Login Again!')</script>");
                    Response.Redirect("UserLogin.aspx");
                }
                else
                {
                    GetUserBookData();
                    if (!Page.IsPostBack)
                        GetUserPersonalDetails();
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('Session Expired! Login Again!')</script>");
                Response.Redirect("UserLogin.aspx");
            }
        }

        // Update
        protected void Button1_Click(object sender, EventArgs e)
        {
            if (Session["username"].ToString() == "" || Session["username"] == null)
            {
                Response.Write("<script>alert('Session Expired! Login Again!')</script>");
                Response.Redirect("UserLogin.aspx");
            }
            else UpdateUserPersonalDetails();
        }

        private void GetUserBookData()
        {
            try
            {
                SqlConnection sqlConnection = new SqlConnection(connStr);
                if (sqlConnection.State == System.Data.ConnectionState.Closed) sqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand($"SELECT * FROM [book_issue_tbl] WHERE [member_id] = '{Session["username"]}'", sqlConnection);
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                DataTable dataTable = new DataTable();
                sqlDataAdapter.Fill(dataTable);
                GridView1.DataSource = dataTable;
                GridView1.DataBind();
            }
            catch (Exception ex)
            {
                Response.Write($"<script>alert('{ex.Message}')</script>");
            }
        }

        private void GetUserPersonalDetails()
        {
            try
            {
                SqlConnection sqlConnection = new SqlConnection(connStr);
                if (sqlConnection.State == System.Data.ConnectionState.Closed) sqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand($"SELECT * FROM [member_issue_tbl] WHERE [member_id] = '{Session["username"]}';", sqlConnection);
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                DataTable dataTable = new DataTable();
                sqlDataAdapter.Fill(dataTable);
                TextBox1.Text = dataTable.Rows[0]["full_name"].ToString();
                TextBox2.Text = dataTable.Rows[0]["dob"].ToString();
                TextBox3.Text = dataTable.Rows[0]["contact_no"].ToString();
                TextBox4.Text = dataTable.Rows[0]["email"].ToString();
                DropDownList1.SelectedValue = dataTable.Rows[0]["state"].ToString().Trim();
                TextBox6.Text = dataTable.Rows[0]["city"].ToString();
                TextBox7.Text = dataTable.Rows[0]["pincode"].ToString();
                TextBox5.Text = dataTable.Rows[0]["full_address"].ToString();
                TextBox8.Text = dataTable.Rows[0]["member_id"].ToString();
                TextBox9.Text = dataTable.Rows[0]["password"].ToString();

                Label1.Text = dataTable.Rows[0]["account_status"].ToString().Trim();
                if (dataTable.Rows[0]["account_status"].ToString().Trim() == "active")
                    Label1.Attributes.Add("class", "badge badge-pill badge-success");
                else if (dataTable.Rows[0]["account_status"].ToString().Trim() == "pending")
                    Label1.Attributes.Add("class", "badge badge-pill badge-warning");
                else if (dataTable.Rows[0]["account_status"].ToString().Trim() == "deactive")
                    Label1.Attributes.Add("class", "badge badge-pill badge-danger");
                else Label1.Attributes.Add("class", "badge badge-pill badge-info");

            }
            catch (Exception ex)
            {
                Response.Write($"<script>alert('{ex.Message}')</script>");
            }
        }

        private void UpdateUserPersonalDetails()
        {
            string password = "";
            if (TextBox10.Text.Trim() == "")
                password = TextBox9.Text.Trim();
            else password = TextBox10.Text.Trim();

            try
            {
                SqlConnection sqlConnection = new SqlConnection(connStr);
                if (sqlConnection.State == System.Data.ConnectionState.Closed) sqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand($"UPDATE [member_master_tbl] SET [full_name] = @full_name, [dob] = @dob, [contact_no] = @contact_no, [email] = @email, [state] = @state, [city] = @city, [pincode] = @pincode, [full_address] = @full_address. [password] = @password, [account_status] = @account_status WHERE [member_id] = '{Session["username"]}'", sqlConnection);
                sqlCommand.Parameters.AddWithValue("@full_name", TextBox1.Text.Trim());
                sqlCommand.Parameters.AddWithValue("@dob", TextBox2.Text.Trim());
                sqlCommand.Parameters.AddWithValue("@contact_no", TextBox3.Text.Trim());
                sqlCommand.Parameters.AddWithValue("@email", TextBox4.Text.Trim());
                sqlCommand.Parameters.AddWithValue("@state", DropDownList1.SelectedItem.Value);
                sqlCommand.Parameters.AddWithValue("@city", TextBox6.Text.Trim());
                sqlCommand.Parameters.AddWithValue("@pincode", TextBox7.Text.Trim());
                sqlCommand.Parameters.AddWithValue("@full_address", TextBox5.Text.Trim());
                sqlCommand.Parameters.AddWithValue("@password", password);
                sqlCommand.Parameters.AddWithValue("@account_status", "pending");

                int result = sqlCommand.ExecuteNonQuery();
                sqlConnection.Close();
                if (result > 0)
                {
                    Response.Write($"<script>alert('Your Details Updated Successfully!')</script>");
                    GetUserPersonalDetails();
                    GetUserBookData();
                }
                else Response.Write($"<script>alert('Invalid Entry!')</script>");
            }
            catch (Exception ex)
            {
                Response.Write($"<script>alert('{ex.Message}')</script>");
            }
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
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