using Autofac.Integration.Web;
using Autofac;
using System;
using LibraryManagementApp.services;

namespace LibraryManagementApp
{
    public class Global : System.Web.HttpApplication, IContainerProviderAccessor
    {
        // Provider that holds the application container.
        static IContainerProvider _containerProvider;

        // Instance property that will be used by Autofac HttpModules // to resolve and inject dependencies.
        public IContainerProvider ContainerProvider
        {
            get { return _containerProvider; }
        }

        protected void Application_Start(object sender, EventArgs e)
        {
            var builder = new ContainerBuilder();

            // Register your service here
            builder.RegisterType<AuthenticationService>().AsSelf().InstancePerRequest();
            builder.RegisterType<AuthorService>().AsSelf().InstancePerRequest();
            builder.RegisterType<BookIssuingService>().AsSelf().InstancePerRequest();
            builder.RegisterType<BookService>().AsSelf().InstancePerRequest();
            builder.RegisterType<MemberService>().AsSelf().InstancePerRequest();
            builder.RegisterType<PublisherService>().AsSelf().InstancePerRequest();
            builder.RegisterType<UserService>().AsSelf().InstancePerRequest();

            // Register your Web Forms pages
            builder.RegisterType<AdminAuthorManagement>().PropertiesAutowired();
            builder.RegisterType<AdminBookInventory>().PropertiesAutowired();
            builder.RegisterType<AdminBookIssuing>().PropertiesAutowired();
            builder.RegisterType<AdminLogin>().PropertiesAutowired();
            builder.RegisterType<AdminMemberManagement>().PropertiesAutowired();
            builder.RegisterType<AdminPublisherManagement>().PropertiesAutowired();
            builder.RegisterType<UserLogin>().PropertiesAutowired();
            builder.RegisterType<UserProfile>().PropertiesAutowired();
            builder.RegisterType<UserSignUp>().PropertiesAutowired();

            // Build the container
            var container = builder.Build();

            // Set the provider
            _containerProvider = new ContainerProvider(container);
        }
    }
}