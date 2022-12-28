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
        string ProdeuctCollectionName = "products";

        public ProductContext()
        {
            MongoClient mongoClient = new MongoClient(connectionString);
            _db = mongoClient.GetDatabase(DBName);

        }

        /// <summary>
        /// insert product to the DB
        /// </summary>
        /// <param name="product"></param>
        public void InsertProductToMongoDb(ProductModel product)
        {
            var collection = _db.GetCollection<ProductModel>(ProdeuctCollectionName);
            collection.InsertOne(product);
        }
        /// <summary>
        /// delete product to mongoDb
        /// </summary>
        /// <param name="product"></param>
        public void DeleteProductFromMongoDb(ProductModel product)
        {
            var collection = _db.GetCollection<ProductModel>(ProdeuctCollectionName);
            var deleteFilter = Builders<ProductModel>.Filter.Eq("Price",120);
            collection.DeleteOne(deleteFilter);
        }
        public void DeleteCollection(ProductModel product)
        {
            var collection = _db.GetCollection<ProductModel>(ProdeuctCollectionName);
            _db.DropCollection(ProdeuctCollectionName);
        }
        /// <summary>
        /// update product to mongoDb
        /// </summary>
        /// <param name="product"></param>
        public void UpdateProductInMongoDb(ProductModel product)
        {
            var collection = _db.GetCollection<ProductModel>(ProdeuctCollectionName);
            var filter = Builders<ProductModel>.Filter.Eq("Price", 240);
            var updateFilter = Builders<ProductModel>.Update.Set("Price", 120);
            collection.UpdateOne(filter, updateFilter);
        }
        /// <summary>
        /// read product to mongoDb
        /// </summary>
        /// <param name="product"></param>
        public void ReadProductFromMongoDb(ProductModel product)
        {
            var collection = _db.GetCollection<ProductModel>(ProdeuctCollectionName);
            var filter = Builders<ProductModel>.Filter.Eq("Price", 120);
            var productDocument = collection.Find(filter).FirstOrDefault();
            Console.WriteLine(productDocument.ToString());
        }






    }
    }
