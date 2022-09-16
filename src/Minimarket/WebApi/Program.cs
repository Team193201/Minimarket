using Infrastructure.Extensions;
using MediatR;
using ProductApplication;
using Shaerd;

var builder = WebApplication.CreateBuilder(args);

var appSetting = builder.Configuration.GetSection(nameof(ApplicationSetting)).Get<ApplicationSetting>();

//--------------------------- Services --------------------------------
// Add services to the container.

builder.Services.AddAppDbContext(appSetting.AppDbContextConfig.ConnectionString);
builder.Services.AddRepository();
builder.Services.AddAppIdentity();


builder.Services.AddMediatR(typeof(IProductApplication));
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();


//--------------------------- Configure --------------------------------
// Configure the HTTP request pipeline.
app.IntializeDatabase();
app.UseCustomException();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
