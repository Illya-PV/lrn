using MongoDB.Bson.Serialization.Attributes;

namespace Learning.Dal.Models
{
    [BsonIgnoreExtraElements]
    public class InsertAndUpdateModelForBank
    {
        public Guid UserId { get; set; }
        public Guid? BankAccountId { get; set; }
        public int AmountOfMoney { get; set; }
        public string BankName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool IsLocked { get; set; }
        public string Fullname => $"{FirstName} {LastName}";

    }
}
