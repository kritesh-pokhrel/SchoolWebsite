using System.Xml.Linq;
using Microsoft.EntityFrameworkCore;
using SchoolWebsite.Data;
using SchoolWebsite.Services;

namespace SchoolWebsite
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            string? ReadWebsiteDbConnectionString()
            {
                var configPath = Path.Combine(builder.Environment.ContentRootPath, "web.config");
                if (!File.Exists(configPath))
                {
                    return null;
                }

                var document = XDocument.Load(configPath);
                return document.Root?
                    .Element("connectionStrings")?
                    .Elements("add")
                    .FirstOrDefault(e => string.Equals((string?)e.Attribute("name"), "WebsiteDb", StringComparison.OrdinalIgnoreCase))
                    ?.Attribute("connectionString")?.Value;
            }

            // EF Core DbContext (SQL Server) and DB-backed content service
            var connectionString = ReadWebsiteDbConnectionString()
                ?? builder.Configuration.GetConnectionString("WebsiteDb")
                ?? builder.Configuration["connectionStrings:WebsiteDb"];

            if (string.IsNullOrWhiteSpace(connectionString))
            {
                throw new InvalidOperationException("Connection string 'WebsiteDb' was not found. Check web.config.");
            }

            builder.Services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(connectionString));
            builder.Services.AddScoped<IContentService, DbContentService>();

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
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}")
                .WithStaticAssets();

            // Ensure database exists and seed default content
            using (var scope = app.Services.CreateScope())
            {
                var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
                db.Database.EnsureCreated();

                if (!db.Contents.Any(c => c.Slug == "about"))
                {
                    db.Contents.Add(new SchoolWebsite.Models.ContentItem
                    {
                        Slug = "about",
                        Title = "About GEMS",
                        BodyHtml = "<p>GEMS SCHOOL is a premier educational institution dedicated to providing excellence in education. We believe in nurturing young minds and preparing them for a bright future.</p><p>Our commitment to academic excellence, combined with a focus on holistic development, ensures that every student reaches their full potential.</p>",
                        UpdatedAt = DateTime.UtcNow
                    });
                    db.SaveChanges();
                }
            }

            app.Run();
        }
    }
}
