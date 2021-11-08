using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevicesAPI.Models
{
    public class Device
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? Temperature { get; set; }
        public Status DeviceStatus { get; set; }
        public DeviceType DeviceType { get; set; }
        public User User { get; set; }

        public List<DeviceUsage> DeviceUsages { get; set; }
    }
}
