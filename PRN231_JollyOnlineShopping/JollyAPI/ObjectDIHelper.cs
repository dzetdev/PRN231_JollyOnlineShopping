using JollyAPI.DAO;
using JollyAPI.Service;

namespace JollyAPI
{
    public class ObjectDIHelper
    {
        public static void AddObjectDI(IServiceCollection services)
        {
            // Add DAO
            services.AddScoped<UserDAO>();
            services.AddScoped<WishListDAO>();
            services.AddScoped<CartDAO>();


            // Add Service
            services.AddScoped<UserServices>();

        }
    }
}
