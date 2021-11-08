using DevicesAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevicesAPI.ViewModels
{
    public class DeviceSummary
    {
        public int DeviceId { get; set; }
        public string DeviceName { get; set; }
        public string DeviceStatus { get; set; }

        public DeviceSummary() { }

        public DeviceSummary GetDeviceSummary(int deviceId, DeviceDbContext context)
        {
            return (DeviceSummary)context.Devices.Where(d => d.Id == deviceId)
                .Select(ds => new DeviceSummary
                {
                    DeviceId = ds.Id,
                    DeviceName = ds.Name,
                    DeviceStatus = ds.DeviceStatus.Name
                }) ;

           
        }

        public ICollection<DeviceSummary> GetUserDeviceSummaries(int userId, DeviceDbContext context)
        {
            return context.Devices.Where(d => d.User.Id == userId)
                .Select(ds => new DeviceSummary
                {
                    DeviceId = ds.Id,
                    DeviceName = ds.Name,
                    DeviceStatus = ds.DeviceStatus.Name
                }).ToList();
        }

        public ICollection<DeviceSummary> GetRelatedDeviceSummaries(int deviceId, DeviceDbContext context)
        {
            Device device = context.Devices.Where(d => d.Id == deviceId)
                .Include(u=> u.User)
                .FirstOrDefault();

            int userId = device.User.Id;

            return GetUserDeviceSummaries(userId, context);
        }

        public ICollection<DeviceSummary> GetSearchedDeviceSummaries(string searchTerm, DeviceDbContext context)
        {
            return context.Devices.Where(d => d.Name.Contains(searchTerm))
                .Select(ds => new DeviceSummary
                {
                    DeviceId = ds.Id,
                    DeviceName = ds.Name,
                    DeviceStatus = ds.DeviceStatus.Name
                }).ToList();
        }
    }
}
