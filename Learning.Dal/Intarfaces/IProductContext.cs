using Learning.Dal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learning.Dal.Intarfaces
{
    public interface IProductContext
    {
        ProductModel InsertProductToMongoDb(ProductModel product);
        ProductModel DeleteProductFromMongoDb(Guid productId);
        ProductModel UpdateProductInMongoDb(Guid productId, ProductModel product);
        ProductModel GetProductById(Guid productId);
        List<ProductModel> GetAllList();
    }
}
