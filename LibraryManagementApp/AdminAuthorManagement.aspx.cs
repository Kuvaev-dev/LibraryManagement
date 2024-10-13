using System;
using LibraryManagementApp.services;

namespace LibraryManagementApp
{
    public partial class AdminAuthorManagement : System.Web.UI.Page
    {
        public AuthorService AuthorService { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindGrid();
            }
        }

        // Add
        protected void Button1_Click(object sender, EventArgs e)
        {
            string result = AuthorService.AddNewAuthor(Convert.ToInt32(TextBox1.Text.Trim()), TextBox2.Text.Trim());
            Response.Write($"<script>alert('{result}')</script>");
            BindGrid();
        }

        // Update
        protected void Button2_Click(object sender, EventArgs e)
        {
            string result = AuthorService.UpdateAuthor(Convert.ToInt32(TextBox1.Text.Trim()), TextBox2.Text.Trim());
            Response.Write($"<script>alert('{result}')</script>");
            BindGrid();
        }

        // Delete
        protected void Button3_Click(object sender, EventArgs e)
        {
            string result = AuthorService.DeleteAuthor(Convert.ToInt32(TextBox1.Text.Trim()));
            Response.Write($"<script>alert('{result}')</script>");
            BindGrid();
        }

        // Go
        protected void Unnamed1_Click(object sender, EventArgs e)
        {
            Author author = AuthorService.GetAuthorByID(Convert.ToInt32(TextBox1.Text.Trim()));
            if (author != null)
            {
                TextBox2.Text = author.AuthorName;
            }
            else
            {
                Response.Write("<script>alert('Invalid Author ID!')</script>");
            }
        }

        private void BindGrid()
        {
            AuthorService authorService = new AuthorService();
            GridView1.DataSource = authorService.GetAuthors();
            GridView1.DataBind();
        }
    }
}
