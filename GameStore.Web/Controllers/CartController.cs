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
            return View(_orderService.GetCurrentUserCart());
        }

        public IActionResult AddToCart(int id)
        {
            _orderService.AddGameToCart(id);
            return RedirectToAction("Cart");
        }

        public IActionResult Delete(int id)
        {
            _orderService.Delete(id);
            return RedirectToAction("Cart");
        }

        public IActionResult Plus(int id)
        {
            _orderService.Plus(id);
            return RedirectToAction("Cart");
        }

        public IActionResult Minus(int id)
        {
            _orderService.Minus(id);
            return RedirectToAction("Cart");
        }
    }
}
