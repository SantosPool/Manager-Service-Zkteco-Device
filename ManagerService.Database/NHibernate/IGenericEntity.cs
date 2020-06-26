using System;
using System.Collections.Generic;
using System.Text;

namespace ManagerService.Database.NHibernate
{
    public interface IGenericEntity<PK>
    {
        PK Id { get; set; }
    }
}
