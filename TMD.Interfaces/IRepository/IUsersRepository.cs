using System.Collections.Generic;
using TMD.Models.DomainModels;

namespace TMD.Interfaces.IRepository
{
    public interface IUsersRepository : IBaseRepository<AspNetUser,int>
    {
        IEnumerable<AspNetUser> GetAllUsers();
    }
}
