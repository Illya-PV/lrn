using MongoDB.Bson.Serialization.Attributes;

namespace Learning.Dal.Models
{
    [BsonIgnoreExtraElements]
    public class ProductModel
    {
        public Guid ProductId { get; set; }
        public int Price { get; set; }
        public int Count { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Color { get; set; }
    }
}
