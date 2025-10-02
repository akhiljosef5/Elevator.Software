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
        public bool IsMoving { get; set; }
    }
}
