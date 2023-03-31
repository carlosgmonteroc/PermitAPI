using Microsoft.AspNetCore.Mvc;
using Permit.Api.Controllers.Common;
using Permit.Application.PermitTypes;
using Permit.Application.PermitTypes.Models;

namespace PermitAPI.Controllers
{
    [Route("api/permit_types")]
    public class PermitTypeController : BaseController
    {
        private readonly IPermitTypeService permitTypeService;
        private readonly ILogger<PermitTypeController> logger;

        public PermitTypeController(
                IPermitTypeService _permitTypeService,
                ILogger<PermitTypeController> _logger)
        {
            permitTypeService = _permitTypeService;
            logger = _logger;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IEnumerable<PermitTypeViewModel>> GetPermitTypes()
        {
            return await permitTypeService.Get();
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<PermitTypeViewModel> CreatePermitType([FromBody] PermitTypeInputViewModel input)
        {
            ArgumentNullException.ThrowIfNull(input);
            return await permitTypeService.Add(input);
        }

        [HttpPut("{Id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<PermitTypeViewModel> UpdatePermitType(int Id, [FromBody] PermitTypeInputViewModel input)
        {
            ArgumentNullException.ThrowIfNull(input);
            return await permitTypeService.Update(Id, input);
        }

        [HttpDelete("{Id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<PermitTypeViewModel> DeletePermitTypes(int Id)
        {
            return await permitTypeService.Delete(Id);
        }
    }
}