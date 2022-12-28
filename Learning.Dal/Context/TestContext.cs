using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;
using Learning.Dal.Models;

namespace Learning.Dal.Context
{
    public class TestContext
    {
        private IMongoDatabase _db;

        string connectionString = "mongodb+srv://illia_pv:localhost1617@cluster0.nvlushg.mongodb.net/test";
        string DBName = "EStore";
        string TestCollectionName = "TEST";

        public TestContext()
        {
            MongoClient mongoClient = new MongoClient(connectionString);
            _db = mongoClient.GetDatabase(DBName);

        }

      
        public void InsertTestToMongoDb(TestModel testid)
        {
            var collection = _db.GetCollection<TestModel>(TestCollectionName);           
            collection.InsertOne(testid);
        }
        
        public void DeleteCollection(TestModel testid)
        {
            var collection = _db.GetCollection<TestModel>(TestCollectionName);
            _db.DropCollection(TestCollectionName);
        }
       
        
        /*public TestContext ReadTestGuidFromMongoDb(Guid bankid) 
        {
            var collection = _db.GetCollection<TestModel>(TestCollectionName);
            var filter = Builders<TestModel>.Filter.Eq("SomeIDGuid", bankid);
            var testDocument = collection.Find(filter).FirstOrDefault();
            return testDocument;
        }*/

        public int ReadTestIntFromMongoDb(int testid)
        {
            var collection = _db.GetCollection<TestModel>(TestCollectionName);
            var filter = Builders<TestModel>.Filter.Eq("SomeIdInt", testid);
            var testDocument = collection.Find(filter).FirstOrDefault();
            return testid;
        }

        public string ReadTestStringFromMongoDb(string testid)
        {
            var collection = _db.GetCollection<TestModel>(TestCollectionName);
            var filter = Builders<TestModel>.Filter.Eq("SomeIDStr", testid);
            var testDocument = collection.Find(filter).FirstOrDefault();
            return testDocument.ToString();
        }
        

    }
}
