using ElevatorApp.Domain;

namespace ElevatorApp.Services
{
    /// <summary>
    /// Chose the closest elevator to the specified floor from a list of available elevators.
    /// Returns the chosen Elevator object.
    /// </summary>
    public class ElevatorService
    {
        public static Elevator PickClosestElevator(List<Elevator> elevators,int originFloor)
        {
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
