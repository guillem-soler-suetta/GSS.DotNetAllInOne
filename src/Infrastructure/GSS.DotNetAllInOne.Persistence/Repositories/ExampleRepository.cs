using GSS.DotNetAllInOne.Domain.Entities;
using GSS.DotNetAllInOne.Domain.Interfaces.Repositories;
using GSS.DotNetAllInOne.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace GSS.DotNetAllInOne.Persistence.Repositories
{
    public class ExampleRepository : GenericRepository<Example, Guid>, IExampleRepository
    {
        private readonly DbSet<Example> _recipes;

        public ExampleRepository(ExamplesDbContext dbContext) : base(dbContext)
        {
            _recipes = dbContext.Set<Example>();
        }
    }
}
