using DevicesAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevicesAPI
{
    public class DeviceDbContext:DbContext
    {
        public DeviceDbContext(DbContextOptions<DeviceDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Device> Devices { get; set; }
        public DbSet<Status> Statuses { get; set; }
        public DbSet<DeviceUsage> DeviceUsages { get; set; }
        public DbSet<DeviceType> DeviceTypes { get; set; }



    }
}
