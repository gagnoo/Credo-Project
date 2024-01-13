using Application.User.Commands.CreateUser;
using Application.User.Commands.GetUser;
using Application.User.Queries.GetAllUsers;
using Application.User.Queries.GetAllUsers.Models;
using Domain.Entities.UserEntity;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Presentation.Models.User;

namespace Presentation.Controllers;

[ApiController]
[Route("api/[controller]/")]
public class UserController : ControllerBase
{
    private readonly IMediator _mediator;

    public UserController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetUser(
        [FromQuery] int userId,
        CancellationToken cancellationToken = default)
    {
        UserResponseModel? user = await _mediator.Send(new GetUserCommand(userId), cancellationToken);
        if (user is null)
        {
            return NotFound();
        }

        return Ok(user);
    }

    [HttpPost("users")]
    public async Task<IActionResult> GetUszers(CancellationToken cancellationToken = default)
    {
        List<UserResponseModel> users = await _mediator.Send(new GetAllUsersCommand(), cancellationToken);
        return Ok(users);
    }

    [HttpPost]
    public async Task<IActionResult> CreateUser(
        [FromBody] CreateUserModel model,
        CancellationToken cancellationToken = default)
    {
        int created = await _mediator.Send(new AddUserCommand(model.Name), cancellationToken);
        return Ok(created > 0);
    }
}