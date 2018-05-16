using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using CloudAppCore1.Models;
using Swashbuckle.AspNetCore.Swagger;
using System;

namespace CloudAppCore1
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "My job API", Version = "v1" });
            });
            
            // Use SQL Database if in Azure, otherwise, use SQLite
            
                services.AddDbContext<JobContext>(options =>
                        options.UseSqlite("Data Source=localJobs.db"));

            // Automatically perform database migration
            services.BuildServiceProvider().GetService<JobContext>().Database.Migrate();
            //var connection = @"Server=localJobs.db;Database=EFGetStarted.AspNetCore.NewDb;Trusted_Connection=True;ConnectRetryCount=0";
            //services.AddDbContext<JobContext>(options => options.UseSqlServer(connection));
            //services.AddEntityFrameworkSqlServer()
            //        .AddDbContext<JobContext>(options =>
            //        {
            //            options.UseSqlServer(Configuration["ConnectionString"],
            //                sqlServerOptionsAction: sqlOptions =>
            //                {
            //                    sqlOptions.MigrationsAssembly(typeof(Startup).GetTypeInfo().Assembly.GetName().Name);
            //                    sqlOptions.EnableRetryOnFailure(maxRetryCount: 10, maxRetryDelay: TimeSpan.FromSeconds(30), errorNumbersToAdd: null);
            //                });
            //        });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });

            app.UseMvc();
        }
    }
}
