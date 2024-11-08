using LibraryManagementApp.services;
using Microsoft.AspNet.WebFormsDependencyInjection.Unity;
using Unity;
using System;
using System.Web.Routing;

namespace LibraryManagementApp
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {
            var container = this.AddUnity();

            container.RegisterType<IUserService, UserService>();
            container.RegisterType<IAuthenticationService, AuthenticationService>();
            container.RegisterType<IAuthorService, AuthorService>();
            container.RegisterType<IBookIssuingService, BookIssuingService>();
            container.RegisterType<IBookService, BookService>();
            container.RegisterType<IMemberService, MemberService>();
            container.RegisterType<IPublisherService, PublisherService>();

            RegisterRoutes(RouteTable.Routes);
        }

        public static void RegisterRoutes(RouteCollection routeBases)
        {
            routeBases.MapPageRoute("AboutUsRoute", "about-us", "~/AboutUs.aspx");
            routeBases.MapPageRoute("AdminAuthorManagementRoute", "authors", "~/AdminAuthorManagement.aspx");
            routeBases.MapPageRoute("AdminBookInventoryRoute", "book-inventory", "~/AdminBookInventory.aspx");
            routeBases.MapPageRoute("AdminBookIssuingRoute", "book-issuing", "~/AdminBookIssuing.aspx");
            routeBases.MapPageRoute("AdminLoginRoute", "admin-login", "~/AdminLogin.aspx");
            routeBases.MapPageRoute("AdminMemberManagementRoute", "members", "~/AdminMemberManagement.aspx");
            routeBases.MapPageRoute("AdminPublisherManagementRoute", "publishers", "~/AdminPublisherManagement.aspx");
            routeBases.MapPageRoute("HomeRoute", "home", "~/Home.aspx");
            routeBases.MapPageRoute("TermsRoute", "terms", "~/Terms.aspx");
            routeBases.MapPageRoute("UserLoginRoute", "login", "~/UserLogin.aspx");
            routeBases.MapPageRoute("UserProfileRoute", "profile", "~/UserProfile.aspx");
            routeBases.MapPageRoute("UserSignUpRoute", "sign-up", "~/UserSignUp.aspx");
            routeBases.MapPageRoute("ViewBooksRoute", "books", "~/ViewBooks.aspx");
        }
    }
}