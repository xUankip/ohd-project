using Microsoft.AspNetCore.Mvc;
using System;

namespace AspnetCoreMvcStarter.Filters
{
  [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false)]
  public class AllowRolesAttribute : TypeFilterAttribute
  {
    public AllowRolesAttribute(params int[] roles) : base(typeof(RoleAuthorizationFilter))
    {
      Arguments = new object[] { roles };
    }
  }
}
