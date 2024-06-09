using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("Banking.Persistance")]
namespace Banking.Domain.Dictionaries.Enums
{
    internal enum OperationTypeEnum
    {
        BankingTransfer = 1,
        AtmOperation = 2,
        BLIK = 3,
        CardPayment= 4
    }
}
