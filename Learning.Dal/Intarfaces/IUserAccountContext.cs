using Learning.Dal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learning.Dal.Intarfaces
{
    public interface IUserAccountContext
    {
        InsertAndUpdateModelForBank InsertBank(InsertAndUpdateModelForBank newBankAccount);
        UserAccountModel DeleteBank(Guid bankId);
        UserAccountModel UpdateBank(Guid bankid, InsertAndUpdateModelForBank newBankAccount);
        UserAccountModel ReadBankById(Guid bankid);
        UserAccountModel GetByName(string BankName);
        List<UserAccountModel> GetAllList();
    }
}
