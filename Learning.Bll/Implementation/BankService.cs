using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Learning.Dal;
using Learning.Dal.Models;
using Learning.Dal.Context;
using Learning.Bll.Interfaces;

namespace Learning.Bll.Implementation
{
    public class BankService:IBankService
    {
        BankContext? bankContext;

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
                bankContext.InsertBankToMongoDb(bank);
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
            bankContext.DeleteBankFromMongoDb(bank);
            return bank;
        }
        /// <summary>
        /// update bank
        /// </summary>
        /// <param name="bank"></param>
        /// <returns></returns>
        public BankModel UpdateBank(BankModel bank) 
        {
            bankContext.UpdateBankInMongoDb(bank);
            return bank;
        }
        /// <summary>
        /// read bank
        /// </summary>
        /// <param name="bank"></param>
        /// <returns></returns>
        public BankModel ReadBank(BankModel bank) 
        {
            bankContext.ReadBankFromMongoDb(bank);
            return bank;
        }
    }
}
