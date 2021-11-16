using GameStore.Domain.Entities.Games;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Core.ViewModels.Games
{
    public static class GameConvertor
    {

        public static GameDetailVm ToGameDetailViewModel(this Game product)
        {
            if (product == null) return null;
            return new GameDetailVm
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                Discount = product.Discount,
                GameGroupId = product.GameGroupId,
                GameGroupTitle = product.GameGroup?.Title,
                Price = product.Price,
                Year = product.Year,
                CPU = product.CPU,
                GPU = product.GPU,
                RAM = product.RAM,
                FreeSpace = product.FreeSpace,
                ImageName = product.ImageName,
            };
        }


        public static GameCreateOrEditVm ToGameCreateOrEditViewModel(this Game game)
        {
            return new GameCreateOrEditVm
            {
                Id = game.Id,
                Name = game.Name,
                GameGroupId = game.GameGroupId,
                GroupTitle = game.GameGroup?.Title,
                Price = game.Price,
                Discount = game.Discount,
                Description =game.Description,
                Year = game.Year,
                Platform = game.Platform,
                CPU = game.CPU,
                GPU = game.GPU,
                RAM = game.RAM,
                FreeSpace = game.FreeSpace,
                CreateDate = game.CreateDate,
                ImageName = game.ImageName,
            };
        }

        public static IQueryable<GameCreateOrEditVm> ToGameCreateOrEditViewModel(this IQueryable<Game> games)
        {
            return games.Select(c => c.ToGameCreateOrEditViewModel());
        }

        public static GameIndexVm ToGameIndexVm(this Game game)
        {
            return new GameIndexVm
            {
                Id = game.Id,
                Name = game.Name,
                GameGroupId = game.GameGroupId,
                GroupTitle = game.GameGroup?.Title,
                Price = game.Price,
                Discount = game.Discount,
                CreateDate = game.CreateDate,
                LastModifyDate = game.LastModifyDate,
                ImageName = game.ImageName,
            };
        }

        public static IEnumerable<GameIndexVm> ToGameIndexVm(this IEnumerable<Game> games)
        {
            return games.Select(c => c.ToGameIndexVm());
        }

        public static IQueryable<GameIndexVm> ToGameIndexVm(this IQueryable<Game> games)
        {
            return games.Select(c => c.ToGameIndexVm());
        }
    }
}
