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
        public IActionResult DeleteUser([FromBody] UserModel user) 
        { 
            _userService.DeleteUser(user);
            return new JsonResult(user);
        }
        [Route("update-user")]
        [HttpPut]
        public IActionResult UpdateUser([FromBody] UserModel user) 
        { 
            _userService.UpdateUser(user);
            return new JsonResult(user);
        }
        [Route("read-user")]
        [HttpGet]
        public IActionResult ReadUser([FromBody] UserModel user) 
        {
            _userService.ReadUser(user);
            return new JsonResult(user);
        }
    }
}
