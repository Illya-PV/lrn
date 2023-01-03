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
        UserPurchasedProductModel InsertUPPToMongoDb(UserPurchasedProductModel userPuechasedProduct);
        UserPurchasedProductModel DeleteUPPFromMongoDb(Guid userId);
        UserPurchasedProductModel UpdateUPPInMongoDb(Guid userId, UserPurchasedProductModel userPurchasedProduct);
        UserPurchasedProductModel GetById(Guid userId);
        List<UserPurchasedProductModel> GetAllList();


    }
}
