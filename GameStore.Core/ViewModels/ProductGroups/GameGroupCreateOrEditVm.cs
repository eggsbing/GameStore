using GameStore.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Core.ViewModels.ProductGroups
{
    public class GameGroupCreateOrEditVm : IAdminCreateOrEditViewModel<int>
    {
        public int Id { get; set; }
        [Display(Name = "Title")]
        [Required(ErrorMessage ="Please enter {0}")]
        public string Title { get; set; }
        [Display(Name = "Create date")]
        public DateTime CreateDate { get; set; }

        public DateTime? LastModifyDate { get; set; }
    }
}
