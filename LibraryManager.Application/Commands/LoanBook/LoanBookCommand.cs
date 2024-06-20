using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManager.Application.Commands.LoanBook
{
    public class LoanBookCommand : IRequest<Unit>
    {
        public LoanBookCommand(int id)
        {
            Id = id;
        }

        public int Id { get; private set; }
    }
}
