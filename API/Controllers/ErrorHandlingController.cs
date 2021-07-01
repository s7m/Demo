using API.Error;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("errors/{statusCode}")]
    [ApiExplorerSettings(IgnoreApi = true)]
    public class ErrorHandlingController : BaseAPIController
    {
        public IActionResult Error(int statusCode)
        {
            return new ObjectResult(new ApiResponse(statusCode));
        }
    }
}
