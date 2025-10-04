using ElevatorApp.Constants;
using ElevatorApp.Domain;
using ElevatorApp.Services;

namespace ElevatorApp.Generator
{
    public class ElevatorRequestGenerator
    {
        private readonly List<Elevator> _elevators;
        private readonly Random _random;

        public ElevatorRequestGenerator(int elevatorCount = 4)
        {
            _random = new Random();
            _elevators = Enumerable.Range(1,elevatorCount)
                                   .Select(id => new Elevator(id))
                                   .ToList();
        }

        public void Start(int requestCount = 3)
        {
            Console.WriteLine("--------Elevators positions-------");
            foreach(var elevator in _elevators)
                Console.WriteLine(elevator);

            for(int i = 0;i < requestCount;i++)
            {
                RunRandomRequest();
            }
        }

        private void RunRandomRequest()
        {
            int originFloor = _random.Next(1,ElevatorConstants.TopFLoor + 1);
            int targetFloor;

            do
            {
                targetFloor = _random.Next(1,ElevatorConstants.TopFLoor + 1);
            } while(targetFloor == originFloor);

            string direction = targetFloor > originFloor ? "Up" : "Down";

            // Log the request
            Console.WriteLine($"\n[LOG]:INFO {DateTime.UtcNow} {direction} request on floor {originFloor} received");

            // Choose elevator
            Elevator chosenElevator = ElevatorService.PickClosestElevator(_elevators,originFloor);

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
                $"at floor {chosenElevator.CurrentFloor}, direction={chosenElevator.LiftDirection}");
        }
    }
}
