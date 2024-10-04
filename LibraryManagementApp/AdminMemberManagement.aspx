<%@ Page Title="" Language="C#" MasterPageFile="~/Library.Master" AutoEventWireup="true" CodeBehind="AdminMemberManagement.aspx.cs" Inherits="LibraryManagementApp.AdminMemberManagement" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid">
        <div class="row">
            <div class="col-md-5">
                <div class="card">
                    <div class="card-body">
                        <div class="row">
                            <div class="col">
                                <center>
                                    <h4>Member Details</h4>
                                </center>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col">
                                <center>
                                    <img src="assets/imgs/generaluser.png" width="100px"/>
                                </center>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col">
                                </hr>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-3">
                                <label>Member ID</label>
                                <div class="form-group">
                                    <div class="input-group">
                                        <asp:TextBox ID="TextBox1" CssClass="form-control" runat="server" placeholder="Member ID"></asp:TextBox>
                                        <asp:LinkButton runat="server" CssClass="btn btn-primary">
                                            <i class="fa-solid fa-circle-check"></i>
                                        </asp:LinkButton>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <label>Full Name</label>
                                <div class="form-group">
                                    <asp:TextBox ID="TextBox2" CssClass="form-control" placeholder="Full Name" runat="server" ReadOnly="true"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-5">
                                <label>Account Status</label>
                                <div class="form-group">
                                    <div class="input-group">
                                        <asp:TextBox ID="TextBox7" CssClass="form-control mr-1" runat="server" placeholder="Account Status" ReadOnly="True"></asp:TextBox>
                                        <asp:LinkButton runat="server" CssClass="btn btn-success mr-1">
                                            <i class="fa-solid fa-circle-check"></i>
                                        </asp:LinkButton>
                                        <asp:LinkButton runat="server" CssClass="btn btn-warning mr-1">
                                            <i class="fa-solid fa-circle-pause"></i>
                                        </asp:LinkButton>
                                        <asp:LinkButton runat="server" CssClass="btn btn-danger mr-1">
                                            <i class="fa-solid fa-circle-xmark"></i>
                                        </asp:LinkButton>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-3">
                                <label>DOB</label>
                                <div class="form-group">
                                    <asp:TextBox ID="TextBox8" CssClass="form-control" placeholder="DOB" runat="server" ReadOnly="true"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <label>Contact №</label>
                                <div class="form-group">
                                    <asp:TextBox ID="TextBox3" CssClass="form-control" placeholder="Contact №" runat="server" ReadOnly="true"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-5">
                                <label>Email ID</label>
                                <div class="form-group">
                                    <asp:TextBox ID="TextBox4" CssClass="form-control" placeholder="Email ID" runat="server" ReadOnly="true"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-4">
                                <label>State</label>
                                <div class="form-group">
                                    <asp:TextBox ID="TextBox9" CssClass="form-control" placeholder="State" runat="server" ReadOnly="true"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <label>City</label>
                                <div class="form-group">
                                    <asp:TextBox ID="TextBox10" CssClass="form-control" placeholder="City" runat="server" ReadOnly="true"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <label>Pin Code</label>
                                <div class="form-group">
                                    <asp:TextBox ID="TextBox11" CssClass="form-control" placeholder="Pin Code" runat="server" ReadOnly="true"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-12">
                                <label>Full Postal Address</label>
                                <div class="form-group">
                                    <asp:TextBox ID="TextBox6" CssClass="form-control" placeholder="Full Postal Address" runat="server" TextMode="Multiline" Rows="2" ReadOnly="true"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-8 mx-auto">
                                <asp:Button ID="Button1" runat="server" Text="Delete User Permanently" class="btn btn-lg btn-block btn-danger"/>
                            </div>
                        </div>
                    </div>
                </div>
                <a href="Home.aspx"><< Back to Home</a>
            </div>
            <div class="col-md-7">
                <div class="card">
                    <div class="card-body">
                        <div class="row">
                            <div class="col">
                                <center>
                                    <h4>Member List</h4>
                                </center>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col">
                                <hr>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col">
                                <asp:GridView CssClass="table table-striped table-bordered" ID="GridView1" runat="server"></asp:GridView>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
