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
using Learning.Common.Models.InsertModels;

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
        public void InsertUserPurchasedProduct(UserPurchasedProductInsertModel UserPurchasedProduct)
        {
            
            if (UserPurchasedProduct.TotalPrice <= 0)
            {
                UserPurchasedProduct.TotalPrice = 0;
            }
            else { _uPP.InsertUPPToMongoDb(UserPurchasedProduct);}
           
        }
        /// <summary>
        /// delete UserPurchasedProduct
        /// </summary>
        /// <param name="UserPurchasedProduct"></param>
        /// <returns></returns>
        public UserPurchasedProductEntity DeleteUserPurchasedProduct(Guid userId)
        {
            return _uPP.DeleteUPPFromMongoDb(userId);
             
        }
        /// <summary>
        /// update UserPurchasedProduct
        /// </summary>
        /// <param name="UserPurchasedProduct"></param>
        /// <returns></returns>
        public UserPurchasedProductEntity UpdateUserPurchasedProduct(Guid userId,UserPurchasedProductEntity UserPurchasedProduct)
        {
            return _uPP.UpdateUPPInMongoDb(userId,UserPurchasedProduct);  
        }
        /// <summary>
        /// read UserPurchasedProduct
        /// </summary>
        /// <param name="UserPurchasedProduct"></param>
        /// <returns></returns>
        public UserPurchasedProductEntity GetById(Guid userId)
        {
            return _uPP.GetById(userId);  
        }
        public List<UserPurchasedProductEntity> GetAllUserPurchasedProduct() 
        {
            return _uPP.GetAllList();
        }
    }
}
