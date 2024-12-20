﻿using LibraryManagementApp.helpers;
using LibraryManagementApp.services;
using System;

namespace LibraryManagementApp
{
    public partial class AdminMemberManagement : System.Web.UI.Page
    {
        private readonly IMemberService _memberService;

        public AdminMemberManagement(IMemberService memberService)
        {
            _memberService = memberService;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            GridView1.DataBind();
        }

        // Go
        protected void LinkButton4_Click(object sender, EventArgs e)
        {
            GetMemberByID();
        }

        // Active
        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            UpdateMemberStatusByID("Active");
        }

        // Pending
        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            UpdateMemberStatusByID("Pending");
        }

        // Deactive
        protected void LinkButton3_Click(object sender, EventArgs e)
        {
            UpdateMemberStatusByID("Deactive");
        }

        // Delete
        protected void Button1_Click(object sender, EventArgs e)
        {
            DeleteMemberByID();
        }

        private void GetMemberByID()
        {
            var memberDetails = _memberService.GetMemberByID(TextBox1.Text.Trim());
            if (memberDetails.Count > 0)
            {
                TextBox2.Text = memberDetails["full_name"];
                TextBox7.Text = memberDetails["account_status"];
                TextBox8.Text = memberDetails["dob"];
                TextBox3.Text = memberDetails["contact_no"];
                TextBox4.Text = memberDetails["email"];
                TextBox9.Text = memberDetails["state"];
                TextBox10.Text = memberDetails["city"];
                TextBox11.Text = memberDetails["pincode"];
                TextBox6.Text = memberDetails["full_address"];
            }
            else
            {
                Response.Write("<script>alert('Member not found!')</script>");
            }
        }

        private void UpdateMemberStatusByID(string status)
        {
            if (_memberService.IsMemberExists(TextBox1.Text.Trim()))
            {
                if (_memberService.UpdateMemberStatusByID(TextBox1.Text.Trim(), status))
                {
                    ClearForm();
                    GridView1.DataBind();
                    Response.Write("<script>alert('Member Status Updated!')</script>");
                }
                else
                {
                    Response.Write("<script>alert('Error updating member status')</script>");
                }
            }
            else
            {
                Response.Write("<script>alert('Invalid Member ID!')</script>");
            }
        }

        private void DeleteMemberByID()
        {
            if (_memberService.IsMemberExists(TextBox1.Text.Trim()))
            {
                if (_memberService.DeleteMemberByID(TextBox1.Text.Trim()))
                {
                    Response.Write("<script>alert('Member Deleted Successfully!')</script>");
                    ClearForm();
                    GridView1.DataBind();
                }
                else
                {
                    Response.Write("<script>alert('Error deleting member')</script>");
                }
            }
            else
            {
                Response.Write("<script>alert('Invalid Member ID!')</script>");
            }
        }

        private void ClearForm()
        {
            TextBox2.Text = "";
            TextBox7.Text = "";
            TextBox8.Text = "";
            TextBox3.Text = "";
            TextBox4.Text = "";
            TextBox9.Text = "";
            TextBox10.Text = "";
            TextBox11.Text = "";
            TextBox6.Text = "";
        }
    }
}