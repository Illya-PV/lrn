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
    public class BankService : IBankService
    {
        private IBankContext _bankContext;

        public BankService(IBankContext bankContext) 
        { 
            _bankContext = bankContext;
        }
 

        /// <summary>
        /// insert bank
        /// </summary>
        /// <param name="bank"></param>
        /// <returns></returns>
        public BankModel InsertBank(BankModel bank) 
        {
            if (bank.AmounOfMoney <= 0)
            {
                bank.AmounOfMoney = 0;
                Console.WriteLine("You haven`t money");
            }
            else
            {
                _bankContext.InsertBankToMongoDb(bank);
                Console.WriteLine($"bank:{bank} added successfully\n");
            }
            return bank;
        }
        /// <summary>
        /// delete bank
        /// </summary>
        /// <param name="bank"></param>
        /// <returns></returns>
        public BankModel DeleteBank(BankModel bank) 
        {
            _bankContext.DeleteBankFromMongoDb(bank);
            return bank;
        }
        /// <summary>
        /// update bank
        /// </summary>
        /// <param name="bank"></param>
        /// <returns></returns>
        public BankModel UpdateBank(BankModel bank) 
        {
            _bankContext.UpdateBankInMongoDb(bank);
            return bank;
        }
        /// <summary>
        /// read bank
        /// </summary>
        /// <param name="bank"></param>
        /// <returns></returns>
        public BankModel ReadBankById(Guid bankid) 
        {
            return _bankContext.ReadBankFromMongoDbById(bankid);
            
        }
        public BankModel ReadBankByMoney(int amountOfMoney)
        {
            return _bankContext.ReadBankFromMongoDbByMoney(amountOfMoney);
        }
        public List<BankModel> GetAllBanks() 
        {
            return _bankContext.GetAllList();
        }
    }
}
