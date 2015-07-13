using System.Collections.Generic;
using TMD.Interfaces.IRepository;
using TMD.Interfaces.IServices;
using TMD.Models.DomainModels;

namespace TMD.Implementation.Services
{
    public class NoteService : INoteService
    {
        private readonly INoteRepository notesRepository;

        public NoteService(INoteRepository notesRepository)
        {
            this.notesRepository = notesRepository;
        }

        public Note GetNote(long id)
        {
            return notesRepository.Find(id);
        }

        public IEnumerable<Note> GetAllNotes()
        {
            return notesRepository.GetAll();
        }        

        public long AddNote(Note note)
        {
            if (note.Id > 0)
                notesRepository.Update(note);
            else
                notesRepository.Add(note);

            notesRepository.SaveChanges();
            return note.Id;
        }
    }
}

