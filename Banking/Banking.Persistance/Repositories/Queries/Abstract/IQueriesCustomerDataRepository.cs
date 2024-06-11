using BankingApp.DataTransferObject.Internals;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("Banking.Application")]
namespace Banking.Persistance.Repositories.Queries.Abstract
{
    internal interface IQueriesCustomerDataRepository
    {
        public Task<CustomerAccountDataDto> GetCustomerAccountData(Guid customerNumber);
    }
}
