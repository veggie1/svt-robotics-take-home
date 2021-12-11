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

        // GET: api/<RobotController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _robotService.GetRobot();
            return Ok(result);
        }

        // POST api/<RobotController>
        [HttpPost]
        public async Task<IActionResult> ClosestRobot([FromBody] RobotCoordinates robotCoordinates)
        {
            var closestRobot = await _robotService.GetClosestRobot(robotCoordinates);
            return Ok(closestRobot);
        }
    }
}
