using AutoMapper;
using Permit.Application.PermitTypes.Models;
using Permit.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Permit.Application.PermitTypes.Mapping
{
    public class PermitViewModelMapping : Profile
    {
        public PermitViewModelMapping() 
        {
            CreateMap<PermitType, PermitTypeViewModel>();
            CreateMap<PermitTypeViewModel, PermitType > ();
        }
    }
}
