using ElevatorApp.Domain;
using ElevatorApp.Services;
using Xunit;

namespace ElevatorApp.Tests.Services
{
    public class ElevatorServiceTests
    {
        [Fact]
        public void PickClosestElevator_ShouldReturnClosestElevator()
        {
            // Arrange
            var elevators = new List<Elevator>
            {
                new Elevator(1) { CurrentFloor = 1 },
                new Elevator(2) { CurrentFloor = 5 },
                new Elevator(3) { CurrentFloor = 9 }
            };

            int originFloor = 6;

            // Act
            var chosenElevator = ElevatorService.PickClosestElevator(elevators,originFloor);

            // Assert
            Assert.Equal(2,chosenElevator.Id); // Elevator 2 is closest to floor 6
        }

        [Fact]
        public void PickClosestElevator_ShouldReturnLowestId_WhenSameDistance()
        {
            // Arrange
            var elevators = new List<Elevator>
            {
                new Elevator(1) { CurrentFloor = 4 },
                new Elevator(2) { CurrentFloor = 8 }
            };

            int originFloor = 6; // both are distance 2 away

            // Act
            var chosenElevator = ElevatorService.PickClosestElevator(elevators,originFloor);

            // Assert
            Assert.Equal(1,chosenElevator.Id); // Tie → Elevator with lower Id
        }
    }
}
