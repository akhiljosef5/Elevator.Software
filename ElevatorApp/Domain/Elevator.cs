using ElevatorApp.Constants;

namespace ElevatorApp.Domain
{
    public class Elevator
    {
        public int Id { get; }
        public int CurrentFloor { get; set; }
        //count of directions, means how many "Up" nd "Down" commands received
        public Direction LiftDirection { get; set; } = Direction.Idle;
        Random random = new Random();
        public Elevator(int id)
        {
            Id = id;
            CurrentFloor = random.Next(1,ElevatorConstants.TopFLoor+1);
        }

        public void Move(int targetFloor, string direction)
        {
            Console.WriteLine($"[LOG]:INFO {DateTime.UtcNow} Car {Id} on floor {CurrentFloor}");

            while(CurrentFloor != targetFloor)
            {
                if(CurrentFloor < targetFloor)
                {
                    LiftDirection = Direction.Up;
                    CurrentFloor++;
                }
                else
                {
                    LiftDirection = Direction.Down;
                    CurrentFloor--;
                }

                Console.WriteLine($"[LOG]:INFO {DateTime.UtcNow} Car {Id} moving {LiftDirection} from {CurrentFloor} floor");
            }

            LiftDirection = Direction.Idle;
        }

        public override string ToString()
        {
            return $"Car {Id} at floor {CurrentFloor}, direction= {LiftDirection}";
        }

    }
}
