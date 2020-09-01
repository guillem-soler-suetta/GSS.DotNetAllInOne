using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GSS.DotNetAllInOne.Domain.Entities
{
    public abstract class Entity<TKey> : IHasKey<TKey>
    {
        public TKey Id { get; set; }

    }
}
