using System;
using WordVision.ec.Domain.Entities;

namespace WordVision.ec.Domain.Contracts
{
    public abstract class AuditableEntity : GenericEntity, IAuditableEntity
    {
        public int Id { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime? LastModifiedOn { get; set; }
    }
}
