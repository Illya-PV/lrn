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
        void InsertProductToMongoDb(ProductModel product);
        void DeleteProductFromMongoDb(ProductModel product);
        void DeleteCollection(ProductModel product);
        void UpdateProductInMongoDb(ProductModel product);
        void ReadProductFromMongoDb(ProductModel product);
    }
}
