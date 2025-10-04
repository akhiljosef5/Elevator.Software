// See https://aka.ms/new-console-template for more information

using ElevatorApp;

Random random = new Random();

//create 4 elevators with Id
var elevators = new List<Elevator>
{
    new Elevator(1),
    new Elevator(2),
    new Elevator(3),
    new Elevator(4)
};

Console.WriteLine("--------Elevators positions-------");
foreach (var elevator in elevators)
{
    Console.WriteLine(elevator);
}

for(int i = 0;i < 2;i++) // simulate random elevator requests
{
    int originFloor = random.Next(1,Constants.TopFLoor + 1);
    int targetFloor;
    do
    {
        targetFloor = random.Next(1,Constants.TopFLoor + 1);
    }    while(targetFloor == originFloor);

    string direction = targetFloor > originFloor? "Up" : "Down";

    // Log the request
    Console.WriteLine($"\n[LOG]:INFO {DateTime.UtcNow} {direction} request on floor {originFloor} received");

    //choose elevator that is closest
    Elevator chosenElevator = ElevatorService.PickClosestElevator(elevators, originFloor);
    // Move to origin
    if(chosenElevator.CurrentFloor != originFloor)
    {
        chosenElevator.Move(originFloor,direction);
    }
    else
    {
        Console.WriteLine($"[LOG]:INFO {DateTime.UtcNow} Car {chosenElevator.Id} already on floor {originFloor}");
    }

    // Move to destination
    Console.WriteLine($"[LOG]:INFO {DateTime.UtcNow} Car {chosenElevator.Id} moving to destination floor {targetFloor}");
    chosenElevator.Move(targetFloor,direction);

    Console.WriteLine($"[LOG]:INFO {DateTime.UtcNow} Car {chosenElevator.Id} " +
        $"at floor {chosenElevator.CurrentFloor}, direction={chosenElevator.Direction}");
}