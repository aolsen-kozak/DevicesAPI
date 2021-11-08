using DevicesAPI.Models;
using DevicesAPI.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevicesAPI.Controllers
{
    [Route("api/devices")]
    [ApiController]
    public class DeviceController : Controller
    {

        DeviceDbContext _dbContext;


        public DeviceController(DeviceDbContext context)
        {
            _dbContext = context;
        }


        // GET: api/devices/5
        [HttpGet("{id}")]
        public ActionResult Details(int id)
        {

            return Ok(new DeviceDetails().GetDeviceDetails(id, _dbContext));
        }

        // GET: devices/search/Device1
        [HttpGet("search/{deviceName}")]
        public ActionResult Details(string deviceName)
        {
            return Ok(new DeviceSummary().GetSearchedDeviceSummaries(deviceName, _dbContext));
        }

        // POST: api/devices/
        [HttpPost]
        public ActionResult Create([FromBody] DeviceDetails deviceToCreate)
        {

            Device device = new Device
            {
                Name = deviceToCreate.DeviceName,
                DeviceStatus = _dbContext.Statuses.Where(s => s.Name == deviceToCreate.DeviceStatus).First(),
                DeviceType = _dbContext.DeviceTypes.Where(dt => dt.Name == deviceToCreate.DeviceType).First(),
                Temperature = deviceToCreate.Temperature,

            };

            _dbContext.Devices.Add(device);

            _dbContext.SaveChanges();

            deviceToCreate.DeviceId = device.Id;

            return new ObjectResult(deviceToCreate) { StatusCode = StatusCodes.Status201Created };
        }


        // PUT: api/devices/edit/5
        [HttpPut("edit/{id}")]
        public ActionResult Edit([FromBody] DeviceDetails deviceToEdit)
        {
            Device device = _dbContext.Devices.Where(d => d.Id == deviceToEdit.DeviceId).FirstOrDefault();

            if (device == null)
            {
                return BadRequest("Device with supplied id does not exist, please check id and try again");
            }

            device.Name = deviceToEdit.DeviceName;
            device.Temperature = deviceToEdit.Temperature;
            device.DeviceStatus = _dbContext.Statuses.Where(s => s.Name == deviceToEdit.DeviceStatus).First();
            device.DeviceType = _dbContext.DeviceTypes.Where(dt => dt.Name == deviceToEdit.DeviceType).First();

            _dbContext.SaveChanges();

            return Ok("Device was updated successfully");
        }



        // DELETE: api/devices/delete/5
        [HttpDelete("delete/{id}")]
        public ActionResult Delete(int id)
        {
            Device device = _dbContext.Devices.Where(d => d.Id == id).FirstOrDefault();

            if (device == null)
            {
                return BadRequest("Device with supplied id does not exist, please check id and try again");
            }

            _dbContext.Devices.Remove(device);

            _dbContext.SaveChanges();

            return Ok("Device was removed successfully");
        }


    }
}
