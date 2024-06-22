using LibraryManager.Application.ViewModels;
using LibraryManager.Core.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManager.Application.Commands.ReceiveBook
{
    public class ReceiveBookCommandHandler : IRequestHandler<ReceiveBookCommand, MessageBookReceiveViewModel>
    {
        private readonly IBookRepository _bookRepository;

        public ReceiveBookCommandHandler(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task<MessageBookReceiveViewModel> Handle(ReceiveBookCommand request, CancellationToken cancellationToken)
        {
            var book = await _bookRepository.GetByIdAsync(request.Id);

            book.Receive();

            await _bookRepository.SaveChangesAsync();

            DateTime now = DateTime.Now;

            TimeSpan difference = book.LoanDate.Subtract(now);

            var message = "Entrega em dia";

            if (difference.TotalDays > 0)
            {
                message = $"Atraso de {difference.TotalDays}";
            }

            return new MessageBookReceiveViewModel(message);
        }
    }
}
