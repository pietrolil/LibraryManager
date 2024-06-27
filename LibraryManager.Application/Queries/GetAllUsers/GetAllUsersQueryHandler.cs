using LibraryManager.Application.ViewModels;
using LibraryManager.Core.Repositories;
using MediatR;

namespace LibraryManager.Application.Queries.GetAllUsers
{
    public class GetAllUsersQueryHandler : IRequestHandler<GetAllUsersQuery, List<UsersViewModel>>
    {
        private readonly IUserRepository _userRepository;

        public GetAllUsersQueryHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<List<UsersViewModel>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
        {
            var users = await _userRepository.GetAllAsync();

            var usersViewModel = users
                .Select(p => new UsersViewModel(p.Id, p.Name))
                .ToList();

            return usersViewModel;
        }
    }
}
