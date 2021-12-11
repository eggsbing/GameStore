using GameStore.Areas.Admin.Controllers;
using GameStore.Core.Services;
using GameStore.Core.ViewModels.Permissions;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameStore.Web.Areas.Admin.Controllers
{
    public class PermissionController : AdminController
    {
        private readonly IPermissionService _permissionService;

        public PermissionController(IPermissionService permissionService)
        {
            _permissionService = permissionService;
        }

        // GET
        public IActionResult Index()
        {
            return View(_permissionService.GetAllRoles());
        }

        // GET
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var role = await _permissionService.FindRoleAsync(id.Value);
            if (role == null)
            {
                return NotFound();
            }
            return View(role);
        }

        // GET
        public async Task<IActionResult> Add()
        {
            return View("AddOrEdit", new RolePermissionAddOrEditVm());
        }

        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add(RolePermissionAddOrEditVm role)
        {
            if (ModelState.IsValid)
            {
                await _permissionService.AddRoleAsync(role);
                return RedirectToAction(nameof(Index));
            }
            return View("AddOrEdit", role);
        }

        // GET
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var role = await _permissionService.FindRoleAsync(id.Value);
            if (role == null)
            {
                return NotFound();
            }
            return View("AddOrEdit", role);
        }

        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, RolePermissionAddOrEditVm role)
        {
            if (id != role.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _permissionService.UpdateRole(role);
                }
                catch (Exception ex)
                {
                    if (!_permissionService.ExistsRole(role.Id))
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
            return View("AddOrEdit", role);
        }

        // GET
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var role = await _permissionService.FindRoleAsync(id.Value);
            if (role == null)
            {
                return NotFound();
            }
            return View(role);
        }

        // POST
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _permissionService.RemoveRoleAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
