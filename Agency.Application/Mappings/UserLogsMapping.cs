using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Agency.Application.Model;
using FluentNHibernate.Mapping;

namespace Agency.Application.Mappings
{
    public class UserLogsMapping : ClassMap<UserLogs>
    {
        public UserLogsMapping()
        {
            Id(t => t.Id);
            Map(t => t.LastRequestDateTime).Not.Nullable();
            Map(t => t.IP).Not.Nullable();
            Map(t => t.UserLatitude).Not.Nullable();
            Map(t => t.UserLongitude).Not.Nullable();
        }
    }
}
