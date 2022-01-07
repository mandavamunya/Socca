using System;
namespace Socca.Domain.Core.Entities
{
    public class BaseEntity
    {
        public int Id { get; set; }
        public DateTime DateCreated { get; set; }

        protected BaseEntity()
        {
            DateCreated = DateTime.Now;
        }
    }
}
