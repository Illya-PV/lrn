using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;
using Learning.Dal.Models;
using Learning.Dal.Intarfaces;
using Learning.Dal.InsertModels;

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
        public void InsertBank(UserAccountInsertModel newBankAccount)
        {         
            var collection = _db.GetCollection<UserAccountEntity>(BankCollectionName);
            var userAccount = new UserAccountEntity()
            { 
              BankAccountId = Guid.NewGuid(),
              BankName = newBankAccount.BankName,
              IsLocked = false,
              AmounOfMoney = newBankAccount.AmountOfMoney   
            }; 
            collection.InsertOne(userAccount);

        }
        /// <summary>
        /// delete bank to mongoDb
        /// </summary>
        /// <param name="bank"></param>
        public UserAccountEntity DeleteBank(Guid bankId)
        {
            var collection = _db.GetCollection<UserAccountEntity>(BankCollectionName);
            var deleteFilter = Builders<UserAccountEntity>.Filter.Eq("BankAccountId", bankId);
            var bankDocument = collection.Find(deleteFilter).FirstOrDefault();
            collection.DeleteOne(deleteFilter);
            return bankDocument;
        }
       
        /// <summary>
        /// update bank by id, and change amount of money
        /// </summary>
        /// <param name="bank"></param>
        public UserAccountEntity UpdateBank(Guid bankid, UserAccountEntity newBankAccount)
        {
            var collection = _db.GetCollection<UserAccountEntity>(BankCollectionName);
            var filter = Builders<UserAccountEntity>.Filter.Eq("BankAccountId", bankid);
            var updateFilter = Builders<UserAccountEntity>.Update.Set("AmountOfMoney", newBankAccount.AmounOfMoney).
                Set("IsLocked", newBankAccount.IsLocked).
                Set("BankName", newBankAccount.BankName);
            collection.UpdateOne(filter, updateFilter);
            return ReadBankById(bankid);    
        }
        /// <summary>
        /// read bank to mongoDb
        /// </summary>
        /// <param name="bank"></param>
        public UserAccountEntity ReadBankById(Guid bankid) 
        {
            var collection = _db.GetCollection<UserAccountEntity>(BankCollectionName);
            var filter = Builders<UserAccountEntity>.Filter.Eq("BankAccountId", bankid);
            var bankDocument = collection.Find(filter).FirstOrDefault();
            return bankDocument;
        }
        public UserAccountEntity GetByName(string BankName) 
        {
            var collenction = _db.GetCollection<UserAccountEntity>(BankCollectionName);
            var filter = Builders<UserAccountEntity>.Filter.Eq("BankName", BankName);
            var bankDocument = collenction.Find(filter).FirstOrDefault();
            return bankDocument;
        }
        /// <summary>
        /// get all users
        /// </summary>
        /// <returns></returns>
        public List<UserAccountEntity> GetAllList() 
        {
            var collection = _db.GetCollection<UserAccountEntity>(BankCollectionName);
            return collection.Aggregate<UserAccountEntity>().ToList();  
        }
       


    }
}
