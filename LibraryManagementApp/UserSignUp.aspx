﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Library.Master" AutoEventWireup="true" CodeBehind="UserSignUp.aspx.cs" Inherits="LibraryManagementApp.UserSignUp" %>
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
                                        <asp:ListItem Text="Vinnytsia" Value="vinnytsia" />
                                        <asp:ListItem Text="Volyn" Value="volyn" />
                                        <asp:ListItem Text="Dnipropetrovsk" Value="dnipropetrovsk" />
                                        <asp:ListItem Text="Donetsk" Value="donetsk" />
                                        <asp:ListItem Text="Zhytomyr" Value="zhytomyr" />
                                        <asp:ListItem Text="Zakarpattia" Value="zakarpattia" />
                                        <asp:ListItem Text="Zaporizhzhia" Value="zaporizhzhia" />
                                        <asp:ListItem Text="Ivano-Frankivsk" Value="ivano-frankivsk" />
                                        <asp:ListItem Text="Kyiv" Value="kyiv" />
                                        <asp:ListItem Text="Kirovohrad" Value="kirovohrad" />
                                        <asp:ListItem Text="Luhansk" Value="luhansk" />
                                        <asp:ListItem Text="Lviv" Value="lviv" />
                                        <asp:ListItem Text="Mykolaiv" Value="mykolaiv" />
                                        <asp:ListItem Text="Odesa" Value="odesa" />
                                        <asp:ListItem Text="Poltava" Value="poltava" />
                                        <asp:ListItem Text="Rivne" Value="rivne" />
                                        <asp:ListItem Text="Sumy" Value="sumy" />
                                        <asp:ListItem Text="Ternopil" Value="ternopil" />
                                        <asp:ListItem Text="Kharkiv" Value="kharkiv" />
                                        <asp:ListItem Text="Kherson" Value="kherson" />
                                        <asp:ListItem Text="Khmelnytskyi" Value="khmelnytskyi" />
                                        <asp:ListItem Text="Cherkasy" Value="cherkasy" />
                                        <asp:ListItem Text="Chernivtsi" Value="chernivtsi" />
                                        <asp:ListItem Text="Chernihiv" Value="chernihiv" />
                                        <asp:ListItem Text="Kyiv City" Value="kyiv-city" />
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
                                <label>User ID</label>
                                <div class="form-group">
                                    <asp:TextBox ID="TextBox8" CssClass="form-control" placeholder="User  ID" runat="server"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBox8" ErrorMessage="User  ID is required." CssClass="text-danger" Display="Dynamic" />
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