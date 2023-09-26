using WeatherApp.Options;
using WeatherApp.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.Configure<WeatherApiOption>(options =>
{
    options.ApiKey = builder.Configuration["ConnectionString:ApiKey"];
    options.BaseUrl = builder.Configuration["ConnectionString:BaseUrl"];
});

builder.Services.AddTransient<IWeatherApiService, WeatherApiService>();
builder.Services.AddHttpClient();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
