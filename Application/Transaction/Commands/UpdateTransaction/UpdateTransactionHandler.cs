using MediatR;

namespace Application.Transaction.Commands.UpdateTransaction;

public class UpdateTransactionHandler : IRequestHandler<UpdateTransactionCommand, bool>
{
    public Task<bool> Handle(UpdateTransactionCommand request, CancellationToken cancellationToken)
    {
        try
        {
            throw new NotImplementedException();
        }
        catch (Exception ex)
        {
            string msg = ex.Message;
            throw;
        }
    }
}