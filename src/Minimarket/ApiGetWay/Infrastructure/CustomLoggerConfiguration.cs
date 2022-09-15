using Serilog;
using Serilog.Configuration;
using Serilog.Events;
using Serilog.Sinks.Elasticsearch;
using Serilog.Sinks.SystemConsole.Themes;

namespace ApiGetWay.Infrastructure
{
    public static class CustomLoggerConfiguration
    {
        private static Serilog.ILogger logger;

        public static Serilog.ILogger CustomCreateLogger(LoggSetting loggSetting, string appRootPath)
        {
            if (loggSetting.EnvironmentName is "Development")
                logger = new LoggerConfiguration()
                                 .MinimumLevel.Verbose()
                                 .Enrich.FromLogContext()
                                 .WriteTo.WriteToConsole(loggSetting.ConsoleStting)
                                 .WriteTo.WriteToFile(loggSetting.FileStting, appRootPath)
                                 .CreateLogger();
            else
                logger = new LoggerConfiguration()
                            .MinimumLevel.Verbose()
                            .Enrich.FromLogContext()
                            .WriteTo.WriteToElasticsearch(loggSetting.ElasticSetting)
                            .WriteTo.WriteToFile(loggSetting.FileStting, appRootPath)
                            .CreateLogger();

            return logger;
        }

        public static LoggerConfiguration WriteToFile(this LoggerSinkConfiguration sinkConfiguration, FileStting fileStting, string appRootPath)
        {
            return sinkConfiguration.File(
                 restrictedToMinimumLevel: LogEventLevel.Debug,
                 path: string.Format(fileStting.Path, appRootPath),
                 outputTemplate: fileStting.OutputTemplate,
                 shared: true,
                 rollingInterval: RollingInterval.Day,
                 fileSizeLimitBytes: 10000
                );
        }

        private static LoggerConfiguration WriteToConsole(this LoggerSinkConfiguration sinkConfiguration, ConsoleStting consoleStting)
        {
            return sinkConfiguration.Console(
                restrictedToMinimumLevel: LogEventLevel.Debug,
                outputTemplate: consoleStting.OutputTemplate,
                theme: AnsiConsoleTheme.Code);
        }

        private static LoggerConfiguration WriteToElasticsearch(this LoggerSinkConfiguration sinkConfiguration, ElasticsearchSetting elasticsearchSetting)
        {
            return sinkConfiguration.Elasticsearch(
                new ElasticsearchSinkOptions(
                    new Uri(elasticsearchSetting.Url))
                {
                    AutoRegisterTemplate = true,
                    AutoRegisterTemplateVersion = AutoRegisterTemplateVersion.ESv7,
                    IndexFormat = elasticsearchSetting.FileNameFormat,
                    FailureCallback = e => Console.WriteLine("Unable to submit event " + e.MessageTemplate),
                    EmitEventFailure = EmitEventFailureHandling.WriteToSelfLog |
                    EmitEventFailureHandling.WriteToFailureSink |
                    EmitEventFailureHandling.RaiseCallback,
                    MinimumLogEventLevel = LogEventLevel.Verbose,
                    RegisterTemplateFailure = RegisterTemplateRecovery.IndexAnyway,
                    DeadLetterIndexName = elasticsearchSetting.FileNameFormat
                });
        }
    }
}