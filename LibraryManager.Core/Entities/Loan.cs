using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManager.Core.Entities
{
    public class Loan : BaseEntity
    {
        public Loan(int idUser, int idBook)
        {
            IdUser = idUser;
            IdBook = idBook;
            LoanDate = DateTime.Now;
        }

        public int IdUser { get; private set; }

        public User User { get; private set; }

        public int IdBook { get; private set; }

        public Book Book { get; private set; }

        public DateTime LoanDate { get; private set; }
    }
}
