using GameStore.Domain.Base;
using GameStore.Domain.Entities.Games;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Domain.Entities.Orders
{
    public class OrderDetails : BaseEntity<int>
    {
        public int GameId { get; set; }
        public int OrderId { get; set; }
        public int Price { get; set; }
        public int Count { get; set; }

        #region Relations
        public Order Order { get; set; }
        public Game Game { get; set; }
        #endregion
    }
}
