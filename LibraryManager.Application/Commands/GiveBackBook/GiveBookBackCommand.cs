using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManager.Application.Commands.GiveBackBook
{
    public class GiveBookBackCommand : IRequest<Unit>
    {
        public GiveBookBackCommand(int id)
        {
            Id = id;
        }

        public int Id { get; private set; }
    }
}
