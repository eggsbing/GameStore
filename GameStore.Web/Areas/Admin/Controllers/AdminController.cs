using GameStore.Web.Attributes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameStore.Areas.Admin.Controllers
{
    [Area("Admin")]
    //[Authorize]
    [PermissionChecker]
    public class AdminController : Controller
    {
    }
}
