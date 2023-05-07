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
             services.AddDbContext<CalculadoraContext>(options =>
             options.UseSqlite(_configuration.GetConnectionString("CalculadoraContext")));
             services.AddControllers();
             services.AddScoped<IOperationsRepository, OperationRepository>();
             services.AddScoped<IHistorialRepository, HistorialRepository>();
             services.AddMvc(options => options.EnableEndpointRouting = false);
        }

        public void Configure(IApplicationBuilder app)
        {
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
