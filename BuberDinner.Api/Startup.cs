using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BuberDinner.App.Services;
using BuberDinner.App.Services.Authentication;
using BuberDinner.Infra;
using BuberDinner.Infra.Authentication;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Microsoft.Extensions.Options;
using BuberDinner.Api.Filters;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Http;

namespace BuberDinner.Api
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
            //TODO: check the Factory class
            // services.AddSingleton<ProblemDetailsFactory, BubberDinnerProblemDetailsFactory>();

            services.AddApplicationDependencies().AddApplicationInfrasctructure(Configuration);
            services.AddControllers(/*opt => opt.Filters.Add<ErrorHandlingFilterAttribute>()*/); //2 way to adding attributes
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "BuberDinner.Api", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            app.UseDeveloperExceptionPage();
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "BuberDinner.Api v1"));

            app.UseRouting();

            app.UseMiddleware<Middleware.ErrorHandlingMiddleware>();   //one way of handling error via middleware


            // app.UseExceptionHandler("/error"); //using controller for exception handling
            // app.Map("/error", (HttpContext httpContext) =>
            // {
            //     Exception? exception = httpContext.Features.Get<IExceptionHandlerFeature>()?.Error;
            //     return Results.Problem();
            // });

            //   app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}


/*
var build 



*/