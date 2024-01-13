using Application.User.Queries.GetAllUsers.Models;
using MediatR;

namespace Application.User.Commands.GetUser;

public record GetUserCommand(int UserId) : IRequest<UserResponseModel?>;