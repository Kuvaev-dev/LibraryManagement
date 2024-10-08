using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LibraryManagementApp
{
    public partial class AdminMemberManagement : System.Web.UI.Page
    {
        private readonly string connStr = ConfigurationManager.ConnectionStrings["con"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            GridView1.DataBind();
        }

        // Go
        protected void LinkButton4_Click(object sender, EventArgs e)
        {
            GetMemberByID();
        }

        // Active
        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            UpdateMemberStatusByID("Active");
        }

        // Pending
        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            UpdateMemberStatusByID("Pending");
        }

        // Deactive
        protected void LinkButton3_Click(object sender, EventArgs e)
        {
            UpdateMemberStatusByID("Deactive");
        }

        // Delete
        protected void Button1_Click(object sender, EventArgs e)
        {
            DeleteMemberByID();
        }

        private bool IsMemberExists()
        {
            try
            {
                SqlConnection sqlConnection = new SqlConnection(connStr);
                if (sqlConnection.State == System.Data.ConnectionState.Closed) sqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand($"SELECT * FROM [member_master_tbl] WHERE [member_id] = '{TextBox1.Text.Trim()}'", sqlConnection);
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

        private void GetMemberByID()
        {
            try
            {
                SqlConnection sqlConnection = new SqlConnection(connStr);
                if (sqlConnection.State == System.Data.ConnectionState.Closed) sqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand($"SELECT * FROM [member_master_tbl] WHERE [member_id] = '{TextBox1.Text.Trim()}'", sqlConnection);
                SqlDataReader reader = sqlCommand.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        TextBox2.Text = reader.GetValue(0);
                        TextBox7.Text = reader.GetValue(10);
                        TextBox8.Text = reader.GetValue(1);
                        TextBox3.Text = reader.GetValue(2);
                        TextBox4.Text = reader.GetValue(3);
                        TextBox9.Text = reader.GetValue(4);
                        TextBox10.Text = reader.GetValue(5);
                        TextBox11.Text = reader.GetValue(6);
                        TextBox6.Text = reader.GetValue(6);
                    }
                }
                else Response.Write("<script>alert('Invalid Credentials!')</script>");
            }
            catch (Exception ex)
            {
                Response.Write($"<script>alert('{ex.Message}')</script>");
            }
        }

        private void UpdateMemberStatusByID(string status)
        {
            if (IsMemberExists())
            {
                try
                {
                    SqlConnection sqlConnection = new SqlConnection(connStr);
                    if (sqlConnection.State == System.Data.ConnectionState.Closed) sqlConnection.Open();
                    SqlCommand sqlCommand = new SqlCommand($"UPDATE [member_master_tbl] SET [account_status] = '{status}' WHERE [member_id] = '{TextBox1.Text.Trim()}'", sqlConnection);
                    sqlCommand.ExecuteNonQuery();
                    sqlConnection.Close();
                    GridView1.DataBind();
                    Response.Write("<script>alert('Member Status Updated!')</script>");
                }
                catch (Exception ex)
                {
                    Response.Write($"<script>alert('{ex.Message}')</script>");
                }
            }
            else
            {
                Response.Write("<script>alert('Invalid Member ID!')</script>");
            }
        }

        private void DeleteMemberByID()
        {
            if (IsMemberExists())
            {
                try
                {
                    SqlConnection sqlConnection = new SqlConnection(connStr);
                    if (sqlConnection.State == System.Data.ConnectionState.Closed) sqlConnection.Open();

                    SqlCommand sqlCommand = new SqlCommand($"DELETE FROM [member_master_tbl] WHERE [member_id] = {TextBox1.Text.Trim()}", sqlConnection);

                    sqlCommand.ExecuteNonQuery();
                    sqlConnection.Close();
                    Response.Write("<script>alert('Member Deleted Successfully!')</script>");
                    GridView1.DataBind();
                }
                catch (Exception ex)
                {
                    Response.Write($"<script>alert('{ex.Message}')</script>");
                }
                Response.Write("<script>alert('Member ID Cannot Be Blank!')</script>");
            }
            else
            {
                Response.Write("<script>alert('Invalid Member ID!')</script>");
            }
        }

        private void ClearForm()
        {
            TextBox2.Text = "";
            TextBox7.Text = "";
            TextBox8.Text = "";
            TextBox3.Text = "";
            TextBox4.Text = "";
            TextBox9.Text = "";
            TextBox10.Text = "";
            TextBox11.Text = "";
            TextBox6.Text = "";
        }
    }
}