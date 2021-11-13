using GameStore.Domain.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Core.ViewModels.Customers
{
    public static class CustomerConvertor
    {
        public static CustomerIndexVm ToCustomerIndexViewModel(this User user)
        {
            return new CustomerIndexVm
            {
                Id = user.Id,
                FullName = user.FullName,
                Email = user.Email,
                Mobile = user.Mobile,
                CreateDate = user.CreateDate,
                IsActive = user.IsActive
            };
        }

        public static IQueryable<CustomerIndexVm> ToCustomerIndexViewModel(this IQueryable<User> users)
        {
            return users.Select(c => c.ToCustomerIndexViewModel());
        }

        public static IEnumerable<CustomerIndexVm> ToCustomerIndexViewModel(this IEnumerable<User> users)
        {
            return users.Select(c => c.ToCustomerIndexViewModel());
        }
    }
}
