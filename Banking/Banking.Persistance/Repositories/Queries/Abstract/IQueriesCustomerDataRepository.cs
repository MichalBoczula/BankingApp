using BankingApp.DataTransferObject.Internals.CustomerAccountData;
using BankingApp.DataTransferObject.Internals.CutomerPersonalData;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("Banking.Application")]
namespace Banking.Persistance.Repositories.Queries.Abstract
{
    internal interface IQueriesCustomerDataRepository
    {
        public Task<CustomerAccountDataDto> GetCustomerAccountData(Guid customerNumber);

        public Task<CustomerPersonalDataDto> GetCustomerPersonalData(Guid customerNumber);
    }
}
