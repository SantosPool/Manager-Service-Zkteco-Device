using ManagerService.Database.NHibernate;
using ManagerService.Entities.Entities;
using System;
using System.Collections.Generic;

namespace ManagerService.Repositories
{
    public interface IUserDAO : IDAOGeneric<User, Int64>
    {
        IList<object> GetUsers();
    }
}
