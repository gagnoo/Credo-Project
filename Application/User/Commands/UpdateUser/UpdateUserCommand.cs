using MediatR;

namespace Application.User.Commands.UpdateUser;

public record UpdateUserCommand(int UserId, string Name) : IRequest<int>;