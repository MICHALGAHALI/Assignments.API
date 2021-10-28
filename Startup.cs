using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Microsoft.EntityFrameworkCore;
using assignments_api.EF.Persistence;

namespace assignments_api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            
            
            Configuration = configuration;
            // // Keep data in AppSettings in file appsettings.json and stored it in the container
           // var appSettingsSection = Configuration.GetSection("AppSettings");
            // services.Configure<AppSettings>(appSettingsSection);
            // var appSettings = appSettingsSection.Get<AppSettings>();
        }

        public IConfiguration Configuration { get; }

        readonly string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy(name: MyAllowSpecificOrigins,
                                            builder =>
                                            {
                                                builder.WithOrigins("http://localhost:4200")
                                                .AllowAnyHeader()
                                                .AllowAnyMethod();
                                            });
            }

            ); // Make sure you call this previous to AddMvc             
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Latest).AddXmlSerializerFormatters();
            services.AddDbContext<AssignmentDbContext>(options=>options.UseSqlServer("Data Source=MICHALG-PC;Initial Catalog=test1;Integrated Security=True"));                
            services.AddRazorPages();
            services.AddHealthChecks();
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "assignments_api", Version = "v1" });
            });
            //services.AddMvc();
    //.AddXmlSerializerFormatters();
            // services.AddDbContext<AssignmentDbContext>(options =>
            // options.UseSqlServer(
            //     Configuration.GetConnectionString("Defult")));  
            // services
            //     .AddScoped<Implementations.Provider>() 
            //     .AddScoped<IJwtAuthorization,Implementations.Provider>()            
            // .AddTransient(typeof(IPipelineBehavior<,>), typeof(TracingBehavior<,>))
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        { 
            app.UseCors(MyAllowSpecificOrigins);
            app.UseAuthorization();
            app.UseRouting();
             
            
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "assignments_api v1"));
            }
            app.UseEndpoints(endpoints =>
            {
                // endpoints.MapControllers();
                endpoints.MapControllerRoute("Default", "{controller=ToDo}/{action=get}/{id?}"); 
                var jsontext = System.IO.File.ReadAllText(@"AssignmentsData.json");
                Seeding.Seed(jsontext, app.ApplicationServices);
            });
           // app.UseHttpsRedirection();
        }
    }
}
