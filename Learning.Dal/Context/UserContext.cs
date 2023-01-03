using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;
using Learning.Dal.Models;
using MongoDB.Bson;
using Learning.Dal.Intarfaces;

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
        public UserModel InsertUserToMongoDb(UserModel user)
        {
            var collection = _db.GetCollection<UserModel>(UserCollectionName); 
            collection.InsertOne(user);
            return user;
        }
        /// <summary>
        /// delete user from mongoDB
        /// </summary>
        /// <param name="user"></param>
        public UserModel DeleteUserFromMongoDb(Guid userId) 
        {
            var collection = _db.GetCollection<UserModel>(UserCollectionName);
            var deleteFilter = Builders<UserModel>.Filter.Eq("UserId",userId);
            var userDocument = collection.Find(deleteFilter).FirstOrDefault();
            collection.DeleteOne(deleteFilter);
            return userDocument;

        }
        /// <summary>
        /// update user in mongoDB
        /// </summary>
        /// <param name="user"></param>
        public UserModel UpdateUserInMongoDb(Guid userID,UserModel user) 
        {
            var collection = _db.GetCollection<UserModel>(UserCollectionName);
            var filter = Builders<UserModel>.Filter.Eq("UserId", userID);
            var updateFilter = Builders<UserModel>.Update.Set("FirstName", user.FirstName).
                Set("LastName", user.LastName).
                Set("Email", user.Email).
                Set("Password", user.Password);
            collection.UpdateOne(filter,updateFilter);
            return ReadUserById(userID);
        }
        /// <summary>
        /// read user from mongoDb
        /// </summary>
        /// <param name="user"></param>
        public UserModel ReadUserById(Guid userId)
        {
            var collection = _db.GetCollection<UserModel>(UserCollectionName);
            var filter = Builders<UserModel>.Filter.Eq("UserId", userId);
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
        public List<UserModel> GetAllList() 
        {
            var collection = _db.GetCollection<UserModel>(UserCollectionName);
            return collection.Aggregate<UserModel>().ToList();
        }
    }
}
