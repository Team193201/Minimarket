using Serilog;

namespace ApiGetWay.Infrastructure
{
    public static class CustomOcelotBuilder
    {
        public static IConfigurationRoot Builder(IWebHostEnvironment webHostEnvironment)
        {
            return new ConfigurationBuilder()
                .SetBasePath(webHostEnvironment.ContentRootPath)
                .AddJsonFile("ocelot.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"ocelot.{webHostEnvironment.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables()
                .Build();
        }
    }
}
