
using Shaerd;





var applicationSetting = new ApplicationSetting();

var builder = WebApplication.CreateBuilder(args);

applicationSetting = builder.Configuration.GetSection(nameof(ApplicationSetting)).Get<ApplicationSetting>();

new ConfigurationBuilder()
   .SetBasePath(builder.Environment.ContentRootPath)
   .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
   .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", optional: true)
   .AddEnvironmentVariables().Build();

//--------------------------- Services --------------------------------
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();


//--------------------------- Configure --------------------------------
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
