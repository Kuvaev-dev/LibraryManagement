using LibraryManagementApp.helpers;
using LibraryManagementApp.models;
using LibraryManagementApp.services;
using System;

namespace LibraryManagementApp
{
    public partial class UserSignUp : System.Web.UI.Page
    {
        private readonly IUserService _userService;

        public UserSignUp(IUserService userService)
        {
            _userService = userService;
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (_userService.IsMemberExists(TextBox8.Text.Trim(), TextBox4.Text.Trim()))
                Response.Write($"<script>alert('Member Already Exists!')</script>");
            else
                SignUpNewMember();
        }

        private void SignUpNewMember()
        {
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
                    Username = TextBox8.Text.Trim(),
                    Password = TextBox9.Text.Trim()
                };

                if (_userService.SignUpNewMember(member))
                {
                    Response.Write("<script>alert('Sign Up Successful. Now go to Login and Authorize yourself.')</script>");
                }
                else
                {
                    Response.Write($"<script>alert('Error occurred during sign up.')</script>");
                }
            }
            catch (Exception ex)
            {
                Response.Write($"<script>alert('Error: {ex.Message}')</script>");
            }
        }
    }
}