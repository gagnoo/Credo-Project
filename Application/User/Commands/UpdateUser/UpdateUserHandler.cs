using Domain.Abstractions;
using MediatR;

namespace Application.User.Commands.UpdateUser;

public class UpdateUserHandler : IRequestHandler<UpdateUserCommand, int>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateUserHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<int> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
    {
        Domain.Entities.UserEntity.User? user = await _unitOfWork
                                                      .UserRepository
                                                      .GetAsync(i => i.UserId == request.UserId,
                                                                cancellationToken);
        if (user is null)
        {
            throw new InvalidOperationException("Could not get user");
        }

        _unitOfWork.UserRepository.Update(user);
        return await _unitOfWork.SaveAsync(cancellationToken);
    }
}