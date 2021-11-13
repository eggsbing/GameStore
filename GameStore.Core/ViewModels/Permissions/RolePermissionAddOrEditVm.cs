using Bz.ClassFinder.Models;
using GameStore.Core.Static;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Core.ViewModels.Permissions
{
    public class RolePermissionAddOrEditVm
    {
        public RolePermissionAddOrEditVm()
        {
            PermissionNames = new List<string>();
        }

        public int Id { get; set; }
        [Display(Name ="Role Name")]
        public string Name { get; set; }

        public List<BzClassInfo> Permissions => Values.Permissions;

        public List<string> PermissionNames { get; set; }
    }
}
