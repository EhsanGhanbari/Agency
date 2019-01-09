using System;

namespace Agency.Application.Model
{
    public class Taxi
    {
        public virtual long Id { get; set; }
        /// <summary>
        /// name of the agency
        /// </summary>
        public virtual string Name { get; set; }

        /// <summary>
        /// Unique assigned code for the agency
        /// </summary>
        public virtual string UniqueCode { get; set; }
        public virtual decimal Latitude { get; set; }
        public virtual decimal Longitude { get; set; }

        public virtual string Telephone1 { get; set; }
        public virtual string Telephone2 { get; set; }
        public virtual string Telephone3 { get; set; }

        public virtual DateTime CreationTime { get; set; }

        /// <summary>
        /// Owner of the ageny
        /// </summary>
        public virtual Owner Owner { get; set; }
    }

}
