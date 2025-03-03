using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using AspnetCoreMvcStarter.Data;
using AspnetCoreMvcStarter.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'ApplicationDbContext' not found.")));

// builder.Services.AddScoped<IPasswordHasher<User>, PasswordHasher<User>>();

// Thêm dịch vụ Session với cấu hình nâng cao
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(3000); // Thời gian hết hạn session
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
    options.Cookie.SameSite = SameSiteMode.Strict; // Bảo vệ CSRF
    options.Cookie.SecurePolicy = CookieSecurePolicy.Always; // Yêu cầu HTTPS
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

// builder.Services.AddIdentity<IdentityUser, IdentityRole>()
//   .AddEntityFrameworkStores<ApplicationDbContext>()
//   .AddDefaultTokenProviders();

builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = "/Auth/Login"; // Account/Login <- default
    options.AccessDeniedPath = "/Auth/AccessDenied"; // Trang 403, đăng nhập rồi nhưng không phải admin hoặc ...
    options.ExpireTimeSpan = TimeSpan.FromMinutes(30);
});

builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

// Add services to the container.
builder.Services.AddControllersWithViews();

// Đăng ký AuthenticationFilter dưới dạng global filter
builder.Services.AddControllersWithViews(options =>
{
    options.Filters.Add<AspnetCoreMvcStarter.Filters.AuthenticationFilter>();
});

var app = builder.Build();

var scope = app.Services.CreateScope();
// tạo mới role
// var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
// // tạo mới user
// var userManager = scope.ServiceProvider.GetRequiredService<UserManager<IdentityUser>>();

// if (!await roleManager.RoleExistsAsync("Admin"))
// {
//   await roleManager.CreateAsync(new IdentityRole("Admin"));
// }

// var adminUser = new IdentityUser
// {
//   UserName = "luyendh@example.com",
//   Email = "luyendh@example.com",
//   EmailConfirmed = true
// };
//
// if (await userManager.FindByEmailAsync(adminUser.Email) == null)
// {
//    var result = await userManager.CreateAsync(adminUser, "Admin@123");
//   if (result.Succeeded)
//   {
//     await userManager.AddToRoleAsync(adminUser, "Admin");
//   }
// }

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

// Middleware để thêm header ngăn cache vào tất cả các response
app.Use(async (context, next) =>
{
    context.Response.Headers["Cache-Control"] = "no-cache, no-store, must-revalidate";
    context.Response.Headers["Pragma"] = "no-cache";
    context.Response.Headers["Expires"] = "0";
    await next();
});

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

// Tạo class AuthenticationFilter trong namespace này nếu chưa có


app.Run();
