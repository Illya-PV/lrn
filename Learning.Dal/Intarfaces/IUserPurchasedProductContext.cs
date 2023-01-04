using Learning.Common.Models.InsertModels;
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
        void InsertUPPToMongoDb(UserPurchasedProductInsertModel intsertUserPuechasedProduct);
        UserPurchasedProductEntity DeleteUPPFromMongoDb(Guid userId);
        UserPurchasedProductEntity UpdateUPPInMongoDb(Guid userId, UserPurchasedProductEntity userPurchasedProduct);
        UserPurchasedProductEntity GetById(Guid userId);
        List<UserPurchasedProductEntity> GetAllList();


    }
}
