using ApiGetWay.Infrastructure;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;
using Serilog;
using Serilog.Events;

var builder = WebApplication.CreateBuilder(args);

var appSetting = builder.Configuration.GetSection(nameof(ApplicationSetting)).Get<ApplicationSetting>();

//--------------------------- Services --------------------------------
// Add services to the container.

builder.Host.UseSerilog(CustomLoggerConfiguration.CustomCreateLogger(appSetting.Logg, builder.Environment.ContentRootPath));
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddOcelot(CustomOcelotBuilder.Builder(builder.Environment));
builder.Services.AddSingleton(Log.Logger);
var app = builder.Build();


//--------------------------- Configure --------------------------------
//-----------------------------------------------------------
// Configure the HTTP request pipeline.

app.UseSerilogRequestLogging(options =>
{
    // Customize the message template
    options.MessageTemplate = "Handled {RequestPath}";

    // Emit debug-level events instead of the defaults
    options.GetLevel = (httpContext, elapsed, ex) => LogEventLevel.Debug;

    // Attach additional properties to the request completion event
    options.EnrichDiagnosticContext = (diagnosticContext, httpContext) =>
    {
        diagnosticContext.Set("RequestHost", httpContext.Request.Host.Value);
        diagnosticContext.Set("RequestScheme", httpContext.Request.Scheme);
    };
});

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
