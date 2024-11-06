using Microsoft.Extensions.DependencyInjection;
using System;

namespace LibraryManagementApp.helpers
{
    public abstract class DIPage : System.Web.UI.Page
    {
        protected T GetService<T>() where T : class
        {
            return ServiceProviderConfig.ServiceProvider.GetService<T>();
        }

        protected override void OnInit(EventArgs e)
        {
            InjectDependencies();
            base.OnInit(e);
        }

        private void InjectDependencies()
        {
            var properties = GetType().GetProperties();
            foreach (var property in properties)
            {
                if (property.CanWrite && property.PropertyType.IsInterface)
                {
                    var service = ServiceProviderConfig.ServiceProvider.GetService(property.PropertyType);
                    if (service != null)
                    {
                        property.SetValue(this, service);
                    }
                }
            }
        }
    }
}