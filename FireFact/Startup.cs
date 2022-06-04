using System.Collections.Generic;
using System.Reflection;
using Common.Middlewares;
using Common.Utils;
using FireFact.Extensions;
using FireFact.Repositories;
using FireFact.Repositories.Interfaces;
using FireFact.Services;
using FireFact.Services.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;
using Common.JwtHelper;
using Microsoft.AspNetCore.Http;

namespace FireFact
{
    public class Startup
    {
        public static IConfiguration StaticConfiguration;
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            StaticConfiguration = configuration;
        }


        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.ConfigureCors();
            services.ConfigureLog();
            services.ConfigureHttpRetry(Configuration);
            services.AddMemoryCache();
            services.AddControllers();
            services.AddTransient<ExceptionHandlingMiddleware>();
            services.ConfigureSwagger();
            services.ConfigureRedis(Configuration);
            services.AddSingleton<IServiceManager, ServiceManager>();
            services.AddSingleton<IRepositoryManager, RepositoryManager>();
            services.AddHttpContextAccessor();
            services.ConfigureMongoDB(Configuration);

            services.AddTransient<IUserService, UserService>();
            services.AddTransient<ITokenService, TokenService>();
            services.AddTransient<ITestResultService, TestResultService>();
            services.AddTransient<IDeviceTypeService, DeviceTypeService>();
            services.AddTransient<IErrorInfoService, ErrorInfoService>();
            services.AddTransient<IJwtUtils, JwtUtils>();

            services.ConfigureInternalServices();

            services.AddControllers().AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.PropertyNamingPolicy = null;
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory)
        {
            // handle control-c
            var applicationLifetime = app.ApplicationServices.GetRequiredService<IHostApplicationLifetime>();
            applicationLifetime.ApplicationStopping.Register(() =>
            {
                Log.Fatal($"{Assembly.GetExecutingAssembly().GetName().Name}-{env.EnvironmentName}: App is shutting down...");
                Log.CloseAndFlush();
            });

            app.UsePathBase(new Microsoft.AspNetCore.Http.PathString("/fact"));

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/fact/swagger/v1/swagger.json", "FireBusiness v1"));
            }

            ApplicationLogging.ConfigureLogger(loggerFactory, Configuration, $"{Assembly.GetExecutingAssembly().GetName().Name}-{env.EnvironmentName}");

            app.UseMiddleware<ExceptionHandlingMiddleware>();

            app.UseDefaultFiles(new DefaultFilesOptions()
            {
                DefaultFileNames = new List<string>()
                {
                    "index.html"
                }
            });

            // app.UseHttpsRedirection();

            app.UseStaticFiles();

            app.UseForwardedHeaders(new ForwardedHeadersOptions
            {
                ForwardedHeaders = ForwardedHeaders.All
            });

            app.UseRouting();

            app.UseCors("CorsPolicy");

            //app.UseAuthentication();
            //app.UseAuthorization();

            app.UseMiddleware<JwtMiddleware>();
            app.Use(next => context =>
            {
                context.Request.EnableBuffering();
                return next(context);
            });
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

        }
    }
}