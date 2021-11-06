using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using AutoMapper;
using GamingWorld.API.Publications.Domain.Repositories;
using GamingWorld.API.Publications.Domain.Services;
using GamingWorld.API.Publications.Persistence.Repositories;
using GamingWorld.API.Publications.Services;
using GamingWorld.API.UserProfiles.Domain.Repositories;
using GamingWorld.API.UserProfiles.Domain.Services;
using GamingWorld.API.UserProfiles.Persistence.Context;
using GamingWorld.API.UserProfiles.Persistence.Repositories;
using GamingWorld.API.UserProfiles.Services;
using GamingWorld.API.Users.Domain.Repositories;
using GamingWorld.API.Users.Domain.Services;
using GamingWorld.API.Users.Persistence.Repositories;
using GamingWorld.API.Users.Services;
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
using IUnitOfWork = GamingWorld.API.Users.Domain.Repositories.IUnitOfWork;
using UnitOfWork = GamingWorld.API.UserProfiles.Persistence.Repositories.UnitOfWork;

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
            services.AddControllers();

                services.AddCors(options =>
            {
                options.AddPolicy("AllowAllHeaders",
                    builder =>
                    {
                        builder.AllowAnyOrigin()
                            .AllowAnyHeader()
                            .AllowAnyMethod();
                    });
            });

            services.AddCors(options => options.AddDefaultPolicy(builder => builder.AllowAnyOrigin()));

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
            
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserService, UserService>();
            
            services.AddScoped<IPublicationRepository, PublicationRepository>();
            services.AddScoped<IPublicationService, PublicationService>();

            services.AddScoped<IUserProfileRepository, UserProfileRepository>();
            services.AddScoped<IUProfileService, UserProfileService>();
            
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddAutoMapper(typeof(Startup));
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

            app.UseCors("AllowAllHeaders");

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}