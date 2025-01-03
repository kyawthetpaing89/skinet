using Microsoft.AspNetCore.Mvc;
using skinet.Errors;

namespace skinet.Controllers
{
    [Route("errors/{code}")]
    //[ApiExplorerSettings(IgnoreApi = true)] // Exclude from Swagger documentation
    public class ErrorController : BaseApiController
    {
        [HttpGet]
        public IActionResult Error(int code)
        {
            return new ObjectResult(new ApiResponse(code));
        }
    }
}