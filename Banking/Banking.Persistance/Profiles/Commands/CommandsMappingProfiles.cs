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
            CreateMap<CreatedAddressExternal, Address>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.CustomerRef, opt => opt.Ignore());

            CreateMap<UpdatedAddressExternal, Address>()
               .ForMember(dest => dest.Id, opt => opt.Ignore())
               .ForMember(dest => dest.CustomerId, opt => opt.Ignore())
               .ForMember(dest => dest.CustomerRef, opt => opt.Ignore())
               .ForMember(dest => dest.VerificationStatus, opt => opt.Ignore());

            CreateMap<CreatedEmailExternal, Email>()
               .ForMember(dest => dest.Id, opt => opt.Ignore())
               .ForMember(dest => dest.CustomerRef, opt => opt.Ignore());

            CreateMap<UpdatedEmailExternal, Email>()
               .ForMember(dest => dest.Id, opt => opt.Ignore())
               .ForMember(dest => dest.CustomerId, opt => opt.Ignore())
               .ForMember(dest => dest.CustomerRef, opt => opt.Ignore())
               .ForMember(dest => dest.VerificationStatus, opt => opt.Ignore());

        }
    }
}
