using ApiGetWay.Infrastructure;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;
using Serilog;



var builder = WebApplication.CreateBuilder(args);

var appSetting = builder.Configuration.GetSection(nameof(ApplicationSetting)).Get<ApplicationSetting>();

//--------------------------- Services --------------------------------
// Add services to the container.

builder.Host.UseSerilog(CustomLoggerConfiguration.CustomCreateLogger(appSetting.Logg));
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddOcelot(CustomOcelotBuilder.Builder(builder.Environment));
builder.Services.AddSingleton(Log.Logger);
var app = builder.Build();


//--------------------------- Configure --------------------------------
//-----------------------------------------------------------
// Configure the HTTP request pipeline.

app.UseSerilogRequestLogging();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();
app.UseRouting();
app.UseOcelot();

app.UseAuthorization();

app.MapControllers();

app.Run();
