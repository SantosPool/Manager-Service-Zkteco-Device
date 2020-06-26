using ManagerService.Entities.Entities;
using ManagerService.Repositories;
using System.Collections.Generic;

namespace ManagerService.Services.Impl
{
    public class UserServiceImpl : IUserService
    {
        private IUserDAO userDAO;

        public UserServiceImpl(IUserDAO _userDAO)
        {
            this.userDAO = _userDAO;
        }
        public void Save(User u)
        {
            this.userDAO.Save(u);
        }
        public IList<User> FindAll()
        {
            var o = this.userDAO.FindAll();
            return o;
        }
        public User Get(long id)
        {
            return this.userDAO.Get(id);
        }
        public void Update(User u)
        {
            userDAO.Update(u);
        }
        public void Delete(long id)
        {
            userDAO.Delete(id);
        }
        public IList<object> GetUsers()
        {

            return userDAO.GetUsers();
        }
    }
}
