using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;
//using Learning.Dal;


string connectingString = "mongodb://127.0.0.1:27017";
string DBname = "EStore";
string collectionName = "Type";

var item = new MongoClient(connectingString);
var db = item.GetDatabase(DBname);
var collection = db.GetCollection<MongoDBModel>(collectionName);

var goods = new MongoDBModel { Name = "computer mouse", Count = 200, Price = 1500, Type = "computer peripherals", Color = "White" };

await collection.InsertOneAsync(goods);

var results = await collection.FindAsync(_ => true);

foreach (var result in results.ToList())
{
    Console.WriteLine($"ID:{result.ID}\n Name:{result.Name}\n Price:{result.Price}\n" +
        $" Count:{result.Count}\n Color:{result.Color}\n Type:{result.Type}:");
}