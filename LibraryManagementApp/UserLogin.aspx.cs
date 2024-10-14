using LibraryManagementApp.helpers;
using LibraryManagementApp.services;
using System;

namespace LibraryManagementApp
{
    public partial class UserLogin : System.Web.UI.Page
    {
        private readonly IAuthenticationService _authService;

        public UserLogin()
        {
            _authService = (IAuthenticationService)ServiceProviderConfig.ServiceProvider.GetService(typeof(IAuthenticationService));
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                var result = _authService.VerifyUserCredentials(TextBox1.Text.Trim(), TextBox2.Text.Trim());

                if (result.IsSuccess)
                {
                    Response.Write("<script>alert('Login Successful')</script>");

                    Session["username"] = TextBox1.Text.Trim();
                    Session["fullname"] = result.FullName;
                    Session["role"] = "user";
                    Session["status"] = result.Status;
                    Session["member_id"] = result.MemberId;
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