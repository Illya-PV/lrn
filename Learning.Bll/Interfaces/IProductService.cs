using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Learning.Dal.Models;
using Learning.Common.Models.InsertModels;

namespace Learning.Bll.Interfaces
{
    public interface IProductService
    {
        void InsertProduct(ProductInsertModel product);
        ProductEntity DeleteProduct(Guid productId);
        ProductEntity UpdateProduct(Guid productId, ProductEntity product);
        ProductEntity ReadProductById(Guid productId);
        List<ProductEntity> GetAllProducts();
    }
}
