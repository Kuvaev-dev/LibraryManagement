using LibraryManagementApp.helpers;
using LibraryManagementApp.services;
using System;

namespace LibraryManagementApp
{
    public partial class AdminBookIssuing : DIPage
    {
        private readonly IBookIssuingService _bookIssuingService;

        protected void Page_Load(object sender, EventArgs e)
        {
            GridView1.DataBind();
        }

        // Issue
        protected void Button1_Click(object sender, EventArgs e)
        {
            if (_bookIssuingService.IsBookExists(TextBox1.Text.Trim()) && _bookIssuingService.IsMemberExists(TextBox2.Text.Trim()))
            {
                if (_bookIssuingService.IsIssuedEntryExists(TextBox1.Text.Trim(), TextBox2.Text.Trim()))
                {
                    Response.Write("<script>alert('This Member already Has This Book!')</script>");
                }
                else
                {
                    _bookIssuingService.IssueBook(
                        TextBox1.Text.Trim(),
                        TextBox4.Text.Trim(),
                        TextBox2.Text.Trim(),
                        TextBox3.Text.Trim(),
                        DateTime.Parse(TextBox5.Text.Trim()),
                        DateTime.Parse(TextBox6.Text.Trim())
                    );
                    Response.Write("<script>alert('Book Issued Successfully!')</script>");
                    GridView1.DataBind();
                }
            }
            else
            {
                Response.Write("<script>alert('Wrong Member ID or Book ID!')</script>");
            }
        }

        // Return
        protected void Button3_Click(object sender, EventArgs e)
        {
            if (_bookIssuingService.IsBookExists(TextBox1.Text.Trim()) && _bookIssuingService.IsMemberExists(TextBox2.Text.Trim()))
            {
                if (_bookIssuingService.IsIssuedEntryExists(TextBox1.Text.Trim(), TextBox2.Text.Trim()))
                {
                    _bookIssuingService.ReturnBook(TextBox1.Text.Trim(), TextBox2.Text.Trim());
                    Response.Write("<script>alert('Book Returned Successfully!')</script>");
                    GridView1.DataBind();
                }
                else
                {
                    Response.Write("<script>alert('This Entry Does Not Exist!')</script>");
                }
            }
            else
            {
                Response.Write("<script>alert('Wrong Member ID or Book ID!')</script>");
            }
        }

        // Go
        protected void Button4_Click(object sender, EventArgs e)
        {
            try
            {
                var names = _bookIssuingService.GetBookAndMemberNames(TextBox1.Text.Trim(), TextBox2.Text.Trim());
                TextBox4.Text = names.bookName;
                TextBox3.Text = names.memberName;
            }
            catch (Exception ex)
            {
                Response.Write($"<script>alert('Error: {ex.Message}')</script>");
            }
        }

        protected void GridView1_RowDataBound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == System.Web.UI.WebControls.DataControlRowType.DataRow)
                {
                    DateTime dateTime = Convert.ToDateTime(e.Row.Cells[5].Text);
                    DateTime today = DateTime.Today;
                    if (today > dateTime)
                        e.Row.BackColor = System.Drawing.Color.PaleVioletRed;
                }
            }
            catch (Exception ex)
            {
                Response.Write($"<script>alert('{ex.Message}')</script>");
            }
        }
    }
}