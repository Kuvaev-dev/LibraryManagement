using System;

namespace LibraryManagementApp
{
    public partial class Library : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["role"].Equals(""))
                {
                    LinkButton1.Visible = true; // User Login Link Button
                    LinkButton2.Visible = true; // Sign Up Link Button
                    LinkButton3.Visible = false; // Logout Link Button
                    LinkButton7.Visible = false; // Hello User Link Button

                    LinkButton6.Visible = true; // Admin Login Link Button
                    LinkButton11.Visible = false; // Author Management Link Button
                    LinkButton12.Visible = false; // Publisher Management Link Button
                    LinkButton8.Visible = false; // Book Inventory Link Button
                    LinkButton9.Visible = false; // Book Issuing Link Button
                    LinkButton10.Visible = false; // Member Management Link Button
                }
                else if (Session["role"].Equals("user"))
                {
                    LinkButton1.Visible = false; // User Login Link Button
                    LinkButton2.Visible = false; // Sign Up Link Button
                    LinkButton3.Visible = true; // Logout Link Button

                    LinkButton7.Visible = true; // Hello User Link Button
                    LinkButton7.Text = $"Hello, {Session["username"]}";

                    LinkButton6.Visible = true; // Admin Login Link Button
                    LinkButton11.Visible = false; // Author Management Link Button
                    LinkButton12.Visible = false; // Publisher Management Link Button
                    LinkButton8.Visible = false; // Book Inventory Link Button
                    LinkButton9.Visible = false; // Book Issuing Link Button
                }
                else if (Session["role"].Equals("admin"))
                {
                    LinkButton1.Visible = false; // User Login Link Button
                    LinkButton2.Visible = false; // Sign Up Link Button
                    LinkButton3.Visible = true; // Logout Link Button

                    LinkButton7.Visible = true; // Hello User Link Button
                    LinkButton7.Text = $"Hello, Admin";

                    LinkButton6.Visible = false; // Admin Login Link Button
                    LinkButton11.Visible = true; // Author Management Link Button
                    LinkButton12.Visible = true; // Publisher Management Link Button
                    LinkButton8.Visible = true; // Book Inventory Link Button
                    LinkButton9.Visible = true; // Book Issuing Link Button
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        // Navigation
        protected void LinkButton6_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdminLogin.aspx");
        }

        protected void LinkButton11_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdminAuthorManagement.aspx");
        }

        protected void LinkButton12_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdminPublisherManagement.aspx");
        }

        protected void LinkButton8_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdminBookInventory.aspx");
        }

        protected void LinkButton9_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdminBookIssuing.aspx");
        }

        protected void LinkButton10_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdminMemberManagement.aspx");
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("UserLogin.aspx");
        }

        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            Response.Redirect("UserSignUp.aspx");
        }

        protected void LinkButton4_Click(object sender, EventArgs e)
        {
            Response.Redirect("ViewBooks.aspx");
        }

        // Logout
        protected void LinkButton3_Click(object sender, EventArgs e)
        {
            Session["username"] = "";
            Session["fullname"] = "";
            Session["role"] = "";
            Session["status"] = "";

            LinkButton1.Visible = true; // User Login Link Button
            LinkButton2.Visible = true; // Sign Up Link Button
            LinkButton3.Visible = false; // Logout Link Button
            LinkButton7.Visible = false; // Hello User Link Button

            LinkButton6.Visible = true; // Admin Login Link Button
            LinkButton11.Visible = false; // Author Management Link Button
            LinkButton12.Visible = false; // Publisher Management Link Button
            LinkButton8.Visible = false; // Book Inventory Link Button
            LinkButton9.Visible = false; // Book Issuing Link Button
            LinkButton10.Visible = false; // Member Management Link Button
        }

        // View Profile
        protected void LinkButton7_Click(object sender, EventArgs e)
        {
            Response.Redirect("UserProfile.aspx");
        }
    }
}