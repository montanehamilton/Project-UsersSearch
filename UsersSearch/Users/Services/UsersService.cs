using System;
using System.Collections.Generic;
using UsersSearch.Users.Dtos;

namespace UsersSearch.Users.Services
{
    public class UsersService
    {
        public IList<UserModel> GetAllUsers()
        {
            return new List<UserModel>
            {
                new User{
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
                    FirstName ="Montane",
                    Id =Guid.NewGuid(),
                    LastName = "Hamilton",
                    Interests = new List<Interest>{
                        new Interest{
                            Description ="Model Railroading"
                        },
                        new Interest {
                            Description = "Programming"
                        }
                    }
                }.ToUserModel(),
                new User{
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
                    FirstName ="Ollie",
                    Id =Guid.NewGuid(),
                    LastName = "Hamilton",
                    Interests = new List<Interest>{
                        new Interest{
                            Description ="Religion"
                        },
                        new Interest {
                            Description = "Birthing"
                        }
                    }
                }.ToUserModel()
            };
        }
    }
}
