using GameStore.Core.Services;
using GameStore.Core.ViewModels.Games;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameStore.Areas.Admin.Controllers
{
    public class GameController : AdminController
    {

        private readonly IGameService _gameService;
        private readonly IGameGroupService _gameGroupService;

        public GameController(IGameService gameService, IGameGroupService gameGroupService)
        {
            _gameService = gameService;
            _gameGroupService = gameGroupService;
        }

        // GET
        public async Task<IActionResult> Index()
        {
            return View(await _gameService.GetAllAsync());
        }

        // GET
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var game = await _gameService.FindAsync(id.Value);
            if (game == null)
            {
                return NotFound();
            }
            return View(game);
        }

        // GET
        public async Task<IActionResult> Create()
        {
            await LoadDropDownList();
            return View("CreateOrEdit", new GameCreateOrEditVm());
        }

        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(GameCreateOrEditVm game)
        {
            if (ModelState.IsValid)
            {
                await _gameService.AddAsync(game);
                return RedirectToAction(nameof(Index));
            }
            await LoadDropDownList();
            return View("CreateOrEdit", game);
        }

        // GET
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var game = await _gameService.FindAsync(id.Value);
            if (game == null)
            {
                return NotFound();
            }
            await LoadDropDownList();
            return View("CreateOrEdit", game);
        }

        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id,GameCreateOrEditVm game)
        {
            if (id != game.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _gameService.EditAsync(game);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await _gameService.Exists(game.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            await LoadDropDownList();
            return View("CreateOrEdit", game);
        }

        // Get
        public async Task<IActionResult> Delete(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }

            var game = await _gameService.FindAsync(id.Value);
            if (game == null)
            {
                return NotFound();
            }
            return View(game);
        }

        // POST
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _gameService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }

        private async Task LoadDropDownList(GameCreateOrEditVm game = null)
        {
            if (game == null)
            {
                ViewBag.Groups = new SelectList(await _gameGroupService.GetAllAsync(), "Id", "Title");
            }
            else
            {
                ViewBag.Groups = new SelectList(await _gameGroupService.GetAllAsync(), "Id", "Title", game.GameGroupId);
            }
        }
    }
}
