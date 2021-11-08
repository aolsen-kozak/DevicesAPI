using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevicesAPI.Models
{
    public class DeviceType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        
        //This will hold the filename of each icon corresponding to the device type
        public string Icon { get; set; }
    }
}
