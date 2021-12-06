using GameStore.Domain.Entities.Notes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Core.ViewModels.Notes
{
    public static class NoteConvertor
    {
        public static NoteCreateOrEditVm ToCreateOrEditVm(this Note notes)
        {
            return new NoteCreateOrEditVm
            {
                Id = notes.Id,
                Name = notes.Name,
                Text = notes.Text,
                CreateDate = notes.CreateDate
            };
        }

        public static IQueryable<NoteCreateOrEditVm> ToCreateOrEditVm(this IQueryable<Note> notes)
        {
            return notes.Select(c => c.ToCreateOrEditVm());
        }


        public static NoteIndexVm ToNoteIndexVm(this Note note)
        {
            if (note == null) return null;
            return new NoteIndexVm
            {
                Id = note.Id,
                Name = note.Name,
                Text = note.Text,
                CreateDate = note.CreateDate,
                LastModifyDate = note.LastModifyDate
            };
        }

        public static IQueryable<NoteIndexVm> ToNoteIndexVm (this IQueryable<Note> note)
        {
            return note.Select(c => c.ToNoteIndexVm());
        }

        public static IEnumerable<NoteIndexVm> ToNoteIndexVm(this IEnumerable<Note> note)
        {
            return note.Select(c => c.ToNoteIndexVm());
        }


    }
}
