<%@ Page Title="" Language="C#" MasterPageFile="~/Library.Master" AutoEventWireup="true" CodeBehind="AdminBookInventory.aspx.cs" Inherits="LibraryManagementApp.AdminBookInventory" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css" rel="stylesheet">
    <script type="text/javascript">
        $(document).ready(function () {
            $('.table').prepend($('<thead></thead>').append($(this).find('tr:first'))).dataTable();
        });

        function readURL(input) {
            if (input.files && input.files[0]) {
                var reader = new FileReader();
                reader.onload = function (e) {
                    $('#imgview').attr('src', e.target.result);
                };
                reader.readAsDataURL(input.files[0]);
            }
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid">
        <div class="row">
            <div class="col-md-5">
                <div class="card">
                    <div class="card-body">
                        <div class="row mb-1">
                            <div class="col text-center">
                                <h4>Book Details</h4>
                            </div>
                        </div>
                        <div class="row mb-1">
                            <div class="col text-center">
                                <img id="imgview" src="book_inventory/books.png" style="width:100px; height:150px;" class="mb-3" />
                            </div>
                        </div>
                        <div class="row mb-1">
                            <div class="col">
                                <hr>
                            </div>
                        </div>
                        <div class="row mb-1">
                            <div class="col">
                                <asp:FileUpload ID="FileUpload1" CssClass="form-control" runat="server" onchange="readURL(this);" />
                            </div>
                        </div>
                        <div class="row mb-1">
                            <div class="col-md-4">
                                <label>Book ID</label>
                                <div class="form-group">
                                    <div class="input-group">
                                        <asp:TextBox ID="TextBox1" CssClass="form-control" runat="server" placeholder="Book ID"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="rfvBookID" runat="server" ControlToValidate="TextBox1" ErrorMessage="Book ID is required." CssClass="text-danger" Display="Dynamic" />
                                        <asp:RegularExpressionValidator ID="revBookID" runat="server" ControlToValidate="TextBox1" ErrorMessage="Invalid Book ID format." ValidationExpression="^\d+$" CssClass="text-danger" Display="Dynamic" />
                                        <asp:Button ID="Button4" runat="server" Text="Go" CssClass="form-control btn btn-primary" OnClick="Button4_Click" CausesValidation="false" />
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-8">
                                <label>Book Name</label>
                                <div class="form-group">
                                    <asp:TextBox ID="TextBox2" CssClass="form-control" placeholder="Book Name" runat="server"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="rfvBookName" runat="server" ControlToValidate="TextBox2" ErrorMessage="Book Name is required." CssClass="text-danger" Display="Dynamic" />
                                </div>
                            </div>
                        </div>
                        <div class="row mb-1">
                            <div class="col-md-4">
                                <label>Language</label>
                                <div class="form-group">
                                    <asp:DropDownList ID="DropDownList1" CssClass="form-control" runat="server">
                                        <asp:ListItem Text="Ukrainian" Value="uk"></asp:ListItem>
                                        <asp:ListItem Text="English" Value="en"></asp:ListItem>
                                        <asp:ListItem Text="Spanish" Value="es"></asp:ListItem>
                                        <asp:ListItem Text="French" Value="fr"></asp:ListItem>
                                        <asp:ListItem Text="German" Value="de"></asp:ListItem>
                                        <asp:ListItem Text="Italian" Value="it"></asp:ListItem>
                                        <asp:ListItem Text="Polish" Value="pl"></asp:ListItem>
                                        <asp:ListItem Text="Russian" Value="ru"></asp:ListItem>
                                        <asp:ListItem Text="Chinese" Value="zh"></asp:ListItem>
                                        <asp:ListItem Text="Japanese" Value="ja"></asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                                <label>Publisher Name</label>
                                <div class="form-group">
                                    <asp:DropDownList ID="DropDownList2" CssClass="form-control" runat="server">
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <label>Author Name</label>
                                <div class="form-group">
                                    <asp:DropDownList ID="DropDownList3" CssClass="form-control" runat="server">
                                    </asp:DropDownList>
                                </div>
                                <label>Publish Date</label>
                                <div class="form-group">
                                    <asp:TextBox ID="TextBox3" CssClass="form-control" placeholder="Date" runat="server" TextMode="Date"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-4">
                            <label>Genre</label>
                            <div class="form-group">
                                <asp:ListBox ID="ListBox1" runat="server" SelectionMode="Multiple" CssClass="form-control">
                                    <asp:ListItem Text="Fantasy" Value="Fantasy" />
                                    <asp:ListItem Text="Science Fiction" Value="Science Fiction" />
                                    <asp:ListItem Text="Mystery" Value="Mystery" />
                                    <asp:ListItem Text="Romance" Value="Romance" />
                                    <asp:ListItem Text="Thriller" Value="Thriller" />
                                    <asp:ListItem Text="Historical" Value="Historical" />
                                    <asp:ListItem Text="Horror" Value="Horror" />
                                    <asp:ListItem Text="Adventure" Value="Adventure" />
                                    <asp:ListItem Text="Drama" Value="Drama" />
                                    <asp:ListItem Text="Poetry" Value="Poetry" />
                                    <asp:ListItem Text="Non-Fiction" Value="Non-Fiction" />
                                    <asp:ListItem Text="Biography" Value="Biography" />
                                    <asp:ListItem Text="Self-Help" Value="Self-Help" />
                                    <asp:ListItem Text="Young Adult" Value="Young Adult" />
                                    <asp:ListItem Text="Children's" Value="Children's" />
                                </asp:ListBox>
                            </div>
                        </div>
                        </div>
                        <div class="row mb-1">
                            <div class="col-md-4">
                                <label>Edition</label>
                                <div class="form-group">
                                    <asp:TextBox ID="TextBox9" CssClass="form-control" placeholder="Edition" runat="server"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <label>Book Cost (Per Unit)</label>
                                <div class="form-group">
                                    <asp:TextBox ID="TextBox10" CssClass="form-control" placeholder="Book Cost (Per Unit)" runat="server" TextMode="Number"></asp:TextBox>
                                    <asp:RangeValidator ID="rvBookCost" runat="server" ControlToValidate="TextBox10" ErrorMessage="Enter a valid cost." MinimumValue="0" MaximumValue="10000" Type="Double" CssClass="text-danger" Display="Dynamic" />
                                </div>
                            </div>
                            <div class="col-md-4">
                                <label>Pages</label>
                                <div class="form-group">
                                    <asp:TextBox ID="TextBox11" CssClass="form-control" placeholder="Pages" runat="server" TextMode="Number"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="row mb-1">
                            <div class="col-md-4">
                                <label>Actual Stock</label>
                                <div class="form-group">
                                    <asp:TextBox ID="TextBox4" CssClass="form-control" placeholder="Actual Stock" runat="server" TextMode="Number"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <label>Current Stock</label>
                                <div class="form-group">
                                    <asp:TextBox ID="TextBox5" CssClass="form-control" placeholder="Current Stock" runat="server" TextMode="Number"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <label>Issued Books</label>
                                <div class="form-group">
                                    <asp:TextBox ID="TextBox7" CssClass="form-control" placeholder="Issued Books" runat="server" TextMode="Number"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="row mb-1">
                            <div class="col-12">
                                <label>Book Description</label>
                                <div class="form-group">
                                    <asp:TextBox ID="TextBox6" CssClass="form-control" placeholder="Book Description" runat="server" TextMode="Multiline" Rows="2"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="row mb-1">
                            <div class="col-4">
                                <asp:Button ID="Button2" runat="server" Text="Add" class="btn btn-lg btn-block btn-success" OnClick="Button2_Click" />
                            </div>
                            <div class="col-4">
                                <asp:Button ID="Button3" runat="server" Text="Update" class="btn btn-lg btn-block btn-warning" OnClick="Button3_Click" />
                            </div>
                            <div class="col-4">
                                <asp:Button ID="Button1" runat="server" Text="Delete" class="btn btn-lg btn-block btn-danger" OnClick="Button1_Click" />
                            </div>
                        </div>
                    </div>
                </div>
                <a href="Home.aspx" class="d-block text-center mt-3 mb-3"><< Back to Home</a>
            </div>
            <div class="col-md-7">
                <div class="card mt-4">
                    <div class="card-body">
                        <div class="row mb-1">
                            <div class="col text-center">
                                <h4>Book Inventory List</h4>
                            </div>
                        </div>
                        <div class="row mb-1">
                            <div class="col">
                                <hr>
                            </div>
                        </div>
                        <div class="row mb-1">
                            <div class="col">
                                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:elibraryDBhosted %>" SelectCommand="SELECT * FROM [book_master_tbl]"></asp:SqlDataSource>
                                <asp:GridView CssClass="table table-striped table-bordered" ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="book_id" DataSourceID="SqlDataSource1">
                                    <Columns>
                                        <asp:BoundField DataField="book_id" HeaderText="ID" ReadOnly="True" SortExpression="book_id">
                                            <ControlStyle Font-Bold="True" />
                                        </asp:BoundField>
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <div class="container-fluid">
                                                    <div class="row">
                                                        <div class="col-lg-10">
                                                            <div class="row">
                                                                <div class="col-12">
                                                                    <asp:Label ID="Label1" runat="server" Text='<%# Eval("book_name") %>' Font-Bold="True" Font-Size="X-Large"></asp:Label>
                                                                </div>
                                                            </div>
                                                            <div class="row">
                                                                <div class="col-12">
                                                                    Author -
                                                                    <asp:Label ID="Label2" runat="server" Font-Bold="True" Text='<%# Eval("author_name") %>'></asp:Label>
                                                                    &nbsp;| Genre -
                                                                    <asp:Label ID="Label3" runat="server" Font-Bold="True" Text='<%# Eval("genre") %>'></asp:Label>
                                                                    &nbsp;| Language -
                                                                    <asp:Label ID="Label4" runat="server" Font-Bold="True" Text='<%# Eval("language") %>'></asp:Label>
                                                                </div>
                                                            </div>
                                                            <div class="row">
                                                                <div class="col-12">
                                                                    Publisher -
                                                                    <asp:Label ID="Label5" runat="server" Font-Bold="True" Text='<%# Eval("publisher_name") %>'></asp:Label>
                                                                    &nbsp;| Publish Date -
                                                                    <asp:Label ID="Label6" runat="server" Font-Bold="True" Text='<%# Eval("publish_date") %>'></asp:Label>
                                                                    &nbsp;| Pages -
                                                                    <asp:Label ID="Label7" runat="server" Font-Bold="True" Text='<%# Eval("no_of_pages") %>'></asp:Label>
                                                                    &nbsp;| Edition -
                                                                    <asp:Label ID="Label8" runat="server" Font-Bold="True" Text='<%# Eval("edition") %>'></asp:Label>
                                                                </div>
                                                            </div>
                                                            <div class="row">
                                                                <div class="col-12">
                                                                    Cost -
                                                                    <asp:Label ID="Label9" runat="server" Font-Bold="True" Text='<%# Eval("book_cost") %>'></asp:Label>
                                                                    &nbsp;| Actual Stock -
                                                                    <asp:Label ID="Label10" runat="server" Font-Bold="True" Text='<%# Eval("actual_stock") %>'></asp:Label>
                                                                    &nbsp;| Available Stock -
                                                                    <asp:Label ID="Label11" runat="server" Font-Bold="True" Text='<%# Eval("current_stock") %>'></asp:Label>
                                                                </div>
                                                            </div>
                                                            <div class="row">
                                                                <div class="col-12">
                                                                    Description -
                                                                    <asp:Label ID="Label12" runat="server" Font-Bold="True" Font-Size="Smaller" Text='<%# Eval("book_description") %>'></asp:Label>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="col-lg-2">
                                                            <asp:Image CssClass="img-fluid p-2" ID="Image1" runat="server" ImageUrl='<%# Eval("book_img_link") %>' />
                                                        </div>
                                                    </div>
                                                </div>
                                            </ItemTemplate>
                                        </asp:TemplateField>
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
