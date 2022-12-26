using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;
using Learning.Dal.Models;
namespace Learning.Dal.Context
{
    public class UserPurchasedProductContext
    {
        private IMongoDatabase _db;

        string connectionString = "mongodb+srv://illia_pv:localhost1617@cluster0.nvlushg.mongodb.net/test";
        string DBName = "EStore";
        string UserPurchasedProductCollectionName = "userPuechasedProduct";

        public UserPurchasedProductContext()
        {
            MongoClient mongoClient = new MongoClient(connectionString);
            _db = mongoClient.GetDatabase(DBName);
        }       
        /// <summary>
        /// insert user`s purchased product to mongoDB
        /// </summary>
        /// <param name="user"></param>
        public void InsertUPPToMongoDb(UserPurchasedProductModel userPuechasedProduct)
        {
            var collection = _db.GetCollection<UserPurchasedProductModel>(UserPurchasedProductCollectionName);
            collection.InsertOne(userPuechasedProduct);
        }
        /// <summary>
        /// delete user`s purchased product to mongoDB
        /// </summary>
        /// <param name="userPuechasedProduct"></param>
        public void DeleteUPPFromMongoDb(UserPurchasedProductModel userPuechasedProduct)
        {
            var collection = _db.GetCollection<UserPurchasedProductModel>(UserPurchasedProductCollectionName);
            var deleteFilter = Builders<UserPurchasedProductModel>.Filter.Eq("TotalPrice", 1200);
            collection.DeleteOne(deleteFilter);
        }
        public void DeleteCollection(UserPurchasedProductModel userPuechasedProduct)
        {
            var collection = _db.GetCollection<UserPurchasedProductModel>(UserPurchasedProductCollectionName);
            _db.DropCollection(UserPurchasedProductCollectionName);
        }
        /// <summary>
        /// update user`s purchased product to mongoDB
        /// </summary>
        /// <param name="userPuechasedProduct"></param>
        public void UpdateUPPInMongoDb(UserPurchasedProductModel userPuechasedProduct)
        {
            var collection = _db.GetCollection<UserPurchasedProductModel>(UserPurchasedProductCollectionName);
            var filter = Builders<UserPurchasedProductModel>.Filter.Eq("TotalPrice", 1000);
            var updateFilter = Builders<UserPurchasedProductModel>.Update.Set("TotalPrice", 1200);
            collection.UpdateOne(filter, updateFilter);
        }
        /// <summary>
        /// read user`s purchased product to mongoDB
        /// </summary>
        /// <param name="userPuechasedProduct"></param>
        public void ReadUPPFromMongoDB(UserPurchasedProductModel userPuechasedProduct) 
        {
            var collection = _db.GetCollection<UserPurchasedProductModel>(UserPurchasedProductCollectionName);
            var filter = Builders<UserPurchasedProductModel>.Filter.Eq("Email", "sbgmail.com");
            var studentDocument = collection.Find(filter).FirstOrDefault();
            Console.WriteLine(studentDocument.ToString());
        }
    }
}
