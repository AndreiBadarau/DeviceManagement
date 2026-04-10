using System.Collections.Generic;

namespace DeviceManagement.API.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Role { get; set; } = string.Empty;
        public string Location { get; set; } = string.Empty;

        // A user can have many devices assigned
        public ICollection<Device> AssignedDevices { get; set; } = new List<Device>();
    }
}