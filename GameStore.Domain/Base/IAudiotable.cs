using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Domain.Base
{
    public interface IAudiotable
    {
        public DateTime CreateDate { get; set; }
        public DateTime? LastModifyDate { get; set; }
    }
}
