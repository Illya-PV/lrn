using Learning.Dal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Learning.Bll.Interfaces
{
    public interface IUserAccountService
    {
        InsertAndUpdateModelForBank InsertBank(InsertAndUpdateModelForBank newBankAccount);
        UserAccount UpdateBank(Guid bankid, InsertAndUpdateModelForBank newBankUser);
        UserAccount DeleteBank(Guid userId);
        UserAccount ReadBankById(Guid bankid);
        UserAccount GetByName(string BankName);
        List<UserAccount> GetAllBanks();


    }
}
