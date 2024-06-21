using LibraryManager.Application.Commands.CreateBook;
using LibraryManager.Application.Commands.DeleteBook;
using LibraryManager.Application.Commands.LoanBook;
using LibraryManager.Application.Commands.ReceiveBook;
using LibraryManager.Application.Queries.GetAllBooks;
using LibraryManager.Application.Queries.GetByIdBooks;
using LibraryManager.Application.ViewModels;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManager.API.Controllers
{
    [Route("api/books")]
    public class BooksController : ControllerBase
    {
        private readonly IMediator _mediator;
        public BooksController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var getAllBooksQuery = new GetAllBooksQuery();

            var books = await _mediator.Send(getAllBooksQuery);

            return Ok(books);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var getBookByIdQuery = new GetByIdBookQuery(id);

            var book = await _mediator.Send(getBookByIdQuery);

            return Ok(book);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateBookCommand command)
        {
            var id = await _mediator.Send(command);

            return CreatedAtAction(nameof(GetById), new { id = id }, command);
        }

        [HttpPut("{id}/loan")]
        public async Task<IActionResult> Loan(int id)
        {
            var command = new LoanBookCommand(id);

            await _mediator.Send(command);

            return NoContent();
        }

        [HttpPut("{id}/receive")]
        public async Task<IActionResult> Receive(int id)
        {
            var command = new ReceiveBookCommand(id);

            var result = await _mediator.Send(command);

            var messageModel = new MessageBookReceiveViewModel(result);

            return Ok(messageModel);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var command = new DeleteBookCommand(id);

            await _mediator.Send(command);

            return NoContent();
        }
    }
}
