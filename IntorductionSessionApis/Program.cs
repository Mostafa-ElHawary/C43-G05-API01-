
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata;
using System.Reflection;
using System.Text;
using static System.Net.Mime.MediaTypeNames;
using static System.Net.WebRequestMethods;
using Microsoft.VisualBasic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.Extensions.Configuration;
using System.Net;
using System;

namespace IntorductionSessionApis
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //This creates an instance of WebApplicationBuilder, which is used to configure the application and its services.
            //args are passed to allow customization of the application's behavior via command-line arguments.

            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            // This adds support for controllers to the application.Controllers handle incoming HTTP requests and return responses.
            // It registers the necessary services(e.g., routing, model binding) required for MVC(Model - View - Controller) functionality.


            builder.Services.AddControllers();

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

            //AddEndpointsApiExplorer: Adds metadata about API endpoints to the application. This metadata is used by tools like Swagger to generate API documentation.
            //AddSwaggerGen: Configures Swagger to generate interactive API documentation.Swagger provides a UI where developers can explore and test the API endpoints.

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            //This builds the application using the configuration defined in the builder.
            //app represents the fully configured web application and is used to define the middleware pipeline.

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            //This middleware enables authorization in the application. It ensures that only authenticated and authorized users can access certain resources or endpoints.
            app.UseAuthorization();

            //This maps the routes defined in the controllers to the middleware pipeline. It allows the application to route incoming HTTP requests to the appropriate controller actions.
            app.MapControllers();

            app.Run();

            //Summary of the Code Flow
            //Initialization : The WebApplicationBuilder is created to configure the application and its services.
            //Service Registration :
            //Controllers are added to handle HTTP requests.
            //Swagger / OpenAPI services are added for API documentation.
            //Application Build : The application is built with the configured services.
            //Middleware Configuration :
            //Swagger middleware is enabled in the development environment.
            //HTTPS redirection ensures secure communication.
            //Authorization middleware enforces access control.
            //Routes are mapped to controllers.
            //Execution : The application starts and listens for incoming requests.
        }
    }
}
