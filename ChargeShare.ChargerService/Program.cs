using ChargeShare.ChargerService.DAL.Contexts;
using ChargeShare.ChargerService.DAL.Repositories;
using ChargeShare.ChargerService.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Shared.Models;
using System.Numerics;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Authentication.JwtBearer;

var builder = WebApplication.CreateBuilder(args);

var configuration = builder.Configuration;

var jwtConfig = configuration.GetSection("JWT");
var secretKey = jwtConfig["secret"];

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


builder.Services.AddIdentity<ChargeSharedUserModel, IdentityRole<int>>().AddEntityFrameworkStores<ChargerContext>().AddDefaultTokenProviders();

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = jwtConfig["validIssuer"],
        ValidAudience = jwtConfig["validAudience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey))
    };

    options.Events = new JwtBearerEvents
    {
        OnMessageReceived = context =>
        {
            var accessToken = context.Request.Query["access_token"];

            // If the request is for our api...
            var path = context.HttpContext.Request.Path;
            if (!string.IsNullOrEmpty(accessToken) &&
                (path.StartsWithSegments("/api/**")))
            {
                // Read the token out of the query string
                context.Token = accessToken;
            }

            return Task.CompletedTask;
        }
    };
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

app.UseAuthorization();

app.UseAuthentication();

app.Run();
