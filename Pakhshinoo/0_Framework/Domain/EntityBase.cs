using System;

namespace _0_Framework.Domain
{
    public class EntityBase
    {
        public long Id { get; set; }
        public DateTime CreateDate { get; set; }
        public EntityBase()
        {
            CreateDate = DateTime.Now;
        }
    }
}
