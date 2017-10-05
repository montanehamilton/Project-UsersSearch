using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using UsersSearch.Users.Dtos;
using Microsoft.AspNetCore.Hosting;

namespace UsersSearch.Users.Services
{
    public class UsersService
    {
        private readonly UsersSearchDbContext _dbContext;
        private readonly IHostingEnvironment _hostingEnvironment;

        public UsersService(UsersSearchDbContext dbContext, IHostingEnvironment hostingEnvironment)
        {
            _dbContext = dbContext;
            _hostingEnvironment = hostingEnvironment;
        }

        public IList<UserModel> GetAllUsers()
        {
            return _dbContext.Set<User>()
                .Include(u => u.Addresses)
                .Include(u => u.Interests)
                .Include(u => u.Avatar)
                .ToList()
                .Select(u => u.ToUserModel())
                .ToList();
        }

        public IList<UserModel> GetMatchingUsers(string searchString)
        {
            return _dbContext.Set<User>()
                .Include(u => u.Addresses)
                .Include(u => u.Interests)
                .Include(u => u.Avatar)
                .Where(u => u.FirstName.Contains(searchString) || u.LastName.Contains(searchString))
                .ToList()
                .Select(u => u.ToUserModel())
                .ToList();
        }

        internal Avatar GetAvatar(Guid userId)
        {
            return _dbContext.Users.Include(u => u.Avatar).First(u => u.Id == userId).Avatar;
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
                            LineOne ="123 Main St.",
                            LineTwo = string.Empty,
                            AdminArea ="UT",
                            City ="Lehi",
                            Id =Guid.NewGuid(),
                            PostalCode ="84043"
                        }
                },
                Avatar = new Avatar
                {
                    Image = "/demoimages/Guy_Headshot.jpg"
                },
                BirthDate = DateTime.Parse("04/06/1982"),
                FirstName = "Sam",
                Id = Guid.NewGuid(),
                LastName = "Smith",
                Interests = new List<Interest>{
                        new Interest{
                            Description ="Snowboarding"
                        },
                        new Interest {
                            Description = "Fly Fishing"
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
                Avatar = new Avatar
                {
                    Image = "/demoimages/th9WVOU0R3.jpg"
                },
                BirthDate = DateTime.Parse("12/08/1986"),
                FirstName = "Rhonda",
                Id = Guid.NewGuid(),
                LastName = "Rhodes",
                Interests = new List<Interest>{
                        new Interest{
                            Description ="Skiing"
                        },
                        new Interest {
                            Description = "Skydiving"
                        }
                }
            });

            _dbContext.Add(
            new User
            {
                Addresses = new List<Address>{
                        new Address {
                            LineOne ="876 Sycamore St.",
                            LineTwo = string.Empty,
                            AdminArea ="CT",
                            City ="New Haven",
                            Id =Guid.NewGuid(),
                            PostalCode ="06510"
                        }
                },
                Avatar = new Avatar
                {
                    Image = "/demoimages/bing-headshot-300x300-300x300.jpg"
                },
                BirthDate = DateTime.Parse("12/08/1979"),
                FirstName = "Trevor",
                Id = Guid.NewGuid(),
                LastName = "Adams",
                Interests = new List<Interest>{
                        new Interest{
                            Description ="Sailing"
                        },
                        new Interest {
                            Description = "Sports Cars"
                        }
                }
            });

            _dbContext.Add(
            new User
            {
                Addresses = new List<Address>{
                        new Address {
                            LineOne ="362 Broadmore Ave.",
                            LineTwo = string.Empty,
                            AdminArea ="CO",
                            City ="Denver",
                            Id =Guid.NewGuid(),
                            PostalCode ="80201"
                        }
                },
                Avatar = new Avatar
                {
                    Image = "/demoimages/thJZD72YL9.jpg"
                },
                BirthDate = DateTime.Parse("12/08/1979"),
                FirstName = "Elias",
                Id = Guid.NewGuid(),
                LastName = "Acuna",
                Interests = new List<Interest>{
                        new Interest{
                            Description ="Sailing"
                        },
                        new Interest {
                            Description = "Sports Cars"
                        }
                }
            });

            _dbContext.Add(
            new User
            {
                Addresses = new List<Address>{
                        new Address {
                            LineOne ="296 Surf Blvd.",
                            LineTwo = string.Empty,
                            AdminArea ="CA",
                            City ="San Jose",
                            Id =Guid.NewGuid(),
                            PostalCode ="95101"
                        }
                },
                Avatar = new Avatar
                {
                    Image = "/demoimages/th8GAI5R3K.jpg"
                },
                BirthDate = DateTime.Parse("12/08/1987"),
                FirstName = "Nicole",
                Id = Guid.NewGuid(),
                LastName = "Williams",
                Interests = new List<Interest>{
                        new Interest{
                            Description ="Surfing"
                        },
                        new Interest {
                            Description = "Wine"
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
