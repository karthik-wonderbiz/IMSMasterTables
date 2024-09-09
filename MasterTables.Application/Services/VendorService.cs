using MasterTables.Application.Interfaces;
using MasterTables.Domain.Entities;
using MasterTables.Domain.Interfaces;

namespace MasterTables.Application.Services
{
    public class VendorService : IVendorService
    {
        private readonly IVendorRepository _VendorRepository;

        public VendorService(IVendorRepository VendorRepository)
        {
            _VendorRepository = VendorRepository;
        }

        public async Task<IEnumerable<Vendor>> GetAllVendorsAsync()
        {
            return await _VendorRepository.GetAllVendorsAsync();
        }

        public async Task<Vendor> GetVendorByIdAsync(Guid id)
        {
            return await _VendorRepository.GetVendorByIdAsync(id);
        }

        public async Task<Vendor> CreateVendorAsync(Vendor Vendor)
        {
            Vendor.CreatedAt = DateTime.UtcNow;
            return await _VendorRepository.AddVendorAsync(Vendor);
        }

        public async Task<Vendor> UpdateVendorAsync(Vendor Vendor)
        {
            Vendor.UpdatedAt = DateTime.UtcNow;
            return await _VendorRepository.UpdateVendorAsync(Vendor);
        }

        public async Task DeleteVendorAsync(Guid id)
        {
            await _VendorRepository.DeleteVendorAsync(id);
        }
    }
}
