using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using AspnetCoreMvcStarter.Data;
using AspnetCoreMvcStarter.Middlewares;
using AspnetCoreMvcStarter.Models;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'ApplicationDbContext' not found.")));

// builder.Services.AddScoped<IPasswordHasher<User>, PasswordHasher<User>>();

// Thêm dịch vụ Session
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options =>
{
  options.IdleTimeout = TimeSpan.FromMinutes(3000);
  options.Cookie.HttpOnly = true;
  options.Cookie.IsEssential = true;
  options.Cookie.SecurePolicy = CookieSecurePolicy.Always; // Đảm bảo cookie chỉ truyền qua HTTPS
  options.Cookie.SameSite = SameSiteMode.Strict; // Hạn chế bị xóa do policy trình duyệt
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

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseSession();
app.UseMiddleware<AuthMiddleware>(); // Đăng ký middleware
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
