using LibraryManager.Application.ViewModels;
using LibraryManager.Core.Repositories;
using MediatR;
using System.Linq;

namespace LibraryManager.Application.Queries.GetAllBooks
{
    public class GetAllBooksQueryHandler : IRequestHandler<GetAllBooksQuery, List<BooksViewModel>>
    {
        private readonly IBookRepository _bookRepository;

        public GetAllBooksQueryHandler(IBookRepository bookRepository) {
            _bookRepository = bookRepository;
        }

        public async Task<List<BooksViewModel>> Handle(GetAllBooksQuery request, CancellationToken cancellationToken)
        {
            var books = await _bookRepository.GetAllAsync();

            var booksViewModel = books
                .Select(p => new BooksViewModel(p.Id, p.Title, p.Author, p.ISBN, p.PublicationYear))
                .ToList();

            return booksViewModel;
        }
    }
}
