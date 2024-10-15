using SportsRidingClubSkovly.Web.Components;
using SportsRidingClubSkovly.Web.Services;
using SportsRidingClubSkovly.Web.Services.Interface;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHttpClient("API", httpClient =>
{
    httpClient.BaseAddress = new Uri("http://localhost:8080");
});

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddScoped<IUserSessionProxy, UserSessionProxy>();

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

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
