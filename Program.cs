
using Microsoft.EntityFrameworkCore;
using NM.APP.CORE.Application.Services;
using NM.APP.CORE.Domain.Entities;
using NM.APP.CORE.Domain.Repositories;
using NM.APP.CORE.Infrastructore.Data;
using NM.APP.CORE.Infrastructore.Repository;
{
    
}

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

            builder.Services.AddScoped<ITBL_AN_UNIProzesse_MainTreeRepository, TBL_AN_UNIProzesse_MainTreeRepository>();
            builder.Services.AddScoped<TBL_AN_UNIProzess_MainTreeService>();

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
