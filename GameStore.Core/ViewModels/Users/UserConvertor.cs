using GameStore.Domain.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Core.ViewModels.Users
{
    public static class UserConvertor
    {
        public static UserDetailVm ToDetailViewModel(this User user)
        {
            return new UserDetailVm
            {
                Email = user.Email,
                CreateDate = user.CreateDate,
                FullName = user.FullName,
                Id = user.Id,
                IsActive = user.IsActive,
                Mobile = user.Mobile,
                EmailCode = user.EmailCode,
                EmailConfirm = user.EmailConfirm
            };
        }

        public static IQueryable<UserDetailVm> ToDetailViewModel(this IQueryable<User> users)
        {
            return users.Select(user => user.ToDetailViewModel());
        }
    }
}
