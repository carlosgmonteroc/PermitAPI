using Microsoft.AspNetCore.Mvc;
using Permit.Application.Common.Models;

namespace Permit.Api.Controllers.Common
{
    [ApiController]
    [ApiVersion("1.0")]
    [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ApiResponseError))]
    public class BaseController : ControllerBase
    {
    }
}
