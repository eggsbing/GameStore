using Bz.ClassFinder.Attributes;
using GameStore.Core.Services;
using GameStore.Core.Static;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameStore.Web.Attributes
{
    public class PermissionCheckerAttribute : AuthorizeAttribute, IAsyncAuthorizationFilter//,IAuthorizationFilter
    {
        public async Task OnAuthorizationAsync(AuthorizationFilterContext context)
        {
            if (context.HttpContext.User.Identity.IsAuthenticated)
            {
                var controllerActionDescriptor = context.ActionDescriptor as ControllerActionDescriptor;
                if (controllerActionDescriptor?.MethodInfo.GetCustomAttributes(typeof(BzDescriptionAttribute), true).Length > 0)
                {
                    IPermissionService accessService = (IPermissionService)context.HttpContext.RequestServices.GetService(typeof(IPermissionService));

                    if (accessService.IsSupperAdmin())
                    {
                        List<string> plist = Values.Permissions.SelectMany(c => c.Methods.Select(x => x.FullName)).ToList();
                        context.HttpContext.Items.Add("permissions", plist);
                    }
                    else
                    {
                        IList<string> permissions;
                        if (context.HttpContext.Items.TryGetValue("permissions", out object obj) && obj is IList<string> pList)
                            permissions = pList;
                        else
                            permissions = await accessService.GetCurrentUserPermissionsAsync();

                        var area = context.RouteData.Values["area"].ToString();
                        var controller = context.RouteData.Values["controller"].ToString();
                        var action = context.RouteData.Values["action"].ToString();
                        var permission = $"GameStore.Web.Areas.{area}.Controllers.{controller}Controller.{action}";



                        if (permissions.Select(c => c.ToLower()).Contains(permission.ToLower()))
                            context.HttpContext.Items.Add("permissions", permissions);
                        else
                            context.Result = new RedirectResult("/auth/access-denied");
                    }

                }

            }
            else
                context.Result = new RedirectResult("/auth/login");
        }
    }
}
