using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookStoreManagerLayer.BookStoreManager;
using BookStoreManagerLayer.IBookStoreManager;
using BookStoreRepositoryLayer.BookStoreRepository;
using BookStoreRepositoryLayer.IBookStoreRepository;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;
using Swashbuckle.AspNetCore.Swagger;

namespace BookStoresApplication
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            this.Configuration = configuration;
        }
        public IConfiguration Configuration { get; }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddTransient<IUserAccountManager, UserAccountManager>();
            services.AddTransient<IUserAccountRepository, UserAccountRepository>();
            ///****************
            ////Adding the Swagger
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("V2", new Swashbuckle.AspNetCore.Swagger.Info { Title = "BookStoreApplication", Version = "V2" });

                //// this service handles the jwt token suppying in headers
                options.AddSecurityDefinition("oauth2", new ApiKeyScheme
                {
                    Description = "Using the jwt bearer token",
                    Name = "Authorization",
                    In = "header",
                    Type = "apiKey"
                });
                options.OperationFilter<SecurityRequirementsOperationFilter>();
            });
        ///*******************
        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
              .AddJwtBearer(options =>
              {
                  var serverSecret = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["JWT:key"]));
                  options.TokenValidationParameters = new TokenValidationParameters
                  {
                      IssuerSigningKey = serverSecret,
                      ValidIssuer = Configuration["JWT:Issuer"],
                      ValidAudience = Configuration["JWT:Audience"]
                  };
              });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                
            }
            else
            {
                app.UseHsts();
            }
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/V2/Swagger.json", "BookStoreApplicationv2");
                c.RoutePrefix = "";
            });
            
            app.UseStaticFiles();
            app.UseAuthentication();
            app.UseDefaultFiles();
            app.UseHttpsRedirection();
            app.UseMvcWithDefaultRoute();
        }
    }
}
