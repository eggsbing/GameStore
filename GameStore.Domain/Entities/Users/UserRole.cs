using GameStore.Domain.Base;
using GameStore.Domain.Entities.Permission;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Domain.Entities.Users
{
    public class UserRole : BaseEntity<int>
    {
        public int UserId { get; set; }
        public int RoleId { get; set; }

        #region Relations
        public User User { get; set; }
        public Role Role { get; set; }
        #endregion
    }
}
