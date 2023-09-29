using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Interfaces;
using Infrastructure.UnitOfWork;
using Microsoft.Extensions.Options;

namespace API.Extension;
public static class ApplicationServiceExtensions
{
    public static void ConfigureCors(this IServiceCollection services) =>
    services.AddCors(options =>{
        options.AddPolicy("CorsPolicy", builder =>
        builder.AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader()
        );
    });

    public static void AddAplicationService(this IServiceCollection services){
        services.AddScoped<IUnitOfWork,UnitOfWork>();
    }
}
