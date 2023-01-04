﻿using Learning.Common.Models.InsertModels;
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
        void InsertUserPurchasedProduct(UserPurchasedProductInsertModel UserPurchasedProduct);
        UserPurchasedProductEntity DeleteUserPurchasedProduct(Guid userId);
        UserPurchasedProductEntity UpdateUserPurchasedProduct(Guid userId, UserPurchasedProductEntity UserPurchasedProduct);
        UserPurchasedProductEntity GetById(Guid userId);
        List<UserPurchasedProductEntity> GetAllUserPurchasedProduct();
    }
}
