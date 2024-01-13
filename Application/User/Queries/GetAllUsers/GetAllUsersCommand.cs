using Application.User.Queries.GetAllUsers.Models;
using MediatR;

namespace Application.User.Queries.GetAllUsers;

public record GetAllUsersCommand() : IRequest<List<UserResponseModel>>;