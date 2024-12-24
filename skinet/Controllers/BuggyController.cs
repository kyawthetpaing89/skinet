using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using skinet.Errors;

namespace skinet.Controllers
{
    public class BuggyController(StoreContext context) : BaseApiController
    {
        private readonly StoreContext _context = context;

        [HttpGet("notfound")]
        public ActionResult GetNotFoundRequest()
        {

            return NotFound(new ApiResponse(404));
        }

        [HttpGet("servererror")]
        public ActionResult GetServerError()
        {
            return Ok();
        }

        [HttpGet("badrequest")]
        public ActionResult GetBadRequest()
        {
            return BadRequest(new ApiResponse(400));
        }

        [HttpGet("badrequest/{id}")]
        public ActionResult GetBadRequest(int id)
        {
            return Ok();
        }
    }
}