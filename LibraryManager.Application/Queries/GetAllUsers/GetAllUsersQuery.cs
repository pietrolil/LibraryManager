using LibraryManager.Application.ViewModels;
using MediatR;

namespace LibraryManager.Application.Queries.GetAllUsers
{
    public class GetAllUsersQuery : IRequest<List<UsersViewModel>>
    {
        public GetAllUsersQuery() { }
    }
}
