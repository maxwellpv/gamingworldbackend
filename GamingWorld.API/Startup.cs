using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using AutoMapper;
using GamingWorld.API.Profiles.Domain.Repositories;
using GamingWorld.API.Profiles.Domain.Services;
using GamingWorld.API.Profiles.Persistence.Repositories;
using GamingWorld.API.Profiles.Services;
using GamingWorld.API.Publications.Domain.Repositories;
using GamingWorld.API.Publications.Domain.Services;
using GamingWorld.API.Publications.Persistence.Repositories;
using GamingWorld.API.Publications.Services;
using GamingWorld.API.Security.Authorization.Handlers.Implementations;
using GamingWorld.API.Security.Authorization.Handlers.Interfaces;
using GamingWorld.API.Security.Authorization.Middleware;
using GamingWorld.API.Security.Authorization.Settings;
using GamingWorld.API.Security.Domain.Repositories;
using GamingWorld.API.Security.Domain.Services;
using GamingWorld.API.Security.Persistence.Repositories;
using GamingWorld.API.Security.Services;
using GamingWorld.API.Shared.Persistence.Contexts;
using GamingWorld.API.Shared.Persistence.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using IUnitOfWork = GamingWorld.API.Shared.Domain.Repositories.IUnitOfWork;

namespace GamingWorld.API
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
            services.AddCors();
            services.AddControllers();
            services.AddRouting(options => options.LowercaseUrls = true);
            
            services.AddDbContext<AppDbContext>(options =>
            {
                //options.UseInMemoryDatabase("supermarket-api-in-memory");
                options.UseMySQL(Configuration.GetConnectionString("Default"));
            });
            
            services.AddSwaggerGen(c =>
            {
                c.DocumentFilter<SnakeCaseDocumentFilter>();
                c.OperationFilter<SnakeCaseOperationFilter>();
                c.SwaggerDoc("v1", new OpenApiInfo {Title = "GamingWorld.API", Version = "v1"});
            });

            services.Configure<AppSettings>(Configuration.GetSection("AppSettings"));
            
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserService, UserService>();
            
            services.AddScoped<IPublicationRepository, PublicationRepository>();
            services.AddScoped<IPublicationService, PublicationService>();

            services.AddScoped<IProfileRepository, ProfileRepository>();
            services.AddScoped<IUProfileService, ProfileService>();
            
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            
            services.AddScoped<IJwtHandler, JwtHandler>();
            
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "GamingWorld.API v1"));
            }
            
            app.UseMiddleware<ErrorHandlerMiddleware>();

            app.UseMiddleware<JwtMiddleware>();

            app.UseCors(builder => builder
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}