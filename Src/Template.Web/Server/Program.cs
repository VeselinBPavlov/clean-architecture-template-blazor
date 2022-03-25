using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using Template.Application;
using Template.Infrastructure;
using Template.Server.Infrastructure.Exstensions;
using Template.Server.Infrastructure.Filters;

var builder = WebApplication.CreateBuilder(args);
ConfigurationManager configuration = builder.Configuration;
IWebHostEnvironment environment = builder.Environment;

// Add services to the container.
builder.Services.AddApplication();
builder.Services.AddInfrastructure(configuration);

builder.Services.AddCors();
builder.Services.Configure<ApplicationSettings>(configuration.GetSection("ApplicationSettings"));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddTokenAuthentication(configuration);

builder.Services.AddHealthChecks();

builder.Services.AddControllersWithViews(options =>
                options.Filters.Add<ApiExceptionFilterAttribute>())
                    .AddFluentValidation();

builder.Services.AddRazorPages();

builder.Services.Configure<ApiBehaviorOptions>(options =>
{
    options.SuppressModelStateInvalidFilter = true;
});

var app = builder.Build();

// Configure the HTTP request pipeline.
await app.UseWebServices(environment)
   .Initialize();

app.Run();
