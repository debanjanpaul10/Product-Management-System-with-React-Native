using Microsoft.EntityFrameworkCore;
using MySql.EntityFrameworkCore.Extensions;
using PMS.Business.Contracts;
using PMS.Business.Managers;
using PMS.Data.Contracts;
using PMS.Data.Entities;
using PMS.Data.Managers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Business Managers
builder.Services.AddScoped<IUserManager, UserManager>();

// Data Managers
builder.Services.AddScoped<IUserDataManager, UserDataManager>();

// System assigned dependencies
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddEntityFrameworkMySQL().AddDbContext<PmsdatabaseContext>(options =>
{
    options.UseMySQL(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder =>
    {
        builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
    });
});

builder.Services.AddApplicationInsightsTelemetry(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();


app.UseAuthorization();
app.MapDefaultControllerRoute();

app.UseCors(builder =>
{
    builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
});

app.Run();
