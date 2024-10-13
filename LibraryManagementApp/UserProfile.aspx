﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Library.Master" AutoEventWireup="true" CodeBehind="UserProfile.aspx.cs" Inherits="LibraryManagementApp.UserProfile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        $(document).ready(function () {
            $('.table').prepend($('<thead></thead>').append($(this).find('tr:first'))).dataTable();
        })
    </script>
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
                                    <img src="assets/imgs/generaluser.png" style="width:150px" />
                                </center>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col">
                                <center>
                                    <h4>Your Profile</h4>
                                    <span>Account Status - </span>
                                    <asp:Label ID="Label1" CssClass="badge rounded-pill text-bg-info text-white" runat="server" Text="Status"></asp:Label>
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
                                        <span class="badge rounded-pill text-bg-info text-white">Login Credentials</span>
                                    </div>
                                </center>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-4">
                                <label>User ID</label>
                                <div class="form-group">
                                    <asp:TextBox ID="TextBox8" CssClass="form-control" placeholder="User ID" runat="server" ReadOnly="true"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <label>Old Password</label>
                                <div class="form-group">
                                    <asp:TextBox ID="TextBox9" CssClass="form-control" placeholder="Old Password" TextMode="Password" runat="server" ReadOnly="true"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <label>New Password</label>
                                <div class="form-group">
                                    <asp:TextBox ID="TextBox10" CssClass="form-control" placeholder="New Password" TextMode="Password" runat="server"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-8 mx-auto">
                                <center>
                                    <div class="form-group">
                                        <asp:Button ID="Button1" class="btn btn-primary btn-block btn-lg" runat="server" Text="Update" OnClick="Button1_Click" />
                                    </div>
                                </center>
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
                                    <img src="assets/imgs/books1.png" style="width:100px"/>
                                </center>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col">
                                <center>
                                    <h4>Your Issued Books</h4>
                                    <asp:Label ID="Label2" CssClass="badge rounded-pill text-bg-info text-white" runat="server" Text="Your Books Info"></asp:Label>
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
                                <asp:GridView CssClass="table table-striped table-bordered" ID="GridView1" runat="server" OnRowDataBound="GridView1_RowDataBound"></asp:GridView>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
