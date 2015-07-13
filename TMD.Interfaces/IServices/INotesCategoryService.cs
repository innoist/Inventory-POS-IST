using System.Collections.Generic;
using TMD.Models.DomainModels;

namespace TMD.Interfaces.IServices
{
    public interface INotesCategoryService
    {
        NotesCategory GetNotesCategory(long id);
        IEnumerable<NotesCategory> GetAllNotesCategories();
        long AddNotesCategory(NotesCategory notesCategory);
    }
}
