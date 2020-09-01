using GSS.DotNetAllInOne.Domain.Interfaces.Repositories;
using GSS.DotNetAllInOne.Persistence.Contexts;
using GSS.DotNetAllInOne.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace GSS.DotNetAllInOne.Persistence
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistenceLayer(this IServiceCollection services, string connectionString)
        {
            services.AddEntityFrameworkNpgsql()
                 .AddDbContext<ExamplesDbContext>(options =>
                     options.UseNpgsql(connectionString));

            services.AddTransient(typeof(IGenericRepository<,>), typeof(GenericRepository<,>));
            services.AddTransient<IExampleRepository, ExampleRepository>();
            return services;
        }
    }
}
