using LibraryManagementApp.services;
using System;

namespace LibraryManagementApp
{
    public partial class UserSignUp : System.Web.UI.Page
    {
        public UserService UserService { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (UserService.IsMemberExists(TextBox8.Text.Trim()))
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
                    MemberId = TextBox8.Text.Trim(),
                    Password = TextBox9.Text.Trim()
                };

                if (UserService.SignUpNewMember(member))
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