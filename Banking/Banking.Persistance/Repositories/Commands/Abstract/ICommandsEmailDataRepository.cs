using BankingApp.DataTransferObject.Externals;

namespace Banking.Persistance.Repositories.Commands.Abstract
{
    internal interface ICommandsEmailDataRepository
    {
        Task<int> AddEmail(CreatedEmailExternal email, CancellationToken cancellationToken);
        Task<bool> EditEmail(UpdatedEmailExternal email, int emailId, CancellationToken cancellationToken);
        Task<bool> DeleteEmail(int emailId, CancellationToken cancellationToken);
    }
}
