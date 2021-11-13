using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Core.Interfaces
{
    public interface IAdminIndexViewModel<TKey>
        where TKey : struct
    {
        public TKey Id { get; set; }
    }

    public interface IAdminCreateOrEditViewModel<TKey>
        where TKey : struct
    {
        public TKey Id { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
