using TMD.Models.DomainModels;
using TMD.Web.Models;

namespace TMD.Web.ModelMappers
{
    public static class NoteMapper
    {
        public static Note CreateFromClientToServer(this NoteModel source)
        {
            return new Note
            {
                Id = source.Id,
                NotesDate = source.NotesDate,
                NotesCategoryId = source.NotesCategoryId,
                IsOpen = source.IsOpen,
                Description = source.Description,
                Amount = source.Amount,

                RecCreatedBy = source.RecCreatedBy,
                RecCreatedDate = source.RecCreatedDate,
                RecLastUpdatedBy = source.RecLastUpdatedBy,
                RecLastUpdatedDate = source.RecLastUpdatedDate
            };
        }

        public static NoteModel CreateFromServerToClient(this Note source)
        {
            return new NoteModel
            {
                Id = source.Id,
                NotesDate = source.NotesDate,
                NotesCategoryId = source.NotesCategoryId,
                IsOpen = source.IsOpen,
                Description = source.Description,
                Amount = source.Amount,
                Category = source.NotesCategory.Name,

                RecCreatedBy = source.RecCreatedBy,
                RecCreatedDate = source.RecCreatedDate,
                RecLastUpdatedBy = source.RecLastUpdatedBy,
                RecLastUpdatedDate = source.RecLastUpdatedDate
            };
        }
    }
}