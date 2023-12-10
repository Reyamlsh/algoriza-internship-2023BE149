
using Core.Service;
using Core.Repository;
using Repository;
using Service;
using Core.Domain;
using Microsoft.EntityFrameworkCore;
using Web.Models;

namespace Web
{
    public class Startup
    {
        private IConfiguration _config;

        public Startup(IConfiguration config)
        {
            _config = config;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContextPool<ApplicationDbContext>(options => options.UseSqlServer(_config.GetConnectionString("DbConnection")));
            services.AddMvc(options => options.EnableEndpointRouting = false);

            //**********************************************************
            services.AddScoped<IDoctorService, SQLDoctorService>();
            services.AddScoped<IPatientService, SQLPatientService>();
            services.AddScoped<IAppointmentService, SQLAppointmentService>();
            services.AddScoped<ISpecializationService, SQLSpecializationService>();
            services.AddScoped<IAdminService, SQLAdminService>();
            services.AddScoped<IUserService, SQLUserService>();
            services.AddScoped<IDiscountService, SQLDiscountService>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if(env.IsDevelopment()) 
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();
            app.UseMvcWithDefaultRoute();

            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("Hello from the other side");
            });
        }
    }
    
}
