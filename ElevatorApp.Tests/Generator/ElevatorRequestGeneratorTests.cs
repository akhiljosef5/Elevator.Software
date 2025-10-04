using ElevatorApp.Domain;
using ElevatorApp.Generator;
using Xunit;

namespace ElevatorApp.Tests.Generator
{
    public class ElevatorRequestGeneratorTests
    {
        [Fact]
        public void Constructor_ShouldInitializeElevators()
        {
            // Act
            var generator = new ElevatorRequestGenerator(elevatorCount: 4);

            // Use reflection or internal access to check elevators exist
            var elevatorsField = typeof(ElevatorRequestGenerator)
                .GetField("_elevators",System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);

            var elevators = elevatorsField.GetValue(generator) as List<Elevator>;

            // Assert
            Assert.NotNull(elevators);
            Assert.Equal(4,elevators.Count);
        }

        [Fact]
        public void Start_ShouldRunWithoutExceptions()
        {
            // Arrange
            var generator = new ElevatorRequestGenerator(elevatorCount: 2);

            // Act & Assert
            var ex = Record.Exception(() => generator.Start(requestCount: 2));
            Assert.Null(ex); // no crash during random request handling
        }
    }
}
