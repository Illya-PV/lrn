using Learning.Bll.Interfaces;
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
        public IActionResult CreateProduct([FromBody] ProductModel product) 
        {
            _productService.InsertProduct(product);
            return new JsonResult(product);
        }
        [Route("delete-product")]
        [HttpDelete]
        public IActionResult DeleteProduct([FromBody] ProductModel product)
        {
            _productService.DeleteProduct(product);
            return new JsonResult(product);
        }
        [Route("update-product")]
        [HttpPut]
        public IActionResult UpdateProduct([FromBody] ProductModel product)
        {
            _productService.UpdateProduct(product);
            return new JsonResult(product);
        }
        [Route("read-product")]
        [HttpGet]
        public IActionResult ReadProduct([FromBody] ProductModel product)
        {
            _productService.ReadProduct(product);
            return new JsonResult(product);
        }

    }
}
