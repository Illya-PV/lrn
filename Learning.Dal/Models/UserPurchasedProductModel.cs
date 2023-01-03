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
    [BsonIgnoreExtraElements]
    public class UserPurchasedProductModel
    { 
        public Guid UserId { get; set; }
        public int TotalPrice { get; set; }
        public Guid ProductID { get; set; }
    }
}
