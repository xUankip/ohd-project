namespace AspnetCoreMvcStarter.Middlewares;
using System.Threading.Tasks;

public class AuthMiddleware
{
  private readonly RequestDelegate _next;

  public AuthMiddleware(RequestDelegate next)
  {
    _next = next;
  }

  public async Task Invoke(HttpContext context)
  {
    var path = context.Request.Path.ToString().ToLower();

    // Bỏ qua trang đăng nhập, đăng xuất và tài nguyên tĩnh (CSS, JS, Images)
    if (path.StartsWith("/auth/login") || path.StartsWith("/auth/logout") ||
        path.StartsWith("/css/") || path.StartsWith("/js/") || path.StartsWith("/images/"))
    {
      await _next(context);
      return;
    }

    // Kiểm tra session
    if (context.Session.GetString("UserId") == null)
    {
      // Lưu URL trước khi chuyển hướng đến trang đăng nhập
      string returnUrl = context.Request.Path + context.Request.QueryString;
      context.Session.SetString("ReturnUrl", returnUrl);

      context.Response.Redirect("/Auth/Login");
      return;
    }

    await _next(context);
  }
}
