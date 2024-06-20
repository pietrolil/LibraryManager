using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManager.Core.Entities
{
    public class User : BaseEntity
    {
        public User(string name, string email)
        {
            Name = name;
            Email = email;
            Loans = new List<Loan>();
        }

        public string Name { get; private set; }

        public string Email { get; private set; }

        public List<Loan> Loans { get; private set; }
    }
}
