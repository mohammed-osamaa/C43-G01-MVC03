using Demo.BusinessLogicLayer.Profiles;
using Demo.BusinessLogicLayer.Services.DepartmentServices;
using Demo.BusinessLogicLayer.Services.EmployeeServices;
using Demo.DataAccessLayer.Data;
using Demo.DataAccessLayer.Repositories.Classes;
using Demo.DataAccessLayer.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Demo.Presention
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);


            #region Add services to the DI container.
            builder.Services.AddControllersWithViews(options =>
            {
                options.Filters.Add(new AutoValidateAntiforgeryTokenAttribute());
            });
            //builder.Services.AddScoped<ApplicationDbContext>(); // Register to DI Container
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
            {
                //options.UseSqlServer("ConnentionString"); 
                options.UseSqlServer(builder.Configuration.GetConnectionString("Default"));
                // Go to AppSetting.json , Search ConnectionString Scope and Get it By Name (Default) 
                options.UseLazyLoadingProxies();
            });
            
            builder.Services.AddScoped<IDepartmentRepository, DepartmentRepository>();
            builder.Services.AddScoped<IDepartmentServices, DepartmentServices>();
            builder.Services.AddAutoMapper(typeof(MappingProiles).Assembly);
            builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            builder.Services.AddScoped<IEmployeeServices, EmployeeServices>();
            #endregion

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
