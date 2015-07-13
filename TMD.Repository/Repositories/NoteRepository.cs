using System.Data.Entity;
using Microsoft.Practices.Unity;
using TMD.Interfaces.IRepository;
using TMD.Models.DomainModels;
using TMD.Repository.BaseRepository;

namespace TMD.Repository.Repositories
{
    public sealed class NoteRepository: BaseRepository<Note>, INoteRepository
    {
        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        public NoteRepository(IUnityContainer container)
            : base(container)
        {
        }

        /// <summary>
        /// Primary database set
        /// </summary>
        protected override IDbSet<Note> DbSet
        {
            get { return db.Notes; }
        }
        #endregion        
    }
}
