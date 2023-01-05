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
    public class UserAccountEntity
    {
        public Guid BankAccountId { get; set; }
        public int AmountOfMoney { get; set; }
        public string BankName{ get; set; }
        public bool IsLocked { get; set; }

    }
}
