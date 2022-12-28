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
        public ProductModel InsertProduct(ProductModel product) 
        {
            product.ProductId = Guid.NewGuid();
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
            return product;
        }
        /// <summary>
        /// delete product
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        public ProductModel DeleteProduct(ProductModel product) 
        {
            _productContext.DeleteProductFromMongoDb(product);
            return product;
        }
        /// <summary>
        /// update product
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        public ProductModel UpdateProduct(ProductModel product) 
        { 
            _productContext.UpdateProductInMongoDb(product);
            return product;
        }
        /// <summary>
        /// update product
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        public ProductModel ReadProduct(ProductModel product) 
        {
            _productContext.ReadProductFromMongoDb(product);
            return product;
        }
    }
}
