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
                GameName = d.Game.Name,
                Count = d.Count,
                Price = d.Price,
                ProductId = d.GameId,
                Product = d.Game?.ToGameDetailViewModel()
            };
        }





        public static AdminOrderVm ToOrderViewModel(this Order o)
        {
            return new AdminOrderVm
            {
                Id = o.Id,
                UserId = o.UserId,
                UserName = o.User.FullName,
                PaidDate = o.PaidDate,
                RegisterDate = o.RegisterDate,
                IsFinalized = o.IsFinalized,
                RefId = o.RefId,
            };
        }

        public static IEnumerable<AdminOrderVm> ToOrderViewModel(this IEnumerable<Order> order)
        {
            return order.Select(c => c.ToOrderViewModel());
        }

        public static IQueryable<AdminOrderVm> ToOrderViewModel(this IQueryable<Order> order)
        {
            return order.Select(c => c.ToOrderViewModel());
        }







        public static AdminOrderDetailVm ToDetailViewModel(this OrderDetails c)
        {
            return new AdminOrderDetailVm
            {
                Id = c.Id,
                OrderId = c.OrderId,
                ProductId = c.GameId,
                Name = c.Game.Name,
                Count = c.Count,
                Price = c.Price
            };
        }

        public static IEnumerable<AdminOrderDetailVm> ToDetailViewModel(this IEnumerable<OrderDetails> order)
        {
            return order.Select(c => c.ToDetailViewModel());
        }

        public static IQueryable<AdminOrderDetailVm> ToDetailViewModel(this IQueryable<OrderDetails> order)
        {
            return order.Select(c => c.ToDetailViewModel());
        }
    }
}
