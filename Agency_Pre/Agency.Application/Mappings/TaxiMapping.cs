using Agency.Application.Model;
using FluentNHibernate.Mapping;

namespace Agency.Application.Mappings
{
    public class TaxiMapping : ClassMap<Taxi>
    {
        public TaxiMapping()
        {
            Id(t => t.Id);
            Map(t => t.Name).Not.Nullable().Length(50);
            Map(t => t.UniqueCode).Not.Nullable().Length(60);
            Map(t => t.Longitude).Not.Nullable();
            Map(t => t.Latitude).Not.Nullable();
            Map(t => t.Telephone1).Not.Nullable();
            Map(t => t.Telephone2).Nullable();
            Map(t => t.Telephone3).Nullable();
            Map(t => t.CreationTime).Not.Nullable();

            References(t => t.Owner, "Owner");

        }
    }
}
