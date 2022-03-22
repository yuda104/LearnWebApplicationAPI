using DataStore.EF;
//using DataStore.EF.Repositories;
using Microsoft.AspNet.OData.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Auth;
using WebApi.Filters;
using WebApplicationAPI.Controllers;

namespace WebApplicationAPI
{
    public class Startup
    {
        private readonly IWebHostEnvironment _env;

        public Startup(IWebHostEnvironment env)
        {
            this._env = env;
        }


        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<ICustomTokenManager, CustomTokenManager>();
            services.AddSingleton<ICustomUserManager, CustomUserManager>();

            if (_env.IsDevelopment())
            {
                services.AddDbContext<BugsContext>(options =>
                {
                    options.UseInMemoryDatabase("Bugs");
                });
            }
            // Add service
            //services.AddTransient<IItemRepository, ItemRepository>();

            services.AddControllers();
            //services.AddOData();

            // Add API Versioning
            services.AddApiVersioning(options =>
            {
                options.ReportApiVersions = true;
                options.AssumeDefaultVersionWhenUnspecified = true;
                options.DefaultApiVersion = new Microsoft.AspNetCore.Mvc.ApiVersion(1, 0);
               // options.ApiVersionReader = new HeaderApiVersionReader("X-API-Version");
            });

            //services.AddOData();
            //services.AddTransient<IInMemItemsRepository, InMemItemsRepository>();
            services.AddVersionedApiExplorer(options => options.GroupNameFormat = "'v'VVV");

            services.AddSwaggerGen(options => {
                options.SwaggerDoc("v1", new OpenApiInfo { Title = "My Web API v1", Version = "version 1" });
                options.SwaggerDoc("v2", new OpenApiInfo { Title = "My Web API v2", Version = "version 2" });
            });

            services.AddCors(options =>
            {
                options.AddDefaultPolicy(builder =>
                {
                    builder.WithOrigins("https://localhost:44301")
                    .AllowAnyHeader()
                    .AllowAnyMethod();
                });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, BugsContext context)
        {

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();

                //Create the in-memory database for dev environment
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                //Configure OpenAPI
                app.UseSwagger();
                app.UseSwaggerUI(
                        options => {
                            options.SwaggerEndpoint("/swagger/v1/swagger.json", "WebAPI v1");
                            options.SwaggerEndpoint("/swagger/v2/swagger.json", "WebAPI v2");
                        });
            }
            
            app.UseRouting();
            app.UseCors();
           // app.UseMiddleware<ApiKeyAttribute>();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();

               // endpoints.MapControllerRoute(
               //    "Default",
               //    "api/v1/{controller}"
               //);
            });

        }
    }
    //public class Startup
    //{
    //    public Startup(IConfiguration configuration, IWebHostEnvironment env)
    //    {
    //        Configuration = configuration;
    //        _env = env;
    //    }

    //    public IConfiguration Configuration { get; }
    //    public IWebHostEnvironment _env { get; }

    //    // This method gets called by the runtime. Use this method to add services to the container.
    //    public void ConfigureServices(IServiceCollection services)
    //    {
    //        if (_env.IsDevelopment())
    //        {
    //            services.AddDbContext<BugsContext>(options =>
    //            {
    //                options.UseInMemoryDatabase("Bugs");
    //            });
    //        }

    //        services.AddControllers();

    //        services.AddApiVersioning(options => {
    //            options.ReportApiVersions = true;
    //            options.AssumeDefaultVersionWhenUnspecified = true;
    //            options.DefaultApiVersion = new Microsoft.AspNetCore.Mvc.ApiVersion(1,0);
    //            //options.ApiVersionReader = ApiVersionReader.Combine(
    //            //        new MediaTypeApiVersionReader("X-API-Version"),
    //            //        new HeaderApiVersionReader("X-API-Version")
    //            //    );
    //           // options.Conventions.Controller<ProjectsController>().ad
    //            //new MediaTypeApiVersionReader("X-API-Version");
    //            //new HeaderApiVersionReader("X-API-Version");
    //        });

    //        services.AddVersionedApiExplorer(options => {
    //            options.GroupNameFormat = "'v'VVV";
    //        });
    //        services.AddSwaggerGen(options => {
    //            options.SwaggerDoc("v1", new OpenApiInfo { Title = "My Web API v1", Version = "version 1" });
    //            options.SwaggerDoc("v2", new OpenApiInfo { Title = "My Web API v2", Version = "version 2" });
    //        });
    //    }

    //    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    //    public void Configure(IApplicationBuilder app, IWebHostEnvironment env, BugsContext context)
    //    {
    //        if (env.IsDevelopment())
    //        {
    //            app.UseDeveloperExceptionPage();

    //            //Create the in-memory database for dev environment
    //            context.Database.EnsureDeleted();
    //            context.Database.EnsureCreated();

    //            //Configure OpenAPI
    //            app.UseSwagger();
    //            app.UseSwaggerUI(
    //                options => {
    //                    options.SwaggerEndpoint("/swagger/v1/swagger.json", "WebAPI v1");
    //                    options.SwaggerEndpoint("/swagger/v2/swagger.json", "WebAPI v2");
    //                });
    //        }
    //        else
    //        {
    //            app.UseExceptionHandler("/Error");
    //            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    //            app.UseHsts();
    //        }

    //        //app.UseHttpsRedirection();
    //        //app.UseStaticFiles();

    //        app.UseRouting();

    //        //app.UseAuthorization();

    //        app.UseEndpoints(endpoints =>
    //        {
    //            endpoints.MapControllers();
    //           // endpoints.MapRazorPages();
    //        });
    //    }
    //}
}
