using Application.User.Queries.GetAllUsers.Models;
using Domain.Abstractions;
using MediatR;

namespace Application.User.Commands.GetUser;

public class GetUserHandler : IRequestHandler<GetUserCommand, UserResponseModel?>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetUserHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<UserResponseModel?> Handle(GetUserCommand request, CancellationToken cancellationToken)
    {
        Domain.Entities.UserEntity.User? user = await _unitOfWork
                                                      .UserRepository
                                                      .GetAsync(i => i.UserId == request.UserId, cancellationToken);
        if (user is null)
        {
            return default;
        }

        UserResponseModel responseModel = new()
        {
            Name = user.Name,
            UserId = user.UserId
        };
        return responseModel;
    }
}