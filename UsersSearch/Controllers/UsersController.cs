using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using UsersSearch.Users.Services;
using UsersSearch.Users.Dtos;
using UsersSearch.Controllers.Dtos;
using System.Threading;

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

        [HttpPost("[action]")]
        public IList<UserModel> All([FromBody] SearchRequest request)
        {
            Thread.Sleep(3000); // To simulate some time so loading gif shows.
            return _usersService.GetMatchingUsers(request.SearchString);
        }

        [HttpGet("[action]")]
        public bool DemoDataStatus()
        {
            return _usersService.GetUserCount() > 0;
        }

        [HttpPost("[action]")]
        public bool DemoData()
        {
            return _usersService.AddOrResetDemoData();
        }
    }
}
