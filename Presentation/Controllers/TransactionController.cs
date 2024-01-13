using Application.Transaction.Commands.CreateTransaction;
using Application.Transaction.Commands.PayTransactionCommand;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Presentation.Models.Transaction;

namespace Presentation.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TransactionController : ControllerBase
{
    private readonly IMediator _mediator;

    public TransactionController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> CreateTransaction(
        [FromBody] CreateTransactionModel model,
        CancellationToken cancellationToken = default)
    {
        CreateTransactionCommand command = new(
                                               model.Amount,
                                               model.CreditorIds,
                                               model.DebtorId,
                                               model.BillId
                                              );

        int result = await _mediator.Send(command, cancellationToken);
        return Ok(result > 0);
    }

    [HttpPost("pay-transaction")]
    public async Task<IActionResult> PayTransaction(
        [FromBody] PayTransactionModel model,
        CancellationToken cancellationToken = default)
    {
        bool result = await _mediator.Send(new PayTransactionCommand(model.TransactionId, model.BillId, model.CreditorUserId, model.Amount),
                                           cancellationToken);
        return Ok(result);
    }
}