using Banking.Persistance.Context;
using Banking.Persistance.Profiles;
using Banking.Persistance.Repositories.Base;
using Banking.Persistance.Repositories.Queries.Abstract;
using Banking.Persistance.Repositories.Queries.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
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

            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            services.AddScoped<IQueryDbContext, QueryDbContext>();
            services.AddScoped<ICommandDbContext, CommandDbContext>();
            services.AddScoped<IQueriesCustomerDataRepository, QueriesCustomerDataRepository>();
            services.AddScoped<IQueriesAddressDataRepository, QueriesAddressDataRepository>();
            return services;
        }
    }
}