using solfagito_learn.Repository.Implementation;
using solfagito_learn.Repository.Interface;
using solfagito_learn.Services.Implementation;
using solfagito_learn.Services.Interface;

namespace solfagito_learn.Data
{
    public static class Registerations
    {
        public static IServiceCollection AllServices(this IServiceCollection services, IConfiguration configuration) 
        {
            services.AddAuthentication("CookieAuth").AddCookie("CookieAuth", options =>
            {
                options.Cookie.Name = "CookieAuth";
                options.LoginPath = "/Auth/login";
                options.LogoutPath = "/Auth/AcessDenied";
                options.ExpireTimeSpan = TimeSpan.FromDays(5);
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
            });



            /* Repository */
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<ILoginRepository, LoginRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();

            /* Services */
            services.AddScoped<IUserServices,UserServices>();
            services.AddScoped<ILoginServices, LoginServices>();
            services.AddScoped<IProductServices, ProductServices>();

            return services;
        }
    }
}
