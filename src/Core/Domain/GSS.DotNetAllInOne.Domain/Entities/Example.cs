using System;

namespace GSS.DotNetAllInOne.Domain.Entities
{
    public class Example : AuditableAggregateRoot<Guid>
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
