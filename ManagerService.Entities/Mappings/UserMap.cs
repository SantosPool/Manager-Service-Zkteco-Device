using FluentNHibernate.Mapping;
using ManagerService.Entities.Entities;

namespace ManagerService.Entities.Mappings
{
    public class UserMap : ClassMap<User>
    {
        public UserMap()
        {
            Table("tblUser");
            Id(x => x.Id, "id");
            Map(x => x.Username, "username");
            Map(x => x.Password, "password");
        }
    }
}
