using LibraryManager.Application.ViewModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManager.Application.Queries.GetByIdBooks
{
    public class GetByIdBookQuery : IRequest<BookDetailsViewModel>
    {
        public GetByIdBookQuery(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
