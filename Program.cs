
using Microsoft.AspNetCore.Http.Json;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using NM.APP.CORE.Application.Services;
using NM.APP.CORE.Domain.Entities;
using NM.APP.CORE.Domain.Repositories;
using NM.APP.CORE.Infrastructore.Data;
using NM.APP.CORE.Infrastructore.Repository;
using System.Reflection;
using System.Text.Json.Serialization;

namespace NM.APP.CORE.WebAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
            //builder.Services.AddOpenApi();

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddDbContext<NMCoreDbContext>(opt =>
            {
                opt.UseInMemoryDatabase("NMInMemoryDB");
                //OptionsBuilderConfigurationExtensions.UseSqlServer(builder.Configuration.GetConnectionString("NMDBConnectionString"));
            });

            builder.Services.AddScoped<ISensorRepository, SensorRepository>();
            builder.Services.AddScoped<SensorService>();

            //Daten direkt
            builder.Services.AddDbContext<NMAPPDbContext>(opt =>
            {
                //opt.UseInMemoryDatabase("NMInMemoryDB");
                opt.UseSqlServer(builder.Configuration.GetConnectionString("NMDBConnectionString"));
                opt.EnableDetailedErrors();
            });

            //Scoped Repositories and Services
            builder.Services.AddScoped<ITBL_AN_UNIProzesse_MainTreeRepository, TBL_AN_UNIProzesse_MainTreeRepository>();
            builder.Services.AddScoped<TBL_AN_UNIProzess_MainTreeService>();

            builder.Services.AddScoped<ITBL_AN_CollectionProtokollRepository, TBL_AN_CollectionProtokollRepository>();
            builder.Services.AddScoped<TBL_AN_CollectionProtokollService>();

            builder.Services.AddScoped<ITBL_AN_UNIProzesse_MainTree_TypRepository, TBL_AN_UNIProzesse_MainTree_TypRepository>();
            builder.Services.AddScoped<TBL_AN_UNIProzesse_MainTree_TypService>();

            builder.Services.AddScoped<ITBL_AN_SolutionRepository, TBL_AN_SolutionRepository>();
            builder.Services.AddScoped<TBL_AN_SolutionService>();

            builder.Services.AddScoped<ITBL_AN_SolutionThemeRepository, TBL_AN_SolutionThemeRepository>();
            builder.Services.AddScoped<TBL_AN_SolutionThemeService>();

            //Json
            builder.Services.AddControllers()
                .AddJsonOptions(options => {
                options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles;
             });




            // Swagger Configuration
            // https://learn.microsoft.com/de-de/aspnet/core/tutorials/getting-started-with-swashbuckle?view=aspnetcore-8.0&tabs=visual-studio
            builder.Services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "IT Dokumentation und Prozesse",
                    Description = "An ASP.NET Core Web API for managing IT items",
                    TermsOfService = new Uri("https://example.com/terms"),
                    Contact = new OpenApiContact
                    {
                        Name = "Example Contact",
                        Url = new Uri("https://example.com/contact")
                    },
                    License = new OpenApiLicense
                    {
                        Name = "Example License",
                        Url = new Uri("https://example.com/license")
                    }
                });

                // using System.Reflection;
                var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
