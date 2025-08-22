using Microsoft.OpenApi.Models;
using PaySafe.API.Extensions;
using System.Text.Json.Serialization;

namespace PaySafe.API
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                var builder = WebApplication.CreateBuilder(args).ConfigureHost();

                AddServices(builder);

                var app = builder.Build();

                ConfigureServices(app);

                app.Run();
            }
            catch (Exception)
            {
                Console.WriteLine("API encerrada inesperadamente");
            }
        }

        public static void AddServices(WebApplicationBuilder builder)
        {

            builder.Services
                .AddControllers()
                .AddJsonOptions(op =>
                {
                    op.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
                    op.JsonSerializerOptions.PropertyNamingPolicy = null;
                });

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "PaySafe API",
                    Version = "v1"
                });
            });
        }

        public static void ConfigureServices(WebApplication app)
        {
            if (app.Environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();;
            }

            app.UseSwagger();

            app.UseSwaggerUI();

            app.UseCors(c =>
            {
                c.AllowAnyHeader();
                c.AllowAnyMethod();
                c.AllowAnyOrigin();
            });

            app.UseRouting();

            app.MapControllers();

            app.Run();
        }
    }
}