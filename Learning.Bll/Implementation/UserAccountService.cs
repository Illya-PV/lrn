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
        public InsertAndUpdateModelForBank InsertBank(InsertAndUpdateModelForBank newBankAccount) 
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
            return newBankAccount;
        }
        /// <summary>
        /// delete bank
        /// </summary>
        /// <param name="bank"></param>
        /// <returns></returns>
        public UserAccount DeleteBank(Guid userId) 
        {
            return  _bankContext.DeleteBank(userId);
            
        }
        /// <summary>
        /// update bank
        /// </summary>
        /// <param name="bank"></param>
        /// <returns></returns>
        public UserAccount UpdateBank(Guid bankid, InsertAndUpdateModelForBank newBankAccount) 
        {
            return _bankContext.UpdateBank(bankid, newBankAccount);
             
        }
        /// <summary>
        /// read bank
        /// </summary>
        /// <param name="bank"></param>
        /// <returns></returns>
        public UserAccount ReadBankById(Guid bankid) 
        {
            return _bankContext.ReadBankById(bankid);           
        }
        public UserAccount GetByName(string BankName) 
        { 
            return _bankContext.GetByName(BankName);
        }
        public List<UserAccount> GetAllBanks() 
        {
            return _bankContext.GetAllList();
        }
    }
}
