using Module.User;
using Module.User.Extensions;
using SportsRideKlubSkovly.API.Extensions;
using System.Reflection.Metadata;
using Microsoft.EntityFrameworkCore;
using Module.User.Infrastructure.DbContexts;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Configuration.AddEnvironmentVariables();
builder.Services.AddUserModule(builder.Configuration);
builder.Services.AddMediatRModules();
builder.Services.AddEndpoints(Module.User.AssemblyReference.Assembly);



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

app.Run();