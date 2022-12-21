using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;


namespace Learning.Dal
{


    public class MongoDBService
    {
        private IMongoDatabase _db;
        public MongoDBService()
        {
            MongoClient mongoClient = new MongoClient("mongodb+srv://illia_pv:localhost1617@cluster0.nvlushg.mongodb.net/test");
           _db = mongoClient.GetDatabase():
        }
    }
}
