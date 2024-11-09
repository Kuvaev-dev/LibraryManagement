using LibraryManagementApp.repositories;
using LibraryManagementApp.services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web.UI.WebControls;

namespace LibraryManagementApp
{
    public partial class AdminBookInventory : System.Web.UI.Page
    {
        private readonly IBookService _bookService;
        private readonly IAuthorPublisherRepository _authorPublisherRepository;
        private readonly IFileUploadRepository _fileUploadRepository;

        public AdminBookInventory(IBookService bookService, IAuthorPublisherRepository authorPublisherRepository, IFileUploadRepository fileUploadRepository)
        {
            _bookService = bookService;
            _authorPublisherRepository = authorPublisherRepository;
            _fileUploadRepository = fileUploadRepository;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                FillAuthorPublisherValues();

            GridView1.DataBind();
        }

        private void FillAuthorPublisherValues()
        {
            try
            {
                var (authorsTable, publishersTable) = _authorPublisherRepository.GetAuthorPublisherData();

                DropDownList3.DataSource = authorsTable;
                DropDownList3.DataValueField = "author_name";
                DropDownList3.DataBind();

                DropDownList2.DataSource = publishersTable;
                DropDownList2.DataValueField = "publisher_name";
                DropDownList2.DataBind();
            }
            catch (Exception ex)
            {
                Response.Write($"<script>alert('Error: {ex.Message}')</script>");
            }
        }

        // Add
        protected void Button2_Click(object sender, EventArgs e)
        {
            if (_bookService.IsBookExists(TextBox1.Text.Trim(), TextBox2.Text.Trim()))
            {
                Response.Write("<script>alert('Book Already Exists!')</script>");
                return;
            }

            if (ValidateInputs())
            {
                var bookDetails = new Dictionary<string, string>
                {
                    {"book_id", TextBox1.Text.Trim()},
                    {"book_name", TextBox2.Text.Trim()},
                    {"genre", string.Join(",", ListBox1.Items.Cast<ListItem>().Where(i => i.Selected).Select(i => i.Value))},
                    {"author_name", DropDownList3.SelectedItem.Value},
                    {"publisher_name", DropDownList2.SelectedItem.Value},
                    {"publish_date", TextBox3.Text.Trim()},
                    {"language", DropDownList1.SelectedItem.Value},
                    {"edition", TextBox9.Text.Trim()},
                    {"book_cost", TextBox10.Text.Trim()},
                    {"no_of_pages", TextBox11.Text.Trim()},
                    {"book_description", TextBox6.Text.Trim()},
                    {"actual_stock", TextBox4.Text.Trim()},
                    {"current_stock", TextBox5.Text.Trim()}
                };

                string filePath = _fileUploadRepository.SaveUploadedFile(FileUpload1, "~/book_inventory/");
                imgview.ImageUrl = filePath;

                if (_bookService.AddNewBook(bookDetails, filePath))
                {
                    Response.Write("<script>alert('Book Added Successfully!')</script>");
                    GridView1.DataBind();
                }
                else
                {
                    Response.Write("<script>alert('Error adding book')</script>");
                }
            }
        }

        // Update
        protected void Button3_Click(object sender, EventArgs e)
        {
            if (ValidateInputs())
            {
                var bookDetails = new Dictionary<string, string>
                {
                    {"book_id", TextBox1.Text.Trim()},
                    {"book_name", TextBox2.Text.Trim()},
                    {"genre", string.Join(",", ListBox1.Items.Cast<ListItem>().Where(i => i.Selected).Select(i => i.Value))},
                    {"author_name", DropDownList3.SelectedItem.Value},
                    {"publisher_name", DropDownList2.SelectedItem.Value},
                    {"publish_date", TextBox3.Text.Trim()},
                    {"language", DropDownList1.SelectedItem.Value},
                    {"edition", TextBox9.Text.Trim()},
                    {"book_cost", TextBox10.Text.Trim()},
                    {"no_of_pages", TextBox11.Text.Trim()},
                    {"book_description", TextBox6.Text.Trim()},
                    {"actual_stock", TextBox4.Text.Trim()},
                    {"current_stock", TextBox5.Text.Trim()}
                };

                string filePath = _fileUploadRepository.SaveUploadedFile(FileUpload1, "~/book_inventory/");
                imgview.ImageUrl = filePath;

                if (_bookService.UpdateBook(bookDetails, filePath))
                {
                    Response.Write("<script>alert('Book Updated Successfully!')</script>");
                    GridView1.DataBind();
                }
                else
                {
                    Response.Write("<script>alert('Error updating book')</script>");
                }
            }
        }

        // Delete
        protected void Button1_Click(object sender, EventArgs e)
        {
            if (_bookService.DeleteBook(TextBox1.Text.Trim()))
            {
                Response.Write("<script>alert('Book Deleted Successfully!')</script>");
                GridView1.DataBind();
            }
            else
            {
                Response.Write("<script>alert('Error deleting book')</script>");
            }
        }

        // Go
        protected void Button4_Click(object sender, EventArgs e)
        {
            var bookDetails = _bookService.GetBookByID(TextBox1.Text.Trim());
            if (bookDetails.Count > 0)
            {
                TextBox2.Text = bookDetails["book_name"];
                TextBox3.Text = bookDetails["publish_date"];
                TextBox9.Text = bookDetails["edition"];
                TextBox10.Text = bookDetails["book_cost"];
                TextBox11.Text = bookDetails["no_of_pages"];
                TextBox4.Text = bookDetails["actual_stock"];
                TextBox5.Text = bookDetails["current_stock"];
                TextBox6.Text = bookDetails["book_description"];
                DropDownList1.SelectedValue = bookDetails["language"];
                DropDownList2.SelectedValue = bookDetails["publisher_name"];
                DropDownList3.SelectedValue = bookDetails["author_name"];

                string[] genres = bookDetails["genre"].Split(',');
                ListBox1.ClearSelection();
                foreach (string genre in genres)
                {
                    ListItem item = ListBox1.Items.FindByText(genre);
                    if (item != null)
                    {
                        item.Selected = true;
                    }
                }
            }
            else
            {
                Response.Write("<script>alert('Invalid Book ID!')</script>");
            }
        }

        private bool ValidateInputs()
        {
            if (string.IsNullOrWhiteSpace(TextBox1.Text) || string.IsNullOrWhiteSpace(TextBox2.Text))
            {
                Response.Write("<script>alert('Book ID and Name are required.')</script>");
                return false;
            }

            if (!int.TryParse(TextBox10.Text, out _) || !int.TryParse(TextBox11.Text, out _))
            {
                Response.Write("<script>alert('Please enter valid numbers for cost and pages.')</script>");
                return false;
            }

            return true;
        }
    }
}