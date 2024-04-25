using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PicPaySimplificado.Communication.Requests;
using PicPaySimplificado.Services.Services.Transaction;
using PicPaySimplificado.Services.Services.Transaction.Exceptions;
using PicPaySimplificado.Services.Services.User;


namespace PicPaySimplificado.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        private TransactionService _transactionService { get; set; }
        //private UserService _userService { get; set; }


        public TransactionController(TransactionService transactionService, UserService userService)
        {
            _transactionService = transactionService;
            // _userService = userService;
        }
        [HttpPost]
        public async Task<IActionResult> CreateTransaction(TransactionRequest transaction)
        {
            try
            {
                var res = await _transactionService.Transfer(transaction);

                return Created(string.Empty, transaction);
            }
            catch (InvalidTransactionException e)
            {

                return BadRequest(e);
            }

        }


    }
}
