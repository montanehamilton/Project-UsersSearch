using System;
using System.Collections.Generic;

namespace UsersSearch.Users.Dtos
{
    public class UserModel
    {
        public Guid Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public IList<Address> Addresses { get; set; } = new List<Address>();

        public int Age { get; set; }

        public IList<Interest> Interests { get; set; } = new List<Interest>();

        public string AvatarUrl { get; set; }
    }
}
