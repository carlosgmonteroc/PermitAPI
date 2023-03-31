using AutoMapper;
using Permit.Application.Permits.Models;

namespace Permit.Application.Permits.Mapping
{
    public class PermitInputViewModelMapping : Profile
    {
        public PermitInputViewModelMapping()
        {
            CreateMap<Domain.Entities.Permit, PermitInputViewModel>();
        }
    }
}
