# SVT Robotics Take Home


## Running and Testing locally

#### Manual Testing
1. Open the solution (SVTRoboticsTakeHome.sln) in Visual Studio 2019
2. Start debugging by clicking on the green arrow near the top
3. The API will start running on http://localhost:32196
4. Using Postman or a similar tool, send a POST request to http://localhost:32196/api/robots using the desired Payload.
Example Payload:

```json
{
  "loadId": 231,
  "x": 5,
  "y": 3
}
```
5. The API will return the robotId, distance to the goal, and the battery level of the robot.
Example result:
```json
{
  "robotId": 4,
  "distanceToGoal": 12.206555615733702,
  "batteryLevel": 37
}
```

#### Unit Tests
*Coming Soon*

## Future Improvements

* Add Unit Tests to various methods, namely, for comparing robots and finding the distances
* Optimize comparision function by sorting the robot list
* Use Visual Studio refactoring to create an Interface for the RobotService and then use that for Dependency Injection
* Add OpenAPI defintions using Swagger
* Use AppSettings.json files for setting the API url (this would allow for different URLs for local development and production deployment)
* Add System Check endpoints to make sure the app is running