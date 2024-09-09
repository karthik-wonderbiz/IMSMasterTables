using MasterTables.Domain.Entities;
using MasterTables.Domain.Interfaces;
using MasterTables.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace MasterTables.Infrastructure.Repositories
{
    public class VendorRepository : IVendorRepository
    {
        private readonly MasterTablesDbContext _context;

        public VendorRepository(MasterTablesDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Vendor>> GetAllVendorsAsync()
        {
            return await _context.Vendors.ToListAsync();
        }

        public async Task<Vendor> GetVendorByIdAsync(Guid id)
        {
            return await _context.Vendors.FindAsync(id);
        }

        public async Task<Vendor> AddVendorAsync(Vendor Vendor)
        {
            _context.Vendors.Add(Vendor);
            await _context.SaveChangesAsync();
            return Vendor;
        }

        public async Task<Vendor> UpdateVendorAsync(Vendor Vendor)
        {
            _context.Vendors.Update(Vendor);
            await _context.SaveChangesAsync();
            return Vendor;
        }

        public async Task DeleteVendorAsync(Guid id)
        {
            var Vendor = await _context.Vendors.FindAsync(id);
            if (Vendor != null)
            {
                _context.Vendors.Remove(Vendor);
                await _context.SaveChangesAsync();
            }
        }
    }
}
