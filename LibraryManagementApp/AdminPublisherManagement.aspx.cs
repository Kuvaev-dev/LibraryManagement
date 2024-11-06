using System;
using LibraryManagementApp.helpers;
using LibraryManagementApp.services;

namespace LibraryManagementApp
{
    public partial class AdminPublisherManagement : DIPage
    {
        public IPublisherService _publisherService { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            GridView1.DataBind();
        }

        // Add
        protected void Button1_Click(object sender, EventArgs e)
        {
            if (_publisherService.IsPublisherExists(TextBox1.Text.Trim()))
                Response.Write("<script>alert('Publisher with this ID already exists!')</script>");
            else
            {
                if (_publisherService.AddNewPublisher(TextBox1.Text.Trim(), TextBox2.Text.Trim()))
                {
                    Response.Write("<script>alert('Publisher Added Successfully!')</script>");
                    ClearForm();
                    GridView1.DataBind();
                }
                else
                {
                    Response.Write("<script>alert('Error adding publisher')</script>");
                }
            }
        }

        // Update
        protected void Button2_Click(object sender, EventArgs e)
        {
            if (_publisherService.IsPublisherExists(TextBox1.Text.Trim()))
            {
                if (_publisherService.UpdatePublisher(TextBox1.Text.Trim(), TextBox2.Text.Trim()))
                {
                    Response.Write("<script>alert('Publisher Updated Successfully!')</script>");
                    ClearForm();
                    GridView1.DataBind();
                }
                else
                {
                    Response.Write("<script>alert('Error updating publisher')</script>");
                }
            }
            else
            {
                Response.Write("<script>alert('Publisher Does Not Exist!')</script>");
            }
        }

        // Delete
        protected void Button3_Click(object sender, EventArgs e)
        {
            if (_publisherService.IsPublisherExists(TextBox1.Text.Trim()))
            {
                if (_publisherService.DeletePublisher(TextBox1.Text.Trim()))
                {
                    Response.Write("<script>alert('Publisher Deleted Successfully!')</script>");
                    ClearForm();
                    GridView1.DataBind();
                }
                else
                {
                    Response.Write("<script>alert('Error deleting publisher')</script>");
                }
            }
            else
            {
                Response.Write("<script>alert('Publisher Does Not Exist!')</script>");
            }
        }

        // Go
        protected void Unnamed1_Click(object sender, EventArgs e)
        {
            var publisherDetails = _publisherService.GetPublisherByID(TextBox1.Text.Trim());
            if (publisherDetails.Count > 0)
            {
                TextBox2.Text = publisherDetails["publisher_name"];
            }
            else
            {
                Response.Write("<script>alert('Invalid Publisher ID!')</script>");
            }
        }

        private void ClearForm()
        {
            TextBox1.Text = "";
            TextBox2.Text = "";
        }
    }
}