using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;
using Learning.Dal.Models;
using MongoDB.Bson;
using Learning.Dal.Intarfaces;
using Learning.Common.Models.InsertModels;
using Learning.Common.Models.PatchModels;

namespace Learning.Dal.Context
{
    public class UserContext:IUserContext
    {
        private IMongoDatabase _db;

        string connectionString = "mongodb+srv://illia_pv:localhost1617@cluster0.nvlushg.mongodb.net/test";
        string DBName = "EStore";
        string UserCollectionName = "user";

        public UserContext()
        {
            MongoClient mongoClient = new MongoClient(connectionString);
            _db = mongoClient.GetDatabase(DBName);
        }

        /// <summary>
        /// insert user to mongoDB
        /// </summary>
        /// <param name="user"></param>
        public void InsertUserToMongoDb(UserInsertModel insertUser)
        {              
            var collection = _db.GetCollection<UserEntity>(UserCollectionName);
            var user = new UserEntity()
            {
                UserId = Guid.NewGuid(),
                BankAccountId = Guid.NewGuid(),
                FirstName = insertUser.FirstName,
                LastName = insertUser.LastName,
                Email = insertUser.Email,
                Password = insertUser.Password
            };
            collection.InsertOne(user);
            
        }
        /// <summary>
        /// delete user from mongoDB
        /// </summary>
        /// <param name="user"></param>
        public UserEntity DeleteUserFromMongoDb(Guid userId) 
        {
            var collection = _db.GetCollection<UserEntity>(UserCollectionName);
            var deleteFilter = Builders<UserEntity>.Filter.Eq("UserId",userId);
            var userDocument = collection.Find(deleteFilter).FirstOrDefault();
            collection.DeleteOne(deleteFilter);
            return userDocument;

        }
        /// <summary>
        /// update user in mongoDB
        /// </summary>
        /// <param name="user"></param>
        public UserEntity UpdateUserInMongoDb(Guid userId, UserPatchModel user) 
        {
            var collection = _db.GetCollection<UserEntity>(UserCollectionName);
            var filter = Builders<UserEntity>.Filter.Eq("UserId", userId);
            var updateFilter = Builders<UserEntity>.Update.Set("FirstName", user.FirstName).
                Set("LastName", user.LastName).
                Set("Email", user.Email).
                Set("Password", user.Password);
            collection.UpdateOne(filter,updateFilter);
            return ReadUserById(userId);
        }
        /// <summary>
        /// read user from mongoDb
        /// </summary>
        /// <param name="user"></param>
        public UserEntity ReadUserById(Guid userId)
        {
            var collection = _db.GetCollection<UserEntity>(UserCollectionName);
            var filter = Builders<UserEntity>.Filter.Eq("UserId", userId);
            var studentDocument = collection.Find(filter).FirstOrDefault();
            return studentDocument;
        }
        /*public UserModel GetByFullname(UserModel firstName, UserModel lastName) 
        {
            var collection = _db.GetCollection<UserModel>(UserCollectionName);
            var filter = Builders<UserModel>.Filter.Eq("FirstName", firstName);
            var studentDocument = collection.Find(filter).FirstOrDefault();
            return studentDocument;
        }*/
        public List<UserEntity> GetAllList() 
        {
            var collection = _db.GetCollection<UserEntity>(UserCollectionName);
            return collection.Aggregate<UserEntity>().ToList();
        }
    }
}
