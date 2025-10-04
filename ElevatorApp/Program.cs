// See https://aka.ms/new-console-template for more information

using ElevatorApp.Generator;

var requestGenerator = new ElevatorRequestGenerator(elevatorCount: 4);
requestGenerator.Start(requestCount: 3);