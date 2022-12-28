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
        public void InsertUserToMongoDb(UserModel user)
        {
            var collection = _db.GetCollection<UserModel>(UserCollectionName); 
            collection.InsertOne(user);
        }
        /// <summary>
        /// delete user from mongoDB
        /// </summary>
        /// <param name="user"></param>
        public void DeleteUserFromMongoDb(UserModel user) 
        {
            var collection = _db.GetCollection<UserModel>(UserCollectionName);
            var deleteFilter = Builders<UserModel>.Filter.Eq("Email","sbgmail.com");
            collection.DeleteOne(deleteFilter);
        }
        /// <summary>
        /// update user in mongoDB
        /// </summary>
        /// <param name="user"></param>
        public void UpdateUserInMongoDb(UserModel user) 
        {
            var collection = _db.GetCollection<UserModel>(UserCollectionName);
            var filter = Builders<UserModel>.Filter.Eq("Email", "sb@gmail.com");
            var updateFilter = Builders<UserModel>.Update.Set("Email", "testtestTEST.com");
            collection.UpdateOne(filter,updateFilter);
        }
        /// <summary>
        /// read user from mongoDb
        /// </summary>
        /// <param name="user"></param>
        public void ReadUserFromMongoDb(UserModel user)
        {
            var collection = _db.GetCollection<UserModel>(UserCollectionName);
            var filter = Builders<UserModel>.Filter.Eq("Email", "sbgmail.com");
            var studentDocument = collection.Find(filter).FirstOrDefault();
            Console.WriteLine(studentDocument.ToString());
        }
    }
}
