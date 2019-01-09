using System;

namespace Agency.Application.Model
{
    public class User
    {
        public virtual int Id { get; set; }

        public virtual string Name { get; set; }

        public virtual string Email { get; set; }

        public virtual string Address { get; set; }

        public virtual string IP { get; set; }

        public virtual bool IsDeleted { get; set; }

        public virtual DateTime CreationTime { get; set; }
    }
}
