using Learning.Bll.Interfaces;
using Learning.Dal.InsertModels;
using Learning.Dal.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Learning.Api.Controllers
{
    [Route("api/v1/bank")]
    [ApiController]
    public class UserAccountController : ControllerBase
    {



        private IUserAccountService _userAccountService;

        public UserAccountController(IUserAccountService bankService)
        {
            _userAccountService = bankService;
        }
        [Route("create-bank")]
        [HttpPost]
        public IActionResult CreateBank([FromBody] UserAccountInsertModel bank)
        {
            _userAccountService.InsertBank(bank);
            return new JsonResult(bank);
        }
        [Route("delete-bank")]
        [HttpDelete]
        public IActionResult DeleteBank(Guid userId)
        {
            var bank = _userAccountService.DeleteBank(userId);
            return new JsonResult(bank);
        }
        [Route("update-bank")]
        [HttpPatch]
        public IActionResult UpdateBank(Guid bankid,[FromBody]UserAccountEntity bank)
        {
            _userAccountService.UpdateBank(bankid, bank);
            return new JsonResult(bank);
        }
        [Route("/{bankid}")]
        [HttpGet]
        public IActionResult ReadBankById(Guid bankid)
        {
           var bank = _userAccountService.ReadBankById(bankid);
            return new JsonResult(bank);
        }
        [Route("get-bank-by-name")]
        [HttpGet]
        public IActionResult GetBankByName(string bankName)
        {
            var bank = _userAccountService.GetByName(bankName);
            return new JsonResult(bank);
        }
        [Route("get-all-banks")]
        [HttpGet]
        public IActionResult GetAllBanks() 
        { 
            var bank = _userAccountService.GetAllBanks();
            return new JsonResult(bank);
        }   
    }
}
