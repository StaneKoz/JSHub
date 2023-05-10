using Portfolio.Dal;
using Portfolio.Dal.Interfaces;
using Portfolio.Dal.Repositories;
using Portfolio.Domain.Entity;
using Portfolio.Service.Implementations;
using Portfolio.Service.Interfaces;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Подключение БД
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<AppDBContext>(options =>
{
    options.UseSqlServer(connectionString);
});
// Авторизация
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        // Неавторизованный пользователь попадает в (ниже)
        options.LoginPath = new PathString("/Account/Login"); 
        options.AccessDeniedPath = new PathString("/Account/Login");
    });

// Важно
builder.Services.AddScoped<IBaseRepository<User>, UserRepostory>();
builder.Services.AddScoped<IBaseRepository<Profile>, ProfileRepository>();
builder.Services.AddScoped<IProfileService, ProfileService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IAccountService, AccountService>(); 
builder.Services.AddControllersWithViews();
builder.Services.AddMvc();

var app = builder.Build();
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.UseStaticFiles();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
