using System;

namespace Agency.Application.Model
{
    /// <summary>
    /// Owner of the agency
    /// </summary>
    public class Owner 
    {
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }
        public virtual string Email { get; set; }
        public virtual string Cellphone { get; set; }
        public virtual string Phone { get; set; }
        public virtual DateTime CreationTime { get; set; }
    }
}
