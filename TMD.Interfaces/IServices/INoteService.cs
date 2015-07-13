using System.Collections.Generic;
using TMD.Models.DomainModels;

namespace TMD.Interfaces.IServices
{
    public interface INoteService
    {
        Note GetNote(long id);
        IEnumerable<Note> GetAllNotes();
        long AddNote(Note note);
    }
}
