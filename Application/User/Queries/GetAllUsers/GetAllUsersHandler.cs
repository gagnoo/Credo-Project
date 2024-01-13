using Application.User.Queries.GetAllUsers.Models;
using Domain.Abstractions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.User.Queries.GetAllUsers;

public class GetAllUsersHandler : IRequestHandler<GetAllUsersCommand, List<UserResponseModel>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllUsersHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<List<UserResponseModel>> Handle(GetAllUsersCommand request, CancellationToken cancellationToken)
    {
        return await _unitOfWork
                     .UserRepository
                     .List()
                     .Select(i => new UserResponseModel
                     {
                         Name = i.Name,
                         UserId = i.UserId
                     })
                     .ToListAsync(cancellationToken);
    }
}