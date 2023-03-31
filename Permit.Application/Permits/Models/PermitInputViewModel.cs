using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Permit.Application.Permits.Models
{
    public class PermitInputViewModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int PermitTypeId { get; set; }
        public DateTime PermitDate { get; set; }
    }
    public class PermitTypeInputViewModelValidator : AbstractValidator<PermitInputViewModel>
    {
        public PermitTypeInputViewModelValidator()
        {
            RuleFor(c => c.FirstName.Length)
            .GreaterThan(3);
            RuleFor(c => c.LastName.Length)
            .GreaterThan(3);
        }
    }
}
