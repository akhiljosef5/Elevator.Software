using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevatorApp
{
    public class Elevator
    {
        public int ElevatorId { get; set; }
        public int CurrentFloor { get; set; }
        public bool IsMoving { get; set; } = false;
        public string Direction { get; set; } = "idle"; // "Up", "Down", or "Idle"

        public static void MoveElevator(List<Elevator> elevators, int targetFloor)
        {
            foreach (Elevator e in elevators)
            {
                if(e.IsMoving)
                {
                    Console.WriteLine($"LOG INFO: elevator {e.ElevatorId} is busy");
                }
                else
                {
                    if(targetFloor == e.CurrentFloor)
                    {
                        e.IsMoving = false;
                        e.Direction = "Idle";
                        return;
                    }
                    e.IsMoving = true;
                    if(targetFloor > e.CurrentFloor)
                    {
                        e.Direction = "Up";
                        while(e.CurrentFloor < targetFloor)
                        {
                            e.CurrentFloor++;
                        }
                        return;
                    }
                    else
                    {
                        e.Direction = "Down";
                        while(e.CurrentFloor > targetFloor)
                        {
                            e.CurrentFloor--;
                        }
                    }
                }
            }
        }
    }
}
