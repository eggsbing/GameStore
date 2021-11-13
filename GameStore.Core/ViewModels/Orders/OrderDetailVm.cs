using GameStore.Core.ViewModels.Games;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Core.ViewModels.Orders
{
    public class OrderDetailVm
    {
        public long Id { get; set; }
        public int ProductId { get; set; }
        public long OrderId { get; set; }
        public int Count { get; set; }
        public int Price { get; set; }

        public GameDetailVm Product { get; set; }
    }
}
