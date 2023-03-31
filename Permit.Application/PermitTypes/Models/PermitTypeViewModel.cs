using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Permit.Application.PermitTypes.Models
{
    public class PermitTypeViewModel
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAd { get; set; }
        public DateTime LastUpdatedAt { get; set; }
    }
}
