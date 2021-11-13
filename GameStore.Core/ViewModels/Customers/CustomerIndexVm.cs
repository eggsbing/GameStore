using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Core.ViewModels.Customers
{
    public class CustomerIndexVm
    {
        public int Id { get; set; }
        [Display(Name ="Full Name")]
        public string FullName { get; set; }
        [Display(Name ="Email")]
        public string Email { get; set; }
        [Display(Name ="Mobile")]
        public string Mobile { get; set; }
        [Display(Name ="Is Active")]
        public bool IsActive { get; set; }
        [Display(Name ="Sign-in Date")]
        public DateTime CreateDate { get; set; }
    }
}
