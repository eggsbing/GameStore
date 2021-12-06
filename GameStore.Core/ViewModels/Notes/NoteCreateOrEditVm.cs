using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Core.ViewModels.Notes
{
    public class NoteCreateOrEditVm
    {
        public int Id { get; set; }

        [Display(Name = "Title")]
        [Required(ErrorMessage ="please enter {0}")]
        public string Name { get; set; }

        [Display(Name ="Body")]
        [Required(ErrorMessage ="please enter {0}")]
        public string Text { get; set; }

        public DateTime CreateDate { get; set; }
        public DateTime? LastModifyDate { get; set; }
    }
}
