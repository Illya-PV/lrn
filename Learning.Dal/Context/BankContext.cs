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
    public class BankContext:IBankContext
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
        public BankModel InsertBankToMongoDb(BankModel bank)
        {
            var collection = _db.GetCollection<BankModel>(BankCollectionName);           
            collection.InsertOne(bank);
            return bank;
        }
        /// <summary>
        /// delete bank to mongoDb
        /// </summary>
        /// <param name="bank"></param>
        public BankModel DeleteBankFromMongoDb(BankModel bank)
        {
            var collection = _db.GetCollection<BankModel>(BankCollectionName);
            var deleteFilter = Builders<BankModel>.Filter.Eq("AmounOfMoney", 120);
            collection.DeleteOne(deleteFilter);
            return bank;
        }
       
        /// <summary>
        /// update bank to mongoDb
        /// </summary>
        /// <param name="bank"></param>
        public BankModel UpdateBankInMongoDb(BankModel bank)
        {
            var collection = _db.GetCollection<BankModel>(BankCollectionName);
            var filter = Builders<BankModel>.Filter.Eq("AmounOfMoney", 100);
            var updateFilter = Builders<BankModel>.Update.Set("AmounOfMoney", 120);
            collection.UpdateOne(filter, updateFilter);
            return bank;    
        }
        /// <summary>
        /// read bank to mongoDb
        /// </summary>
        /// <param name="bank"></param>
        public BankModel ReadBankFromMongoDbById(Guid bankid) 
        {
            var collection = _db.GetCollection<BankModel>(BankCollectionName);
            var filter = Builders<BankModel>.Filter.Eq("BankAccountId", bankid);
            var bankDocument = collection.Find(filter).FirstOrDefault();
            return bankDocument;
        }
        public BankModel ReadBankFromMongoDbByMoney(int amountOfMoney) 
        {
            var collection = _db.GetCollection<BankModel>(BankCollectionName);
            var filter = Builders<BankModel>.Filter.Eq("AmounOfMoney", amountOfMoney);
            var bankDocument = collection.Find(filter).FirstOrDefault();
            return bankDocument;
        }
        public List<BankModel> GetAllList() 
        {
            var collection = _db.GetCollection<BankModel>(BankCollectionName);
            return collection.Aggregate<BankModel>().ToList();
            
        }


    }
}
