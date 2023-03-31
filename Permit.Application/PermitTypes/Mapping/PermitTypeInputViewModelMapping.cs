using AutoMapper;
using Permit.Application.PermitTypes.Models;
using Permit.Domain.Entities;

namespace Permit.Application.PermitTypes.Mapping
{
    public class PermitInputViewModelMapping : Profile
    {
        public PermitInputViewModelMapping()
        {
            CreateMap<PermitType, PermitTypeInputViewModel>();
        }
    }
}
