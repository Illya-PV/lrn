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
            Guid bankId = Guid.NewGuid();   
            var collection = _db.GetCollection<InsertAndUpdateModelForBank>(BankCollectionName);
            collection.InsertOne(newBankAccount);
            return newBankAccount;
            
        }
        /// <summary>
        /// delete bank to mongoDb
        /// </summary>
        /// <param name="bank"></param>
        public UserAccountModel DeleteBank(Guid bankId)
        {
            var collection = _db.GetCollection<UserAccountModel>(BankCollectionName);
            var deleteFilter = Builders<UserAccountModel>.Filter.Eq("BankAccountId", bankId);
            var bankDocument = collection.Find(deleteFilter).FirstOrDefault();
            collection.DeleteOne(deleteFilter);
            return bankDocument;
        }
       
        /// <summary>
        /// update bank by id, and change amount of money
        /// </summary>
        /// <param name="bank"></param>
        public UserAccountModel UpdateBank(Guid bankid, InsertAndUpdateModelForBank newBankAccount)
        {
            var collection = _db.GetCollection<UserAccountModel>(BankCollectionName);
            var filter = Builders<UserAccountModel>.Filter.Eq("BankAccountId", bankid);
            var updateFilter = Builders<UserAccountModel>.Update.Set("AmountOfMoney", newBankAccount.AmountOfMoney).
                Set("IsLocked", newBankAccount.IsLocked).
                Set("BankName", newBankAccount.BankName);
            collection.UpdateOne(filter, updateFilter);
            return ReadBankById(bankid);    
        }
        /// <summary>
        /// read bank to mongoDb
        /// </summary>
        /// <param name="bank"></param>
        public UserAccountModel ReadBankById(Guid bankid) 
        {
            var collection = _db.GetCollection<UserAccountModel>(BankCollectionName);
            var filter = Builders<UserAccountModel>.Filter.Eq("BankAccountId", bankid);
            var bankDocument = collection.Find(filter).FirstOrDefault();
            return bankDocument;
        }
        public UserAccountModel GetByName(string BankName) 
        {
            var collenction = _db.GetCollection<UserAccountModel>(BankCollectionName);
            var filter = Builders<UserAccountModel>.Filter.Eq("BankName", BankName);
            var bankDocument = collenction.Find(filter).FirstOrDefault();
            return bankDocument;
        }
        /// <summary>
        /// get all users
        /// </summary>
        /// <returns></returns>
        public List<UserAccountModel> GetAllList() 
        {
            var collection = _db.GetCollection<UserAccountModel>(BankCollectionName);
            return collection.Aggregate<UserAccountModel>().ToList();  
        }
       


    }
}
