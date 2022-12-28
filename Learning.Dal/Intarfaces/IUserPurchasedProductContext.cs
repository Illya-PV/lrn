using Learning.Dal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learning.Dal.Intarfaces
{
    public interface IUserPurchasedProductContext
    {
        void InsertUPPToMongoDb(UserPurchasedProductModel userPuechasedProduct);
        void DeleteUPPFromMongoDb(UserPurchasedProductModel userPuechasedProduct);
        void UpdateUPPInMongoDb(UserPurchasedProductModel userPuechasedProduct);
        void ReadUPPFromMongoDB(UserPurchasedProductModel userPuechasedProduct);


    }
}
