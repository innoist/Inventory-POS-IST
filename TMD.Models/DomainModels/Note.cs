namespace TMD.Models.DomainModels
{
    public class Note
    {
        public long Id { get; set; }
        public System.DateTime NotesDate { get; set; }
        public long NotesCategoryId { get; set; }
        public string Description { get; set; }
        public bool IsOpen { get; set; }
        public decimal? Amount { get; set; }
        public System.DateTime RecCreatedDate { get; set; }
        public System.DateTime RecLastUpdatedDate { get; set; }
        public string RecCreatedBy { get; set; }
        public string RecLastUpdatedBy { get; set; }

        public virtual NotesCategory NotesCategory { get; set; }
    }
}
