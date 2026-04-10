using DeviceManagement.API.Data;
using DeviceManagement.API.Models;
using DeviceManagement.API.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections;
using System.Diagnostics.Eventing.Reader;
using System.Threading.Tasks;

namespace DeviceManagement.API.Repositories
{
    public class DeviceRepository : IDeviceRepository
    {
        private readonly AppDbContext _context;

        public DeviceRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Device>> GetAllAsync()
        {
            return await _context.Devices
                .Include(d => d.AssignedUser)
                .ToListAsync();
        }

        public async Task<Device?> GetByIdAsync(int id)
        {
            return await _context.Devices
                .Include(d => d.AssignedUser)
                .FirstOrDefaultAsync(d => d.Id == id);
        }

        public async Task<Device> CreateAsync(Device device)
        {
            _context.Devices.Add(device);
            await _context.SaveChangesAsync();
            return device;
        }

        public async Task<Device?> UpdateAsync(int id, Device updated)
        {
            var device = await _context.Devices.FindAsync(id);
            if (device == null) return null;

            device.Name = updated.Name;
            device.Manufacturer = updated.Manufacturer;
            device.Type = updated.Type;
            device.OperatingSystem = updated.OperatingSystem;
            device.OsVersion = updated.OsVersion;
            device.Processor = updated.Processor;
            device.RamAmount = updated.RamAmount;
            device.Description = updated.Description;
            device.AssignedUserId = updated.AssignedUserId;

            await _context.SaveChangesAsync();
            return device;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var device = await _context.Devices.FindAsync(id);
            if (device == null) return false;

            _context.Devices.Remove(device);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}