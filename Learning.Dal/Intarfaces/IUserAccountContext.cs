using Learning.Dal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Learning.Dal.InsertModels;
using Learning.Common.Models.PatchModels;

namespace Learning.Dal.Intarfaces
{
    public interface IUserAccountContext
    {
        void InsertBank(UserAccountInsertModel newBankAccount);
        UserAccountEntity DeleteBank(Guid bankId);
        UserAccountEntity UpdateBank(Guid bankid, UserAccountPatchModel newUserAccount);
        UserAccountEntity ReadBankById(Guid bankid);
        UserAccountEntity GetByName(string BankName);
        List<UserAccountEntity> GetAllList();
    }
}
