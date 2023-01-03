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
        UserAccountModel UpdateBank(Guid bankid, InsertAndUpdateModelForBank newBankUser);
        UserAccountModel DeleteBank(Guid userId);
        UserAccountModel ReadBankById(Guid bankid);
        UserAccountModel GetByName(string BankName);
        List<UserAccountModel> GetAllBanks();


    }
}
