using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("Banking.Persistance")]
namespace Banking.Domain.Dictionaries.Enums
{
    internal enum DocumentTypeEnum
    {
        IdCard = 1,
        Passport = 2
    }
}
