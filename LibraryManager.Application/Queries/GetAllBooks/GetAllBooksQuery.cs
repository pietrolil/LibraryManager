using MediatR;
using LibraryManager.Application.ViewModels;

namespace LibraryManager.Application.Queries.GetAllBooks
{
    public class GetAllBooksQuery : IRequest<List<BooksViewModel>>
    {
        public GetAllBooksQuery() { }
    }
}
