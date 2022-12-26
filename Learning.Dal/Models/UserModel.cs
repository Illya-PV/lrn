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
    public class UserModel
    { 
        public Guid UserId { get; set; }        
        public Guid BankAccountId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Fullname => $"{FirstName} {LastName}";
        public string Email { get; set; }
        public string Password { get; set; }
    }
}




   
        

