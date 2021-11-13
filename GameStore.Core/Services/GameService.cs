using GameStore.Core.Interfaces;
using GameStore.Core.Static;
using GameStore.Core.Utilities.Extensions;
using GameStore.Core.ViewModels.Games;
using GameStore.Data.Context;
using GameStore.Domain.Entities.Games;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using X.PagedList;

namespace GameStore.Core.Services
{
    public interface IGameService : IGenericService<int, GameIndexVm, GameCreateOrEditVm>
    {
        IPagedList<GameDetailVm> GetGamesByGroupId(int groupId, int page = 1);
        GameDetailVm GetGameDetail(int gameId);
    }
    public class GameService : IGameService
    {
        private readonly GameStoreContext _context;

        public GameService(GameStoreContext context)
        {
            _context = context;
        }

        public async Task<bool> AddAsync(GameCreateOrEditVm vm)
        {
            try
            {
                string gameImageName = null;
                if (vm.ImageFile != null)
                {
                    gameImageName = DateTime.Now.ToString("yyyy-dd-mm-ss_") + vm.ImageFile.FileName;
                    var thumbSize = new ThumbSize(100, 100);
                    vm.ImageFile.AddImageToServer(gameImageName, PathTools.PrductImageServerPath, thumbSize);
                }

                await _context.Games.AddAsync(new Game
                {
                    Id = vm.Id,
                    GameGroupId = vm.GameGroupId,
                    Name = vm.Name,
                    Price = vm.Price,
                    Discount = vm.Discount,
                    Platform = vm.Platform,
                    CPU = vm.CPU,
                    GPU = vm.GPU,
                    RAM = vm.RAM,
                    FreeSpace = vm.FreeSpace,
                    CreateDate = DateTime.Now,
                    Description = vm.Description,
                    Year = vm.Year,
                    ImageName = gameImageName,
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
                var Games = await _context.Games.FindAsync(id);
                //Games.ImageName.DeleteImage(PathTools.PrductImageServerPath);
                _context.Games.Remove(Games);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {

                return false;
            }
        }

        public async Task<bool> EditAsync(GameCreateOrEditVm vm)
        {
            try
            {
                var game = await _context.Games.FindAsync(vm.Id);
                if (vm.ImageFile != null)
                {
                    var gameImageName = DateTime.Now.ToString("yyyy-dd-mm-ss_") + vm.ImageFile.FileName;
                    var thumbSize = new ThumbSize(100, 100);
                    vm.ImageFile.AddImageToServer(gameImageName, PathTools.PrductImageServerPath, thumbSize, vm.ImageName);
                    game.ImageName = gameImageName;
                }

                var Games = await _context.Games.FindAsync(vm.Id);
                Games.Name = vm.Name;
                Games.GameGroupId = vm.GameGroupId;
                Games.Price = vm.Price;
                Games.Discount = vm.Discount;
                Games.Description = vm.Description;
                Games.Year = vm.Year;
                Games.Platform = vm.Platform;
                Games.CPU = vm.CPU;
                Games.GPU = vm.GPU;
                Games.RAM = vm.RAM;
                Games.FreeSpace = vm.FreeSpace;
                Games.LastModifyDate = DateTime.Now;
                _context.Games.Update(Games);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {

                return false;
            }
        }

        public async Task<bool> Exists(int id)
        {
            return await _context.Games.AnyAsync(c => c.Id == id);
        }

        public async Task<GameCreateOrEditVm> FindAsync(int id)
        {
            var model = await _context.Games
                .Include(c => c.GameGroup)
                .SingleOrDefaultAsync(c => c.Id == id);
            return model.ToGameCreateOrEditViewModel();
        }

        public async Task<List<GameIndexVm>> GetAllAsync()
        {
            return await _context.Games
                .Include(c => c.GameGroup)
                .OrderByDescending(c => c.Id)
                .ToGameIndexVm().ToListAsync();
        }

        public GameDetailVm GetGameDetail(int gameId)
        {
            var model = _context.Games.Include(c => c.GameGroup).Single(c => c.Id == gameId);
            return model.ToGameDetailViewModel();
        }

        public IPagedList<GameDetailVm> GetGamesByGroupId(int groupId, int page = 1)
        {
            if (page <= 0)
            {
                page = 1;
            }
            return _context.Games
                .Where(c => c.GameGroupId == groupId)
                .Select(c => c.ToGameDetailViewModel())
                .ToPagedList(page, Values.PageSize);
        }
    }
}
