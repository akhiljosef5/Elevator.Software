
namespace ElevatorApp
{
    public class Elevator
    {
        public int Id { get; }
        public int CurrentFloor { get; set; }
        //count of directions, means how many "Up" nd "Down" commands received
        public string Direction { get; set; } = Constants.Idle;
        Random random = new Random();
        public Elevator(int id)
        {
            Id = id;
            CurrentFloor = random.Next(1,Constants.TopFLoor+1);
        }

        public void Move(int targetFloor, string direction)
        {
            Console.WriteLine($"[LOG]:INFO {DateTime.UtcNow} Car {this.Id} on floor {this.CurrentFloor}");

            while(CurrentFloor != targetFloor)
            {
                if(CurrentFloor < targetFloor)
                {
                    Direction = "Up";
                    CurrentFloor++;
                }
                else
                {
                    Direction = "Down";
                    CurrentFloor--;
                }

                Console.WriteLine($"[LOG]:INFO {DateTime.UtcNow} Car {Id} moving {Direction} from {CurrentFloor} floor");
            }

            Direction = "Idle";
        }

        public override string ToString()
        {
            return $"Car {Id} at floor {CurrentFloor}, direction= {Direction}";
        }

    }
}
