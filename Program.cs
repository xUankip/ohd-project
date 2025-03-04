using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using AspnetCoreMvcStarter.Data;
using AspnetCoreMvcStarter.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using AspnetCoreMvcStarter.Filters;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'ApplicationDbContext' not found.")));

// Thêm dịch vụ Session với cấu hình được điều chỉnh
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
    options.Cookie.SameSite = SameSiteMode.Lax; // Thay đổi từ Strict sang Lax để dễ hoạt động hơn

    // Trong môi trường Development, không yêu cầu HTTPS
    if (builder.Environment.IsDevelopment())
    {
        options.Cookie.SecurePolicy = CookieSecurePolicy.None; // Cho phép hoạt động trên HTTP trong môi trường phát triển
    }
    else
    {
        options.Cookie.SecurePolicy = CookieSecurePolicy.Always;
    }
});
builder.Services.AddScoped<EmailService>();

// Thêm authentication với cấu hình tương tự
builder.Services.AddAuthentication("CustomAuthScheme")
    .AddCookie("CustomAuthScheme", options =>
    {
        options.Cookie.Name = "CustomAuthCookie";
        options.LoginPath = "/Auth/Login";
        options.LogoutPath = "/Auth/Logout";
        options.AccessDeniedPath = "/Auth/AccessDenied";

        // Áp dụng cùng logic với session cookie
        if (builder.Environment.IsDevelopment())
        {
            options.Cookie.SecurePolicy = CookieSecurePolicy.None;
        }
        else
        {
            options.Cookie.SecurePolicy = CookieSecurePolicy.Always;
        }
        options.Cookie.SameSite = SameSiteMode.Lax;
    });

// Cấu hình cache để ngăn chặn nút back của trình duyệt sau khi logout
builder.Services.AddMvc(options =>
{
    options.Filters.Add(new ResponseCacheAttribute
    {
        NoStore = true,
        Location = ResponseCacheLocation.None
    });
});

// Điều chỉnh cấu hình cookie ứng dụng
builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = "/Auth/Login";
    options.AccessDeniedPath = "/Auth/AccessDenied";
    options.ExpireTimeSpan = TimeSpan.FromMinutes(30);

    // Áp dụng cùng logic với session cookie
    if (builder.Environment.IsDevelopment())
    {
        options.Cookie.SecurePolicy = CookieSecurePolicy.None;
    }
});

builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

// Add services to the container.
builder.Services.AddControllersWithViews();

// Đăng ký AuthenticationFilter dưới dạng global filter
builder.Services.AddControllersWithViews(options =>
{
    options.Filters.Add<AuthenticationFilter>();
});

// Đăng ký RoleAuthorizationFilter để sử dụng với AllowRolesAttribute

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
else
{
    // Trong môi trường phát triển, chỉ áp dụng header cache cho các route cụ thể
    app.Use(async (context, next) =>
    {
        // Chỉ áp dụng cho các route liên quan đến Auth
        if (context.Request.Path.StartsWithSegments("/Auth"))
        {
            context.Response.Headers["Cache-Control"] = "no-cache, no-store, must-revalidate";
            context.Response.Headers["Pragma"] = "no-cache";
            context.Response.Headers["Expires"] = "0";
        }
        await next();
    });
}

app.UseHttpsRedirection();
app.UseStaticFiles();

// Đặt Session middleware trước Routing để đảm bảo nó có sẵn trong toàn bộ pipeline
app.UseSession();
app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
