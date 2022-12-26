using Learning.Dal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Learning.Bll.Interfaces
{
    public interface IBankService
    {
        BankModel InsertBank(BankModel bank);
        BankModel UpdateBank(BankModel bank);
        BankModel DeleteBank(BankModel bank);
        BankModel ReadBank(BankModel bank);

    }
}
