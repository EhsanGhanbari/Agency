using Agency.Application.Model;
using FluentNHibernate.Mapping;

namespace Agency.Application.Mappings
{
    public class UserMapping : ClassMap<User>
    {
        public UserMapping()
        {
            Id(u => u.Id);
            Map(u => u.Name).Nullable().Length(50);
            Map(u => u.Email).Not.Nullable().Length(50);
            Map(u => u.Address).Nullable();
            Map(u => u.IsDeleted);
            Map(u => u.CreationTime).Not.Nullable();
        }
    }
}
