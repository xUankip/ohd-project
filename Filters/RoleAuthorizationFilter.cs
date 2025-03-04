using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Linq;

namespace AspnetCoreMvcStarter.Filters
{
  public class RoleAuthorizationFilter : IAuthorizationFilter
  {
    private readonly int[] _allowedRoleIds;

    public RoleAuthorizationFilter(int[] allowedRoleIds)
    {
      _allowedRoleIds = allowedRoleIds;
    }

    public void OnAuthorization(AuthorizationFilterContext context)
    {
      var user = context.HttpContext.User;

      if (!user.Identity.IsAuthenticated)
      {
        context.Result = new RedirectToActionResult("Login", "Auth", null);
        return;
      }

      if (user.HasClaim(c => c.Type == "RoleId"))
      {
        var roleIdClaim = user.FindFirst("RoleId");
        if (roleIdClaim != null && int.TryParse(roleIdClaim.Value, out int roleId))
        {
          if (!_allowedRoleIds.Contains(roleId))
          {
            context.Result = new RedirectToActionResult("AccessDenied", "Auth", null);
          }
        }
      }
      else
      {
        // Nếu không tìm thấy claim RoleId, chuyển hướng đến trang từ chối truy cập
        context.Result = new RedirectToActionResult("AccessDenied", "Auth", null);
      }
    }
  }
}
