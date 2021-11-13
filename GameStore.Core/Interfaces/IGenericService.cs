using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Core.Interfaces
{
    public interface IGenericService<TKey, TIndex, TCreateOrEdit>
        where TKey : struct
        where TIndex : IAdminIndexViewModel<TKey>
        where TCreateOrEdit : IAdminCreateOrEditViewModel<TKey>
    {
        Task<TCreateOrEdit> FindAsync(TKey id);

        Task<bool> AddAsync(TCreateOrEdit vm);

        Task<bool> EditAsync(TCreateOrEdit vm);

        Task<bool> DeleteAsync(TKey id);

        Task<List<TIndex>> GetAllAsync();
        Task<bool> Exists(TKey id);
    }
}
