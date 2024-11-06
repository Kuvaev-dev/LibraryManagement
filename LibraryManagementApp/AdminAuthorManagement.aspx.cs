using System;
using LibraryManagementApp.helpers;
using LibraryManagementApp.models;
using LibraryManagementApp.services;

namespace LibraryManagementApp
{
    public partial class AdminAuthorManagement : DIPage
    {
        public IAuthorService _authorService { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        // Add
        protected void Button1_Click(object sender, EventArgs e)
        {
            string result = _authorService.AddNewAuthor(TextBox1.Text.Trim(), TextBox2.Text.Trim());
            Response.Write($"<script>alert('{result}')</script>");
            GridView1.DataBind();
        }

        // Update
        protected void Button2_Click(object sender, EventArgs e)
        {
            string result = _authorService.UpdateAuthor(TextBox1.Text.Trim(), TextBox2.Text.Trim());
            Response.Write($"<script>alert('{result}')</script>");
            GridView1.DataBind();
        }

        // Delete
        protected void Button3_Click(object sender, EventArgs e)
        {
            string result = _authorService.DeleteAuthor(TextBox1.Text.Trim());
            Response.Write($"<script>alert('{result}')</script>");
            GridView1.DataBind();
        }

        // Go
        protected void Unnamed1_Click(object sender, EventArgs e)
        {
            Author author = _authorService.GetAuthorByID(TextBox1.Text.Trim());
            if (author != null)
            {
                TextBox2.Text = author.AuthorName;
            }
            else
            {
                Response.Write("<script>alert('Invalid Author ID!')</script>");
            }
        }
    }
}
