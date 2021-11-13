using GameStore.Core.Interfaces;
using GameStore.Core.Static;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Core.ViewModels.Games
{
    public class GameIndexVm : IAdminIndexViewModel<int>
    {
        public int Id { get; set; }
        
        [Display(Name ="Name")]
        public string Name { get; set; }
        [Display(Name ="Price")]
        public int Price { get; set; }
        [Display(Name ="Discount")]
        public int Discount { get; set; }
        [Display(Name ="Create date")]
        public DateTime CreateDate { get; set; }
        [Display(Name ="Last Edit date")]
        public DateTime? LastModifyDate { get; set; }

        #region GameGroup
        public int GameGroupId { get; set; }

        [Display(Name ="Categories")]
        public string GroupTitle { get; set; }
        #endregion

        #region Image
        [Display(Name="Image")]
        public string ImageName { get; set; }
        public string ImageFullName =>
            !string.IsNullOrEmpty(ImageName)
            ? $"{PathTools.PrductImagePath}{ImageName}"
            : PathTools.PrductImageDefautl;
        #endregion
    }
}
