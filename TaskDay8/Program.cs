using Microsoft.EntityFrameworkCore;
using TaskDay8.Models;
using TaskDay8.Repository;

namespace TaskDay8
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            builder.Services.AddDbContext<AppDbContext>(option =>
            option.UseSqlServer(builder.Configuration.GetConnectionString("MyDataBase")));

            builder.Services.AddScoped<ICourseRepo, CourseRepo>();
            builder.Services.AddScoped<ITrackRepo, TrackRepo>();
            builder.Services.AddScoped<ITraineeRepo, TraineeRepo>();


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
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
