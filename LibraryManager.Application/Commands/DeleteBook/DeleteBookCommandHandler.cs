using LibraryManager.Application.Commands.DeleteBook;
using LibraryManager.Core.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManager.Application.Commands.DeleteBook
{
    public class DeleteBookCommandHandler : IRequestHandler<DeleteBookCommand, Unit>
    {
        private readonly IBookRepository _bookRepository;

        public DeleteBookCommandHandler(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task<Unit> Handle(DeleteBookCommand request, CancellationToken cancellationToken)
        {
            var book = await _bookRepository.GetByIdAsync(request.Id);

            book.Remove();

            await _bookRepository.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
