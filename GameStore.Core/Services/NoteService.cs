using GameStore.Core.Interfaces;
using GameStore.Core.ViewModels.Notes;
using GameStore.Data.Context;
using GameStore.Domain.Entities.Notes;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Core.Services
{
    public interface INoteService
    {
        Task<NoteCreateOrEditVm> FindAsync(int id);

        Task<bool> AddAsync(NoteCreateOrEditVm vm);

        Task<bool> EditAsync(NoteCreateOrEditVm vm);

        Task<bool> DeleteAsync(int id);

        Task<List<NoteIndexVm>> GetAllAsync();
        Task<bool> Exists(int id);
        Task<List<NoteIndexVm>> GetNoteDetail(int id);
    }

    public class NoteService : INoteService
    {
        private readonly GameStoreContext _context;

        public NoteService(GameStoreContext context)
        {
            _context = context;
        }

        public async Task<bool> AddAsync(NoteCreateOrEditVm vm)
        {
            try
            {
                await _context.Notes.AddAsync(new Note
                {
                    Id = vm.Id,
                    Name = vm.Name,
                    Text = vm.Text,
                    CreateDate = DateTime.Now,
                    LastModifyDate = vm.LastModifyDate
                });
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> DeleteAsync(int id)
        {
            try
            {
                var note = await _context.Notes.FindAsync(id);
                _context.Notes.Remove(note);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> EditAsync(NoteCreateOrEditVm vm)
        {
            try
            {
                var Note = await _context.Notes.FindAsync(vm.Id);
                Note.Name = vm.Name;
                Note.Text = vm.Text;
                Note.CreateDate = vm.CreateDate;
                Note.LastModifyDate = DateTime.Now;
                _context.Notes.Update(Note);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> Exists(int id)
        {
            return await _context.Notes.AnyAsync(c => c.Id == id);
        }

        public async Task<NoteCreateOrEditVm> FindAsync(int id)
        {
            var model = await _context.Notes
                .SingleOrDefaultAsync(c => c.Id == id);
            return model.ToCreateOrEditVm();
        }

        public async Task<List<NoteIndexVm>> GetAllAsync()
        {
            return await _context.Notes
                .OrderByDescending(c => c.Id)
                .ToNoteIndexVm().ToListAsync();
        }

        public async Task<List<NoteIndexVm>> GetNoteDetail(int id)
        {
            return await _context.Notes
                .Where(c => c.Id == id)
                .ToNoteIndexVm()
                .ToListAsync();
        }
    }
}
