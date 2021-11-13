using GameStore.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Core.ViewModels.ProductGroups
{
    public class GameGroupIndexVm : IAdminIndexViewModel<int>
    {
        public int Id { get; set; }
        [Display(Name ="Title")]
        public string Title { get; set; }
        [Display(Name ="Create date")]
        public DateTime CreateDate { get; set; }
        [Display(Name ="Last Edit date")]
        public DateTime? LastModifyDate { get; set; }
    }
}
