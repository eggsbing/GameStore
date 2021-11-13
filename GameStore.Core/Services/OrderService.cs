using GameStore.Core.Interfaces;
using GameStore.Core.ViewModels.Orders;
using GameStore.Data.Context;
using GameStore.Domain.Entities.Orders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Core.Services
{
    public interface IOrderService
    {
        OrderVm GetCurrentUserCart();
        void AddGameToCart(int gameId);
        OrderVm Find(long id);
        void VerifyOrder(long id, string refId);
    }

    public class OrderService : IOrderService
    {
        private readonly GameStoreContext _context;
        private readonly ICurrentUserService _currentUserService;

        public OrderService(GameStoreContext context, ICurrentUserService currentUserService)
        {
            _context = context;
            _currentUserService = currentUserService;
        }

        public void AddGameToCart(int gameId)
        {
            Order cart = _context.Orders.AsNoTracking()
                .Where(c => c.UserId == _currentUserService.UserId)
                .SingleOrDefault(c => c.IsFinalized == false);
            if (cart == null)
            {
                cart = new Order
                {
                    IsFinalized = false,
                    RegisterDate = DateTime.Now,
                    UserId = _currentUserService.UserId,
                };
                _context.Orders.Add(cart);
                _context.SaveChanges();
            }
            var game = _context.Games.AsNoTracking().Single(c => c.Id == gameId);
            var orderDetail = _context.OrderDetails.SingleOrDefault(c => c.GameId == gameId);
            if (orderDetail == null)
            {
                _context.OrderDetails.Add(new OrderDetails
                {
                    OrderId = cart.Id,
                    Count = 1,
                    Price = game.Price,
                    GameId = gameId,
                });
            }
            else
            {
                orderDetail.Price = game.Price;
                orderDetail.Count++;
                _context.OrderDetails.Update(orderDetail);
            }
            _context.SaveChanges();
        }

        public OrderVm Find(long id)
        {
            var order = _context.Orders
                .AsNoTracking()
                .Include(c => c.OrderDetails).ThenInclude(c => c.Game)
                .SingleOrDefault(c => c.Id == id);
            return order.ToViewModel();
        }

        public OrderVm GetCurrentUserCart()
        {
            var cart = _context.Orders
                .AsNoTracking()
                .Where(c => c.UserId == _currentUserService.UserId)
                .Include(c => c.OrderDetails).ThenInclude(c => c.Game)
                .Include(c => c.User)
                .FirstOrDefault(c => c.IsFinalized == false);

            if (cart == null) return null;

            return cart.ToViewModel();
        }

        public void VerifyOrder(long id, string refId)
        {
            var order = _context.Orders.Find(id);
            order.IsFinalized = true;
            order.PaidDate = DateTime.Now;
            order.RefId = refId;

            _context.Orders.Update(order);
            _context.SaveChanges();
        }
    }
}
