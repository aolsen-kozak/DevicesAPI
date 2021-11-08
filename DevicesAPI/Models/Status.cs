using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevicesAPI.Models
{
    public class Status
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Device> Devices { get; set; }
    }
}
