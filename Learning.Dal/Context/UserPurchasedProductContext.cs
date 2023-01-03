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
    public class UserPurchasedProductContext:IUserPurchasedProductContext
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
        public UserPurchasedProductModel InsertUPPToMongoDb(UserPurchasedProductModel userPuechasedProduct)
        {
            var collection = _db.GetCollection<UserPurchasedProductModel>(UserPurchasedProductCollectionName);
            collection.InsertOne(userPuechasedProduct);
            return userPuechasedProduct;
        }
        /// <summary>
        /// delete user`s purchased product to mongoDB
        /// </summary>
        /// <param name="userPuechasedProduct"></param>
        public UserPurchasedProductModel DeleteUPPFromMongoDb(Guid userId)
        {
            var collection = _db.GetCollection<UserPurchasedProductModel>(UserPurchasedProductCollectionName);
            var deleteFilter = Builders<UserPurchasedProductModel>.Filter.Eq("UserId", userId);
            var UserPurchasedProductDocument = collection.Find(deleteFilter).FirstOrDefault();
            collection.DeleteOne(deleteFilter);
            return UserPurchasedProductDocument;
        }
        /// <summary>
        /// update user`s purchased product to mongoDB
        /// </summary>
        /// <param name="userPuechasedProduct"></param>
        public UserPurchasedProductModel UpdateUPPInMongoDb(Guid userId,UserPurchasedProductModel userPurchasedProduct)
        {
            var collection = _db.GetCollection<UserPurchasedProductModel>(UserPurchasedProductCollectionName);
            var filter = Builders<UserPurchasedProductModel>.Filter.Eq("UserId", userId);
            var updateFilter = Builders<UserPurchasedProductModel>.Update.Set("TotalPrice", userPurchasedProduct.TotalPrice);
            collection.UpdateOne(filter, updateFilter);
            return GetById(userId);
        }
        /// <summary>
        /// read user`s purchased product to mongoDB
        /// </summary>
        /// <param name="userPuechasedProduct"></param>
        public UserPurchasedProductModel GetById(Guid userId) 
        {
            var collection = _db.GetCollection<UserPurchasedProductModel>(UserPurchasedProductCollectionName);
            var filter = Builders<UserPurchasedProductModel>.Filter.Eq("UserId", userId);
            var UserPurchasedProductDocument = collection.Find(filter).FirstOrDefault();
            return UserPurchasedProductDocument;
        }
        public List<UserPurchasedProductModel> GetAllList() 
        {
            var collection = _db.GetCollection<UserPurchasedProductModel>(UserPurchasedProductCollectionName);
            return collection.Aggregate<UserPurchasedProductModel>().ToList();
        }
    }
}
