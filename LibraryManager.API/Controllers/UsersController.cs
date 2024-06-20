using LibraryManager.Core.Entities;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManager.API.Controllers
{
    [Route("api/users")]
    public class UsersController : ControllerBase
    {
        [HttpPost]
        public IActionResult Post([FromBody] User body)
        {
            return Ok();
        }
    }
}
