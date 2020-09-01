using GSS.DotNetAllInOne.Domain.Entities;
using System;

namespace GSS.DotNetAllInOne.Domain.Interfaces.Repositories
{
    public interface IExampleRepository : IGenericRepository<Example, Guid>
    {
    }
}
