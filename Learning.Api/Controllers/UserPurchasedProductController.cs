using Learning.Bll.Interfaces;
using Learning.Dal.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Learning.Api.Controllers
{
    [Route("api/v1/user-purchased-product")]
    [ApiController]
    public class UserPurchasedProductController : Controller
    {
        private IUserPurchasedProductService _userPurchasedProductService;

        public UserPurchasedProductController(IUserPurchasedProductService userPurchasedProductService)
        {
            _userPurchasedProductService = userPurchasedProductService;
        }
        [Route("create-upp")]
        [HttpPost]
        public IActionResult CreateUPP([FromBody] UserPurchasedProductModel userPurchasedProduct) 
        { 
            _userPurchasedProductService.InsertUserPurchasedProduct(userPurchasedProduct);
            return new JsonResult(userPurchasedProduct);
        }
        [Route("delete-upp")]
        [HttpDelete]
        public IActionResult DeleteUPP([FromBody] UserPurchasedProductModel userPurchasedProduct)
        {
            _userPurchasedProductService.DeleteUserPurchasedProduct(userPurchasedProduct);
            return new JsonResult(userPurchasedProduct);
        }
        [Route("update-upp")]
        [HttpPut]
        public IActionResult UpdateUPP([FromBody] UserPurchasedProductModel userPurchasedProduct)
        {
            _userPurchasedProductService.UpdateUserPurchasedProduct(userPurchasedProduct);
            return new JsonResult(userPurchasedProduct);
        }
        [Route("create-upp")]
        [HttpGet]
        public IActionResult ReadUPP([FromBody] UserPurchasedProductModel userPurchasedProduct)
        {
            _userPurchasedProductService.ReadUserPurchasedProduct(userPurchasedProduct);
            return new JsonResult(userPurchasedProduct);
        }
    }
}
