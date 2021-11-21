using GameStore.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Core.Services
{
    public interface IEmailCodeService
    {
        Task<bool> EmailCode(Guid id);
    }
    public class EmailCodeService : IEmailCodeService
    {
        private readonly GameStoreContext _context;

        public EmailCodeService(GameStoreContext context)
        {
            _context = context;
        }

        public async Task<bool> EmailCode(Guid id)
        {
            if (await _context.Users.AnyAsync(c => c.EmailCode == id))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
