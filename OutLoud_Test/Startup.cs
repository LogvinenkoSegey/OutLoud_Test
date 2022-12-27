using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using OutLoud_Test.BusinessLogic.Services;
using OutLoud_Test.BusinessLogic.Services.Interfaces;
using OutLoud_Test.DataAccess;
using OutLoud_Test.DataAccess.Entities;
using OutLoud_Test.DataAccess.Repositories;
using OutLoud_Test.DataAccess.Repositories.Interfaces;
using System.Text;

namespace OutLoud_Test
{
    public class Startup
    {
        public Startup(IConfiguration configuration) => 
            Configuration = configuration;

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IFeedService, FeedService>();
            services.AddScoped<INewsService, NewsService>();

            services.AddScoped<IFeedRepository, FeedRepository>();
            services.AddScoped<INewsRepository, NewsRepository>();

            services.AddRazorPages();
            services.AddControllersWithViews();

            services.AddDbContext<AppDbContext>(o => o.UseSqlServer(Configuration.GetConnectionString("NewsDatabase")));

            services.Configure<ApplicationSettings>(Configuration.GetSection("ApplicationSettings"));
            var appSettingsSections = Configuration.GetSection("ApplicationSettings");
            services.Configure<ApplicationSettings>(appSettingsSections);

            var appSettings = appSettingsSections.Get<ApplicationSettings>();
            var key = Encoding.ASCII.GetBytes(appSettings.Secret);
            services.AddScoped<ApplicationSettings>();

            services.AddCors(options =>
            {
                options.AddPolicy("AllowAllOrigin", builder => builder.AllowAnyOrigin());
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
            });
        }
    }
}
