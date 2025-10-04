using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevatorApp
{
    public class ElevatorService
    {
        public static Elevator PickClosestElevator(List<Elevator> elevators, int originFloor) {
            /*order the elevators by the distance from the target floor, and if
            two elevators are at same distance then choose the one with lower Id*/
            var closestElevator = elevators
                .OrderBy(e => Math.Abs(e.CurrentFloor - originFloor))
                .ThenBy(e => e.Id)
                .First();
            return closestElevator;
        }
    }
}
