<%@ Page Title="" Language="C#" MasterPageFile="~/Library.Master" AutoEventWireup="true" CodeBehind="AdminBookIssuing.aspx.cs" Inherits="LibraryManagementApp.AdminBookIssuing" %>
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
                                    <h4>Book Issuing</h4>
                                </center>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col">
                                <center>
                                    <img src="assets/imgs/books.png" width="100px"/>
                                </center>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col">
                                </hr>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-6">
                                <label>Member ID</label>
                                <div class="form-group">
                                    <asp:TextBox ID="TextBox2" CssClass="form-control" placeholder="Member ID" runat="server"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-6">
                                <label>Book ID</label>
                                <div class="form-group">
                                    <div class="input-group">
                                        <asp:TextBox ID="TextBox1" CssClass="form-control" runat="server" placeholder="Book ID"></asp:TextBox>
                                        <asp:Button ID="Button4" CssClass="btn btn-primary" runat="server" Text="Go" />
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-6">
                                <label>Member Name</label>
                                <div class="form-group">
                                    <asp:TextBox ID="TextBox3" CssClass="form-control" placeholder="Member Name" runat="server" ReadOnly="true"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-6">
                                <label>Book Name</label>
                                <div class="form-group">
                                    <asp:TextBox ID="TextBox4" CssClass="form-control" placeholder="Book Name" runat="server" ReadOnly="true"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-6">
                                <label>Start Date</label>
                                <div class="form-group">
                                    <asp:TextBox ID="TextBox5" CssClass="form-control" placeholder="Start Date" runat="server" TextMode="Date"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-6">
                                <label>End Date</label>
                                <div class="form-group">
                                    <asp:TextBox ID="TextBox6" CssClass="form-control" placeholder="End Date" runat="server" TextMode="Date"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-4">
                                <asp:Button ID="Button1" runat="server" Text="Issue" class="btn btn-lg btn-block btn-primary"/>
                            </div>
                            <div class="col-4">
                                <asp:Button ID="Button3" runat="server" Text="Return" class="btn btn-lg btn-block btn-success"/>
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
                                    <h4>Issued Book List</h4>
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