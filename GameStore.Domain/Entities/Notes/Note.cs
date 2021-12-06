using GameStore.Domain.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Domain.Entities.Notes
{
    public class Note : BaseEntity<int>, IAudiotable
    {
        [Required]
        [MaxLength]
        public string Name { get; set; }

        [Required]
        public string Text { get; set; }


        #region Adiotable
        public DateTime CreateDate { get; set; }
        public DateTime? LastModifyDate { get; set; }
        #endregion

    }
}
