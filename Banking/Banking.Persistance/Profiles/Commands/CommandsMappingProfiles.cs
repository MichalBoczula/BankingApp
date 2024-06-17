using AutoMapper;
using Banking.Domain.Entities;
using BankingApp.DataTransferObject.Externals;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("Banking.Persistance.UnitTests")]
namespace Banking.Persistance.Profiles.Commands
{
    internal class CommandsMappingProfiles : Profile
    {
        public CommandsMappingProfiles()
        {
            CreateMap<AddressExternal, Address>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.CustomerRef, opt => opt.Ignore());
        }
    }
}
