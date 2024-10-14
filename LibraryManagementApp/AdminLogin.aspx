<%@ Page Title="" Language="C#" MasterPageFile="~/Library.Master" AutoEventWireup="true" CodeBehind="AdminLogin.aspx.cs" Inherits="LibraryManagementApp.AdminLogin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css" rel="stylesheet">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="row">
            <div class="col-md-6 mx-auto">
                <div class="card">
                    <div class="card-body">
                        <div class="row">
                            <div class="col text-center">
                                <img src="assets/imgs/adminuser.png" style="width:150px" class="mb-3" />
                            </div>
                        </div>
                        <div class="row">
                            <div class="col text-center">
                                <h3>Admin Login</h3>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col">
                                <hr>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col">
                                <label class="mb-1">Admin ID</label>
                                <div class="form-group">
                                    <asp:TextBox ID="TextBox1" CssClass="form-control mb-3" placeholder="Admin ID" runat="server"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="rfvAdminID" runat="server" ControlToValidate="TextBox1" ErrorMessage="Admin ID is required." CssClass="text-danger" Display="Dynamic" />
                                </div>
                                <label class="mb-1">Password</label>
                                <div class="form-group">
                                    <asp:TextBox ID="TextBox2" CssClass="form-control mb-3" placeholder="Password" TextMode="Password" runat="server"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="rfvPassword" runat="server" ControlToValidate="TextBox2" ErrorMessage="Password is required." CssClass="text-danger" Display="Dynamic" />
                                </div>
                                <div class="form-group text-center">
                                    <asp:Button ID="Button1" class="btn btn-success btn-block btn-lg" runat="server" Text="Login" OnClick="Button1_Click" />
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <a href="Home.aspx" class="d-block text-center mt-3 mb-3"><< Back to Home</a>
            </div>
        </div>
    </div>
</asp:Content>
