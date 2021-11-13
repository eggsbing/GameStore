using GameStore.Core.Interfaces;
using GameStore.Core.ViewModels.Customers;
using GameStore.Core.ViewModels.ProductGroups;
using GameStore.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Core.Services
{
    public interface ICustomerService
    {
        Task<List<CustomerIndexVm>> GetAllAsync();
    }

    public class CustomerService : ICustomerService
    {
        private readonly GameStoreContext _context;

        public CustomerService(GameStoreContext gameStoreContext)
        {
            _context = gameStoreContext;
        }

        public async Task<List<CustomerIndexVm>> GetAllAsync()
        {
            return await _context.Users.ToCustomerIndexViewModel().ToListAsync();
        }
    }
}
