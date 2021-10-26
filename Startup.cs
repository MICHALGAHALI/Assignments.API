using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using assignments_api.Persistence;
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

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<AssignmentDbContext>(options=>options.UseSqlServer(""));
            services.AddRazorPages();
            services.AddHealthChecks();
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "assignments_api", Version = "v1" });
            });
            // services
            //     .AddScoped<Implementations.Provider>() 
            //     .AddScoped<IJwtAuthorization,Implementations.Provider>()            
            // .AddTransient(typeof(IPipelineBehavior<,>), typeof(TracingBehavior<,>))
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        { 
//             ASP.NET Core הציג קונספט חדש בשם Middleware. Middleware אינו אלא component (מחלקה) שמבוצע בכל בקשה ביישום ASP.NET Core.

// ב- ASP.NET הקלאסי HttpHandlers ו- HttpModules היו חלק מצינור הבקשה, והיה צורך ששניהם יהיו מוגדרים ומבוצעים בכל בקשה.

// בדרך כלל, יהיו Middleware מרובים ב- ASP.NET Core web application.
// Middleware יכול להיות מסופק מה framework, מחבילת NuGet או custom middleware.

// אנו יכולים לקבוע את סדר ביצוע  middleware ב request pipeline. כל middleware מוסיף או משנה את בקשת http ומעביר אפשרות שליטה ל  middleware הבא.

// הדיאגרמה הבאה ממחישה את הסדר הטיפוסי של שכבות middleware.
// הסדר חשוב מאוד, ולכן הכרחי להבין את המיקום של כל middleware בצינור הבקשה:
             app.UseAuthorization();
             app.UseRouting();
             app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute("Default", "{controller=ToDo}/{action=get}/{id?}"); 
            });
            
            // app.UseEndpoints(endpoints =>
            // {
            //     endpoints.MapRazorPages(); //Routes for pages
            //     endpoints.MapControllers(); //Routes for my API controllers
            // });

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "assignments_api v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();
        }
    }
}
