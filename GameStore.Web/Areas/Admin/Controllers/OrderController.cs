using GameStore.Areas.Admin.Controllers;
using GameStore.Core.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameStore.Web.Areas.Admin.Controllers
{
    public class OrderController : AdminController
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _orderService.GetAllAsync());
        }

        
        public async Task<IActionResult> OrderDetail(int id)
        {
            return View(await _orderService.GetOrderDetail(id));
        }
    }
}
