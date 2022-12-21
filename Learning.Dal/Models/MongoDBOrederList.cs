using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;
using MongoDB;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Learning.Dal.Models
{
    public class MongoDBOrederList
    { 
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public int IDPurchase { get; set; }
        public DateTime DateOfOrder { get; set; }
        public int TotalCost { get; set; }
    }
}
