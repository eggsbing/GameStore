﻿using GameStore.Core.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZarinpalSandbox;

namespace GameStore.Web.Controllers
{
    public class BackFromBankController : Controller
    {
        private readonly IGameService _gameService;
        private readonly IOrderService _orderService;

        public BackFromBankController(IGameService gameService, IOrderService orderService)
        {
            _gameService = gameService;
            _orderService = orderService;
        }

        
        public IActionResult Index(int id)
        {
            if (HttpContext.Request.Query["Status"] != "" &&
                HttpContext.Request.Query["Status"].ToString().ToLower() == "ok" &&
                HttpContext.Request.Query["Authority"] != "")
            {
                string authority = HttpContext.Request.Query["Authority"].ToString();

                var order = _orderService.Find(id);
                var payment = new Payment(order.FinalPrice);
                var res = payment.Verification(authority).Result;
                if (res.Status == 100)
                {
                    _orderService.VerifyOrder(id, res.RefId.ToString());
                    ViewBag.Code = res.RefId;
                    return View();
                }

            }

            return NotFound();
        }
    }
}
