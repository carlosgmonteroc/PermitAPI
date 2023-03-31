using Microsoft.AspNetCore.Mvc;
using Permit.Api.Controllers.Common;
using Permit.Application.Permits;
using Permit.Application.Permits.Models;

namespace PermitAPI.Controllers
{
    [Route("api/permits")]
    public class PermitController : BaseController
    {
        private readonly IPermitService permitService;
        private readonly ILogger<PermitTypeController> logger;

        public PermitController(
                IPermitService _permitService,
                ILogger<PermitTypeController> _logger)
        {
            permitService = _permitService;
            logger = _logger;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IEnumerable<PermitViewModel>> GetPermits()
        {
            return await permitService.Get();
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<PermitViewModel> CreatePermit([FromBody] PermitInputViewModel input)
        {
            ArgumentNullException.ThrowIfNull(input);
            return await permitService.Add(input);
        }

        [HttpPut("{Id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<PermitViewModel> UpdatePermitType(int Id, [FromBody] PermitInputViewModel input)
        {
            ArgumentNullException.ThrowIfNull(input);
            return await permitService.Update(Id, input);
        }

        [HttpDelete("{Id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<PermitViewModel> DeletePermitTypes(int Id)
        {
            return await permitService.Delete(Id);
        }
    }
}