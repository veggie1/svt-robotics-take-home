using Microsoft.AspNetCore.Mvc;
using RobotEngine;
using RobotEngine.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SVTRoboticsTakeHome.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RobotsController : ControllerBase
    {
        private readonly RobotService _robotService;
        public RobotsController(RobotService robotService)
        {
            _robotService = robotService;
        }

        // POST api/<RobotController>
        [HttpPost]
        public async Task<IActionResult> ClosestRobot([FromBody] LoadCoordinates loadCoordinates)
        {
            var closestRobot = await _robotService.GetBestRobot(loadCoordinates);
            return Ok(closestRobot);
        }
    }
}
