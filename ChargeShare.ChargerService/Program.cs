using ChargeShare.ChargerService.DAL.Contexts;
using ChargeShare.ChargerService.DAL.Repositories;
using ChargeShare.ChargerService.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Shared.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

builder.Services.AddControllers();


builder.Services.AddDbContext<ChargerContext>(options =>
{
    options.UseSqlServer("Server=(localdb)\\mssqllocaldb; Database=chargerDb; Trusted_Connection=True; trustServerCertificate=true");
});

builder.Services.AddTransient<IChargerRepository, ChargerRepository>();

builder.Services.AddTransient<IChargerService, ChargerService>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("post", policy =>
    {
        policy.AllowCredentials().AllowAnyHeader().AllowAnyMethod();
    });
});


var app = builder.Build();

// Configure the HTTP request pipeline.
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}


app.MapControllers();

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseCors("post");

app.UseRouting();

/*app.UseAuthorization();

app.UseAuthentication();*/

app.Run();
