using Microsoft.AspNetCore.Authentication.Cookies;
using SportsRidingClubSkovly.Web.Components;
using SportsRidingClubSkovly.Web.Services;
using SportsRidingClubSkovly.Web.Services.Interface;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(option =>
    {
        option.Cookie.Name = "auth_token";
        option.LoginPath = "/login";
        option.Cookie.MaxAge = TimeSpan.FromDays(7);
        option.AccessDeniedPath = "/access-denied";
    });

builder.Services.AddAuthorization();
builder.Services.AddCascadingAuthenticationState();
builder.Services.AddHttpContextAccessor();

var httpClientName = builder.Configuration["ApiHttpClientName"];
ArgumentNullException.ThrowIfNullOrEmpty(httpClientName);

builder.Services.AddHttpClient(httpClientName, httpClient =>
{
    httpClient.BaseAddress = new Uri("http://localhost:9000");
});

builder.Services.AddScoped<IUserManagementProxy, UserManagementProxy>();
builder.Services.AddScoped<IAccountProxy, AccountProxy>();

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddScoped<IUserSessionProxy, UserSessionProxy>();

// builder.Services.AddHttpContextAccessor();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.UseAuthentication();
app.UseAuthorization();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();

