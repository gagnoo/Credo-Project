using Application.Billing.Commands.CreateBill;
using Application.Billing.Commands.GetBill;
using Domain.Entities.BillingEntity;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Presentation.Models.Bill;

namespace Presentation.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BillingController : ControllerBase
{
    private readonly IMediator _mediator;

    public BillingController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetBill(
        [FromQuery] int id,
        CancellationToken cancellationToken = default)
    {
        Bill? bill = await _mediator.Send(new GetBillCommand(id), cancellationToken);
        if (bill is null)
        {
            return NotFound();
        }

        return Ok(bill);
    }

    [HttpPost]
    public async Task<IActionResult> CreateBill(
        [FromBody] CreateBillModel model,
        CancellationToken cancellationToken = default)
    {
        int result = await _mediator.Send(new CreateBillCommand(model.Amount, model.ParticipantIds, model.DebitorId), cancellationToken);
        return Ok(result > 0);
    }
}