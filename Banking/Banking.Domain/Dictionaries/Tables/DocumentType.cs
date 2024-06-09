using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("Banking.Persistance")]
namespace Banking.Domain.Dictionaries.Tables
{
    internal class DocumentType
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
