using BankingApp.DataTransferObject.Internals.CutomerPersonalData;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("Banking.Application")]
[assembly: InternalsVisibleTo("Banking.Application.UnitTests")]
[assembly: InternalsVisibleTo("DynamicProxyGenAssembly2")]
namespace Banking.Persistance.Repositories.Queries.Abstract
{
    internal interface IQueriesEmailDataRepository
    {
        Task<EmailDto> GetEmailById(int emailId);
    }
}
