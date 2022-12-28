using Learning.Bll.Interfaces;
using Learning.Dal.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Learning.Api.Controllers
{
    [Route("api/v1/bank")]
    [ApiController]
    public class BankController : ControllerBase
    {



        private IBankService _bankService;

        public BankController(IBankService bankService)
        {
            _bankService = bankService;
        }
        [Route("create-bank")]
        [HttpPost]
        public IActionResult CreateBank([FromBody] BankModel bank)
        {
            _bankService.InsertBank(bank);
            return new JsonResult(bank);
        }
        [Route("delete-bank")]
        [HttpDelete]
        public IActionResult DeleteBank([FromBody] BankModel bank)
        {
            _bankService.DeleteBank(bank);
            return new JsonResult(bank);
        }
        [Route("update-bank")]
        [HttpPatch]
        public IActionResult UpdateBank([FromBody] BankModel bank)
        {
            _bankService.UpdateBank(bank);
            return new JsonResult(bank);
        }
        [Route("/{bankid}")]
        [HttpGet]
        public IActionResult ReadBankById(Guid bankid)
        {
           var bank = _bankService.ReadBankById(bankid);
            return new JsonResult(bank);
        }

        [Route("bank-money")]
        [HttpGet]
        public IActionResult ReadBankByMoney(int amountOfMoney) 
        { 
            var bank = _bankService.ReadBankByMoney(amountOfMoney);
            return new JsonResult(bank);
        }
        [Route("get-all-banks")]
        [HttpGet]
        public IActionResult GetAllBanks() 
        { 
            var bank = _bankService.GetAllBanks();
            return new JsonResult(bank);
        }

        
    }
}
