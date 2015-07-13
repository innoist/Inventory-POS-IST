using System.Collections.Generic;
using TMD.Interfaces.IRepository;
using TMD.Interfaces.IServices;
using TMD.Models.DomainModels;

namespace TMD.Implementation.Services
{
    public class NotesCategoryService : INotesCategoryService
    {
        private readonly INotesCategoryRepository notesCategoryRepository;

        public NotesCategoryService(INotesCategoryRepository notesCategoryRepository)
        {
            this.notesCategoryRepository = notesCategoryRepository;
        }

        public NotesCategory GetNotesCategory(long id)
        {
            return notesCategoryRepository.Find(id);
        }

        public IEnumerable<NotesCategory> GetAllNotesCategories()
        {
            return notesCategoryRepository.GetAll();
        }        

        public long AddNotesCategory(NotesCategory category)
        {
            if (category.Id > 0)
                notesCategoryRepository.Update(category);
            else
                notesCategoryRepository.Add(category);

            notesCategoryRepository.SaveChanges();
            return category.Id;
        }
    }
}

