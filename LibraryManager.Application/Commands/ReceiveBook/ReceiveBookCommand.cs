using LibraryManager.Application.ViewModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManager.Application.Commands.ReceiveBook
{
    public class ReceiveBookCommand : IRequest<MessageBookReceiveViewModel>
    {
        public ReceiveBookCommand(int id)
        {
            Id = id;
        }

        public int Id { get; private set; }
    }
}
