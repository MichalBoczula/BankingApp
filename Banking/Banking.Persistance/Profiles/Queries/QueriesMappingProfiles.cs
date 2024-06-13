using AutoMapper;
using Banking.Domain.Entities;
using BankingApp.DataTransferObject.Internals.CustomerAccountData;
using BankingApp.DataTransferObject.Internals.CutomerPersonalData;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("Banking.Persistance.UnitTests")]
namespace Banking.Persistance.Profiles.Queries
{
    internal class QueriesMappingProfiles : Profile
    {
        public QueriesMappingProfiles()
        {
            CreateMap<Customer, CustomerAccountDataDto>();
            CreateMap<BankingAccount, BankingAccountDto>();
            CreateMap<Operation, OperationDto>();

            CreateMap<Customer, CustomerPersonalDataDto>();
            CreateMap<Address, AddressDto>();
            CreateMap<Email, EmailDto>();
            CreateMap<Phone, PhoneDto>();
        }
    }
}
