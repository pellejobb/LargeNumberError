using System;
using System.IO.Compression;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SnapObjects.Data;
using SnapObjects.Data.AspNetCore;
using DWNet.Data.AspNetCore;
using SnapObjects.Data.Oracle;
using LargeNumberError.Services.Impl;
using LargeNumberError.Services;

namespace LargeNumberError
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc(m =>
            {
                m.UseCoreIntegrated();
                m.UsePowerBuilderIntegrated();
            })
            .SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            // Uncomment the following line to connect to the SQL server database.
            // Note: Replace "ContextName" with the configured context name; replace "key" with the database connection name that exists in appsettings.json. The sample code is as follows:
            // services.AddDataContext<ContextName>(m => m.UseSqlServer(Configuration["ConnectionStrings:key"]));

            // Uncomment the following line to connect to the Oracle database.
            // Note: Replace "ContextName" with the configured context name; replace "key" with the database connection name that exists in appsettings.json. The sample code is as follows:
             services.AddDataContext<DefaultDataContext>(m => m.UseOracle(Configuration["ConnectionStrings:TEST19SENTORP"]));

            // Uncomment the following line to connect to the PostGreSql database.
            // Note: Replace "ContextName" with the configured context name; replace "key" with the database connection name that exists in appsettings.json. The sample code is as follows:
            // services.AddDataContext<ContextName>(m => m.UsePostgreSql(Configuration["ConnectionStrings:key"]));

            // Uncomment the following line to connect to the ODBC database.
            // Note: Replace "ContextName" with the configured context name; replace "key" with the database connection name that exists in appsettings.json. The sample code is as follows:
            // services.AddDataContext<ContextName>(m => m.UseOdbc(Configuration["ConnectionStrings:key"]));
            services.AddScoped<ILargeNumberModelService, LargeNumberModelService>();
            services.AddGzipCompression(CompressionLevel.Fastest);
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            // Adds middleware for redirecting HTTP Requests to HTTPS.
            // app.UseHttpsRedirection();

            app.UseResponseCompression();

            app.UseMvc();

            app.UseDataWindow();
        }
    }
}