using CQRS.Kafka.API.Commands;
using CQRS.Kafka.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace CQRS.Kafka.API.Controllers;

[ApiController]
[Route("api/bank")]
public class BankController(BankCommandService commandService) : ControllerBase
{
    [HttpPost("deposit")]
    public async Task<IActionResult> Deposit([FromBody] DepositMoney command)
    {
        await commandService.HandleDeposit(command);
        return Ok("Deposit processed.");
    }

    [HttpPost("withdraw")]
    public async Task<IActionResult> Withdraw([FromBody] WithdrawMoney command)
    {
        await commandService.HandleWithdraw(command);
        return Ok("Withdrawal processed.");
    }

    [HttpPost("transfer")]
    public async Task<IActionResult> Transfer([FromBody] TransferMoney command)
    {
        await commandService.HandleTransfer(command);
        return Ok("Transfer processed.");
    }
}
