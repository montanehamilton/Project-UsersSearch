using System;
using System.Collections.Generic;

namespace UsersSearch.Users
{
    public class User
    {
        public Guid Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public IList<Address> Addresses { get; set; } = new List<Address>();

        public DateTime BirthDate { get; set; }

        public IList<Interest> Interests { get; set; } = new List<Interest>();

        public Avatar Avatar { get; set; }
        public Guid AvatarId { get; set; }
    }
}
