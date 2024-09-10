using MasterTables.Domain.Entities;
using MasterTables.Domain.Interfaces;
using MasterTables.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace MasterTables.Infrastructure.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly MasterTablesDbContext _context;

        public CustomerRepository(MasterTablesDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Customer>> GetAllCustomersAsync(CancellationToken cancellationToken = default)
        {
            return await _context.Customers.ToListAsync(cancellationToken);
        }

        public async Task<Customer> GetCustomerByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return await _context.Customers.FindAsync(new object[] { id }, cancellationToken);
        }

        public async Task AddCustomerAsync(Customer customer, CancellationToken cancellationToken = default)
        {
            await _context.Customers.AddAsync(customer, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task UpdateCustomerAsync(Customer customer, CancellationToken cancellationToken = default)
        {
            _context.Customers.Update(customer);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task DeleteCustomerAsync(Customer customer, CancellationToken cancellationToken = default)
        {
            _context.Customers.Remove(customer);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task<bool> CustomerExistsAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return await _context.Customers.AnyAsync(c => c.Id == id, cancellationToken);
        }
    }
}
