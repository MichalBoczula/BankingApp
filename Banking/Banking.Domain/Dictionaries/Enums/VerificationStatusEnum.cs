using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("Banking.Persistance")]
namespace Banking.Domain.Dictionaries.Enums
{
    internal enum VerificationStatusEnum
    {
        Positive = 1,
        Negative = 2
    }
}
