namespace ApiGetWay.Infrastructure
{
    public class ApplicationSetting
    {
        public LoggSetting Logg { get; set; }
    }

    public class LoggSetting
    {
        public string EnvironmentName { get; set; }
        public ConsoleStting ConsoleStting { get; set; }
        public ElasticsearchSetting ElasticSetting { get; set; }
        public FileStting FileStting { get; set; }
    }

    public class FileStting
    {
        public string OutputTemplate { get; set; }
        public string Path { get; set; }
    } 
    
    public class ConsoleStting
    {
        public string OutputTemplate { get; set; }
    }

    public class ElasticsearchSetting
    {
        public string Url { get; set; }
        public string FileNameFormat { get; set; }
    }
}
