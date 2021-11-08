using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevicesAPI.ViewModels
{
    public class DeviceDetails
    {
        public int DeviceId { get; set; }
        public string DeviceName { get; set; }
        public int Temperature { get; set; }
        public string DeviceStatus { get; set; }
        public string DeviceType { get; set; }

        public ICollection<DeviceUsageView> DeviceUsageViews { get; set; }
        protected ICollection<DeviceSummary> RelatedDevices { get; set; }


        public DeviceDetails() { }

        public DeviceDetails GetDeviceDetails(int deviceId, DeviceDbContext context)
        {
            
            var deviceUsageViews = context.DeviceUsages.Where(du => du.Device.Id == deviceId)
                .OrderBy(du => du.Date)
                .Select(du => new DeviceUsageView
                {
                    UsageDate = du.Date,
                    UsageHours = du.UsageHours
                }).ToList();


            var relatedDevices = new DeviceSummary().GetRelatedDeviceSummaries(deviceId, context);

            return context.Devices.Where(d => d.Id == deviceId)
                .Select(d => new DeviceDetails
                {
                    DeviceId = d.Id,
                    DeviceName = d.Name,
                    Temperature = (int)d.Temperature,
                    DeviceStatus = d.DeviceStatus.Name,
                    DeviceType = d.DeviceType.Name,
                    RelatedDevices = relatedDevices,
                    DeviceUsageViews = deviceUsageViews

                }).FirstOrDefault();
        }
    }

    public class DeviceUsageView
    {
        public DateTime UsageDate { get; set; }
        public double UsageHours { get; set; }
    }
}
