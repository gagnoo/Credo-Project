using Domain.Abstractions;
using MediatR;

namespace Application.User.Commands.CreateUser;

public class AddUserHandler : IRequestHandler<AddUserCommand, int>
{
    private readonly IUnitOfWork _unitOfWork;

    public AddUserHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public Task<int> Handle(AddUserCommand request, CancellationToken cancellationToken)
    {
        _unitOfWork.UserRepository.Add(new Domain.Entities.UserEntity.User
        {
            Name = request.Name
        });

        return _unitOfWork.SaveAsync(cancellationToken);
    }
}