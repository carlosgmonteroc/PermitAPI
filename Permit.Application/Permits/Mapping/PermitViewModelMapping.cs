using AutoMapper;
using Permit.Application.Permits.Models;

namespace Permit.Application.Permits.Mapping
{
    public class PermitViewModelMapping : Profile
    {
        public PermitViewModelMapping() 
        {
            CreateMap<Domain.Entities.Permit, PermitViewModel>();
        }
    }
}
