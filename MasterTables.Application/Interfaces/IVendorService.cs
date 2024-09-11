using MasterTables.Domain.Entities;


namespace MasterTables.Application.Interfaces
{
    public interface IVendorService
    {
        Task<IEnumerable<Vendor>> GetAllVendorsAsync();
        Task<Vendor> GetVendorByIdAsync(Guid id);
        Task<Vendor> CreateVendorAsync(Vendor Vendor);
        Task<Vendor> UpdateVendorAsync(Vendor Vendor);
        Task DeleteVendorAsync(Guid id);
    }
}
