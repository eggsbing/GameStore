using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Core.ViewModels.Permissions
{
    public class ShowRoleVm
    {
        public int Id { get; set; }

        [Display(Name ="Role Name")]
        public string Name { get; set; }
    }
}
