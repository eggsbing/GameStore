using GameStore.Domain.Base;
using GameStore.Domain.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Domain.Entities.Permission
{
    public class Role : BaseEntity<int>
    {
        public string Name { get; set; }

        #region Relations
        public ICollection<UserRole> UserRoles { get; set; }
        public ICollection<RolePermission> RolePermissions { get; set; }
        #endregion

    }
}
