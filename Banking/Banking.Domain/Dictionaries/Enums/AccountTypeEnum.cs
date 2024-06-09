using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("Banking.Persistance")]
namespace Banking.Domain.Dictionaries.Enums
{
    internal enum AccountTypeEnum
    {
        Business = 1, 
        Personal = 2
    }
}
