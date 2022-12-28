using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Learning.Dal;
using Learning.Dal.Models;
using Learning.Dal.Context;
using Learning.Bll.Interfaces;
using Learning.Dal.Intarfaces;

namespace Learning.Bll.Implementation
{
    public class UserPurchasedProductServiceI:IUserPurchasedProductService
    {
        private IUserPurchasedProductContext _uPP;

        public UserPurchasedProductService(IUserPurchasedProductContext userPurchasedProductContext) 
        { 
            _uPP = userPurchasedProductContext;
        }

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
            else { _uPP.InsertUPPToMongoDb(UserPurchasedProduct);}
            return UserPurchasedProduct;
        }
        /// <summary>
        /// delete UserPurchasedProduct
        /// </summary>
        /// <param name="UserPurchasedProduct"></param>
        /// <returns></returns>
        public UserPurchasedProductModel DeleteUserPurchasedProduct(UserPurchasedProductModel UserPurchasedProduct)
        {
            _uPP.DeleteUPPFromMongoDb(UserPurchasedProduct);
            return UserPurchasedProduct;
        }
        /// <summary>
        /// update UserPurchasedProduct
        /// </summary>
        /// <param name="UserPurchasedProduct"></param>
        /// <returns></returns>
        public UserPurchasedProductModel UpdateUserPurchasedProduct(UserPurchasedProductModel UserPurchasedProduct)
        {
            _uPP.UpdateUPPInMongoDb(UserPurchasedProduct);
            return UserPurchasedProduct;
        }
        /// <summary>
        /// read UserPurchasedProduct
        /// </summary>
        /// <param name="UserPurchasedProduct"></param>
        /// <returns></returns>
        public UserPurchasedProductModel ReadUserPurchasedProduct(UserPurchasedProductModel UserPurchasedProduct)
        {
            _uPP.ReadUPPFromMongoDB(UserPurchasedProduct);
            return UserPurchasedProduct;
        }
    }
}
