using Learning.Bll.Interfaces;
using Learning.Common.Models.InsertModels;
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
        public IActionResult CreateUPP([FromBody] UserPurchasedProductInsertModel userPurchasedProduct)
        {
            _userPurchasedProductService.InsertUserPurchasedProduct(userPurchasedProduct);
            return new JsonResult(userPurchasedProduct);
        }
        [Route("delete-upp")]
        [HttpDelete]
        public IActionResult DeleteUPP(Guid userId)
        {
            var someUsersProduct = _userPurchasedProductService.DeleteUserPurchasedProduct(userId);
            return new JsonResult(someUsersProduct);
        }
        [Route("update-upp")]
        [HttpPatch]
        public IActionResult UpdateUPP(Guid userId, [FromBody] UserPurchasedProductEntity userPurchasedProduct)
        {
            var someUsersProduct = _userPurchasedProductService.UpdateUserPurchasedProduct(userId, userPurchasedProduct);
            return new JsonResult(someUsersProduct);
        }
        [Route("get-upp-by-id")]
        [HttpGet]
        public IActionResult ReadUPP(Guid userId)
        {
            var someUsersProduct = _userPurchasedProductService.GetById(userId);
            return new JsonResult(someUsersProduct);
        }
        [Route("get-all")]
        [HttpGet]
        public IActionResult GetAll()
        {
            var someUsersProduct = _userPurchasedProductService.GetAllUserPurchasedProduct();
            return new JsonResult(someUsersProduct);

        }
    }
}
