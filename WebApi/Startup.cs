using DataLayer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLayer.Repositories.AuthenticationRepository;
using BusinessLayer.Repositories.DeparmentRepositories;
using BusinessLayer.Repositories.UserRepository;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace WebApi
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

            services.AddDbContext<DataContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DataConnection"), b => b.MigrationsAssembly("WebApi")));

            //services.AddControllers().AddNewtonsoftJson(x => x.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Serialize);
            services.AddControllers().AddNewtonsoftJson(options =>
            {
                options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            });

            services.AddScoped<IDeparmentRepository, DeparmentRepository>();
            services.AddScoped<IAuthenticationRepository, AuthenticationRepository>();
            services.AddScoped<IUserRepository, UserRepository>();

            services.AddDbContext<DataContext>(x => x.UseSqlServer(Configuration["ConnectionStrings"]));

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
                {
                    Version = "v1",
                    Title = "One Inch Punch Backend Service",
                    Description = "One Inch Punch Training Service",
                    Contact = new Microsoft.OpenApi.Models.OpenApiContact
                    {
                        Name = "Selim Can Bagdatli",
                        Email = "selimcan.bagdatli@bs.nttdata.com.tr",
                    },
                    License = new Microsoft.OpenApi.Models.OpenApiLicense
                    {
                        Name = "Selim Can Bagdatli",
                    }
                });
            });

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

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "JirabackendService API V1");
            });
        }
    }
}
