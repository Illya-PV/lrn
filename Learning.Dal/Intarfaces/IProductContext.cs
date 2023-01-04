using Learning.Dal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Learning.Common.Models.InsertModels;

namespace Learning.Dal.Intarfaces
{
    public interface IProductContext
    {
        void InsertProductToMongoDb(ProductInsertModel product);
        ProductEntity DeleteProductFromMongoDb(Guid productId);
        ProductEntity UpdateProductInMongoDb(Guid productId, ProductEntity product);
        ProductEntity GetProductById(Guid productId);
        List<ProductEntity> GetAllList();
    }
}
