using GameStore.Core.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZarinpalSandbox;

namespace GameStore.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IGameService _gameService;
        private readonly IOrderService _orderService;

        public HomeController(IGameService gameService, IOrderService orderService)
        {
            _gameService = gameService;
            _orderService = orderService;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Product()
        {
            return View();
        }
        public IActionResult Cart()
        {
            return View();
        }
        public IActionResult Contact()
        {
            return View();
        }
        public IActionResult About()
        {
            return View();
        }

        [Route("detil/{id}")]
        public IActionResult GameDetails(int id)
        {
            return View(_gameService.GetGameDetail(id));
        }

    }
}
