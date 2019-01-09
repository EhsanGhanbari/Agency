using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agency.Application.Model
{
    public class UserLogs
    {
        public virtual long Id { get; set; }
        public virtual DateTime LastRequestDateTime { get; set; }
        public virtual string IP { get; set; }
        public virtual decimal UserLatitude { get; set; }
        public virtual decimal UserLongitude { get; set; }
    }
}
