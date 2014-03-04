using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace RoboticsChallenge
{
    public class Command
    {
        public String name;
        public Motor[] motors;
        public int motorcount;
        public int[] keys1;
        public int keys1Count = 0;

        public Command(String name) {
            
            this.name = name;
            motors = new Motor[3];

            //Remove opening/closing brackets
            String line = name.Substring(1, name.Length - 2);

            //Split out each key bind for this command
            string[] keybinds = line.Split(' ');
            keys1 = new int[keybinds.Length];
            for (int i = 0; i < keybinds.Length; i++)
            {
                this.keys1[this.keys1Count++] = (int)Enum.Parse(typeof(Keys), keybinds[i]);
            }

            this.motorcount = 3;
            for (int i = 0; i <= (int)NXTOutputPort.PortC; i++)
            {
                motors[i] = new Motor((NXTOutputPort)i, 1, 100);
            }
        }

        public string ShortName
        {
            get
            {
                return this.name;
            }
        }

   
    }
}
