using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Learning.Dal.Models;

namespace Learning.Bll.Interfaces
{
    public interface IProductService
    {
        ProductModel InsertProduct(ProductModel product);
        ProductModel DeleteProduct(Guid productId);
        ProductModel UpdateProduct(Guid productId, ProductModel product);
        ProductModel ReadProductById(Guid productId);
        List<ProductModel> GetAllProducts();
    }
}
