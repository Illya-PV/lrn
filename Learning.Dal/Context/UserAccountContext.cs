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
    public class UserAccountContext: IUserAccountContext
    {
        private IMongoDatabase _db;

        string connectionString = "mongodb+srv://illia_pv:localhost1617@cluster0.nvlushg.mongodb.net/test";
        string DBName = "EStore";
        string BankCollectionName = "bank";

        public UserAccountContext()
        {
            MongoClient mongoClient = new MongoClient(connectionString);
            _db = mongoClient.GetDatabase(DBName);

        }

        /// <summary>
        /// insert bank to mongoDb
        /// </summary>
        /// <param name="bank"></param>
        public InsertAndUpdateModelForBank InsertBank(InsertAndUpdateModelForBank newBankAccount)
        {
            var collection = _db.GetCollection<InsertAndUpdateModelForBank>(BankCollectionName);           
            collection.InsertOne(newBankAccount);
            return newBankAccount;
            
        }
        /// <summary>
        /// delete bank to mongoDb
        /// </summary>
        /// <param name="bank"></param>
        public UserAccount DeleteBank(Guid bankId)
        {
            var collection = _db.GetCollection<UserAccount>(BankCollectionName);
            var filter = Builders<UserAccount>.Filter.Eq("BankAccountId", bankId);
            var bankDocument = collection.Find(filter).FirstOrDefault();
            collection.DeleteOne(filter);
            return bankDocument;
        }
       
        /// <summary>
        /// update bank by id, and change amount of money
        /// </summary>
        /// <param name="bank"></param>
        public UserAccount UpdateBank(Guid bankid, InsertAndUpdateModelForBank newBankAccount)
        {
            var collection = _db.GetCollection<UserAccount>(BankCollectionName);
            var filter = Builders<UserAccount>.Filter.Eq("BankAccountId", bankid);
            var updateFilter = Builders<UserAccount>.Update.Set("AmountOfMoney", newBankAccount.AmountOfMoney).Set("IsLocked", newBankAccount.IsLocked).Set("BankName", newBankAccount.BankName);
            collection.UpdateOne(filter, updateFilter);
            return ReadBankById(bankid);    
        }
        /// <summary>
        /// read bank to mongoDb
        /// </summary>
        /// <param name="bank"></param>
        public UserAccount ReadBankById(Guid bankid) 
        {
            var collection = _db.GetCollection<UserAccount>(BankCollectionName);
            var filter = Builders<UserAccount>.Filter.Eq("BankAccountId", bankid);
            var bankDocument = collection.Find(filter).FirstOrDefault();
            return bankDocument;
        }
        public UserAccount GetByName(string BankName) 
        {
            var collenction = _db.GetCollection<UserAccount>(BankCollectionName);
            var filter = Builders<UserAccount>.Filter.Eq("BankName", BankName);
            var bankDocument = collenction.Find(filter).FirstOrDefault();
            return bankDocument;
        }
        /// <summary>
        /// get all users
        /// </summary>
        /// <returns></returns>
        public List<UserAccount> GetAllList() 
        {
            var collection = _db.GetCollection<UserAccount>(BankCollectionName);
            return collection.Aggregate<UserAccount>().ToList();
            
        }


    }
}
