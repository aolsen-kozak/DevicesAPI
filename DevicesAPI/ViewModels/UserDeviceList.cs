using DevicesAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevicesAPI.ViewModels
{
    public class UserDeviceList
    {
        public int UserId { get; set; }
        public ICollection<Device> UserDevices { get; set; }
    }
}
