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
    public class MongoDBGoodsModel
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public int IDItem { get; set; }
        public int Price { get; set; }
        public int Count { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Color { get; set; }
    }
}
