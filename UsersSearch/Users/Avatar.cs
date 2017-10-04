using System;

namespace UsersSearch.Users
{
    public class Avatar
    {
        public Guid Id { get; set; }

        public byte[] Image { get; set; } = new byte[0];
    }
}
