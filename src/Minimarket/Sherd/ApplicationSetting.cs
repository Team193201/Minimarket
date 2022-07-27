namespace Sherd
{
    public class ApplicationSetting
    {
        public AppDbContextConfig AppDbContextConfig { get; set; }
        public Logging Logging { get; set; }
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
}