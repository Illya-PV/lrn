using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;
using Learning.Dal.Models;

namespace Learning.Dal.Context
{
    public class BankContext
    {
        private IMongoDatabase _db;

        string connectionString = "mongodb+srv://illia_pv:localhost1617@cluster0.nvlushg.mongodb.net/test";
        string DBName = "EStore";
        string BankCollectionName = "bank";

        public BankContext()
        {
            MongoClient mongoClient = new MongoClient(connectionString);
            _db = mongoClient.GetDatabase(DBName);

        }

        /// <summary>
        /// insert bank to mongoDb
        /// </summary>
        /// <param name="bank"></param>
        public void InsertBankToMongoDb(BankModel bank)
        {
            var collection = _db.GetCollection<BankModel>(BankCollectionName);           
            collection.InsertOne(bank);
        }
        /// <summary>
        /// delete bank to mongoDb
        /// </summary>
        /// <param name="bank"></param>
        public void DeleteBankFromMongoDb(BankModel bank)
        {
            var collection = _db.GetCollection<BankModel>(BankCollectionName);
            var deleteFilter = Builders<BankModel>.Filter.Eq("AmounOfMoney", 120);
            collection.DeleteOne(deleteFilter);
        }
        public void DeleteCollection(BankModel bank)
        {
            var collection = _db.GetCollection<BankModel>(BankCollectionName);
            _db.DropCollection(BankCollectionName);
        }
        /// <summary>
        /// update bank to mongoDb
        /// </summary>
        /// <param name="bank"></param>
        public void UpdateBankInMongoDb(BankModel bank)
        {
            var collection = _db.GetCollection<BankModel>(BankCollectionName);
            var filter = Builders<BankModel>.Filter.Eq("AmounOfMoney", 100);
            var updateFilter = Builders<BankModel>.Update.Set("AmounOfMoney", 120);
            collection.UpdateOne(filter, updateFilter);
        }
        /// <summary>
        /// read bank to mongoDb
        /// </summary>
        /// <param name="bank"></param>
        public void ReadBankFromMongoDb(BankModel bank) 
        {
            var collection = _db.GetCollection<BankModel>(BankCollectionName);
            var filter = Builders<BankModel>.Filter.Eq("Price", 120);
            var productDocument = collection.Find(filter).FirstOrDefault();
            Console.WriteLine(productDocument.ToString());
        }


    }
}
