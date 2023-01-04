using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;
using Learning.Dal.Models;
using Learning.Dal.Intarfaces;

using Learning.Common.Models.InsertModels;

namespace Learning.Dal.Context
{
    public class ProductContext:IProductContext
    {
        private IMongoDatabase _db;

        string connectionString = "mongodb+srv://illia_pv:localhost1617@cluster0.nvlushg.mongodb.net/test";
        string DBName = "EStore";
        string ProductCollectionName = "products";

        public ProductContext()
        {
            MongoClient mongoClient = new MongoClient(connectionString);
            _db = mongoClient.GetDatabase(DBName);

        }

        /// <summary>
        /// insert product to the DB
        /// </summary>
        /// <param name="product"></param>
        public void InsertProductToMongoDb(ProductInsertModel insertProduct)
        {
            var collection = _db.GetCollection<ProductEntity>(ProductCollectionName);
            var product = new ProductEntity() 
            {
                ProductId = Guid.NewGuid(),
                Color = insertProduct.Color,
                Name = insertProduct.Name,
                Price = insertProduct.Price,
                Count = insertProduct.Count,
                Type = insertProduct.Type
            };
            collection.InsertOne(product);
        }
        /// <summary>
        /// delete product to mongoDb
        /// </summary>
        /// <param name="product"></param>
        public ProductEntity DeleteProductFromMongoDb(Guid productId)
        {
            var collection = _db.GetCollection<ProductEntity>(ProductCollectionName);
            var filter = Builders<ProductEntity>.Filter.Eq("ProductId", productId);
            var bankDocument = collection.Find(filter).FirstOrDefault();
            collection.DeleteOne(filter);
            return bankDocument;
        }
/*        public void DeleteCollection(ProductModel product)
        {
            var collection = _db.GetCollection<ProductModel>(ProdeuctCollectionName);
            _db.DropCollection(ProdeuctCollectionName);
        }*/
        /// <summary>
        /// update product to mongoDb
        /// </summary>
        /// <param name="product"></param>
        public ProductEntity UpdateProductInMongoDb(Guid productId,ProductEntity product)
        {
            var collection = _db.GetCollection<ProductEntity>(ProductCollectionName);
            var filter = Builders<ProductEntity>.Filter.Eq("ProductId", productId);
            var updateFilter = Builders<ProductEntity>.Update.Set("Price", product.Price).
                Set("Count", product.Count).
                Set("Name", product.Name).
                Set("Type", product.Type).
                Set("Color", product.Color);
            collection.UpdateOne(filter, updateFilter);
            return GetProductById(productId);
        }
        /// <summary>
        /// read product to mongoDb
        /// </summary>
        /// <param name="product"></param>
        public ProductEntity GetProductById(Guid productId)
        {
            var collection = _db.GetCollection<ProductEntity>(ProductCollectionName);
            var filter = Builders<ProductEntity>.Filter.Eq("ProductId", productId);
            var productDocument = collection.Find(filter).FirstOrDefault();
            return productDocument;
        }

        public List<ProductEntity> GetAllList()
        {
            var collection = _db.GetCollection<ProductEntity>(ProductCollectionName);
            return collection.Aggregate<ProductEntity>().ToList();
        }







    }
    }
