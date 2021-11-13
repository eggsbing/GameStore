using GameStore.Core.Interfaces;
using GameStore.Core.Static;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Core.ViewModels.Games
{
    public class GameCreateOrEditVm : IAdminCreateOrEditViewModel<int>
    {
        public int Id { get; set; }
        
        [Display(Name = "Game Name")]
        [Required(ErrorMessage ="Please enter {0}")]
        public string Name { get; set; }

        [Display(Name ="Price")]
        [Required(ErrorMessage ="Please enter {0}")]
        public int Price { get; set; }

        [Display(Name = "Discount")]
        public int Discount { get; set; }

        [Display(Name ="Description")]
        [Required(ErrorMessage ="Please enter {0}")]
        public string Description { get; set; }

        [Display(Name = "Year")]
        public int Year { get; set; }

        [Display(Name = "Platform")]
        public string Platform { get; set; }

        [Display(Name = "CPU")]
        public string CPU { get; set; }

        [Display(Name = "GPU")]
        public string GPU { get; set; }

        [Display(Name = "RAM")]
        public string RAM { get; set; }

        [Display(Name = "FreeSpace")]
        public string FreeSpace { get; set; }

        [Display(Name = "Create Date")]
        public DateTime CreateDate { get; set; }

        #region GameGroup
        public int GameGroupId { get; set; }

        [Display(Name = "Categories")]
        public string GroupTitle { get; set; }
        #endregion

        #region Image
        [Display(Name ="Image Name")]
        public IFormFile ImageFile { get; set; }
        public string ImageName { get; set; }
        public string ImageFullName =>
            !string.IsNullOrEmpty(ImageName)
            ? $"{PathTools.PrductImagePath}{ImageName}"
            : PathTools.PrductImageDefautl;
        #endregion
    }
}
