using BelajarDotNet.Models;

namespace BelajarDotNet.Models.ModelBinding
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews(options =>
            {
                options.ModelBinderProviders.Insert(1, new DateRangeModelBinderProvider());
            });

            builder.Services.AddRouting(options =>
            {
                options.ConstraintMap.Add("alphanumeric", typeof(AlphaNumericConstraint));
            });


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseRouting();

            app.UseAuthorization();

            app.MapStaticAssets();

            // Conentional Routing

            // /Student/Index , /Student/Details/int
            //app.MapControllerRoute(
            //    name: "CustomRouteConventional",
            //    pattern: "{controller=Home}/{action=Index}/{id:int?}"
            //    );

            // /Student/Details/adj66sds
            //app.MapControllerRoute(
            //    name: "CustomRouteConventional",
            //    pattern: "{controller=Home}/{action=Index}/{id:alphanumeric?}"
            //    );

            //app.MapControllerRoute(
            //   name: "StudentAll",
            //    pattern: "Student/All",
            //    defaults: new { controller = "Student", action = "Index" })
            //    .WithStaticAssets();

            //app.MapControllerRoute(
            //   name: "StudentIndex",
            //    pattern: "StudentDetails/{ID}",
            //    defaults: new { controller = "Student", action = "Details" })
            //    .WithStaticAssets();

            //app.MapControllerRoute(
            //    name: "default",
            //    pattern: "{controller=Home}/{action=Index}/{id:int?}",
            //    defaults:new {controller="Home", action="Index"})
            //    .WithStaticAssets();


            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}")
                .WithStaticAssets();

            app.Run();
        }
    }
}
