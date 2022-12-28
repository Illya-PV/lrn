using Learning.Dal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learning.Dal.Intarfaces
{
    public interface IBankContext
    {
        BankModel InsertBankToMongoDb(BankModel bank);
        BankModel DeleteBankFromMongoDb(BankModel bank);
        BankModel UpdateBankInMongoDb(BankModel bank);
        BankModel ReadBankFromMongoDbById(Guid bankid);
        BankModel ReadBankFromMongoDbByMoney(int amountOfMoney);
        List<BankModel> GetAllList();
    }
}
