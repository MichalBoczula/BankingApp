using AutoMapper;
using Banking.Domain.Entities;
using BankingApp.DataTransferObject.Internals;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("Banking.Persistance.UnitTests")]
namespace Banking.Persistance.Profiles.Queries
{
    internal class QueriesMappingProfiles : Profile
    {
        public QueriesMappingProfiles()
        {
            CreateMap<Customer, CustomerAccountDataDto>().ReverseMap();
        }
    }
}
