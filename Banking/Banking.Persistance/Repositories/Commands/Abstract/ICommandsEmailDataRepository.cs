using BankingApp.DataTransferObject.Externals;

namespace Banking.Persistance.Repositories.Commands.Abstract
{
    internal interface ICommandsEmailDataRepository
    {
        Task<int> AddEmail(CreatedEmailExternal email, CancellationToken cancellationToken);
    }
}
