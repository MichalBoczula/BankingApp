using Banking.Persistance.Context;
using Banking.Persistance.Repositories.Abstract;
using Banking.Persistance.Repositories.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("Banking.API")]
namespace Banking.Persistance.DependencyInjection
{
    internal static class PersistanceDI
    {
        public static IServiceCollection AddPersistance(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<CommandDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("CommandConnection")));
            
            services.AddDbContext<QueryDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("QueryConnection")));

            services.AddScoped<IPersonalDataRepository, PersonalDataRepository>();
            return services;
        }
    }
}