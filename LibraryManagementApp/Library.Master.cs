using System;

namespace LibraryManagementApp
{
    public partial class Library : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["role"] == null || Session["role"].Equals(""))
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
                    LinkButton7.Enabled = false;

                    LinkButton6.Visible = false; // Admin Login Link Button
                    LinkButton11.Visible = true; // Author Management Link Button
                    LinkButton12.Visible = true; // Publisher Management Link Button
                    LinkButton10.Visible = true; // Publisher Management Link Button
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
            Response.Redirect("admin-login");
        }

        protected void LinkButton11_Click(object sender, EventArgs e)
        {
            Response.Redirect("authors");
        }

        protected void LinkButton12_Click(object sender, EventArgs e)
        {
            Response.Redirect("publishers");
        }

        protected void LinkButton8_Click(object sender, EventArgs e)
        {
            Response.Redirect("book-inventory");
        }

        protected void LinkButton9_Click(object sender, EventArgs e)
        {
            Response.Redirect("book-issuing");
        }

        protected void LinkButton10_Click(object sender, EventArgs e)
        {
            Response.Redirect("members");
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("login");
        }

        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            Response.Redirect("sign-up");
        }

        protected void LinkButton4_Click(object sender, EventArgs e)
        {
            Response.Redirect("books");
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

            Response.Redirect("home");
        }

        // View Profile
        protected void LinkButton7_Click(object sender, EventArgs e)
        {
            Response.Redirect("profile");
        }
    }
}