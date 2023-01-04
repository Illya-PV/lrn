using Learning.Bll.Interfaces;
using Learning.Dal;
using Learning.Dal.Context;
using Learning.Dal.Intarfaces;
using Learning.Dal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Learning.Common.Models.InsertModels;

namespace Learning.Bll.Implementation
{
    public class ProductService:IProductService
    {
        private IProductContext _productContext;

        public ProductService(IProductContext productContext) 
        { 
            _productContext = productContext;
        }

        /// <summary>
        /// insert product
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        public void InsertProduct(ProductInsertModel product) 
        {
            
            
            if (product.Price <= 0)
            {
                product.Price *= 0;

                Console.WriteLine("Price cannot be less then 0");
                if (product.Count <= 0)
                {
                    product.Count *= 0;
                    Console.WriteLine("This product is empty\n");
                }
            }
            else if (product.Count <= 0)
            {
                product.Count *= 0;
                Console.WriteLine("This product is empty\n");
            }
            else
            {
                _productContext.InsertProductToMongoDb(product);
                Console.WriteLine($"product:{product} added successfully\n");
            }
            
        }
        /// <summary>
        /// delete product
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        public ProductEntity DeleteProduct(Guid productId) 
        {
            return _productContext.DeleteProductFromMongoDb(productId);
            
        }
        /// <summary>
        /// update product
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        public ProductEntity UpdateProduct(Guid productId,ProductEntity product) 
        {
            return _productContext.UpdateProductInMongoDb(productId,product);
            
        }
        /// <summary>
        /// update product
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        public ProductEntity ReadProductById(Guid productId) 
        {
            return _productContext.GetProductById(productId);
            
        }
        public List<ProductEntity> GetAllProducts() 
        {
            return _productContext.GetAllList();
            
        }
    }
}
