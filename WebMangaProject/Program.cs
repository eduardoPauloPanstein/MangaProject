using BusinessLogicalLayer.Implementations;
using BusinessLogicalLayer.Interfaces;
using DataAccessLayer;
using DataAccessLayer.Implementations;
using DataAccessLayer.Interfaces;
using Entities.Enums;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddTransient<IMangaService, MangaService>();
builder.Services.AddTransient<IMangaDAL, MangaDAL>();
builder.Services.AddTransient<IUserService, UserService>();
builder.Services.AddTransient<IUserDAL, UserDAL>();
builder.Services.AddTransient<ApiConsumer.IApiConnect, ApiConsumer.ApiConnect>();
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());
builder.Services.AddDbContext<MangaProjectDbContext>(options => options.UseSqlServer("name=ConnectionStrings:SqlServerMangaProjectConnection"));

builder.Services.AddAuthentication("CookieSerieAuth")
    .AddCookie("CookieSerieAuth", opt =>
    {
        opt.Cookie.Name = "SeriesAuthCookie";
    });

builder.Services.AddAuthorization(opt =>
{
    opt.AddPolicy("User", p => p.RequireRole(UserRoles.User.ToString()));
    opt.AddPolicy(UserRoles.Admin.ToString(), p => p.RequireRole(UserRoles.Admin.ToString()));
});

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

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
