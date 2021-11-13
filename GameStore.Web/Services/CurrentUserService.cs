using GameStore.Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace GameStore.Web.Services
{
    public class CurrentUserService : ICurrentUserService
    {
        public CurrentUserService(IHttpContextAccessor httpContextAccessor)
        {
            if (httpContextAccessor?.HttpContext?.User != null && httpContextAccessor.HttpContext.User.Identity.IsAuthenticated)
            {
                UserId = int.Parse(httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier));
                Mobile = httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.MobilePhone);
                Email = httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.Email);
            }
            else
            {
                UserId = 0;
                Mobile = "";
                Email = "";
            }

            UserIp = httpContextAccessor?.HttpContext?.Connection.RemoteIpAddress.ToString();
            UrlReferer = httpContextAccessor?.HttpContext?.Request.Headers["Referer"].ToString();
            CurrentUrl = httpContextAccessor?.HttpContext?.Request.GetDisplayUrl();
        }

        public int UserId { get; }
        public string UserIp { get; }
        public string Mobile { get; }
        public string UrlReferer { get; set; }
        public string CurrentUrl { get; set; }
        public string Email { get; }
    }
}
