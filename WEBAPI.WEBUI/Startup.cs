using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using WEBAPI.BL.Reports;
using WEBAPI.DAL;
using WEBAPI.DAL.Repository;
using WEBAPI.WEBUI.BL;
using WEBAPI.WEBUI.BL.Reports;
using WEBAPI.WEBUI.BL.Service;
using System;

namespace WEBAPI.WEBUI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        [Obsolete]
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddScoped<IEducationRepository, EducationRepository>();

            services.AddScoped<IStudentsService, StudentsService>();
            services.AddScoped<IHomeWorksService, HomeWorksService>();
            services.AddScoped<ILecturersService, LecturersService>();
            services.AddScoped<ILecturesService, LecturesService>();
            services.AddScoped<IAttendingLecturesService, AttendingLecturesService>();
            services.AddScoped<IReportSaver, ReportToTextFile>();
            services.AddScoped<IReportSaver, ReportToXmlFile>();
            services.AddScoped<IReportSaver, ReportToJsonFile>();
            services.AddScoped<GetDataForWarning, GetDataForWarning>();
            services.AddScoped<ISendWarning, SendWarning>();

            IConfigurationSection connStrings = Configuration.GetSection("ConnectionStrings");

            var connString = Configuration.GetConnectionString("EducationDatabase");
            services.AddDbContext<WEBAPIContext>(opt =>
           opt.UseSqlServer(connString), ServiceLifetime.Scoped);

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddControllers();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Education API", Version = "v1" });
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

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Education API V1");
            });

            app.UseMiddleware(typeof(ErrorHandlingMiddleware));

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
