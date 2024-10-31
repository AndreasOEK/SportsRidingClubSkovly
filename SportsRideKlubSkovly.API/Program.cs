using System.Text;
using MediatR;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;
using Module.User.Application.Abstractions;
using Module.User.Application.Features.UserAccount.Command;
using Module.User.Application.Features.UserAccount.Command.Dto;
using Module.User.Extensions;
using Module.User.Infrastructure.Services;
using SportsRideKlubSkovly.API.Abstractions;
using SportsRideKlubSkovly.API.Extensions;
using SportsRideKlubSkovly.API.Helpers;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(o =>
    {
        o.RequireHttpsMetadata = false;
        o.TokenValidationParameters = new TokenValidationParameters
        {
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Secret"])),
            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            ValidAudience = builder.Configuration["Jwt:Audience"],
            ClockSkew = TimeSpan.Zero
        };
    });

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Configuration.AddEnvironmentVariables();
builder.Services.AddUserModule(builder.Configuration);
builder.Services.AddMediatRModules();
builder.Services.AddEndpoints(Module.User.AssemblyReference.Assembly);
builder.Services.AddScoped(typeof(IPipelineBehavior<,>), typeof(MediatorPipelineBehavior<,>));
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<TokenProvider>();

builder.Services.AddAuthorization();

// builder.Services.ConfigureOptions<JwtOptionsSetup>();
// builder.Services.ConfigureOptions<JwtBearerOptionsSetup>();

builder.Services.AddSwaggerGenWithAuth();

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

// var doesEmailExist = await app.Services
//     .GetRequiredService<IUserRepository>()
//     .DoesUserExist("Admin@SkovlyRideKlub.dk");
//
// if (!doesEmailExist)
//     await app.Services
//         .GetRequiredService<IMediator>()
//         .Send(new SignUpUserCommand(
//             new SignUpUserRequest(
//                 "admin",
//                 "admin",
//                 "Admin",
//                 "",
//                 "12345678",
//                 "Admin@SkovlyRideKlub.dk")));

app.Run();