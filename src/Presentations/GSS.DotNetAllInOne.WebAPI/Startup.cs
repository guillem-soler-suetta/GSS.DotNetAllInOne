using AutoMapper;
using GSS.DotNetAllInOne.Application;
using GSS.DotNetAllInOne.Persistence;
using GSS.DotNetAllInOne.WebAPI.ConfigurationOptions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.ComponentModel;
using System.Linq;

namespace GSS.DotNetAllInOne.WebAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            AppSettings = new AppSettings();
            Configuration.Bind(AppSettings);
        }

        private AppSettings AppSettings { get; set; }
        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAutoMapper(typeof(Startup));
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.CustomSchemaIds(x => x.GetCustomAttributes(false).OfType<DisplayNameAttribute>().FirstOrDefault()?.DisplayName ?? x.Name);
            });
            services.AddCors(options =>
            {
                options.AddPolicy("AllowedOrigins", builder => builder
                    .WithOrigins(AppSettings.CORS.AllowedOrigins)
                    .AllowAnyMethod()
                    .AllowAnyHeader());

                options.AddPolicy("AllowAnyOrigin", builder => builder
                    .AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader());

                options.AddPolicy("CustomPolicy", builder => builder
                    .AllowAnyOrigin()
                    .WithMethods("Get")
                    .WithHeaders("Content-Type"));
            });

            services.AddPersistenceLayer(AppSettings.ConnectionStrings.Examples);
            services.AddApplicationLayer();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors(AppSettings.CORS.AllowAnyOrigin ? "AllowAnyOrigin" : "AllowedOrigins");


            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
