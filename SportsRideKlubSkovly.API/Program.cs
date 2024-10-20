using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Module.User.Extensions;
using Module.User.Infrastructure.Authentication;
using SportsRideKlubSkovly.API.Abstractions;
using SportsRideKlubSkovly.API.Extensions;
using SportsRideKlubSkovly.API.Helpers;
using SportsRideKlubSkovly.API.OptionsSetup;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Configuration.AddEnvironmentVariables();
builder.Services.AddUserModule(builder.Configuration);
builder.Services.AddMediatRModules();
builder.Services.AddEndpoints(Module.User.AssemblyReference.Assembly);
builder.Services.AddScoped(typeof(IPipelineBehavior<,>), typeof(MediatorPipelineBehavior<,>));
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer();

builder.Services.AddAuthorization();

builder.Services.ConfigureOptions<JwtOptionsSetup>();
builder.Services.ConfigureOptions<JwtBearerOptionsSetup>();

builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapEndpoints();
app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.Run();