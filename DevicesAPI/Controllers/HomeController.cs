using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevicesAPI.Controllers
{
    [ApiController]
    [Route("home")]
    public class HomeController : Controller
    {
        [HttpGet]
        public string Get()
        {
            return "API Program is up.  Fire away, Postman!";
        }
    }
}
