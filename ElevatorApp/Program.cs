// See https://aka.ms/new-console-template for more information

using ElevatorApp;

Random rnd = new Random();

var elevator = new Elevator(1);

for(int i = 0;i < 2;i++) // simulate random elevator requests
{
    int originFloor = rnd.Next(1,Constants.TopFLoor + 1);
    int targetFloor;
    do
    {
        targetFloor = rnd.Next(1,Constants.TopFLoor + 1);
    } while(targetFloor == originFloor);

    string direction = targetFloor > originFloor? "Up" : "Down";

    // Log the request
    Console.WriteLine($"\n[LOG]:INFO {DateTime.UtcNow} {direction} request on floor {originFloor} received");

    // Move to origin
    if(elevator.CurrentFloor != originFloor)
    {
        elevator.Move(originFloor,direction);
    }
    else
    {
        Console.WriteLine($"[LOG]:INFO {DateTime.UtcNow} Car {elevator.Id} already on floor {originFloor}");
    }

    // Move to destination
    Console.WriteLine($"[LOG]:INFO {DateTime.UtcNow} Car {elevator.Id} moving to destination floor {targetFloor}");
    elevator.Move(targetFloor,direction);

    Console.WriteLine($"[LOG]:INFO {DateTime.UtcNow} Car {elevator.Id} at floor {elevator.CurrentFloor}, direction={elevator.Direction}");
}