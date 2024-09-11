using MasterTables.Application.DTOs;
using MasterTables.Application.Interfaces;
using MasterTables.Domain.Exceptions;
using MediatR;
using MasterTables.Application.Commands;
using MasterTables.Application.Queries;

namespace MasterTables.Application.Services
{
    public class TaxService : ITaxService
    {
        private readonly IMediator _mediator;

        public TaxService(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<IEnumerable<TaxDto>> GetAllTaxesAsync(CancellationToken cancellationToken)
        {
            try
            {
                var query = new GetAllTaxesQuery();
                var result = await _mediator.Send(query, cancellationToken);
                return result;
            }
            catch (Exception ex)
            {
                // Log exception here
                throw new ApplicationException("An error occurred while retrieving taxes.", ex);
            }
        }

        public async Task<TaxDto> GetTaxByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            try
            {
                var query = new GetTaxByIdQuery(id);
                var result = await _mediator.Send(query, cancellationToken);
                if (result == null)
                {
                    throw new TaxNotFoundException($"Tax with ID {id} not found.");
                }
                return result;
            }
            catch (TaxNotFoundException)
            {
                throw;
            }
            catch (Exception ex)
            {
                // Log exception here
                throw new ApplicationException("An error occurred while retrieving the tax.", ex);
            }
        }

        public async Task<TaxDto> CreateTaxAsync(CreateTaxCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var command = new CreateTaxCommand
                {
                    TaxName = request.TaxName,
                    Percentage = request.Percentage,
                    Code = request.Code,
                };
                var result = await _mediator.Send(command, cancellationToken);
                if (result == null)
                {
                    throw new TaxAlreadyExistsException("Tax already exists.");
                }
                return result;
            }
            catch (TaxAlreadyExistsException)
            {
                throw; // rethrow the custom exception
            }
            catch (Exception ex)
            {
                // Log exception here
                throw new ApplicationException("An error occurred while creating the tax.", ex);
            }
        }

        public async Task<TaxDto> UpdateTaxAsync(UpdateTaxCommand command, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _mediator.Send(command, cancellationToken);
                if (result == null)
                {
                    throw new TaxNotFoundException("Tax not found for update.");
                }
                return result;
            }
            catch (TaxNotFoundException)
            {
                throw; // rethrow the custom exception
            }
            catch (Exception ex)
            {
                // Log exception here
                throw;
            }
        }

        public async Task<bool> DeleteTaxAsync(Guid id, CancellationToken cancellationToken)
        {
            try
            {
                var command = new DeleteTaxCommand { Id = id };
                var result = await _mediator.Send(command, cancellationToken);
                if (!result)
                {
                    throw new TaxNotFoundException("Tax not found for deletion.");
                }
                return result;
            }
            catch (TaxNotFoundException)
            {
                throw; // rethrow the custom exception
            }
            catch (Exception ex)
            {
                // Log exception here
                throw;
            }
        }
    }
}
