using System;
using UsersSearch.Users.Dtos;

namespace UsersSearch.Users.Services
{
    public static class UserExtensions
    {
        public static UserModel ToUserModel(this User user)
        {
            var userModel = new UserModel
            {
                Addresses = user.Addresses,
                AvatarUrl = $"/api/Users/{user.Id}/Avatar",
                FirstName = user.FirstName,
                LastName = user.LastName,
                Age = DateTime.Now.Year - user.BirthDate.Year,
                Interests = user.Interests
            };

            return userModel;
        }
    }
}
