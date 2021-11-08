using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevicesAPI.ViewModels
{
    public class UserView
    {
        public string Username { get; set; }

        public ICollection<DeviceSummary> UserDevices { get; set; }
    }
}
