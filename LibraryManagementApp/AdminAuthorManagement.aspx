<%@ Page Title="" Language="C#" MasterPageFile="~/Library.Master" AutoEventWireup="true" CodeBehind="AdminAuthorManagement.aspx.cs" Inherits="LibraryManagementApp.AdminAuthorManagement" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        $(document).ready(function () {
            $('.table').prepend($('<thead></thead>').append($(this).find('tr:first'))).dataTable();
        })
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="row">
            <div class="col-md-5">
                <div class="card">
                    <div class="card-body">
                        <div class="row">
                            <div class="col">
                                <center>
                                    <h4>Author Details</h4>
                                </center>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col">
                                <center>
                                    <img src="assets/imgs/writer.png" width="100px"/>
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
                                <label>Author ID</label>
                                <div class="form-group">
                                    <div class="input-group">
                                        <asp:TextBox ID="TextBox1" CssClass="form-control" placeholder="ID" runat="server"></asp:TextBox>
                                        <asp:Button class="btn btn-primary" runat="server" Text="Go" OnClick="Unnamed1_Click"/>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-9">
                                <label>Author Name</label>
                                <div class="form-group">
                                    <asp:TextBox ID="TextBox2" CssClass="form-control" placeholder="Name" runat="server"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        
                        <div class="row">
                            <div class="col-4">
                                <asp:Button ID="Button1" runat="server" Text="Add" class="btn btn-lg btn-block btn-success" OnClick="Button1_Click"/>
                            </div>
                            <div class="col-4">
                                <asp:Button ID="Button2" runat="server" Text="Update" class="btn btn-lg btn-block btn-warning" OnClick="Button2_Click"/>
                            </div>
                            <div class="col-4">
                                <asp:Button ID="Button3" runat="server" Text="Delete" class="btn btn-lg btn-block btn-danger" OnClick="Button3_Click"/>
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
                                    <h4>Author List</h4>
                                </center>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col">
                                <hr>
                            </div>
                        </div>
                        <div class="row">
                            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:elibraryDB %>" ProviderName="<%$ ConnectionStrings:elibraryDB.ProviderName %>" SelectCommand="SELECT * FROM [author_master_tbl]"></asp:SqlDataSource>
                            <div class="col">
                                <asp:GridView CssClass="table table-striped table-bordered" ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="author_id" DataSourceID="SqlDataSource1">
                                    <Columns>
                                        <asp:BoundField DataField="author_id" HeaderText="author_id" ReadOnly="True" SortExpression="author_id" />
                                        <asp:BoundField DataField="author_name" HeaderText="author_name" SortExpression="author_name" />
                                    </Columns>
                                </asp:GridView>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
