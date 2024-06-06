using Banking.Persistance.Repositories.Abstract;
using Banking.Persistance.Repositories.Concrete;
using Microsoft.Extensions.DependencyInjection;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("Banking.API")]
namespace Banking.Persistance.DependencyInjection
{
    internal static class PersistanceDI
    {
        public static IServiceCollection AddPersistance(this IServiceCollection services)
        {
            services.AddScoped<IPersonalDataRepository, PersonalDataRepository>();
            return services;
        }
    }
}
