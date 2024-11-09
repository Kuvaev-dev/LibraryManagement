<%@ Page Title="Terms and Conditions" Language="C#" MasterPageFile="~/Library.Master" AutoEventWireup="true" CodeBehind="Terms.aspx.cs" Inherits="LibraryManagementApp.Terms" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container mt-5">
        <div class="row">
            <div class="col">
                <h1 class="text-center">Terms and Conditions</h1>
                <hr />
                <p class="lead text-justify">
                    By accessing and using our library management system, you agree to comply with the following terms and conditions. Please read them carefully.
                </p>
                <ul class="list-group">
                    <li class="list-group-item">
                        <strong>Membership:</strong> Membership is required to borrow books and access certain resources. Members must provide accurate information during registration.
                    </li>
                    <li class="list-group-item">
                        <strong>Borrowing Limits:</strong> Members are allowed to borrow a limited number of books at a time. The borrowing limit and duration may vary based on the membership type.
                    </li>
                    <li class="list-group-item">
                        <strong>Late Returns:</strong> Late returns may incur fines. Members are responsible for returning borrowed items on or before the due date.
                    </li>
                    <li class="list-group-item">
                        <strong>Resource Usage:</strong> Library resources are for personal and educational use only. Unauthorized commercial use is prohibited.
                    </li>
                    <li class="list-group-item">
                        <strong>Privacy:</strong> We respect your privacy and are committed to protecting your personal information. Please refer to our privacy policy for more details.
                    </li>
                </ul>
                <p class="text-justify mt-3">
                    We reserve the right to modify these terms and conditions at any time. Changes will be communicated to members via email or through our website.
                </p>
            </div>
        </div>
    </div>
</asp:Content>
