using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.OpenApi.Models;

namespace API.Extensions
{
    public static class SwaggerServiceExtensions
    {
        public static IServiceCollection AddSwaggerDocumentation(this IServiceCollection services)
        {
                
                services.AddSwaggerGen( c => 
                {
                    var securitySchema = new OpenApiSecurityScheme 
                    {
                        Description = "JWT yetki",
                        Name = "Authorization",
                        In = ParameterLocation.Header,
                        Type = SecuritySchemeType.Http,
                        Scheme = "bearer",
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                        }
                    };
                    c.AddSecurityDefinition("Bearer", securitySchema);
                    var securityReq = new OpenApiSecurityRequirement { {securitySchema, new[] {"Bearer"}}};

                    c.AddSecurityRequirement(securityReq);
                });
            return services;  
        }

        public static IApplicationBuilder UseSwaggerDocumentation(this IApplicationBuilder app)
        {
             app.UseSwagger();
            app.UseSwaggerUI();    
            return app;
        }
    }
}