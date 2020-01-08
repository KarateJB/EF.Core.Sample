using System;
using EFCore.Ap.Utils;
using EFCore.Core.Models;
using EFCore.Dal;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace EFCore.Ap
{
    public class Startup
    {
        private readonly AppSettings appSettings = null;

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            this.appSettings = new AppSettings();
            this.Configuration.Bind(this.appSettings);
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.Configure<AppSettings>(this.Configuration);

            // Inject Entity framework DAL services
            services.AddEntityFrameworkNpgsql().AddDbContext<MyDbContext>(
                options => options.UseNpgsql(this.appSettings.ConnectionStrings.DB, optionsAction =>
                {
                    optionsAction.EnableRetryOnFailure(5, TimeSpan.FromSeconds(10), null);
                }));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.ConfigureDbContextFactory(this.appSettings);

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
