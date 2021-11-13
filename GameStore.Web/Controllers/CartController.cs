using GameStore.Core.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameStore.Web.Controllers
{
    public class CartController : Controller
    {
        private readonly IOrderService _orderService;

        public CartController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        public IActionResult Cart()
        {
            return View();
        }

        [Route("cart/{id}")]
        public IActionResult AddToCart(int id)
        {
            _orderService.AddGameToCart(id);
            return View("Cart");
        }
    }
}
