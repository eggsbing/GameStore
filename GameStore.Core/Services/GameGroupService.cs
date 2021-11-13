using GameStore.Core.Interfaces;
using GameStore.Core.Utilities.Extensions;
using GameStore.Core.Utilities.Security;
using GameStore.Core.ViewModels.ProductGroups;
using GameStore.Core.ViewModels.Users;
using GameStore.Data.Context;
using GameStore.Domain.Entities.Games;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Core.Services
{
    public interface IGameGroupService : IGenericService<int, GameGroupIndexVm, GameGroupCreateOrEditVm>
    {

    }
    public class GameGroupService : IGameGroupService
    {
        private readonly GameStoreContext _context;

        public GameGroupService(GameStoreContext context)
        {
            _context = context;
        }

        public async Task<bool> AddAsync(GameGroupCreateOrEditVm vm)
        {
            try
            {
                _context.GameGroups.Add(new GameGroup
                {
                    Id = vm.Id,
                    CreateDate = DateTime.Now,
                    Title = vm.Title
                });
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {

                return false;
            }
        }

        public async Task<bool> DeleteAsync(int id)
        {
            try
            {
                var GameGroups = await _context.GameGroups.FindAsync(id);
                _context.GameGroups.Remove(GameGroups);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {

                return false;
            }
        }

        public async Task<bool> EditAsync(GameGroupCreateOrEditVm vm)
        {
            try
            {
                var GameGroups = await _context.GameGroups.FindAsync(vm.Id);
                GameGroups.Title = vm.Title;
                GameGroups.LastModifyDate = DateTime.Now;
                _context.GameGroups.Update(GameGroups);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {

                return false;
            }
        }

        public async Task<GameGroupCreateOrEditVm> FindAsync(int id)
        {
            var model = await _context.GameGroups
                .FirstOrDefaultAsync(m => m.Id == id);
            return model.ToCreateOrEditViewModel();
        }

        public async Task<bool> Exists(int id)
        {
            return await _context.GameGroups.AnyAsync(e => e.Id == id);
        }

        public async Task<List<GameGroupIndexVm>> GetAllAsync()
        {
            return await _context.GameGroups.ToIndexViewModel().ToListAsync();
        }
    }
}
