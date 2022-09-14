using Ocelot.DependencyInjection;
using Ocelot.Middleware;

var builder = WebApplication.CreateBuilder(args);

var configuration = new ConfigurationBuilder()
   .SetBasePath(builder.Environment.ContentRootPath)
   .AddJsonFile("ocelot.json", optional: false, reloadOnChange: true)
   .AddJsonFile($"ocelot.{builder.Environment.EnvironmentName}.json", optional: true)
   .AddEnvironmentVariables().Build();

//--------------------------- Services --------------------------------
// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddOcelot(configuration);

var app = builder.Build();


//--------------------------- Configure --------------------------------
//-----------------------------------------------------------
// Configure the HTTP request pipeline.
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
