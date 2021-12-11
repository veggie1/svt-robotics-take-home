using RestSharp;
using RestSharp.Authenticators;
using RobotEngine.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotEngine
{
    public class RobotService
    {
        public async Task<ClosestRobotResult> GetBestRobot(LoadCoordinates loadCoordinates)
        {
            var robots = await GetRobots();
            var robot1 = robots.First();

            var bestRobot = new CompareRobotResult()
            {
                Robot = robot1,
                Distance = await GetDistanceFromRobotToTarget(loadCoordinates, robot1)
            };

            foreach(Robot robot in robots)
            {
                bestRobot = await CompareRobots(loadCoordinates, robot, bestRobot.Robot);
            }

            var result = new ClosestRobotResult()
            {
                BatteryLevel = bestRobot.Robot.BatteryLevel,
                DistanceToGoal = bestRobot.Distance,
                RobotId = bestRobot.Robot.RobotId
            };

            return result;
        }

        private async Task<CompareRobotResult> CompareRobots(LoadCoordinates loadCoordinates, Robot a, Robot b)
        {
            var aIsWinner = false;

            var aDistance = await GetDistanceFromRobotToTarget(loadCoordinates, a);
            var bDistance = await GetDistanceFromRobotToTarget(loadCoordinates, b);

            if(Math.Abs(aDistance) < 10 && Math.Abs(bDistance) < 10)
            {
                aIsWinner = a.BatteryLevel > b.BatteryLevel;
            }
            else
            {
                aIsWinner = aDistance < bDistance;
            }

            if (aIsWinner)
            {
                return new CompareRobotResult()
                {
                    Robot = a,
                    Distance = aDistance
                };
            }
            else
            {
                return new CompareRobotResult()
                {
                    Robot = b,
                    Distance = bDistance
                };
            }
        }

        private async Task<IEnumerable<Robot>> GetRobots()
        {
            var client = new RestClient("https://60c8ed887dafc90017ffbd56.mockapi.io");
            var request = new RestRequest("robots");
            var robots = await client.GetAsync<IEnumerable<Robot>>(request);

            return robots;
        }

        private async Task<double> GetDistanceFromRobotToTarget(LoadCoordinates loadCoordinates, Robot robot)
        {
            var x2 = Math.Pow(loadCoordinates.x + robot.x, 2);
            var y2 = Math.Pow(loadCoordinates.y + robot.y, 2);

            var distance = Math.Sqrt(x2 + y2);

            return distance;
        }
    }
}
