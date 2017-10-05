using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using UsersSearch.Users.Services;
using UsersSearch.Users.Dtos;

namespace UsersSearch.Controllers
{
    [Route("api/[controller]")]
    public class UsersController : Controller
    {
        private UsersService _usersService { get; }

        public UsersController(UsersService usersService)
        {
            _usersService = usersService;
        }
        
        [HttpGet("[action]")]
        public IList<UserModel> All()
        {
            return _usersService.GetAllUsers();
        }
    }
}