using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TokaWeb.APP.Attributes
{
    public class AuthorizeAtribute : Attribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext filterContext)
        {
            string token = filterContext.HttpContext.Request.Cookies["user-login"];
            if (!string.IsNullOrEmpty(token))
            {
                // validar token en DB

            }
            else
            {
                filterContext.Result = new RedirectToActionResult("Index", "Login", null);

            }
        }
    }
}
