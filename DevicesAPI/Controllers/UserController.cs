using DevicesAPI.Models;
using DevicesAPI.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DevicesAPI.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UserController : ControllerBase
    {
        DeviceDbContext _deviceContext;
        
        public UserController(DeviceDbContext context)
        {
            _deviceContext = context;
        }

        // GET api/users/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            User user = _deviceContext.Users.Where(u => u.Id == id)
                .FirstOrDefault();
            
            if (user == null)
            {
                return NotFound("User with suppplied id not found");
            }

            UserView userView = new UserView
            {
                Username = user.Username,
                UserDevices = new DeviceSummary().GetUserDeviceSummaries(user.Id, _deviceContext)
            };

            return Ok(userView);
            
        }

        // POST api/users
        [HttpPost]
        public IActionResult Post([FromBody] User userToCreate) 
        { 
            if(_deviceContext.Users.Any(u => u.Username == userToCreate.Username))
            {
                return BadRequest("Username already exists, please choose another one");
            }

            _deviceContext.Users.Add(userToCreate);

            _deviceContext.SaveChanges();

            return new ObjectResult(userToCreate) { StatusCode = StatusCodes.Status201Created };
        }


   
    }
}
