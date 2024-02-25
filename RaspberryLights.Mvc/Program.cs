using Microsoft.EntityFrameworkCore;
using RaspberryLights.Application;
using RaspberryLights.Application.Interfaces;
using RaspberryLights.Infrastructure;
using RaspberryLights.Application;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddMediatR(cfg =>
    cfg.RegisterServicesFromAssembly(typeof(AssemblyMarker).Assembly));
builder.Services.AddDbContext<RaspberryLightsDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("RaspberryLightsDb")));
builder.Services.AddScoped<IRaspberryLightsDbContext>(provider => provider.GetService<RaspberryLightsDbContext>()!);


var app = builder.Build();


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    "default",
    "{controller=RaspberryLights}/{action=Index}/{id?}");

app.Run();