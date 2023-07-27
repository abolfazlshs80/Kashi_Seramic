

using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Pr_Signal_ir.Application.Extentions
{
    public static class UserExtentions
    {

        public static string GetUserId(this ClaimsPrincipal user)
        {
            if (user.Identity.IsAuthenticated)
                return user?.FindFirst("Id")?.ToString()?.Replace("Id: ","");
            else
                return null;
        }
        public static string GetNameUser(this ClaimsPrincipal user)
        {
            if (user.Identity.IsAuthenticated)
                return user.Identity.Name;
            else
                return null;
        }
    }
}
