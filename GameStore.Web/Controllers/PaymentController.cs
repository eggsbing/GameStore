using GameStore.Core.Services;
using GameStore.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZarinpalSandbox;

namespace GameStore.Web.Controllers
{
    [Authorize]
    public class PaymentController : Controller
    {
        private readonly IOrderService _orderService;
        private IConfiguration _configuration;
        public PaymentController(IOrderService orderService, IConfiguration configuration)
        {
            _orderService = orderService;
            _configuration = configuration;
        }

        [Route("cart")]
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Pay()
        {
            var order = _orderService.GetCurrentUserCart();
            if (order == null)
            {
                return NotFound();
            }

            var bankConfig = new BankVm();
            _configuration.GetSection("Bank").Bind(bankConfig);

            var payment = new Payment(order.FinalPrice);
            var result = payment.PaymentRequest($"Pay bill number {order.Id}", $"{bankConfig.CallBackUrl}{order.Id}");

            if (result.Result.Status == 100)
            {
                return Redirect($"{bankConfig.BankUrl}{result.Result.Authority}");
            }
            else
            {
                return NotFound();
            }
        }
    }
}
