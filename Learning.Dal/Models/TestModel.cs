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
    public class TestModel
    {
        public Guid SomeIDGuid { get; set; }
        public int SomeIdInt { get; set; }
        public string SomeIDStr { get; set; }
    }
}
