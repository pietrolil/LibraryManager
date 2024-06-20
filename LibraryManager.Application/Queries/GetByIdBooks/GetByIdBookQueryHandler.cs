using LibraryManager.Application.ViewModels;
using LibraryManager.Core.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManager.Application.Queries.GetByIdBooks
{
    public class GetByIdBookQueryHandler : IRequestHandler<GetByIdBookQuery, BookDetailsViewModel>
    {
        private readonly IBookRepository _bookRepository;

        public GetByIdBookQueryHandler(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task<BookDetailsViewModel> Handle(GetByIdBookQuery request, CancellationToken cancellationToken)
        {
            var book = await _bookRepository.GetByIdAsync(request.Id);

            if (book == null) return null;

            var bookDetailsViewModel = new BookDetailsViewModel(
                book.Id,
                book.Title,
                book.Author,
                book.Status,
                book.ISBN,
                book.PublicationYear
            );

            return bookDetailsViewModel;
        }
    }
}
