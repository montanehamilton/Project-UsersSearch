using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using UsersSearch.Users.Dtos;

namespace UsersSearch.Users.Services
{
    public class UsersService
    {
        private readonly UsersSearchDbContext _dbContext;

        public UsersService(UsersSearchDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IList<UserModel> GetAllUsers()
        {
            return _dbContext.Set<User>()
                .Include(u => u.Addresses)
                .Include(u => u.Interests)
                .ToList()
                .Select(u => u.ToUserModel())
                .ToList();
        }

        public bool AddOrResetDemoData()
        {
            if (GetUserCount() > 0)
            {
                var existingAddresses = _dbContext.Addresses.ToList();
                _dbContext.Addresses.RemoveRange(existingAddresses);

                var existingInterests = _dbContext.Interests.ToList();
                _dbContext.Interests.RemoveRange(existingInterests);

                var existingAvatars = _dbContext.Avatars.ToList();
                _dbContext.Avatars.RemoveRange(existingAvatars);

                var existingUsers = _dbContext.Users.ToList();
                _dbContext.Users.RemoveRange(existingUsers);
                _dbContext.SaveChanges();
            }
            
            _dbContext.Add(
            new User
            {
                Addresses = new List<Address>{
                        new Address {
                            LineOne ="5258 N Grey Hawk Dr",
                            LineTwo = string.Empty,
                            AdminArea ="UT",
                            City ="Lehi",
                            Id =Guid.NewGuid(),
                            PostalCode ="84043"
                        }
                },
                Avatar = new Avatar(),
                BirthDate = DateTime.Parse("04/06/1975"),
                FirstName = "Montane",
                Id = Guid.NewGuid(),
                LastName = "Hamilton",
                Interests = new List<Interest>{
                        new Interest{
                            Description ="Model Railroading"
                        },
                        new Interest {
                            Description = "Programming"
                        }
                }
            });

            _dbContext.Add(
            new User
            {
                Addresses = new List<Address>{
                        new Address {
                            LineOne ="513 27th St. No.",
                            LineTwo = string.Empty,
                            AdminArea ="MT",
                            City ="Great Falls",
                            Id =Guid.NewGuid(),
                            PostalCode ="59401"
                        }
                },
                Avatar = new Avatar(),
                BirthDate = DateTime.Parse("04/06/2005"),
                FirstName = "Ollie",
                Id = Guid.NewGuid(),
                LastName = "Hamilton",
                Interests = new List<Interest>{
                        new Interest{
                            Description ="Religion"
                        },
                        new Interest {
                            Description = "Birthing"
                        }
                }
            });

            _dbContext.SaveChanges();

            return true;
        }

        public int GetUserCount()
        {
            return _dbContext.Set<User>().Count();
        }
    }
}
