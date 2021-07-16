using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using ShowCase.Data;
using ShowCase.Models;
using ShowCase.Repository;
using ShowCase.Repository.Contracts;
using ShowCase.Repository.Implementation;
using ShowCase.Security;
using ShowCase.Security.ManageRoles;
using ShowCase.Security.ManageRoles.CreateRoles;
using ShowCase.Security.ManageRoles.EditRoles;
using ShowCase.Security.Operations;
using ShowCase.Security.Operations.ProductOperations;
using ShowCase.Security.Operations.UserInformation;
using ShowCaseAPI.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShowCaseAPI
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

            #region Swagger
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { 
                    Title = "ShowCaseAPI",
                    Version = "v1",
                    Description = "Authentication and Authorization in ASP.NET 5 with JWT and Swagger"
                });

                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme() { 
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "Enter 'Bearer' [space] and then your valid token in the text input below.\r\n\r\nExample: \"Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9\"",
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement {
                    {   
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        new string[]{ }
                    }
                });
            });
            #endregion

            #region Database Connection
            services.AddDbContextPool<AppDbContext>(
                options => options.UseSqlServer(
                    Configuration.GetConnectionString("DBConnection")).EnableSensitiveDataLogging()
            );
            #endregion

            #region Database Repositories
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            #endregion

            #region Configure Jwt  
            services.Configure<JwtConfig>(Configuration.GetSection("JwtConfig"));
            
            services.AddAuthentication(options => {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(jwt => {
                var key = Encoding.ASCII.GetBytes(Configuration["JwtConfig:Secret"]);
                jwt.SaveToken = true;
                jwt.TokenValidationParameters = new TokenValidationParameters{
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateLifetime = true,
                    RequireExpirationTime = false
                };
            });
            #endregion

            #region Identity
            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<AppDbContext>()
                .AddDefaultTokenProviders();

            services.Configure<IdentityOptions>(options => {
                options.Password.RequiredLength = 6;
                options.Password.RequiredUniqueChars = 3;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireLowercase = false;
                options.SignIn.RequireConfirmedEmail = true;
            });
            #endregion

            #region AuthorizationHandlers
            
            services.AddSingleton<IAuthorizationHandler, CanCreateRolesHandler>();
            services.AddSingleton<IAuthorizationHandler, CanEditRolesHandler>();
            services.AddSingleton<IAuthorizationHandler, CanDeleteRolesHandler>();
            services.AddSingleton<IAuthorizationHandler, CanDeleteRolesHandler>();
            services.AddSingleton<IAuthorizationHandler, ProductAuthorizationHandler>();
            services.AddSingleton<IAuthorizationHandler, OrderAuthorizationHandler>();

            // UserInformation - PersonalInformation.
            services.AddSingleton<IAuthorizationHandler, UserListHandler>();
            services.AddSingleton<IAuthorizationHandler, UserPersonalInformationHandler>();
            services.AddSingleton<IAuthorizationHandler, UserAddressInformationHandler>();
            services.AddSingleton<IAuthorizationHandler, UserPaymentMethodHandler>();
            services.AddSingleton<IAuthorizationHandler, ConfirmOrderAuthorizationHandler>();


            services.AddSingleton<IAuthorizationHandler, CanEditOnlyOtherAdminRolesAndClaimsHandler>();
            services.AddSingleton<IAuthorizationHandler, SuperAdminHandler>();

            #endregion

            services.AddControllersWithViews().AddNewtonsoftJson(options =>
               options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
            );
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ShowCaseAPI v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
