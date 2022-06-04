using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Common.MongoDbHelper;
using Common.Services;
using Common.Services.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using MongoDB.Bson.Serialization.Conventions;
using MongoDB.Driver;
using Newtonsoft.Json;
using Polly;
using Polly.Contrib.WaitAndRetry;
using Polly.Extensions.Http;
using Serilog;
using StackExchange.Redis;

namespace FireFact.Extensions
{
    public static class ServiceExtensions
    {
        public static void ConfigureCors(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder.AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader());
            });
        }

        public static void ConfigureLog(this IServiceCollection services)
        {
            services.AddSingleton(Log.Logger);
        }

        public static void ConfigureHttpRetry(this IServiceCollection services, IConfiguration configuration)
        {
            int retryDelaySecs = configuration.GetValue<int>("Retry:DelaySecs", 2);
            int retryTimes = configuration.GetValue<int>("Retry:Times", 3);
            services.AddHttpClient("HttpClient").AddPolicyHandler(
                HttpPolicyExtensions
                    .HandleTransientHttpError()
                    .OrResult(msg => msg.StatusCode == System.Net.HttpStatusCode.NotFound)
                    .WaitAndRetryAsync(Backoff.DecorrelatedJitterBackoffV2(
                        medianFirstRetryDelay: TimeSpan.FromSeconds(retryDelaySecs), retryCount: retryTimes))
                );
        }

        public static void ConfigureSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Fire Manufacture Server", Version = "v1" });
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = @"JWT Authorization header using the Bearer scheme.
                      Enter 'Bearer' [space] and then your token in the text input below.
                      Example: 'Bearer 12345abcdef'",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer"
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement()
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            },
                            Scheme = "oauth2",
                            Name = "Bearer",
                            In = ParameterLocation.Header,
                        },
                        new List<string>()
                    }
                });
            });
        }

        public static void ConfigureRedis(this IServiceCollection services, IConfiguration configuration)
        {
            var redisConnectionString = configuration.GetValue<string>("Redis:ConnectionString", "localhost:6379");
            services.AddStackExchangeRedisCache(options =>
            {
                options.Configuration = redisConnectionString;
            });

            services.AddSingleton<IConnectionMultiplexer>(ConnectionMultiplexer.Connect(redisConnectionString));
        }

        public static void ConfigureMongoDB(this IServiceCollection services, IConfiguration configuration)
        {
            //services.AddSingleton<IMongoClient>(sp =>
            //{
            //    var mongoConnectionString = configuration.GetValue<string>("MongoDB:ConnectionString", "localhost:27017");

            //    return new MongoClient(mongoConnectionString);
            //});

            //services.AddSingleton(sp =>
            //{
            //    var client = sp.GetRequiredService<IMongoClient>();
            //    var database = configuration.GetValue<string>("MongoDB:DatabaseName", "localDb");
            //    return client.GetDatabase(database);
            //});

            //var conventionPack = new ConventionPack { new IgnoreExtraElementsConvention(true) };
            //ConventionRegistry.Register("IgnoreExtraElements", conventionPack, type => true);

            //MongoDB.Bson.Serialization.BsonSerializer.RegisterSerializer(MongoDB.Bson.Serialization.Serializers.DateTimeSerializer.LocalInstance);
            services.AddMongoDb(configuration);
        }

        public static void ConfigureInternalServices(this IServiceCollection services)
        {
            services.AddTransient<IFireInventoryService, FireInventoryService>();
        }
    }
}