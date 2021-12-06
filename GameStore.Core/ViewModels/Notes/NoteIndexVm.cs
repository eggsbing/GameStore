using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Core.ViewModels.Notes
{
    public class NoteIndexVm
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Text { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? LastModifyDate { get; set; }
    }
}
