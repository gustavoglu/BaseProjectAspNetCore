﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http;
using BaseProjectANC.Infra.Bus;
using BaseProjectANC.Infra.IoC;
using BaseProjectANC.Infra.Identity.Data;
using Microsoft.EntityFrameworkCore;
using BaseProjectANC.Infra.Identity.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using AutoMapper;
using Microsoft.AspNetCore.Mvc.Formatters;
using BaseProjectANC.Services.API.Configurations;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Swagger;
using BaseProjectANC.Services.API.Middlewares;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc.Authorization;
using BaseProjectANC.Infra.Identity.Authorization;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace BaseProjectANC.Services.API
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }
        private const string SecretKey = "BaseProjectAspNetCoreSercretKey";
        private readonly SymmetricSecurityKey _signKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(SecretKey));
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {



            services.AddDbContext<ApplicationDbContext>(opt =>
            opt.UseSqlServer(Configuration.GetConnectionString("DefaultConnectoin")));

            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            services.AddOptions();
            services.AddMvc(options =>
            {
                options.OutputFormatters.Remove(new XmlDataContractSerializerOutputFormatter());
                //  options.UseCentralRoutePrefix(new RouteAttribute("api/v{version}"));
                var policy = new AuthorizationPolicyBuilder()
                .AddAuthenticationSchemes(JwtBearerDefaults.AuthenticationScheme)
                .RequireAuthenticatedUser()
                .Build();

                options.Filters.Add(new AuthorizeFilter(policy));

            });

            var jwtAppSettingOptions = Configuration.GetSection(nameof(JwtTokenOptions));

            services.Configure<JwtTokenOptions>(options =>
            {
                options.Issuer = jwtAppSettingOptions[nameof(JwtTokenOptions.Issuer)];
                options.Audience = jwtAppSettingOptions[nameof(JwtTokenOptions.Audience)];
                options.SigningCredentials = new SigningCredentials(_signKey, SecurityAlgorithms.HmacSha256);
            });

            services.AddAutoMapper();

            services.AddSwaggerGen(s =>
            {
                s.SwaggerDoc("v1", new Info()
                {
                    Version = "v1",
                    Title = "BaseProjectANC API",
                    Description = "API do Projeto Base de Asp Net Core",
                    TermsOfService = "Nenhum",
                    Contact = new Contact { Name = "Gustavo Giroldo", Email = "gustavoglu@hotmail.com" },
                });
            });

            NativeSimpleInjector.RegisterDependencys(services);

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory, IHttpContextAccessor accessor)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            var jwtAppSettingOptions = Configuration.GetSection(nameof(JwtTokenOptions));

            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidIssuer = jwtAppSettingOptions[nameof(JwtTokenOptions.Audience)],

                ValidateAudience = true,
                ValidAudience = jwtAppSettingOptions[nameof(JwtTokenOptions.Audience)],

                ValidateIssuerSigningKey = true,
                IssuerSigningKey = _signKey,

                RequireExpirationTime = true,
                ValidateLifetime = true,

                ClockSkew = TimeSpan.Zero

            };

            app.UseJwtBearerAuthentication(new JwtBearerOptions
            {
                AutomaticAuthenticate = true,
                AutomaticChallenge = true,
                TokenValidationParameters = tokenValidationParameters
            });


            app.UseCors(c =>
            {
                c.AllowAnyHeader();
                c.AllowAnyMethod();
                c.AllowAnyOrigin();
            });

            app.UseStaticFiles();
            app.UseIdentity();
            app.UseMvc();

            //app.UseSWaggerAuthorized();
            app.UseSwagger();
            app.UseSwaggerUI(s =>
            {
                s.SwaggerEndpoint("/swagger/v1/swagger.json", "BaseProjectANC API V1");
            });

            InMemoryBus.ContainerAccessor = () => accessor.HttpContext.RequestServices;
        }
    }
}
