using GameStore.Domain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Domain.Entities.Permission
{
    public class RolePermission : BaseEntity<int>
    {
        public int RoleId { get; set; }
        public string PermissionName { get; set; }

        #region Relations
        public Role Role { get; set; }
        #endregion
    }
}
