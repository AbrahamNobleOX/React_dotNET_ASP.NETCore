using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class BuggyController : BaseApiController
    {
        [HttpGet("not-found")]
        public ActionResult GetNotFound()
        {
            return NotFound(); // This method returns a 404 Not Found response
        }

        [HttpGet("bad-request")]
        public ActionResult GetBadRequest()
        {
            return BadRequest(new ProblemDetails { Title = "This is a bad request" }); // This method returns a 400 Bad Request response
        }

        [HttpGet("unauthorised")]
        public ActionResult GetUnauthorised()
        {
            return Unauthorized(); // This method returns a 401 Unauthorized response
        }

        [HttpGet("validation-error")]
        public ActionResult GetValidationError()
        {
            // This method returns a 400 Bad Request response with two validation errors
            ModelState.AddModelError("Problem1", "This is the first error");
            ModelState.AddModelError("Problem2", "This is the second error");
            return ValidationProblem();
        }

        [HttpGet("server-error")]
        public ActionResult GetServerError()
        {
            throw new Exception("This is a server error"); // This method throws an exception, which returns a 500 Internal Server Error response, it requires the ExceptionMiddleware to give the desired output
        }

    }
}