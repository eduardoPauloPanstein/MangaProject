using BusinessLogicalLayer.Implementations;
using BusinessLogicalLayer.Interfaces.IMangaInterfaces;
using BusinessLogicalLayer.Interfaces.IUserInterfaces;
using DataAccessLayer;
using DataAccessLayer.Implementations;
using DataAccessLayer.Interfaces.IMangaInterfaces;
using DataAccessLayer.Interfaces.IUSerInterfaces;
using Entities.Enums;
using Microsoft.AspNetCore.CookiePolicy;
using Microsoft.EntityFrameworkCore;
using MvcPresentationLayer.Apis.MangaProjectApi;
using MvcPresentationLayer.Apis.MangaProjectApi.Mangas;
using MvcPresentationLayer.Utilities;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddTransient<IMangaService, MangaService>();
builder.Services.AddTransient<IMangaDAL, MangaDAL>();
builder.Services.AddTransient<IUserService, BusinessLogicalLayer.Implementations.UserService>();
builder.Services.AddTransient<IUserDAL, UserDAL>();

builder.Services.AddSingleton<IMangaProjectApiUserService, MangaProjectApiUserService>();
builder.Services.AddSingleton<IMangaProjectApiMangaService, MangaProjectApiMangaService>();

builder.Services.AddTransient<ApiConsumer.IApiConnect, ApiConsumer.ApiConnect>();
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());
builder.Services.AddDbContext<MangaProjectDbContext>(options => options.UseSqlServer("name=ConnectionStrings:SqlServerMangaProjectConnection"));

builder.Services.AddAuthentication("CookieSerieAuth")
    .AddCookie("CookieSerieAuth", opt =>
    {
        opt.Cookie.Name = "SeriesAuthCookie";
        opt.LoginPath = "/User/Login"; //401
        opt.AccessDeniedPath = "/Home/Index"; //403 Forbidden !Create view for errors
        opt.ExpireTimeSpan = TimeSpan.FromDays(1);
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

app.UseCors();
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseCookiePolicy(new CookiePolicyOptions
{
    MinimumSameSitePolicy = SameSiteMode.Strict,
    HttpOnly = HttpOnlyPolicy.Always
}); 

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
