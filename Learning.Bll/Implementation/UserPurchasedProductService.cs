using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Learning.Dal;
using Learning.Dal.Context;
using Learning.Dal.Models;

namespace Learning.Bll.Implementation
{
    public class UserPurchasedProductServiceIUserPurchasedProductService
    {
        UserPurchasedProductContext uPP;

        /// <summary>
        /// insert UserPurchasedProduct
        /// </summary>
        /// <param name="UserPurchasedProduct"></param>
        /// <returns></returns>
        public UserPurchasedProductModel InsertUserPurchasedProduct(UserPurchasedProductModel UserPurchasedProduct)
        {
            UserPurchasedProduct.UserId = Guid.NewGuid();
            if (UserPurchasedProduct.TotalPrice <= 0)
            {
                UserPurchasedProduct.TotalPrice = 0;
            }
            else { uPP.InsertUPPToMongoDb(UserPurchasedProduct);}
            return UserPurchasedProduct;
        }
        /// <summary>
        /// delete UserPurchasedProduct
        /// </summary>
        /// <param name="UserPurchasedProduct"></param>
        /// <returns></returns>
        public UserPurchasedProductModel DeleteUserPurchasedProduct(UserPurchasedProductModel UserPurchasedProduct)
        {
            uPP.DeleteUPPFromMongoDb(UserPurchasedProduct);
            return UserPurchasedProduct;
        }
        /// <summary>
        /// update UserPurchasedProduct
        /// </summary>
        /// <param name="UserPurchasedProduct"></param>
        /// <returns></returns>
        public UserPurchasedProductModel UpdateUserPurchasedProduct(UserPurchasedProductModel UserPurchasedProduct)
        {
            uPP.UpdateUPPInMongoDb(UserPurchasedProduct);
            return UserPurchasedProduct;
        }
        /// <summary>
        /// read UserPurchasedProduct
        /// </summary>
        /// <param name="UserPurchasedProduct"></param>
        /// <returns></returns>
        public UserPurchasedProductModel ReadUserPurchasedProduct(UserPurchasedProductModel UserPurchasedProduct)
        {
            uPP.ReadUPPFromMongoDB(UserPurchasedProduct);
            return UserPurchasedProduct;
        }
    }
}
