using Agency.Application.Model;
using FluentNHibernate.Mapping;

namespace Agency.Application.Mappings
{
    public class OwnerMapping : ClassMap<Owner>
    {
        public OwnerMapping()
        {
            Id(o => o.Id);
            Map(o => o.Email).Not.Nullable().Length(50);
            Map(o => o.Name).Not.Nullable().Length(30);
            Map(o => o.Cellphone).Not.Nullable().Length(15);
            Map(o => o.Phone).Nullable();
            Map(o => o.CreationTime).Not.Nullable();
        }
    }
}
