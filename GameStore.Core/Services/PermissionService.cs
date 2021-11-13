using GameStore.Core.Interfaces;
using GameStore.Core.ViewModels.Permissions;
using GameStore.Data.Context;
using GameStore.Domain.Entities.Permission;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Core.Services
{
    public interface IPermissionService
    {
        IQueryable<ShowRoleVm> GetAllRoles();
        Task<bool> AddRoleAsync(RolePermissionAddOrEditVm vm);
        Task<RolePermissionAddOrEditVm> FindRoleAsync(int id);
        Task<bool> UpdateRole(RolePermissionAddOrEditVm vm);
        bool ExistsRole(int id);
        Task<bool> RemoveRoleAsync(int id);
        void RemoveRolePermissions(int roleId);
        Task<bool> CheckPermission(string permissionName);
        bool IsSupperAdmin();
        Task<IList<string>> GetCurrentUserPermissionsAsync();
        bool IsRemovable(int roleId);
    }

    public class PermissionService : IPermissionService
    {
        private readonly GameStoreContext _context;
        private readonly ICurrentUserService _currentUserService;

        public PermissionService(GameStoreContext context, ICurrentUserService currentUserService)
        {
            _context = context;
            _currentUserService = currentUserService;
        }

        public async Task<bool> AddRoleAsync(RolePermissionAddOrEditVm vm)
        {
            try
            {
                var model = new Role()
                {
                    Name = vm.Name
                };
                var role = await _context.Roles.AddAsync(model);
                await _context.SaveChangesAsync();

                foreach (var PermissionName in vm.PermissionNames)
                {
                    await _context.RolePermissions.AddAsync(new RolePermission()
                    {
                        RoleId = role.Entity.Id,
                        PermissionName = PermissionName
                    });
                }
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {

                return false;
            }
        }

        public async Task<bool> CheckPermission(string permissionName)
        {
            return await _context.UserRoles
                .Include(r => r.Role).ThenInclude(r => r.RolePermissions)
                .AnyAsync(p =>
                p.UserId == _currentUserService.UserId &&
                p.Role.RolePermissions.Any(pe => pe.PermissionName == permissionName));

        }

        public bool ExistsRole(int id)
        {
            return _context.Roles.Any(c => c.Id == id);
        }

        public async Task<RolePermissionAddOrEditVm> FindRoleAsync(int id)
        {
            var model = await _context.Roles.Include(c => c.RolePermissions).FirstOrDefaultAsync(c => c.Id == id);

            var vm = model.ToRolePermissionAddOrEditViewModel();
            vm.PermissionNames = _context.RolePermissions
                .Where(c => c.RoleId == id)
                .Select(c => c.PermissionName)
                .ToList();
            return vm;
        }

        public IQueryable<ShowRoleVm> GetAllRoles()
        {
            return _context.Roles
                .Include(c => c.UserRoles)
                .ThenInclude(c => c.User)
                .Select(c => c.ToShowRoleViewModel());
        }

        public async Task<IList<string>> GetCurrentUserPermissionsAsync()
        {
            return await _context.UserRoles.Where(c => c.UserId == _currentUserService.UserId)
                .Include(r => r.Role).ThenInclude(r => r.RolePermissions)
                .SelectMany(c => c.Role.RolePermissions).Select(c => c.PermissionName)
                .Distinct()
                .ToListAsync();
        }

        public bool IsRemovable(int roleId)
        {
            return !_context.UserRoles.Any(c => c.RoleId == roleId);
        }

        public bool IsSupperAdmin()
        {
            return _currentUserService.UserId == 2;
        }

        public async Task<bool> RemoveRoleAsync(int id)
        {
            try
            {
                if (!IsRemovable(id)) return false;
                var role = await _context.Roles.FindAsync(id);
                _context.Roles.Remove(role);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public void RemoveRolePermissions(int roleId)
        {
            var rolePermissions = _context.RolePermissions.Where(c => c.RoleId == roleId);
            _context.RolePermissions.RemoveRange(rolePermissions);
            _context.SaveChanges();
        }

        public async Task<bool> UpdateRole(RolePermissionAddOrEditVm vm)
        {
            try
            {
                var model = new Role()
                {
                    Name = vm.Name
                };
                RemoveRolePermissions(vm.Id);
                _context.Roles.Update(model);
                foreach (var permissionName in vm.PermissionNames)
                {
                    await _context.RolePermissions.AddAsync(
                        new RolePermission()
                        {
                            RoleId = vm.Id,
                            PermissionName = permissionName
                        });
                }

                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}
