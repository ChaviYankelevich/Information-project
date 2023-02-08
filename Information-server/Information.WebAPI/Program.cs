using AutoMapper.Configuration;
using Information.Context;
using Information.Repository.Interfaces;
using Information.Service;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Options;
using System.Text.Json;
using Information.Common.DTOs;

internal class Program
{
    private static void Main(string[] args)
    {
        
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        builder.Services.AddCors(options =>
        {
            options.AddPolicy(name: "Chavi",
                              policy =>
                              {
                                  policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
                              });
        });
        builder.Services.AddServices();


        builder.Services.AddDbContext<IContext, DataContext>(
    options =>
        options.UseSqlServer(
            "name=ConnectionStrings:Information",
            x => x.MigrationsAssembly("Information.Context")));       
        var app = builder.Build();


        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }
        app.UseCors("Chavi");
        app.UseHttpsRedirection();

        app.UseAuthorization();
        //app.Use(async (Context, next) =>
        //{            
        //    DateOnly d = DateOnly.FromDateTime(DateTime.Now);
        //    if (d.DayOfWeek == DayOfWeek.Saturday)
        //    {
        //        Context.Response.StatusCode = StatusCodes.Status400BadRequest;

        //        //var bytes = Encoding.UTF8.GetBytes("Shabes!");

        //        //await Context.Response.Body.WriteAsync(bytes, 0, bytes.Length);
        //        var jsonOptions = Context.RequestServices.GetService<IOptions<JsonOptions>>();

        //        // Serialise using the settings provided
        //        var json = JsonSerializer.Serialize(
        //            new { Foo = "Shabes!" }, // Switch this with your object
        //            jsonOptions?.Value.JsonSerializerOptions);

        //        // Write to the response
        //        await Context.Response.WriteAsync(json);
        //    }

        //    else
        //        await next(Context);
        //});
        app.MapControllers();

        app.Run();
    }
}