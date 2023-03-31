using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Permit.Application.PermitTypes.Models
{
    public class PermitTypeInputViewModel
    {
        public string Description { get; set; }
    }
    public class PermitTypeInputViewModelValidator : AbstractValidator<PermitTypeInputViewModel>
    {
        public PermitTypeInputViewModelValidator()
        {
            RuleFor(c => c.Description.Length)
            .InclusiveBetween(5, 20);
        }
    }
}
