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
        UserPurchasedProductModel InsertUserPurchasedProduct(UserPurchasedProductModel userPurchasedProduct);
        UserPurchasedProductModel DeleteUserPurchasedProduct(UserPurchasedProductModel userPurchasedProduct);
        UserPurchasedProductModel UpdateUserPurchasedProduct(UserPurchasedProductModel userPurchasedProduct);
        UserPurchasedProductModel ReadUserPurchasedProduct(UserPurchasedProductModel userPurchasedProduct);
    }
}
