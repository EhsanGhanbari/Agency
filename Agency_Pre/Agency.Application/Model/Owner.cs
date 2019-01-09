using System;

namespace Agency.Application.Model
{
    /// <summary>
    /// Owner of the agency
    /// </summary>
    public class Owner 
    {
        public virtual int Id { get; set; }
        public virtual string OwnerName { get; set; }
        public virtual string OwnerEmail { get; set; }
        public virtual string Cellephone { get; set; }
        public virtual DateTime CreationTime { get; set; }
    }
}
