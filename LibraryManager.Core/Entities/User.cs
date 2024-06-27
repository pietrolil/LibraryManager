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
            Books = new List<Book>();
        }

        public string Name { get; private set; }

        public string Email { get; private set; }

        public List<Book>? Books { get; private set; }
    }
}
