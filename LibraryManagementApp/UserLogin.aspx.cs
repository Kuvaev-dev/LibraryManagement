using LibraryManagementApp.helpers;
using LibraryManagementApp.services;
using System;

namespace LibraryManagementApp
{
    public partial class UserLogin : System.Web.UI.Page
    {
        private readonly IAuthenticationService _authService;

        public UserLogin(IAuthenticationService authService)
        {
            _authService = authService;
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                var result = _authService.VerifyUserCredentials(TextBox1.Text.Trim(), TextBox2.Text.Trim());

                if (result.IsSuccess && result.Status != "Deactive")
                {
                    Response.Write("<script>alert('Login Successful')</script>");

                    Session["username"] = TextBox1.Text.Trim();
                    Session["fullname"] = result.FullName;
                    Session["role"] = "user";
                    Session["status"] = result.Status;
                    Session["member_id"] = result.MemberId;

                    Response.Redirect("home");
                }
                else if (result.Status == "Deactive")
                {
                    Response.Write("<script>alert('Your Profile Is Inactive')</script>");
                    Response.Redirect("home");
                }
                else
                {
                    Response.Write($"<script>alert('{result.ErrorMessage}')</script>");
                }
            }
            catch (Exception ex)
            {
                Response.Write($"<script>alert('Error: {ex.Message}')</script>");
            }
        }

    }
}