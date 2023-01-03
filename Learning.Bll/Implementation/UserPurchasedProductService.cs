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
    public class UserPurchasedProductService : IUserPurchasedProductService
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
        public UserPurchasedProductModel DeleteUserPurchasedProduct(Guid userId)
        {
            return _uPP.DeleteUPPFromMongoDb(userId);
             
        }
        /// <summary>
        /// update UserPurchasedProduct
        /// </summary>
        /// <param name="UserPurchasedProduct"></param>
        /// <returns></returns>
        public UserPurchasedProductModel UpdateUserPurchasedProduct(Guid userId,UserPurchasedProductModel UserPurchasedProduct)
        {
            return _uPP.UpdateUPPInMongoDb(userId,UserPurchasedProduct);  
        }
        /// <summary>
        /// read UserPurchasedProduct
        /// </summary>
        /// <param name="UserPurchasedProduct"></param>
        /// <returns></returns>
        public UserPurchasedProductModel GetById(Guid userId)
        {
            return _uPP.GetById(userId);  
        }
        public List<UserPurchasedProductModel> GetAllUserPurchasedProduct() 
        {
            return _uPP.GetAllList();
        }
    }
}
