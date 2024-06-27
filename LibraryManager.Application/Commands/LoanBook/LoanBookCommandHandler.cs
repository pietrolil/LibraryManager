using LibraryManager.Core.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManager.Application.Commands.LoanBook
{
    public class LoanBookCommandHandler : IRequestHandler<LoanBookCommand, Unit>
    {
        private readonly IBookRepository _bookRepository;

        public LoanBookCommandHandler(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task<Unit> Handle(LoanBookCommand request, CancellationToken cancellationToken)
        {
            var book = await _bookRepository.GetByIdAsync(request.BookId);

            book.Loan(request.UserId);

            await _bookRepository.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
