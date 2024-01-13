using MediatR;

namespace Application.User.Commands.CreateUser;

public record AddUserCommand(string Name) : IRequest<int>;