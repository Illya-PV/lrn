using Learning.Dal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learning.Bll.Interfaces
{
    public interface IUserPurchasedProductService
    {
        UserPurchasedProductModel InsertUserPurchasedProduct(UserPurchasedProductModel UserPurchasedProduct);
        UserPurchasedProductModel DeleteUserPurchasedProduct(Guid userId);
        UserPurchasedProductModel UpdateUserPurchasedProduct(Guid userId, UserPurchasedProductModel UserPurchasedProduct);
        UserPurchasedProductModel GetById(Guid userId);
        List<UserPurchasedProductModel> GetAllUserPurchasedProduct();
    }
}
