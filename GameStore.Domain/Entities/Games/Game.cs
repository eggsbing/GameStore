using GameStore.Domain.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Domain.Entities.Games
{
    public class Game : BaseEntity<int>, IAudiotable
    {
        public int GameGroupId { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        public int Price { get; set; }
        public int Discount { get; set; }
        [Required]
        [MaxLength(700)]
        public string Description { get; set; }
        public int Year { get; set; }
        public string Platform { get; set; }
        public int NumberOfPurchase { get; set; }

        // Requirment
        [MaxLength(50)]
        public string CPU { get; set; }
        [MaxLength(50)]
        public string GPU { get; set; }
        [MaxLength(50)]
        public string RAM { get; set; }
        [MaxLength(50)]
        public string FreeSpace { get; set; }

        // Image
        public string ImageName { get; set; }

        #region Adiotable
        public DateTime CreateDate { get; set; }
        public DateTime? LastModifyDate { get; set; }
        #endregion

        #region Relations
        public GameGroup GameGroup { get; set; }
        public ICollection<GameComment> GameComments { get; set; }
        #endregion
    }
}
