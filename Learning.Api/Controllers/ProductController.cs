using Learning.Bll.Interfaces;
using Learning.Common.Models.InsertModels;
using Learning.Dal.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Learning.Api.Controllers
{
    [Route("api/v1/product")]
    [ApiController]
    public class ProductController : Controller
    {
        

        private IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }
        [Route("create-product")]
        [HttpPost]
        public IActionResult CreateProduct([FromBody] ProductInsertModel product) 
        {
            _productService.InsertProduct(product);
            return new JsonResult(product);
        }
        [Route("delete-product")]
        [HttpDelete]
        public IActionResult DeleteProduct(Guid productId)
        {
            var someProduct = _productService.DeleteProduct(productId);
            return new JsonResult(someProduct);
        }
        [Route("update-product")]
        [HttpPatch]
        public IActionResult UpdateProduct(Guid productId,[FromBody] ProductEntity product)
        {
            var someProduct = _productService.UpdateProduct(productId,product);
            return new JsonResult(someProduct);
        }
        [Route("read-product")]
        [HttpGet]
        public IActionResult ReadProductById(Guid productId)
        {
            var someProduct = _productService.ReadProductById(productId);
            return new JsonResult(someProduct);
        }
        [Route("get-all-products")]
        [HttpGet]
        public IActionResult GetAllProducts() 
        {
            var someProduct = _productService.GetAllProducts();
            return new JsonResult(someProduct);
        }

    }
}
