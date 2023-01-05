using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;
using Learning.Dal.Models;
using Learning.Dal.Intarfaces;
using Learning.Common.Models.InsertModels;
using Learning.Common.Models.PatchModels;

namespace Learning.Dal.Context
{
    public class UserPurchasedProductContext:IUserPurchasedProductContext
    {
        private IMongoDatabase _db;

        string connectionString = "mongodb+srv://illia_pv:localhost1617@cluster0.nvlushg.mongodb.net/test";
        string DBName = "EStore";
        string UserPurchasedProductCollectionName = "userPurchasedProduct";

        public UserPurchasedProductContext()
        {
            MongoClient mongoClient = new MongoClient(connectionString);
            _db = mongoClient.GetDatabase(DBName);
        }       
        /// <summary>
        /// insert user`s purchased product to mongoDB
        /// </summary>
        /// <param name="user"></param>
        public void InsertUPPToMongoDb(UserPurchasedProductInsertModel intsertUserPuechasedProduct)
        {
            var collection = _db.GetCollection<UserPurchasedProductEntity>(UserPurchasedProductCollectionName);
            var userPuechasedProduct = new UserPurchasedProductEntity() 
            { 
                UserId = Guid.NewGuid(),
                ProductId = Guid.NewGuid(),
                TotalPrice = intsertUserPuechasedProduct.TotalPrice
            };
            collection.InsertOne(userPuechasedProduct);
            
        }
        /// <summary>
        /// delete user`s purchased product to mongoDB
        /// </summary>
        /// <param name="userPuechasedProduct"></param>
        public UserPurchasedProductEntity DeleteUPPFromMongoDb(Guid userId)
        {
            var collection = _db.GetCollection<UserPurchasedProductEntity>(UserPurchasedProductCollectionName);
            var deleteFilter = Builders<UserPurchasedProductEntity>.Filter.Eq("UserId", userId);
            var UserPurchasedProductDocument = collection.Find(deleteFilter).FirstOrDefault();
            collection.DeleteOne(deleteFilter);
            return UserPurchasedProductDocument;
        }
        /// <summary>
        /// update user`s purchased product to mongoDB
        /// </summary>
        /// <param name="userPuechasedProduct"></param>
        public UserPurchasedProductEntity UpdateUPPInMongoDb(Guid userId,UserPurchasedProductPatchModel userPurchasedProduct)
        {
            var collection = _db.GetCollection<UserPurchasedProductEntity>(UserPurchasedProductCollectionName);
            var filter = Builders<UserPurchasedProductEntity>.Filter.Eq("UserId", userId);
            var updateFilter = Builders<UserPurchasedProductEntity>.Update.Set("TotalPrice", userPurchasedProduct.TotalPrice);
            collection.UpdateOne(filter, updateFilter);
            return GetById(userId);
        }
        /// <summary>
        /// read user`s purchased product to mongoDB
        /// </summary>
        /// <param name="userPuechasedProduct"></param>
        public UserPurchasedProductEntity GetById(Guid userId) 
        {
            var collection = _db.GetCollection<UserPurchasedProductEntity>(UserPurchasedProductCollectionName);
            var filter = Builders<UserPurchasedProductEntity>.Filter.Eq("UserId", userId);
            var UserPurchasedProductDocument = collection.Find(filter).FirstOrDefault();
            return UserPurchasedProductDocument;
        }
        public List<UserPurchasedProductEntity> GetAllList() 
        {
            var collection = _db.GetCollection<UserPurchasedProductEntity>(UserPurchasedProductCollectionName);
            return collection.Aggregate<UserPurchasedProductEntity>().ToList();
        }
    }
}
