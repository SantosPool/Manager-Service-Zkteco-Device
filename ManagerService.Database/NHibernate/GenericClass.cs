using System;
using System.Collections.Generic;
using System.Text;

namespace ManagerService.Database.NHibernate
{
    public abstract class GenericClass : IGenericEntity<Int64>
    {
        public virtual long Id { get; set; }
        public virtual string Name { get; set; }
        public bool Status { get; set; }
    }
}
