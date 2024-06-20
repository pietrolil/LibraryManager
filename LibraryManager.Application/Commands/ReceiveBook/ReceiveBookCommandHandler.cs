using LibraryManager.Core.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManager.Application.Commands.ReceiveBook
{
    public class ReceiveBookCommandHandler : IRequestHandler<ReceiveBookCommand, string>
    {
        private readonly IBookRepository _bookRepository;

        public ReceiveBookCommandHandler(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task<string> Handle(ReceiveBookCommand request, CancellationToken cancellationToken)
        {
            var book = await _bookRepository.GetByIdAsync(request.Id);

            book.Receive();

            await _bookRepository.SaveChangesAsync();

            DateTime now = DateTime.Now;

            TimeSpan difference = book.LoanDate.Subtract(now);

            if (difference.TotalDays > 0)
            {
                return $"Atraso de {difference.TotalDays}";
            }

            return "Entrega em dia";
        }
    }
}
