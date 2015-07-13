using System.Collections.Generic;
using TMD.Web.Models;

namespace TMD.Web.ViewModels
{
    public class NoteViewModel
    {
        public NoteViewModel()
        {
            NoteCategories = new List<NotesCategoryModel>();
        }
        public NoteModel NoteModel { get; set; }
        public IEnumerable<NotesCategoryModel> NoteCategories { get; set; }
    }
}