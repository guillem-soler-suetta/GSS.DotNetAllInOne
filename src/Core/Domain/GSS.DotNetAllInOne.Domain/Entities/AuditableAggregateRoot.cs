using System;
using System.ComponentModel.DataAnnotations;

namespace GSS.DotNetAllInOne.Domain.Entities
{
    public class AuditableAggregateRoot<TKey> : AggregateRoot<TKey>
    {
        [Timestamp]
        public byte[] RowVersion { get; set; }

        public string CreatedBy { get; set; }

        public DateTime Created { get; set; }

        public string LastModifiedBy { get; set; }

        public DateTime? LastModified { get; set; }
    }
}
