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
        UserAccount DeleteBank(Guid bankId);
        UserAccount UpdateBank(Guid bankid, InsertAndUpdateModelForBank newBankAccount);
        UserAccount ReadBankById(Guid bankid);
        UserAccount GetByName(string BankName);
        List<UserAccount> GetAllList();
    }
}
