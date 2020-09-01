using GSS.DotNetAllInOne.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GSS.DotNetAllInOne.Persistence.Contexts
{
    public class ExamplesDbContext : DbContext
    {
        public ExamplesDbContext(DbContextOptions<ExamplesDbContext> options)
         : base(options)
        {
        }

        public DbSet<Example> Examples { get; set; }
    }
}
