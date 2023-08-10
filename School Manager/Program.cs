using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using School_Manager.Data;
using School_Manager.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddScoped<ISchoolManager, SchoolManager>();
builder.Services.AddSingleton<WeatherForecastService>();


var app = builder.Build();
app.MapGet("/hello", () => "Hi how you doing");
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
