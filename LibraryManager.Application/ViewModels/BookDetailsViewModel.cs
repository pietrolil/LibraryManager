using LibraryManager.Core.Enums;

namespace LibraryManager.Application.ViewModels
{
    public class BookDetailsViewModel
    {
        public BookDetailsViewModel(int id, string title, string author,BookStatusEnum status, string iSBN, int publicationYear)
        {
            Id = id;
            Title = title;
            Author = author;
            Status = status;
            ISBN = iSBN;
            PublicationYear = publicationYear;
        }

        public int Id { get; private set; }

        public string Title { get; private set; }

        public string Author { get; private set; }

        public BookStatusEnum Status { get; private set; }

        public string ISBN { get; private set; }

        public int PublicationYear { get; private set; }
    }
}
