using CountryData.Standard;
using CountryDataDotnetDemo.Web.Components;
using CountryDataDotnetDemo.Web.Components.Interface;
using Refit;

var builder = WebApplication.CreateBuilder(args);

builder.AddServiceDefaults();

// Load configuration
var backendBaseUrl = builder.Configuration.GetSection("ApiSettings:BackendBaseUrl").Value;
var frontendBaseUrl = builder.Configuration.GetSection("ApiSettings:FrontendBaseUrl").Value;

builder.Services.AddSingleton<CountryHelper>();

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(frontendBaseUrl) });
builder.Services.AddRefitClient<ICountryDataApi>()
    .ConfigureHttpClient(c => c.BaseAddress = new Uri(backendBaseUrl));

var app = builder.Build();

app.MapDefaultEndpoints();

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
