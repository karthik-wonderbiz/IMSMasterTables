using MediatR;
using MasterTables.Application.Commands;
using MasterTables.Domain.Interfaces;

namespace MasterTables.Application.CommandHandlers
{
    public class DeleteCustomerCommandHandler : IRequestHandler<DeleteCustomerCommand, bool>
    {
        private readonly ICustomerRepository _repository;

        public DeleteCustomerCommandHandler(ICustomerRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> Handle(DeleteCustomerCommand request, CancellationToken cancellationToken = default)
        {
            var customer = await _repository.GetCustomerByIdAsync(request.Id, cancellationToken);
            if (customer == null)
            {
                throw new Exception("Customer not found"); // Custom exception handling can be used
            }

            await _repository.DeleteCustomerAsync(customer, cancellationToken);
            return true;
        }
    }
}
