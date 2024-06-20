using LibraryManager.Core.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManager.Application.Commands.GiveBackBook
{
    public class GiveBookBackCommandHandler : IRequestHandler<GiveBookBackCommand, Unit>
    {
        private readonly IBookRepository _bookRepository;

        public GiveBookBackCommandHandler(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task<Unit> Handle(GiveBookBackCommand request, CancellationToken cancellationToken)
        {
            var book = await _bookRepository.GetByIdAsync(request.Id);

            book.Receive();

            await _bookRepository.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
