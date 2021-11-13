using GameStore.Core.ViewModels.Games;
using GameStore.Domain.Entities.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Core.ViewModels.Orders
{
    public static class OrderConvertor
    {
        public static OrderVm ToViewModel(this Order o)
        {
            return new OrderVm
            {
                Id = o.Id,
                UserId = o.UserId,
                PaidDate = o.PaidDate,
                RegisterDate = o.RegisterDate,
                IsFinalized = o.IsFinalized,
                OrderDetails = o.OrderDetails?.Select(c => c.ToViewModel()).ToList()
            };
        }

        public static OrderDetailVm ToViewModel(this OrderDetails d)
        {
            return new OrderDetailVm
            {
                Id = d.Id,
                OrderId = d.OrderId,
                Count = d.Count,
                Price = d.Price,
                ProductId = d.GameId,
                Product = d.Game.ToGameDetailViewModel()
            };
        }
    }
}
