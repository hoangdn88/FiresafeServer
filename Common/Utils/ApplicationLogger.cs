using System;
using System.IO;
using System.Reflection;
using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Serilog;
using Serilog.Events;
using Serilog.Sinks.Elasticsearch;

namespace Common.Utils
{
    public static class ApplicationLogging
    {
        public static void ConfigureLogger(ILoggerFactory inputFactory, IConfiguration configuration, string indexName)
        {
            var serilogLogger = new LoggerConfiguration()
                .ReadFrom.Configuration(configuration)
                .WriteTo.Console()
                .WriteTo.Elasticsearch(ConfigureElasticSink(configuration, indexName))
                .WriteTo.Logger(l => l.Filter.ByIncludingOnly(e => e.Level == LogEventLevel.Error || e.Level == LogEventLevel.Fatal).
                            WriteTo.Telegram(configuration.GetValue<string>("Serilog:TelegramApiKey", ""),
                            configuration.GetValue<string>("Serilog:TelegramGroupId", "")))
                .CreateLogger();

            Log.Logger = serilogLogger;
            inputFactory.AddSerilog(serilogLogger);

            Log.Fatal($"{indexName}: App is starting...");
        }

        private static ElasticsearchSinkOptions ConfigureElasticSink(IConfiguration configuration, string indexName)
        {
            var uri = new Uri(configuration.GetValue<string>("Serilog:ElasticConfiguration:Uri", ""));
            var elasticConfig = new ElasticsearchSinkOptions(uri)
            {
                AutoRegisterTemplate = true,
                IndexFormat = $"{indexName.ToLower().Replace(".", "-")}-{DateTime.UtcNow:yyyy-MM}",
                ModifyConnectionSettings = x => x.BasicAuthentication(configuration.GetValue<string>("Serilog:ElasticConfiguration:UserName", ""), configuration.GetValue<string>("Serilog:ElasticConfiguration:Pass", "")),

            };

            return elasticConfig;
        }
    }
}
