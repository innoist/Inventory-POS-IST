using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using TMD.Interfaces.IServices;
using TMD.Web.ModelMappers;
using TMD.Web.Models;
using TMD.Web.ViewModels;
using TMD.Web.ViewModels.Common;

namespace TMD.Web.Controllers
{
    public class NotesController : Controller
    {
        private readonly INoteService noteService;
        private readonly INotesCategoryService noteCategoryService;

        public NotesController(INoteService noteService, INotesCategoryService noteCategoryService)
        {
            this.noteService = noteService;
            this.noteCategoryService = noteCategoryService;
        }
        //
        // GET: /Note/
        public ActionResult Index()
        {
            IEnumerable<NoteModel> notes = noteService.GetAllNotes().Select(x => x.CreateFromServerToClient());
            return View(notes);
        }

        //
        // GET: /Note/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Note/Create
        public ActionResult Create(long? id)
        {
            NoteViewModel model = new NoteViewModel();
            model.NoteCategories = noteCategoryService.GetAllNotesCategories().Select(x => x.CreateFromServerToClient());
            if (id != null)
            {
                var note = noteService.GetNote((long)id);
                if (note != null)
                    model.NoteModel = note.CreateFromServerToClient();
            }
            return View(model);
        }

        //
        // POST: /Note/Create
        [HttpPost]
        public ActionResult Create(NoteViewModel note)
        {
            try
            {
                if (note.NoteModel.Id == 0)
                {
                    note.NoteModel.RecCreatedBy = User.Identity.Name;
                    note.NoteModel.RecCreatedDate = DateTime.Now;
                }
                note.NoteModel.RecLastUpdatedBy = User.Identity.Name;
                note.NoteModel.RecLastUpdatedDate = DateTime.Now;


                if (noteService.AddNote(note.NoteModel.CreateFromClientToServer()) > 0)
                {
                    //Product Saved
                    TempData["message"] = new MessageViewModel { Message = "Notes category has been saved successfully.", IsSaved = true };
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Note/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Note/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Note/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Note/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
