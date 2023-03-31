using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Permit.Application.Common.Models
{
    public class ApiResponseError
    {
        public int StatusCode { get; set; }
        public string Error { get; set; }
    }
}
