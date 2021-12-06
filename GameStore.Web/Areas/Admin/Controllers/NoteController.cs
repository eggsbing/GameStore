using GameStore.Areas.Admin.Controllers;
using GameStore.Core.Services;
using GameStore.Core.ViewModels.Notes;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace GameStore.Web.Areas.Admin.Controllers
{
    public class NoteController : AdminController
    {
        private readonly INoteService _noteService;
        private readonly IWebHostEnvironment _root;

        public NoteController(INoteService noteService, IWebHostEnvironment root)
        {
            _noteService = noteService;
            _root = root;
        }

        public async Task<IActionResult> Index(int id)
        {
            return View(await _noteService.GetNoteDetail(id));
        }

        // GET
        public async Task<IActionResult> Create()
        {
            return View("CreateOrEdit", new NoteCreateOrEditVm());
        }

        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(NoteCreateOrEditVm note)
        {
            if (ModelState.IsValid)
            {
                await _noteService.AddAsync(note);
                return RedirectToAction("Index", "Home");
            }
            return View("CreateOrEdit", note);
        }

        // GET
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var note = await _noteService.FindAsync(id.Value);
            if (note == null)
            {
                return NotFound();
            }
            return View("CreateOrEdit", note);
        }

        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, NoteCreateOrEditVm note)
        {
            if (id != note.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _noteService.EditAsync(note);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await _noteService.Exists(note.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index", "Home");
            }

            return View("CreateOrEdit", note);
        }

        // GET
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var note = await _noteService.FindAsync(id.Value);
            if (note == null)
            {
                return NotFound();
            }

            return View(note);
        }

        // POST
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _noteService.DeleteAsync(id);
            return RedirectToAction("Index", "Home");
        }

        // POST
        [HttpPost]
        [Route("file-upload")]
        public IActionResult UploadImage(IFormFile upload)
        {
            if (upload.Length <= 0) return null;

            var fileName = Guid.NewGuid() + Path.GetExtension(upload.FileName).ToLower();
            var path = Path.Combine(_root.WebRootPath, "upload/notes", fileName);
            using (var stream = new FileStream(path, FileMode.Create))
            {
                upload.CopyTo(stream);
            }
            var url = $"{"/upload/notes/"}{fileName}";

            return Json(new { uploaded = true, url });
        }
    }
}
