using LibraryManager.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManager.Application.ViewModels
{
    public class BooksViewModel
    {
        public BooksViewModel(int id, string title, string author, string iSBN, int publicationYear)
        {
            Id = id;
            Title = title;
            Author = author;
            ISBN = iSBN;
            PublicationYear = publicationYear;
        }

        public int Id { get; private set; }

        public string Title { get; private set; }

        public string Author { get; private set; }

        public string ISBN { get; private set; }

        public int PublicationYear { get; private set; }
    }
}
