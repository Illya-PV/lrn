using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Learning.Dal.Models;
using Learning.Common.Models.InsertModels;
using Learning.Common.Models.PatchModels;

namespace Learning.Bll.Interfaces
{
    public interface IProductService
    {
        void InsertProduct(ProductInsertModel product);
        ProductEntity DeleteProduct(Guid productId);
        ProductEntity UpdateProduct(Guid productId, ProductPatchModel product);
        ProductEntity ReadProductById(Guid productId);
        List<ProductEntity> GetAllProducts();
    }
}
