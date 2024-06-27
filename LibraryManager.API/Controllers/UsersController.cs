using LibraryManager.Application.Commands.CreateUser;
using LibraryManager.Application.Queries.GetAllBooks;
using LibraryManager.Application.Queries.GetAllUsers;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManager.API.Controllers
{
    [Route("api/users")]
    public class UsersController : ControllerBase
    {
        private readonly IMediator _mediator;
        public UsersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var getAllUsersQuery = new GetAllUsersQuery();

            var users = await _mediator.Send(getAllUsersQuery);

            return Ok(users);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateUserCommand command)
        {
            await _mediator.Send(command);

            return Ok();
        }
    }
}
