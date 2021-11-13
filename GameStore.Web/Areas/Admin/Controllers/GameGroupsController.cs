using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GameStore.Data.Context;
using GameStore.Domain.Entities.Games;
using GameStore.Core.Services;
using GameStore.Core.ViewModels.ProductGroups;
using Bz.ClassFinder.Attributes;

namespace GameStore.Areas.Admin.Controllers
{
    [BzDescription("Game Group")]
    public class GameGroupsController : AdminController
    {
        //private readonly GameStoreContext _context;

        private readonly IGameGroupService _productGroupService;

        public GameGroupsController(IGameGroupService productGroupService)
        {
            _productGroupService = productGroupService;
        }


        [BzDescription("List")]
        // GET: Admin/GameGroups
        public async Task<IActionResult> Index()
        {
            return View(await _productGroupService.GetAllAsync());
        }

        [BzDescription("Details")]
        // GET: Admin/GameGroups/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gameGroup = await _productGroupService.FindAsync(id.Value);
            if (gameGroup == null)
            {
                return NotFound();
            }

            return View(gameGroup);
        }

        [BzDescription("Create")]
        // GET: Admin/GameGroups/Create
        public IActionResult Create()
        {
            return View("CreateOrEdit", new GameGroupCreateOrEditVm());
        }

        [BzDescription("Create")]
        // POST: Admin/GameGroups/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Title")] GameGroupCreateOrEditVm gameGroup)
        {
            if (ModelState.IsValid)
            {
                await _productGroupService.AddAsync(gameGroup);
                return RedirectToAction(nameof(Index));
            }
            return View("CreateOrEdit", gameGroup);
        }

        [BzDescription("Edit")]
        // GET: Admin/GameGroups/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gameGroup = await _productGroupService.FindAsync(id.Value);
            if (gameGroup == null)
            {
                return NotFound();
            }
            return View("CreateOrEdit" ,gameGroup);
        }

        [BzDescription("Edit")]
        // POST: Admin/GameGroups/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Title,CreateDate,Id")] GameGroupCreateOrEditVm gameGroup)
        {
            if (id != gameGroup.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _productGroupService.EditAsync(gameGroup);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await _productGroupService.Exists(gameGroup.Id))
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
            return View("CreateOrEdit", gameGroup);
        }

        [BzDescription("Delete")]
        // GET: Admin/GameGroups/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gameGroup = await _productGroupService.FindAsync(id.Value);
            if (gameGroup == null)
            {
                return NotFound();
            }

            return View(gameGroup);
        }

        [BzDescription("Delete Confirmed")]
        // POST: Admin/GameGroups/Delete/5
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _productGroupService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }

        //private bool GameGroupExists(int id)
        //{
        //    return _context.GameGroups.Any(e => e.Id == id);
        //}
    }
}
