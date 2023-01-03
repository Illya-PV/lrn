using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;
using Learning.Dal.Models;
using Learning.Dal.Intarfaces;

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
        public ProductModel InsertProductToMongoDb(ProductModel product)
        {
            var collection = _db.GetCollection<ProductModel>(ProductCollectionName);
            collection.InsertOne(product);
            return product;
        }
        /// <summary>
        /// delete product to mongoDb
        /// </summary>
        /// <param name="product"></param>
        public ProductModel DeleteProductFromMongoDb(Guid productId)
        {
            var collection = _db.GetCollection<ProductModel>(ProductCollectionName);
            var filter = Builders<ProductModel>.Filter.Eq("ProductId", productId);
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
        public ProductModel UpdateProductInMongoDb(Guid productId,ProductModel product)
        {
            var collection = _db.GetCollection<ProductModel>(ProductCollectionName);
            var filter = Builders<ProductModel>.Filter.Eq("ProductId", productId);
            var updateFilter = Builders<ProductModel>.Update.Set("Price", product.Price).
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
        public ProductModel GetProductById(Guid productId)
        {
            var collection = _db.GetCollection<ProductModel>(ProductCollectionName);
            var filter = Builders<ProductModel>.Filter.Eq("ProductId", productId);
            var productDocument = collection.Find(filter).FirstOrDefault();
            return productDocument;
        }

        public List<ProductModel> GetAllList()
        {
            var collection = _db.GetCollection<ProductModel>(ProductCollectionName);
            return collection.Aggregate<ProductModel>().ToList();
        }







    }
    }
