using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RoboticsChallenge
{
    public class Motor
    {
        public NXTOutputPort port;
        public int direction;
        public int power;
        public Motor(NXTOutputPort port, int direction, int power)
        {
            this.port = port; 
            this.direction = direction;
            this.power = power; 
        }
    }
}
