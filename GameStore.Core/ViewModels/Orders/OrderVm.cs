using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Core.ViewModels.Orders
{
    public class OrderVm
    {
        public long Id { get; set; }
        public int UserId { get; set; }
        public DateTime RegisterDate { get; set; }
        public DateTime? PaidDate { get; set; }
        public bool IsFinalized { get; set; }
        public List<OrderDetailVm> OrderDetails { get; set; }

        public int TotalPrice => OrderDetails.Sum(c => c.Price);
        public int FinalPrice => OrderDetails.Sum(c => c.Price * c.Count);
    }
}
