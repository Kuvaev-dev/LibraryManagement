using LibraryManagementApp.helpers;
using LibraryManagementApp.services;
using System;

namespace LibraryManagementApp
{
    public partial class AdminLogin : System.Web.UI.Page
    {
        private readonly IAuthenticationService _authService;

        public AdminLogin(IAuthenticationService authService)
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
                var result = _authService.VerifyAdminCredentials(TextBox1.Text.Trim(), TextBox2.Text.Trim());

                if (result.IsSuccess)
                {
                    Session["username"] = TextBox1.Text.Trim();
                    Session["fullname"] = result.FullName;
                    Session["role"] = "admin";

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