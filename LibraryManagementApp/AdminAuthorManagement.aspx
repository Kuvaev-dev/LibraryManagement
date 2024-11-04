<%@ Page Title="" Language="C#" MasterPageFile="~/Library.Master" AutoEventWireup="true" CodeBehind="AdminAuthorManagement.aspx.cs" Inherits="LibraryManagementApp.AdminAuthorManagement" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css" rel="stylesheet">
    <script type="text/javascript">
        $(document).ready(function () {
            $('.table').prepend($('<thead></thead>').append($(this).find('tr:first'))).dataTable();
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="row">
            <div class="col-md-5">
                <div class="card mt-4">
                    <div class="card-body">
                        <div class="row mb-3">
                            <div class="col text-center">
                                <h4>Author Details</h4>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col text-center">
                                <img src="assets/imgs/writer.png" width="100px" class="mb-3" />
                            </div>
                        </div>
                        <div class="row mb-1">
                            <div class="col">
                                <hr />
                            </div>
                        </div>
                        <div class="row mb-3">
                            <div class="col-md-4">
                                <label>Author ID</label>
                                <div class="form-group">
                                    <div class="input-group">
                                        <asp:TextBox ID="TextBox1" CssClass="form-control" placeholder="ID" runat="server"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBox1" ErrorMessage="Author ID is required" CssClass="text-danger" Display="Dynamic" />
                                        <asp:RegularExpressionValidator ID="RegexValidator1" runat="server" ControlToValidate="TextBox1" ErrorMessage="Invalid ID format" ValidationExpression="^\d+$" CssClass="text-danger" Display="Dynamic" />
                                        <asp:Button class="btn btn-primary" runat="server" Text="Go" OnClick="Unnamed1_Click" />
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-8">
                                <label>Author Name</label>
                                <div class="form-group">
                                    <asp:TextBox ID="TextBox2" CssClass="form-control" placeholder="Name" runat="server"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-4">
                                <asp:Button ID="Button1" runat="server" Text="Add" class="btn btn-lg btn-block btn-success" OnClick="Button1_Click" />
                            </div>
                            <div class="col-4">
                                <asp:Button ID="Button2" runat="server" Text="Update" class="btn btn-lg btn-block btn-warning" OnClick="Button2_Click" />
                            </div>
                            <div class="col-4">
                                <asp:Button ID="Button3" runat="server" Text="Delete" class="btn btn-lg btn-block btn-danger" OnClick="Button3_Click" />
                            </div>
                        </div>
                    </div>
                </div>
                <a href="Home.aspx" class="d-block text-center mt-1 mb-1"><< Back to Home</a>
            </div>
            <div class="col-md-7">
                <div class="card mt-4">
                    <div class="card-body">
                        <div class="row mb-1">
                            <div class="col text-center">
                                <h4>Author List</h4>
                            </div>
                        </div>
                        <div class="row mb-1">
                            <div class="col">
                                <hr>
                            </div>
                        </div>
                        <div class="row mb-1">
                            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:elibraryDBhosted %>" ProviderName="<%$ ConnectionStrings:elibraryDBhosted.ProviderName %>" SelectCommand="SELECT * FROM [author_master_tbl]"></asp:SqlDataSource>
                            <div class="col">
                                <asp:GridView CssClass="table table-striped table-bordered" ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="author_id" DataSourceID="SqlDataSource1">
                                    <Columns>
                                        <asp:BoundField DataField="author_id" HeaderText="Author ID" ReadOnly="True" SortExpression="author_id" />
                                        <asp:BoundField DataField="author_name" HeaderText="Author Name" SortExpression="author_name" />
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