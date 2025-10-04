using ElevatorApp.Constants;

namespace ElevatorApp.Domain
{
    /// <summary>
    /// Elevator class representing an individual elevator in the system.
    /// </summary>
    public class Elevator
    {
        public int Id { get; }
        public int CurrentFloor { get; set; }
        public Direction LiftDirection { get; set; } = Direction.Idle;
        Random random = new Random();
        public Elevator(int id)
        {
            Id = id;
            CurrentFloor = random.Next(1,ElevatorConstants.TopFLoor + 1);
        }

        /// <summary>
        /// Move the elevator to the target floor by specifying the direction based on the target floor.
        /// </summary>
        /// <param name="targetFloor"></param>
        /// <param name="direction"></param>
        public void Move(int targetFloor,string direction)
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

        /// <summary>
        /// Override ToString method to print elevator details.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"Car {Id} at floor {CurrentFloor}, direction= {LiftDirection}";
        }

    }
}
