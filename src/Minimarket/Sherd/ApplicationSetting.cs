namespace Shaerd
{
    public class ApplicationSetting
    {
        public AppDbContextConfig AppDbContextConfig { get; set; }
        public Logging Logging { get; set; }
        public AppMongoDB AppMongoDB { get; set; }
    }

    public class AppDbContextConfig
    {
        public string ConnectionString { get; set; }
    }

    public class Logging
    {
        public LogLevel LogLevel { get; set; }
    }

    public class LogLevel
    {
        public string Default { get; set; }
        public string MicrosoftAspNetCore { get; set; }
    }

    public class AppMongoDB
    {
        public string ConnectionUrl { get; set; }
        public string DatabaseName { get; set; }
        public List<string> CollectionNames { get; set; } = new();
    }
}