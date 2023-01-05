using Learning.Bll.Interfaces;
using Learning.Common.Models.InsertModels;
using Learning.Common.Models.PatchModels;
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
        [Route("create-user-purchased-product")]
        [HttpPost]
        public IActionResult CreateUPP([FromBody] UserPurchasedProductInsertModel userPurchasedProduct)
        {
            _userPurchasedProductService.InsertUserPurchasedProduct(userPurchasedProduct);
            return new JsonResult(userPurchasedProduct);
        }
        [Route("delete-user-purchased-product")]
        [HttpDelete]
        public IActionResult DeleteUPP(Guid userId)
        {
            var someUsersProduct = _userPurchasedProductService.DeleteUserPurchasedProduct(userId);
            return new JsonResult(someUsersProduct);
        }
        [Route("update-user-purchased-product")]
        [HttpPatch]
        public IActionResult UpdateUPP(Guid userId, [FromBody] UserPurchasedProductPatchModel userPurchasedProduct)
        {
            var someUsersProduct = _userPurchasedProductService.UpdateUserPurchasedProduct(userId, userPurchasedProduct);
            return new JsonResult(someUsersProduct);
        }
        [Route("get-user-purchased-product-by-id")]
        [HttpGet]
        public IActionResult ReadUPP(Guid userId)
        {
            var someUsersProduct = _userPurchasedProductService.GetById(userId);
            return new JsonResult(someUsersProduct);
        }
        [Route("get-all-user-purchased-product")]
        [HttpGet]
        public IActionResult GetAll()
        {
            var someUsersProduct = _userPurchasedProductService.GetAllUserPurchasedProduct();
            return new JsonResult(someUsersProduct);

        }
    }
}
