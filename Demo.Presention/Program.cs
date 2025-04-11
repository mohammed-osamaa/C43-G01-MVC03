using Demo.BusinessLogicLayer.Profiles;
using Demo.BusinessLogicLayer.Services.AttachmentServises;
using Demo.BusinessLogicLayer.Services.DepartmentServices;
using Demo.BusinessLogicLayer.Services.EmployeeServices;
using Demo.DataAccessLayer.Data;
using Demo.DataAccessLayer.Models.IdentityModel;
using Demo.DataAccessLayer.Repositories.Classes;
using Demo.DataAccessLayer.Repositories.Interfaces;
using Microsoft.AspNetCore.Identity;
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
            
            builder.Services.AddIdentity<ApplicationUser, IdentityRole>(options =>
            {
                options.Password.RequiredLength = 6;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireNonAlphanumeric = false;
            }).AddEntityFrameworkStores<ApplicationDbContext>();

            //builder.Services.AddScoped<IDepartmentRepository, DepartmentRepository>();
            //builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            builder.Services.AddScoped<IDepartmentServices, DepartmentServices>();
            builder.Services.AddAutoMapper(typeof(MappingProiles).Assembly);
            builder.Services.AddScoped<IEmployeeServices, EmployeeServices>();
            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
            builder.Services.AddScoped<IAttachmentServices, AttachmentServises>();
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

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Account}/{action=Register}/{id?}");

            app.Run();
        }
    }
}
