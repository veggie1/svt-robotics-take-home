using RobotEngine.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RobotEngine
{
    public class RobotService
    {
        public async Task<string> GetRobot()
        {
            return "Success";
        }

        public async Task<RobotInformation> GetClosestRobot(RobotCoordinates robotCoordinates)
        {
            return new RobotInformation();
        }
    }
}
