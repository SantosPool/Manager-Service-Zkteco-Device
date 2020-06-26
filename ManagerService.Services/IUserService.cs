using ManagerService.Entities.Entities;
using System.Collections.Generic;
namespace ManagerService.Services
{
    public interface IUserService
    {
        void Save(User u);
        IList<User> FindAll();
        User Get(long id);
        void Update(User u);
        void Delete(long id);
        IList<object> GetUsers();
    }
}
