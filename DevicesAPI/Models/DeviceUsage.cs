using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevicesAPI.Models
{
    public class DeviceUsage
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public double UsageHours { get; set; }
        public Device Device { get; set; }

    }
}
