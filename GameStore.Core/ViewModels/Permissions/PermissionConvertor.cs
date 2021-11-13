using GameStore.Domain.Entities.Permission;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Core.ViewModels.Permissions
{
    public static class PermissionConvertor
    {
        public static ShowRoleVm ToShowRoleViewModel(this Role r)
        {
            return new ShowRoleVm
            {
                Id = r.Id,
                Name = r.Name,
            };
        }

        public static RolePermissionAddOrEditVm ToRolePermissionAddOrEditViewModel(this Role r)
        {
            return new RolePermissionAddOrEditVm
            {
                Id = r.Id,
                Name = r.Name,
            };
        }
    }
}
