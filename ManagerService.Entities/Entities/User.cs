using ManagerService.Database.NHibernate;
using System;

namespace ManagerService.Entities.Entities
{
    public class User : IGenericEntity<Int64>
    {
        public virtual long Id { get; set; }
        public virtual string Username { get; set; }
        public virtual string Password { get; set; }
    }
}
