<%@ Page Title="" Language="C#" MasterPageFile="~/Library.Master" AutoEventWireup="true" CodeBehind="UserSignUp.aspx.cs" Inherits="LibraryManagementApp.UserSignUp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="row">
            <div class="col-md-8 mx-auto">
                <div class="card">
                    <div class="card-body">
                        <div class="row">
                            <div class="col">
                                <center>
                                    <img src="assets/imgs/generaluser.png" style="width:150px" />
                                </center>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col">
                                <center>
                                    <h4>Member Sign Up</h4>
                                </center>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col">
                                <hr />
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-6">
                                <label>Full Name</label>
                                <div class="form-group">
                                    <asp:TextBox ID="TextBox1" CssClass="form-control" placeholder="Full Name" runat="server"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="rfvFullName" runat="server" ControlToValidate="TextBox1" ErrorMessage="Full Name is required." CssClass="text-danger" Display="Dynamic" />
                                </div>
                            </div>
                            <div class="col-md-6">
                                <label>Date of Birth</label>
                                <div class="form-group">
                                    <asp:TextBox ID="TextBox2" CssClass="form-control" placeholder="Date of Birth" TextMode="Date" runat="server"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="rfvDOB" runat="server" ControlToValidate="TextBox2" ErrorMessage="Date of Birth is required." CssClass="text-danger" Display="Dynamic" />
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-6">
                                <label>Contact №</label>
                                <div class="form-group">
                                    <asp:TextBox ID="TextBox3" CssClass="form-control" placeholder="Contact №" runat="server" TextMode="Number"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="rfvContact" runat="server" ControlToValidate="TextBox3" ErrorMessage="Contact № is required." CssClass="text-danger" Display="Dynamic" />
                                    <asp:RegularExpressionValidator ID="revContact" runat="server" ControlToValidate="TextBox3" ErrorMessage="Invalid contact number." ValidationExpression="^\d{10}$" CssClass="text-danger" Display="Dynamic" />
                                </div>
                            </div>
                            <div class="col-md-6">
                                <label>Email ID</label>
                                <div class="form-group">
                                    <asp:TextBox ID="TextBox4" CssClass="form-control" placeholder="Email ID" TextMode="Email" runat="server"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="rfvEmail" runat="server" ControlToValidate="TextBox4" ErrorMessage="Email ID is required." CssClass="text-danger" Display="Dynamic" />
                                    <asp:RegularExpressionValidator ID="revEmail" runat="server" ControlToValidate="TextBox4" ErrorMessage="Invalid email format." ValidationExpression="^[^@\s]+@[^@\s]+\.[^@\s]+$" CssClass="text-danger" Display="Dynamic" />
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-4">
                                <label>State</label>
                                <div class="form-group">
                                    <asp:DropDownList ID="DropDownList1" CssClass="form-control" runat="server">
                                        <asp:ListItem Text="Select" Value="select" />
                                        <asp:ListItem Text="Vinnytsia" Value="Vinnytsia" />
                                        <asp:ListItem Text="Volyn" Value="Volyn" />
                                        <asp:ListItem Text="Dnipropetrovsk" Value="Dnipropetrovsk" />
                                        <asp:ListItem Text="Donetsk" Value="Donetsk" />
                                        <asp:ListItem Text="Zhytomyr" Value="Zhytomyr" />
                                        <asp:ListItem Text="Zakarpattia" Value="Zakarpattia" />
                                        <asp:ListItem Text="Zaporizhzhia" Value="Zaporizhzhia" />
                                        <asp:ListItem Text="Ivano-Frankivsk" Value="Ivano-Frankivsk" />
                                        <asp:ListItem Text="Kyiv" Value="Kyiv" />
                                        <asp:ListItem Text="Kirovohrad" Value="Kirovohrad" />
                                        <asp:ListItem Text="Luhansk" Value="Luhansk" />
                                        <asp:ListItem Text="Lviv" Value="Lviv" />
                                        <asp:ListItem Text="Mykolaiv" Value="Mykolaiv" />
                                        <asp:ListItem Text="Odesa" Value="Odesa" />
                                        <asp:ListItem Text="Poltava" Value="Poltava" />
                                        <asp:ListItem Text="Rivne" Value="Rivne" />
                                        <asp:ListItem Text="Sumy" Value="Sumy" />
                                        <asp:ListItem Text="Ternopil" Value="Ternopil" />
                                        <asp:ListItem Text="Kharkiv" Value="Kharkiv" />
                                        <asp:ListItem Text="Kherson" Value="Kherson" />
                                        <asp:ListItem Text="Khmelnytskyi" Value="Khmelnytskyi" />
                                        <asp:ListItem Text="Cherkasy" Value="Cherkasy" />
                                        <asp:ListItem Text="Chernivtsi" Value="Chernivtsi" />
                                        <asp:ListItem Text="Chernihiv" Value="Chernihiv" />
                                        <asp:ListItem Text="Kyiv City" Value="Kyiv-city" />
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="rfvState" runat="server" ControlToValidate="DropDownList1" InitialValue="select" ErrorMessage="State is required." CssClass="text-danger" Display="Dynamic" />
                                </div>
                            </div>
                            <div class="col-md-4">
                                <label>City</label>
                                <div class="form-group">
                                    <asp:TextBox ID="TextBox6" CssClass="form-control" placeholder="City" runat="server"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="rfvCity" runat="server" ControlToValidate="TextBox6" ErrorMessage="City is required." CssClass="text-danger" Display="Dynamic" />
                                </div>
                            </div>
                            <div class="col-md-4">
                                <label>Pincode</label>
                                <div class="form-group">
                                    <asp:TextBox ID="TextBox7" CssClass="form-control" placeholder="Pincode" TextMode="Number" runat="server"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="rfvPincode" runat="server" ControlToValidate="TextBox7" ErrorMessage="Pincode is required." CssClass="text-danger" Display="Dynamic" />
                                    <asp:RegularExpressionValidator ID="revPincode" runat="server" ControlToValidate="TextBox7" ErrorMessage="Invalid pincode." ValidationExpression="^\d{6}$" CssClass="text-danger" Display="Dynamic" />
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col">
                                <label>Full Address</label>
                                <div class="form-group">
                                    <asp:TextBox ID="TextBox5" CssClass="form-control" placeholder="Full Address" runat="server" TextMode="Multiline"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="rfvAddress" runat="server" ControlToValidate="TextBox5" ErrorMessage="Full Address is required." CssClass="text-danger" Display="Dynamic" />
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col">
                                <center>
                                    <div class="form-group text-center">
                                        <span class="badge rounded-pill text-bg-info">Login Credentials</span>
                                    </div>
                                </center>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-6">
                                <label>User Name</label>
                                <div class="form-group">
                                    <asp:TextBox ID="TextBox8" CssClass="form-control" placeholder="User Name" runat="server"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBox8" ErrorMessage="User Name is required." CssClass="text-danger" Display="Dynamic" />
                                </div>
                            </div>
                            <div class="col-md-6">
                                <label>Password</label>
                                <div class="form-group">
                                    <asp:TextBox ID="TextBox9" CssClass="form-control" placeholder="Password" TextMode="Password" runat="server"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="rfvPassword" runat="server" ControlToValidate="TextBox9" ErrorMessage="Password is required." CssClass="text-danger" Display="Dynamic" />
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col">
                                <div class="form-group text-center">
                                    <asp:Button ID="Button1" class="btn btn-success btn-block btn-lg" runat="server" Text="Sign Up" OnClick="Button1_Click" />
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <a href="Home.aspx"><< Back to Home</a>
            </div>
        </div>
    </div>
</asp:Content>