using Learning.Common.Models.PatchModels;
using Learning.Dal.InsertModels;
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
        void InsertBank(UserAccountInsertModel newBankAccount);
        UserAccountEntity UpdateBank(Guid bankid, UserAccountEntity newBankAccount);
        UserAccountEntity DeleteBank(Guid userId);
        UserAccountEntity ReadBankById(Guid bankid);
        UserAccountEntity GetByName(string BankName);
        List<UserAccountEntity> GetAllBanks();


    }
}
