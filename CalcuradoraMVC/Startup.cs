using CalcuradoraMVC.Data;
using CalcuradoraMVC.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using CalcuradoraMVC.Models;
namespace CalcuradoraMVC
{
    public class Startup
    {
        private IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSession(options =>
            {
                options.Cookie.Name = ".MyApp.Session";
                options.Cookie.HttpOnly = true;
                options.IdleTimeout = TimeSpan.FromMinutes(30);
                options.Cookie.IsEssential = true;
            });

            services.AddMemoryCache();
            services.AddDbContext<CalculadoraContext>(options =>
            options.UseSqlite(_configuration.GetConnectionString("CalculadoraContext")));
            services.AddControllers();
            services.AddHttpContextAccessor();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<ICalculadoraRepository, CalculadoraRepository>();
            services.AddScoped<IHistorialRepository, HistorialRepository>();
            services.AddMvc(options => options.EnableEndpointRouting = false);
        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseSession();
            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "calculadora",
                    template: "{controller}/{action}/{id?}",
                    defaults: new { controller = "Home", action = "Index" },
                    constraints: new { id = "[0-9]+" });
            });
        }
    }
}
