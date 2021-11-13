using GameStore.Domain.Base;
using GameStore.Domain.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Domain.Entities.Orders
{
    public class Order : BaseEntity<int>
    {
        public int UserId { get; set; }
        public DateTime RegisterDate { get; set; }
        public DateTime? PaidDate { get; set; }
        public bool IsFinalized { get; set; }
        public string RefId { get; set; }

        #region Relations
        public User User { get; set; }
        public ICollection<OrderDetails> OrderDetails { get; set; }
        #endregion
    }
}
