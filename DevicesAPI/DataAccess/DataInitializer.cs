using DevicesAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevicesAPI.DataAccess
{
    public class DataInitializer
    {
        public static void Initialize(DeviceDbContext context)
        {
            context.Database.EnsureCreated();

            if (context.Users.Any())
            {
                //We've already seeded data, let's bail.
                return;
            }

            DeviceType[] deviceTypes = new DeviceType[]
                {
                    new DeviceType{Name = "IPhone", Icon="images/icons/iphone.jpeg" },
                    new DeviceType{Name = "Android Phone", Icon="images/icons/android_phone.jpeg"  },
                    new DeviceType{Name = "Laptop", Icon="images/icons/laptop.jpeg" },
                };

            context.DeviceTypes.AddRange(deviceTypes);

            context.SaveChanges();

            Status[] statuses = new Status[]
            {
                new Status{ Name = "Available"},
                new Status{Name = "Offline"}
            };

            context.AddRange(statuses);

            context.SaveChanges();

            User[] users = new User[]{
                new User{ Username = "User1", Password = "testpass123"},
                new User{ Username = "User2", Password = "testpass123"},
                new User{ Username = "User3", Password = "testpass123"}
            };

            context.Users.AddRange(users);

            context.SaveChanges();

            Device[] devices = new Device[]
                {
                    new Device{Name="User1_Laptop", DeviceType = deviceTypes.Where(t=> t.Name == "Laptop").First(),
                        DeviceStatus = statuses.Where(s => s.Name == "Available").First(), User = users.Where(u=>u.Username == "User1").First(),
                        Temperature = -6},
                    new Device{Name="User1_IPhone", DeviceType = deviceTypes.Where(t=> t.Name == "IPhone").First(),
                        DeviceStatus = statuses.Where(s => s.Name == "Offline").First(), User = users.Where(u=>u.Username == "User1").First(),
                        Temperature = -6},
                    new Device{Name="User2_Android", DeviceType = deviceTypes.Where(t=> t.Name == "Android Phone").First(),
                        DeviceStatus = statuses.Where(s => s.Name == "Available").First(), User = users.Where(u=>u.Username == "User2").First(),
                        Temperature = 10},
                    new Device{Name="User2_Laptop", DeviceType = deviceTypes.Where(t=> t.Name == "Laptop").First(),
                        DeviceStatus = statuses.Where(s => s.Name == "Available").First(), User = users.Where(u=>u.Username == "User2").First(),
                        Temperature = 10},
                    new Device{Name="User3_Laptop", DeviceType = deviceTypes.Where(t=> t.Name == "Laptop").First(),
                        DeviceStatus = statuses.Where(s => s.Name == "Available").First(), User = users.Where(u=>u.Username == "User3").First(),
                        Temperature = 15},

                };

            context.Devices.AddRange(devices);
                
            context.SaveChanges();

            //Seeding some device usage stats

            List<DeviceUsage> deviceUsages = new List<DeviceUsage>();

            Random rng = new Random();

            foreach(Device d in devices)
            {
                for( int i = 0; i < 7; i++)
                {
                    deviceUsages.Add(new DeviceUsage
                    {
                        Device = d, Date = DateTime.Today.AddDays(-i), UsageHours = rng.Next(3, 12)
                    });
                }
            }

            context.DeviceUsages.AddRange(deviceUsages);

            context.SaveChanges();

        }
    }
}
