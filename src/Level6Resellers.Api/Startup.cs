using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using AutoMapper;
using Level6Resellers.Api.Swagger;
using Level6Resellers.BusinessLogic.Configurations.Mapper;
using Level6Resellers.BusinessLogic.Interfaces;
using Level6Resellers.BusinessLogic.Services;
using Level6Resellers.DataLayer.Context;
using Level6Resellers.DataLayer.Repository;
using Level6Resellers.DataLayer.Repository.Interface;
using Level6Resellers.DataLayer.UnitOfWork;
using Level6Resellers.DataLayer.UnitOfWork.Interface;
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
using Swashbuckle.AspNetCore.Swagger;

namespace Level6Resellers.Api
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
            //IdentityServer
            //IdentityServer configs
            var builder = services.AddIdentityServer(options =>
            {
                options.Events.RaiseErrorEvents = true;
                options.Events.RaiseInformationEvents = true;
                options.Events.RaiseFailureEvents = true;
                options.Events.RaiseSuccessEvents = true;
            })
                .AddInMemoryIdentityResources(IdentityConfig.Ids)
                .AddInMemoryApiResources(IdentityConfig.Apis)
                .AddInMemoryClients(IdentityConfig.Clients)
                .AddDeveloperSigningCredential();

            ////Identity(Bearer access token)
            string identityUrl = Configuration["Auth:Authority"];
            string clientId = Configuration["Auth:ClientId"];
            string clientSecret = Configuration["Auth:ClientSecret"];
            string scope = Configuration["Auth:Scope"];

            services.AddAuthentication("Bearer")
            .AddJwtBearer(options =>
            {
                options.Authority = identityUrl;
                options.RequireHttpsMetadata = false;
                options.Audience = scope;
            });

            //Swagger
            services.AddSwaggerGen(swagger =>
            {
                swagger.SwaggerDoc(SwaggerConfiguration.DocNameV1,
                    new OpenApiInfo
                    {
                        Title = SwaggerConfiguration.DocInfoTitle,
                        Version = "v1",
                        Description = SwaggerConfiguration.DocInfoDescription,
                    });

                swagger.AddSecurityDefinition("OAuth2", 
                    new OpenApiSecurityScheme
                    {
                        Type = SecuritySchemeType.OAuth2,
                        Flows = new OpenApiOAuthFlows
                        {
                            ClientCredentials = new OpenApiOAuthFlow
                            {
                                TokenUrl = new Uri($"{identityUrl}/connect/token"),
                                Scopes = new Dictionary<string, string>
                                {
                                    {scope,  "Level6 resellers API"}
                                }
                            },
                        }
                    }
                );

                swagger.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference{ Type = ReferenceType.SecurityScheme, Id = "OAuth2"}
                        },
                        new List<string>(){ scope }
                    }
                });

                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                swagger.IncludeXmlComments(xmlPath);
            });

            //Mapper
            services.AddAutoMapper(typeof(ResellersMapperProfile));

            //Context
            string connectionString = Configuration.GetConnectionString("ResellersConnectionString");
            bool inMemoryDb = Configuration.GetValue<bool>("InMemoryDB");

            if(inMemoryDb)
            {
                services.AddDbContext<ResellersContext>(options =>
                options.UseInMemoryDatabase("resellers"));
            }
            else
            {
                services.AddDbContext<ResellersContext>(options =>
                options.UseSqlServer(connectionString));
            }

            //Unit of work
            services.AddScoped<IUnitOfWork, EntityFrameworkUnitOfWork<ResellersContext>>();

            //Repository
            services.AddScoped<IRepository, ContextRepository<ResellersContext>>();

            //Services
            services.AddScoped<ICustomerCompanyService, CustomerCompanyService>();
            services.AddScoped<IResellerCompanyService, ResellerCompanyService>();
            services.AddScoped<IResellerCustomerService, ResellerCustomerService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IProductResellerCustomerService, ProductResellerCustomerService>();
            services.AddScoped<IUserCustomerService, UserCustomerService>();
            services.AddScoped<IPurchaseService, PurchaseService>();

            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseIdentityServer();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint(SwaggerConfiguration.EndpointUrl, SwaggerConfiguration.EndpointDescription);
                c.OAuthClientId(Configuration["Auth:ClientId"]);
                c.OAuthClientSecret(Configuration["Auth:ClientSecret"]);
                c.OAuthAppName("SwaggerUI Client");
                c.RoutePrefix = string.Empty;
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
