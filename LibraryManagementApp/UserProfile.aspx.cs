using System;
using System.Data;
using System.Web.UI.WebControls;
using System.Drawing;
using LibraryManagementApp.services;

namespace LibraryManagementApp
{
    public partial class UserProfile : System.Web.UI.Page
    {
        public UserService UserService { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["username"] == null || string.IsNullOrEmpty(Session["username"].ToString()))
            {
                Response.Write("<script>alert('Session Expired! Login Again!')</script>");
                Response.Redirect("User Login.aspx");
            }
            else
            {
                if (!IsPostBack)
                {
                    GetUserBookData();
                    GetUserPersonalDetails();
                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (Session["username"] == null || string.IsNullOrEmpty(Session["username"].ToString()))
            {
                Response.Write("<script>alert('Session Expired! Login Again!')</script>");
                Response.Redirect("User Login.aspx");
            }
            else
            {
                UpdateUserPersonalDetails();
            }
        }

        private void GetUserBookData()
        {
            try
            {
                DataTable dataTable = UserService.GetUserBookData(Session["username"].ToString());
                GridView1.DataSource = dataTable;
                GridView1.DataBind();
            }
            catch (Exception ex)
            {
                Response.Write($"<script>alert('Error: {ex.Message}')</script>");
            }
        }

        private void GetUserPersonalDetails()
        {
            try
            {
                var member = UserService.GetUserPersonalDetails(Session["username"].ToString());
                if (member != null)
                {
                    TextBox1.Text = member.FullName;
                    TextBox2.Text = member.DOB;
                    TextBox3.Text = member.ContactNo;
                    TextBox4.Text = member.Email;
                    DropDownList1.SelectedValue = member.State;
                    TextBox6.Text = member.City;
                    TextBox7.Text = member.Pincode;
                    TextBox5.Text = member.FullAddress;
                    TextBox8.Text = member.MemberId;
                    TextBox9.Text = member.Password;

                    Label1.Text = member.AccountStatus;
                    switch (member.AccountStatus)
                    {
                        case "active":
                            Label1.CssClass = "badge badge-pill badge-success";
                            break;
                        case "pending":
                            Label1.CssClass = "badge badge-pill badge-warning";
                            break;
                        case "deactive":
                            Label1.CssClass = "badge badge-pill badge-danger";
                            break;
                        default:
                            Label1.CssClass = "badge badge-pill badge-info";
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                Response.Write($"<script>alert('Error: {ex.Message}')</script>");
            }
        }

        private void UpdateUserPersonalDetails()
        {
            string password = string.IsNullOrEmpty(TextBox10.Text.Trim()) ? TextBox9.Text.Trim() : TextBox10.Text.Trim();

            try
            {
                var member = new Member
                {
                    FullName = TextBox1.Text.Trim(),
                    DOB = TextBox2.Text.Trim(),
                    ContactNo = TextBox3.Text.Trim(),
                    Email = TextBox4.Text.Trim(),
                    State = DropDownList1.SelectedItem.Value,
                    City = TextBox6.Text.Trim(),
                    Pincode = TextBox7.Text.Trim(),
                    FullAddress = TextBox5.Text.Trim(),
                    Password = password,
                    MemberId = Session["username"].ToString(),
                    AccountStatus = "pending"
                };

                if (UserService.UpdateUserPersonalDetails(member))
                {
                    Response.Write($"<script>alert('Your Details Updated Successfully!')</script>");
                    GetUserPersonalDetails();
                    GetUserBookData();
                }
                else
                {
                    Response.Write($"<script>alert('Invalid Entry!')</script>");
                }
            }
            catch (Exception ex)
            {
                Response.Write($"<script>alert('Error: {ex.Message}')</script>");
            }
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    DateTime dateTime = Convert.ToDateTime(e.Row.Cells[5].Text);
                    if (DateTime.Today > dateTime)
                    {
                        e.Row.BackColor = Color.PaleVioletRed;
                    }
                }
            }
            catch (Exception ex)
            {
                Response.Write($"<script>alert('Error: {ex.Message}')</script>");
            }
        }
    }
}