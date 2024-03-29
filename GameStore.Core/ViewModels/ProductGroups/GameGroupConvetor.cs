﻿using GameStore.Domain.Entities.Games;
using System.Collections.Generic;
using System.Linq;

namespace GameStore.Core.ViewModels.ProductGroups
{
    public static class GameGroupConvetor
    {
        public static GameGroupCreateOrEditVm ToCreateOrEditViewModel(this GameGroup group)
        {
            return new GameGroupCreateOrEditVm
            {
                Title = group.Title,
                CreateDate = group.CreateDate,
                Id = group.Id,
                LastModifyDate = group.LastModifyDate,                
            };
        }

        public static IQueryable<GameGroupCreateOrEditVm> ToCreateOrEditViewModel(this IQueryable<GameGroup> groups)
        {
            return groups.Select(c => c.ToCreateOrEditViewModel());
        }


        public static GameGroupIndexVm ToIndexViewModel(this GameGroup group)
        {
            return new GameGroupIndexVm
            {
                Id = group.Id,
                Title = group.Title,
                CreateDate = group.CreateDate,
                LastModifyDate = group.LastModifyDate
            };
        }
        public static IEnumerable<GameGroupIndexVm> ToIndexViewModel(this IEnumerable<GameGroup> groups)
        {
            return groups.Select(c => c.ToIndexViewModel());
        }
        public static IQueryable<GameGroupIndexVm> ToIndexViewModel(this IQueryable<GameGroup> groups)
        {
            return groups.Select(c => c.ToIndexViewModel());
        }
    }
}
