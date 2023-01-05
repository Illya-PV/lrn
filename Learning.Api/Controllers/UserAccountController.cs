using Learning.Bll.Interfaces;
using Learning.Common.Models.PatchModels;
using Learning.Dal.InsertModels;
using Learning.Dal.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Learning.Api.Controllers
{
    [Route("api/v1/user-account")]
    [ApiController]
    public class UserAccountController : ControllerBase
    {



        private IUserAccountService _userAccountService;

        public UserAccountController(IUserAccountService bankService)
        {
            _userAccountService = bankService;
        }
        [Route("create-user-account")]
        [HttpPost]
        public IActionResult CreateBank([FromBody] UserAccountInsertModel bank)
        {
            _userAccountService.InsertBank(bank);
            return new JsonResult(bank);
        }
        [Route("delete-user-account")]
        [HttpDelete]
        public IActionResult DeleteBank(Guid userId)
        {
            var bank = _userAccountService.DeleteBank(userId);
            return new JsonResult(bank);
        }
        [Route("update-user-account")]
        [HttpPatch]
        public IActionResult UpdateBank(Guid bankid,[FromBody]UserAccountPatchModel bank)
        {
            _userAccountService.UpdateBank(bankid, bank);
            return new JsonResult(bank);
        }
        [Route("get-user-account-by-id")]
        [HttpGet]
        public IActionResult ReadBankById(Guid bankid)
        {
           var bank = _userAccountService.ReadBankById(bankid);
            return new JsonResult(bank);
        }
        [Route("get-user-account-by-name")]
        [HttpGet]
        public IActionResult GetBankByName(string bankName)
        {
            var bank = _userAccountService.GetByName(bankName);
            return new JsonResult(bank);
        }
        [Route("get-all-user-accounts")]
        [HttpGet]
        public IActionResult GetAllBanks() 
        { 
            var bank = _userAccountService.GetAllBanks();
            return new JsonResult(bank);
        }   
    }
}
