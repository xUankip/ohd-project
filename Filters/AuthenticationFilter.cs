using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace AspnetCoreMvcStarter.Filters
{
  public class AuthenticationFilter : IActionFilter
  {
    public void OnActionExecuting(ActionExecutingContext context)
    {

      if (context.Controller.GetType().Name == "AuthController")
        return;


      if (!context.HttpContext.Session.TryGetValue("UserId", out _))
      {

        context.Result = new RedirectToActionResult("Login", "Auth", null);
      }
    }

    public void OnActionExecuted(ActionExecutedContext context)
    {
    }
  }
}
