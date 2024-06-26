﻿using LibraryManager.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManager.Core.Entities
{
    public class Book : BaseEntity
    {
        public Book(string title, string author, string iSBN, int publicationYear)
        {
            Title = title;
            Author = author;
            ISBN = iSBN;
            PublicationYear = publicationYear;
            Status = BookStatusEnum.Avaliable;
        }

        public string Title { get; private set; }

        public string Author { get; private set; }

        public string ISBN { get; private set; }

        public BookStatusEnum Status { get; private set; }

        public int PublicationYear { get; private set; }

        public DateTime LoanDate { get; private set; }

        public int? UserId { get; private set; }

        public User Client { get; private set; }

        public void Loan(int idClient)
        {
            if (Status == BookStatusEnum.Avaliable)
            {
                Status = BookStatusEnum.InLoan;
                LoanDate = DateTime.Now;
                UserId = idClient;
            }
        }

        public void Receive()
        {
            if (Status == BookStatusEnum.InLoan && UserId != 0)
            {
                Status = BookStatusEnum.Avaliable;
                UserId = null;
            }
        }
    }
}
