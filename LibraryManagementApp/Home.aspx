<%@ Page Title="" Language="C#" MasterPageFile="~/Library.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="LibraryManagementApp.Home" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css" rel="stylesheet">
    <style>
        .footerlinks {
            color: #ffffff;
            text-decoration: none !important;
        }

        .footerlinks:hover {
            color: #ffd800;
        }

        #footer1, #footer2 {
            background: #762b00;
        }

        @media (max-width: 768px) {
            .container {
                padding: 0 15px;
            }

            .col-md-4 {
                margin-bottom: 20px;
            }

            img {
                width: 100%;
                height: auto;
            }

            h2, h4, p {
                text-align: center;
            }
        }

        .img-fluid {
            max-width: 100%;
            height: auto;
        }

        .info-img-fluid {
            max-width: 60%;
            height: auto;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section>
        <img src="assets/imgs/home-bg.jpg" class="img-fluid"/>
    </section>
    <section>
        <div class="container">
            <div class="row">
                <div class="col-12">
                    <center>
                        <h2>Our Features</h2>
                        <p><b>Our 3 Primary Features</b></p>
                    </center>
                </div>
            </div>
            <div class="row d-flex flex-row">
                <div class="col-12 col-md-4">
                    <center>
                        <img src="assets/imgs/digital-inventory.png" class="info-img-fluid" />
                        <h4>Digital Book Inventory</h4>
                        <p class="text-center">Our library offers a comprehensive digital inventory of books, allowing you to browse and reserve titles from the comfort of your home. Stay updated with the latest additions and manage your reading list easily.</p>
                    </center>
                </div>
                <div class="col-12 col-md-4">
                    <center>
                        <img src="assets/imgs/search-online.png" class="info-img-fluid" />
                        <h4>Search Books</h4>
                        <p class="text-center">With our advanced search feature, finding your next read is a breeze. Search by title, author, or genre to discover a wide range of books available in our collection.</p>
                    </center>
                </div>
                <div class="col-12 col-md-4">
                    <center>
                        <img src="assets/imgs/defaulters-list.png" class="info-img-fluid" />
                        <h4>Defaulter List</h4>
                        <p class="text-center">Stay informed with our defaulter list feature, which helps you keep track of overdue books and manage your borrowing history to avoid penalties.</p>
                    </center>
                </div>
            </div>
        </div>
    </section>
    <section>
        <img src="assets/imgs/in-homepage-banner.jpg" class="img-fluid"/>
    </section>
    <section>
        <div class="container">
            <div class="row">
                <div class="col-12">
                    <center>
                        <h2>Our Process</h2>
                        <p><b>We have a Simple 3 Step Process</b></p>
                    </center>
                </div>
            </div>
            <div class="row d-flex flex-row">
                <div class="col-12 col-md-4">
                    <center>
                        <img src="assets/imgs/sign-up.png" class="info-img-fluid" />
                        <h4>Sign Up</h4>
                        <p class="text-center">Join our library community by signing up online. It's quick and easy, giving you access to our vast collection of resources and services.</p>
                    </center>
                </div>
                <div class="col-12 col-md-4">
                    <center>
                        <img src="assets/imgs/search-online.png" class="info-img-fluid" />
                        <h4>Search Books</h4>
                        <p class="text-center">Explore our extensive catalog to find the books you love. Use our search tools to locate specific titles or discover new favorites.</p>
                    </center>
                </div>
                <div class="col-12 col-md-4">
                    <center>
                        <img src="assets/imgs/library.png" class="info-img-fluid" />
                        <h4>Visit Us</h4>
                        <p class="text-center">Visit our library to enjoy a quiet reading environment, access additional resources, and participate in community events and workshops.</p>
                    </center>
                </div>
            </div>
        </div>
    </section>
</asp:Content>
