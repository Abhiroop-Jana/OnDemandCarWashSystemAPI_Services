
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnDemandCarWashSystemAPI.Configurations;
using OnDemandCarWashSystemAPI.DTOs;
using OnDemandCarWashSystemAPI.Interface;
using OnDemandCarWashSystemAPI.Models;
using OnDemandCarWashSystemAPI.Repository;
using OnDemandCarWashSystemAPI.Services;


namespace OnDemandCarWashSystemAPI
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
            services.AddAutoMapper(typeof(MapperConfig));
            services.AddSwaggerGen(options =>
            {
                options.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
                {
                    Description = "Standard Authorization header using the Bearer scheme(\"bearer {token}\")",
                    In = ParameterLocation.Header,
                    Name = "authorization",
                    Type = SecuritySchemeType.ApiKey
                });
                options.OperationFilter<SecurityRequirementsOperationFilter>();
            });
            services.AddDbContext<CarWashContext>
                (x => x.UseSqlServer(Configuration.GetConnectionString("Connstr")));

            services.AddTransient<IPackage, PackageRepository>();
            services.AddTransient<PackageService, PackageService>();

            services.AddTransient<IAdmin, AdminRepository>();
            services.AddTransient<AdminService, AdminService>();

            services.AddTransient<ICar, CarRepository>();
            services.AddTransient<CarService, CarService>();

            services.AddScoped<IRepository<UserDetails, int>,UserRepository>();
            services.AddScoped<UserService, UserService>();

            services.AddScoped<IRegister<CreateUserDto, UserDetails>, RegisterRepository>();
            services.AddScoped<RegisterService, RegisterService>();

            services.AddScoped<IViewInvoice, ViewInvoiceRepository>();
            services.AddScoped<ViewInvoiceService, ViewInvoiceService>();

            services.AddScoped<IToken, TokenRepository>();

            services.AddScoped<ILogin<Login, int>, LoginRepository>();
            services.AddScoped<LoginService, LoginService>();

            services.AddTransient<IAddress, AddressRepository>();
            services.AddTransient<AddressService, AddressService>();

            services.AddTransient<IOrder, OrderRepository>();
            services.AddTransient<OrderService, OrderService>();

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration.GetSection("AppSettings:Token").Value)),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                };
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "OnDemandCarWashSystemAPI v1"));
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
