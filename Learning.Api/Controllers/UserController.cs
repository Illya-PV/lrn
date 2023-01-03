using Learning.Bll.Interfaces;
using Learning.Dal.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Learning.Api.Controllers
{
    [Route("api/v1/user")]
    [ApiController]
    public class UserController : Controller
    {
        private IUserService _userService;

        public UserController(IUserService userService) 
        { 
            _userService = userService;
        }
        [Route("create-user")]
        [HttpPost]
        public IActionResult CreateUser([FromBody] UserModel user) 
        { 
            _userService.InsertUser(user);
            return new JsonResult(user);
        }
        [Route("delete-user")]
        [HttpDelete]
        public IActionResult DeleteUser(Guid userId) 
        { 
            var someUser = _userService.DeleteUser(userId);
            return new JsonResult(someUser);
        }
        [Route("update-user")]
        [HttpPatch]
        public IActionResult UpdateUser(Guid userId, [FromBody] UserModel user) 
        { 
            var someUser = _userService.UpdateUser(userId,user);
            return new JsonResult(someUser);
        }
        [Route("read-user-by-id")]
        [HttpGet]
        public IActionResult ReadUserById(Guid userId) 
        {
            var someUser = _userService.GetUserById(userId);
            return new JsonResult(someUser);
        }
        [Route("get-all-users")]
        [HttpGet]
        public IActionResult GetAllUsers() 
        {
            var someUsers = _userService.GetAllUsers();
            return new JsonResult(someUsers);
        }
    }
}
