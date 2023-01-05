using Learning.Dal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Learning.Common.Models.InsertModels;
using Learning.Common.Models.PatchModels;

namespace Learning.Dal.Intarfaces
{
    public interface IProductContext
    {
        void InsertProductToMongoDb(ProductInsertModel product);
        ProductEntity DeleteProductFromMongoDb(Guid productId);
        ProductEntity UpdateProductInMongoDb(Guid productId, ProductPatchModel product);
        ProductEntity GetProductById(Guid productId);
        List<ProductEntity> GetAllList();
    }
}
