using GameStore.Domain.Base;
using GameStore.Domain.Entities.Games;
using GameStore.Domain.Entities.Orders;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Domain.Entities.Users
{
    public class User : BaseEntity<int>, IAudiotable
    {
        [MaxLength(75)]
        public string FullName { get; set; }
        [Required]
        [MaxLength(150)]
        [EmailAddress]
        public string Email { get; set; }
        public Guid EmailCode { get; set; }
        public bool EmailConfirm { get; set; }
        [Required]
        [MaxLength(150)]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [MaxLength(11)]
        public string Mobile { get; set; }
        public bool IsActive { get; set; }

        #region Audiotable
        public DateTime CreateDate { get; set; }
        public DateTime? LastModifyDate { get; set; }
        #endregion

        #region Relations
        public ICollection<Order> Orders { get; set; }
        public ICollection<GameComment> GameComments { get; set; }
        #endregion
    }
}
