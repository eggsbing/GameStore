using GameStore.Domain.Base;
using GameStore.Domain.Entities.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Domain.Entities.Games
{
    public class GameComment : BaseEntity<int>, IAudiotable
    {
        public int GameId { get; set; }
        public int UserId { get; set; }

        [Required]
        [MaxLength(500)]
        public string Message { get; set; }
        public byte Rate { get; set; }

        #region Audiotable
        public DateTime CreateDate { get; set; }
        public DateTime? LastModifyDate { get; set; }
        #endregion

        #region Relations
        public Game Game { get; set; }
        public User User { get; set; }
        #endregion
    }
}
