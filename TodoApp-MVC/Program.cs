using Microsoft.EntityFrameworkCore;
using TodoApp.Data;
using Microsoft.Extensions.DependencyInjection;

public class Program
{
    public static void Main(string[] args)
    {
        // Create a new WebApplication instance using the command-line arguments.
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddControllersWithViews();

        // Configure the application to use the SQLite database by adding the ApplicationDbContext to the services.
        builder.Services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

        // Build the application.
        var app = builder.Build();

        // Configure the HTTP request pipeline.

        // If the application is not running in the Development environment, set up the exception handler.
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Home/Error");

            // Enable HTTP Strict Transport Security (HSTS) for secure connections.
            // The default HSTS value is 30 days, but you may want to change this for production scenarios.
            // More information: https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }

        // Redirect HTTP requests to HTTPS if needed.
        app.UseHttpsRedirection();

        // Serve static files (e.g., CSS, JavaScript, images) from the wwwroot folder.
        app.UseStaticFiles();

        // Enable routing to handle incoming HTTP requests and map them to controllers and actions.
        app.UseRouting();

        // Enable authentication and authorization for the application.
        app.UseAuthorization();

        // Map the default controller route, specifying the default controller, action, and optional id parameter.
        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=ToDo}/{action=Index}/{id?}");

        // Start the application, and the request pipeline will be processed to handle incoming requests.
        app.Run();
    }
}
