using Microsoft.Extensions.DependencyInjection;
using LibraryManagementApp.services;

namespace LibraryManagementApp.helpers {

    public static class ServiceProviderConfig
    {
        public static ServiceProvider ServiceProvider { get; private set; }

        public static void Configure()
        {
            var serviceCollection = new ServiceCollection();

            serviceCollection.AddTransient<IUserService, UserService>();
            serviceCollection.AddTransient<IAuthenticationService, AuthenticationService>();
            serviceCollection.AddTransient<IAuthorService, AuthorService>();
            serviceCollection.AddTransient<IBookIssuingService, BookIssuingService>();
            serviceCollection.AddTransient<IBookService, BookService>();
            serviceCollection.AddTransient<IMemberService, MemberService>();
            serviceCollection.AddTransient<IPublisherService, PublisherService>();

            ServiceProvider = serviceCollection.BuildServiceProvider();
        }
    }
}