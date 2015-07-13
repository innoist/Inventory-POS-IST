using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using TMD.Interfaces.IServices;
using TMD.Models.DomainModels;
using TMD.Web.ModelMappers;
using TMD.Web.Models;
using TMD.Web.ViewModels.Common;

namespace TMD.Web.Controllers
{
    public class NotesCategoryController : Controller
    {
        private readonly INotesCategoryService notesCategoryService;

        public NotesCategoryController(INotesCategoryService notesCategoryService)
        {
            this.notesCategoryService = notesCategoryService;
        }
        //
        // GET: /NotesCategory/
        public ActionResult Index()
        {
            IEnumerable<NotesCategoryModel> notesCategories = notesCategoryService.GetAllNotesCategories().Select(x => x.CreateFromServerToClient());
            return View(notesCategories);
        }

        //
        // GET: /NotesCategory/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /NotesCategory/Create
        public ActionResult Create(long? id)
        {
            NotesCategoryModel model = new NotesCategoryModel();
            if (id != null)
            {
                var category = notesCategoryService.GetNotesCategory((long)id);
                if (category != null)
                    model = category.CreateFromServerToClient();
            }
            return View(model);
        }

        //
        // POST: /NotesCategory/Create
        [HttpPost]
        public ActionResult Create(NotesCategoryModel category)
        {
            try
            {
                if (category.Id == 0)
                {
                    category.RecCreatedBy = User.Identity.Name;
                    category.RecCreatedDate = DateTime.Now;
                }
                category.RecLastUpdatedBy = User.Identity.Name;
                category.RecLastUpdatedDate = DateTime.Now;


                if (notesCategoryService.AddNotesCategory(category.CreateFromClientToServer()) > 0)
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
        // GET: /NotesCategory/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /NotesCategory/Edit/5
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
        // GET: /NotesCategory/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /NotesCategory/Delete/5
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
