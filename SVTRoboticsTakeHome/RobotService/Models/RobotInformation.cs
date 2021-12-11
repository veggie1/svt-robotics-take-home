using System;
using System.Collections.Generic;
using System.Text;

namespace RobotEngine.Models
{
    public class RobotInformation
    {
        public int RobotId { get; set; }
        public double DistanceToGoal { get; set; }
        public int BatteryLevel { get; set; }
    }
}
