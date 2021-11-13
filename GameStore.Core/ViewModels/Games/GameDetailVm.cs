using GameStore.Core.Static;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Core.ViewModels.Games
{
    public class GameDetailVm
    {
        public int Id { get; set; }
        public int GameGroupId { get; set; }
        public string GameGroupTitle { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public int Year { get; set; }
        public int Discount { get; set; }
        public int FinalPrice => Price - Discount;
        public string Description { get; set; }
        public string CPU { get; set; }
        public string GPU { get; set; }
        public string RAM { get; set; }
        public string FreeSpace { get; set; }

        #region Image
        public string ImageName { get; set; }
        public string ImageFullName =>
            !string.IsNullOrEmpty(ImageName)
            ? $"{PathTools.PrductImagePath}{ImageName}"
            : PathTools.PrductImageDefautl;
        #endregion
    }
}
