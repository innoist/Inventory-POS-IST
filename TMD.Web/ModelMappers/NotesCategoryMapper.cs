using TMD.Models.DomainModels;
using TMD.Web.Models;

namespace TMD.Web.ModelMappers
{
    public static class NotesCategoryMapper
    {
        public static NotesCategory CreateFromClientToServer(this NotesCategoryModel source)
        {
            return new NotesCategory
            {
                Id=source.Id,
                Name = source.Name,
                Description = source.Description,
                
                RecCreatedBy = source.RecCreatedBy,
                RecCreatedDate = source.RecCreatedDate,
                RecLastUpdatedBy = source.RecLastUpdatedBy,
                RecLastUpdatedDate = source.RecLastUpdatedDate
            };
        }

        public static NotesCategoryModel CreateFromServerToClient(this NotesCategory source)
        {
            return new NotesCategoryModel
            {
                Id = source.Id,
                Name = source.Name,
                Description = source.Description,                

                RecCreatedBy = source.RecCreatedBy,
                RecCreatedDate = source.RecCreatedDate,
                RecLastUpdatedBy = source.RecLastUpdatedBy,
                RecLastUpdatedDate = source.RecLastUpdatedDate
            };
        }
    }
}