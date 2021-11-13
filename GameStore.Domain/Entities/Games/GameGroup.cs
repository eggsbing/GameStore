using GameStore.Domain.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Domain.Entities.Games
{
    public class GameGroup : BaseEntity<int>, IAudiotable
    {
        [Required]
        [MaxLength(50)]
        public string Title { get; set; }

        #region Audiotable
        public DateTime CreateDate { get; set; }
        public DateTime? LastModifyDate { get; set; }
        #endregion

        #region Relations
        public ICollection<Game> Games { get; set; }
        #endregion
    }
}
