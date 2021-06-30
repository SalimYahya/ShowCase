using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using ShowCase.Configuration;
using ShowCase.Data;
using ShowCase.Models;
using ShowCase.Repository;
using ShowCase.Repository.Contracts;
using ShowCase.Repository.Implementation;
using ShowCase.Repository.Repository;
using ShowCase.Security;
using ShowCase.Security.ManageRoles;
using ShowCase.Security.ManageRoles.CreateRoles;
using ShowCase.Security.ManageRoles.DeleteRoles;
using ShowCase.Security.ManageRoles.EditRoles;
using ShowCase.Security.Operations;
using ShowCase.Security.Operations.ProductOperations;
using ShowCase.Security.Operations.UserInformation;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShowCase
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
            // Localization
            services.AddLocalization(opt => { opt.ResourcesPath = "Resources"; });
            services.AddMvc().AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix)
                .AddDataAnnotationsLocalization();

            // DbRepos
            //services.AddScoped(typeof(IRepositoryBase<,>), typeof(RepositoryBase<,>));

            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IRoleRepository, RoleRepository>();


            services.Configure<RequestLocalizationOptions>(opt => {

                var supportedCultures = new List<CultureInfo> {
                    new CultureInfo("en"),
                    new CultureInfo("ar"),
                };

                opt.DefaultRequestCulture = new RequestCulture("en");
                opt.SupportedCultures = supportedCultures;
                opt.SupportedUICultures = supportedCultures;
            });

            services.AddControllersWithViews();

            // Configure Jwt - Secret Key
            services.Configure<JwtConfig>(Configuration.GetSection("JwtConfig"));

            // Swagger
            services.AddSwaggerGen(swagger =>
            {
                //This is to generate the Default UI of Swagger Documentation    
                swagger.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "ASP.NET 5 Web API",
                    Description = "Authentication and Authorization in ASP.NET 5 with JWT and Swagger"
                });
                // To Enable authorization using Swagger (JWT)    
                swagger.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "Enter 'Bearer' [space] and then your valid token in the text input below.\r\n\r\nExample: \"Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9\"",
                });
                swagger.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                          new OpenApiSecurityScheme
                            {
                                Reference = new OpenApiReference
                                {
                                    Type = ReferenceType.SecurityScheme,
                                    Id = "Bearer"
                                }
                            },
                            new string[] {}

                    }
                });
            });

            services.AddDbContextPool<AppDbContext>(
                options => options.UseSqlServer(
                    Configuration.GetConnectionString("DBConnection")).EnableSensitiveDataLogging()
            );

            // Configure Jwt - Authentication
            services.AddAuthentication(options => {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(jwt => {

                var key = Encoding.ASCII.GetBytes(Configuration["JwtConfig:Secret"]);

                jwt.SaveToken = true;

                jwt.TokenValidationParameters = new TokenValidationParameters {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateLifetime = true,
                    RequireExpirationTime = false
                };

            });

            
            services.AddIdentity<ApplicationUser, IdentityRole>()
                    .AddEntityFrameworkStores<AppDbContext>();

            services.Configure<IdentityOptions>(
                options => {
                    options.Password.RequiredLength = 6;
                    options.Password.RequiredUniqueChars = 3;
                    options.Password.RequireNonAlphanumeric = false;
                    options.Password.RequireUppercase = false;
                    options.Password.RequireLowercase = false;
            });



            // Add Mvc to Apply Authorization Globally
            services.AddMvc(options => {
                var policy = new AuthorizationPolicyBuilder()
                                 .RequireAuthenticatedUser()
                                 .Build();
                options.Filters.Add(new AuthorizeFilter(policy));
            });

            services.ConfigureApplicationCookie(options => {
                options.AccessDeniedPath = new Microsoft.AspNetCore.Http.PathString("/Adminstration/AccessDenied");
            });

            services.AddAuthorization(options => {
               
                options.AddPolicy("CreateRolePolicy",
                    policy => policy.AddRequirements(new CreateRoleRequirement()));

                options.AddPolicy("EditRolePolicy",
                    policy => policy.AddRequirements(new EditRolesRequirement()));

                options.AddPolicy("DeleteRolePolicy",
                    policy => policy.AddRequirements(new DeleteRolesRequirement()));

                options.AddPolicy("EditUserRolesAndPolicy",
                    policy => policy.AddRequirements(new ManageUserRolesAndClaimsRequirement()));

                options.AddPolicy("ProductOperations",
                    policy => policy.AddRequirements(new OperationAuthorizationRequirement()));
            });

            
            services.AddSingleton<IAuthorizationHandler, CanCreateRolesHandler>();
            services.AddSingleton<IAuthorizationHandler, CanEditRolesHandler>();
            services.AddSingleton<IAuthorizationHandler, CanDeleteRolesHandler>();
            services.AddSingleton<IAuthorizationHandler, CanDeleteRolesHandler>();
            services.AddSingleton<IAuthorizationHandler, ProductAuthorizationHandler>();
            services.AddSingleton<IAuthorizationHandler, OrderAuthorizationHandler>();

            // UserInformation - PersonalInformation.
            services.AddSingleton<IAuthorizationHandler, UserPersonalInformationHandler>();
            services.AddSingleton<IAuthorizationHandler, UserAddressInformationHandler>();
            services.AddSingleton<IAuthorizationHandler, UserPaymentMethodHandler>();
            services.AddSingleton<IAuthorizationHandler, ConfirmOrderAuthorizationHandler>();


            services.AddSingleton<IAuthorizationHandler, CanEditOnlyOtherAdminRolesAndClaimsHandler>();
            services.AddSingleton<IAuthorizationHandler, SuperAdminHandler>();


            services.AddControllersWithViews().AddNewtonsoftJson(options =>
               options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
            );


            services.AddHttpContextAccessor();
            services.AddSession(options => {
                options.IdleTimeout = TimeSpan.FromSeconds(3600);
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, 
            AppDbContext appDbContext, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json","My API Version 1"));
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseSession();
            app.UseAuthentication();
            app.UseAuthorization();

            // Localization

            app.UseRequestLocalization(app.ApplicationServices.GetRequiredService<IOptions<RequestLocalizationOptions>>().Value);

            /*
             *   var supportedCultures = new[] { new CultureInfo("en"), new CultureInfo("ar") };
             *   var localizationOptions = new RequestLocalizationOptions
             *   {
             *       SupportedCultures = supportedCultures,
             *       SupportedUICultures = supportedCultures,
             *       DefaultRequestCulture = new RequestCulture("en"),
             *   };
             *
             *   localizationOptions.RequestCultureProviders.Clear();
             *
             *   localizationOptions.RequestCultureProviders.Add(new QueryStringRequestCultureProvider() { QueryStringKey = "lang" });
            */

            /*
             *  var supportedCultures = new[] { "en", "ar" };
             *  var localizationOptions = new RequestLocalizationOptions()
             *      .SetDefaultCulture(supportedCultures[0])
             *      .AddSupportedCultures(supportedCultures)
             *      .AddSupportedUICultures(supportedCultures);
             *
             *  app.UseRequestLocalization(localizationOptions);
             */

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });

            UsersRolesDummyData.Initilize(appDbContext, userManager, roleManager).Wait();
        }
    }
}
