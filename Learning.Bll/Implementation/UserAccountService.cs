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
using Learning.Dal.InsertModels;
using Learning.Common.Models.PatchModels;

namespace Learning.Bll.Implementation
{
    public class UserAccountService : IUserAccountService
    {
        private Dal.Intarfaces.IUserAccountContext _bankContext;

        public UserAccountService(Dal.Intarfaces.IUserAccountContext bankContext) 
        { 
            _bankContext = bankContext;
        }
 

        /// <summary>
        /// insert bank
        /// </summary>
        /// <param name="bank"></param>
        /// <returns></returns>
        public void InsertBank(UserAccountInsertModel newBankAccount) 
        {
            if (newBankAccount.AmountOfMoney <= 0)
            {
                newBankAccount.AmountOfMoney = 0;
                Console.WriteLine("You haven`t money");
            }
            else
            {
                _bankContext.InsertBank(newBankAccount);
                Console.WriteLine($"bank:{newBankAccount} added successfully\n");
            }
            
        }
        /// <summary>
        /// delete bank
        /// </summary>
        /// <param name="bank"></param>
        /// <returns></returns>
        public UserAccountEntity DeleteBank(Guid userId) 
        {
            return  _bankContext.DeleteBank(userId);
            
        }
        /// <summary>
        /// update bank
        /// </summary>
        /// <param name="bank"></param>
        /// <returns></returns>
        public UserAccountEntity UpdateBank(Guid bankid, UserAccountPatchModel newBankAccount) 
        {
            return _bankContext.UpdateBank(bankid, newBankAccount);
             
        }
        /// <summary>
        /// read bank
        /// </summary>
        /// <param name="bank"></param>
        /// <returns></returns>
        public UserAccountEntity ReadBankById(Guid bankid) 
        {
            return _bankContext.ReadBankById(bankid);           
        }
        public UserAccountEntity GetByName(string BankName) 
        { 
            return _bankContext.GetByName(BankName);
        }
        public List<UserAccountEntity> GetAllBanks() 
        {
            return _bankContext.GetAllList();
        }
    }
}
