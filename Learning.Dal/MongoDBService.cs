using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Learning.Dal.Models;
using MongoDB.Driver;
using Learning.Dal.Context;

namespace Learning.Dal
{


    public class MongoDBService
    {
        private IMongoDatabase _db;

        string connectionString = "mongodb+srv://illia_pv:localhost1617@cluster0.nvlushg.mongodb.net/test";
        string DBName = "EStore";
        string ProdeuctCollectionName = "products";
        string UserCollectionName = "user";
        string BankCollectionName = "bank";
        public MongoDBService()
        {
            MongoClient mongoClient = new MongoClient(connectionString);
            _db = mongoClient.GetDatabase(DBName);

        }


       /* /// <summary>
        /// insert product to the DB
        /// </summary>
        /// <param name="product"></param>
        public void InsertProductToMongoDb(ProductModel product)
        {
            var collection = _db.GetCollection<ProductModel>(ProdeuctCollectionName);
            
            if (product.Price <= 0)
            {
                product.Price *= 0;

                Console.WriteLine("Price cannot be less then 0");
                if (product.Count <= 0)
                {
                    product.Count *= 0;
                    Console.WriteLine("This product is empty\n");
                }
            }
            else if (product.Count <= 0)
            {
                product.Count *= 0;
                Console.WriteLine("This product is empty\n");
            }
            else 
            {
                collection.InsertOne(product);
                Console.WriteLine($"product:{product} added successfully\n"); 
            }
        }

        /// <summary>
        /// insert user to mongoDB
        /// </summary>
        /// <param name="user"></param>
        public void InsertUserToMongoDb(UserModel user) 
        {
            var collection = _db.GetCollection<UserModel>(UserCollectionName);

            if (user.FirstName == " " | user.LastName == " ")
            {
                Console.WriteLine("user name can`t be empty\n");
                user.FirstName = "default";
                user.LastName = "default";
                if (user.Email.Contains('@') == false)
                {
                    Console.WriteLine("wrong email addres\n");
                }
                else
                {
                    collection.InsertOne(user);
                    Console.WriteLine("user added successfully\n");
                }
            }
            else if (user.Email.Contains('@') == false)
            {
                Console.WriteLine("wrong email addres\n");
            }
            else
            {
                collection.InsertOne(user);
                Console.WriteLine($"user:{user} added successfully\n");
            }
            collection.InsertOne(user);
        }

        public void InsertBankToMongoDb(BankModel bank) 
        {
            var collection = _db.GetCollection<BankModel>(BankCollectionName);
            if (bank.AmounOfMoney <= 0)
            {
                bank.AmounOfMoney = 0;
                Console.WriteLine("You haven`t money");
            }
            else 
            {
                Console.WriteLine($"bank:{bank} added successfully\n");
                collection.InsertOne(bank); 
            }
            
        }*/
   
    }
}
