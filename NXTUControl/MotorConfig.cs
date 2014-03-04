using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace RoboticsChallenge
{
    public class MotorConfig
    {

        public ArrayList commands;
        public String filename;
        public int commandcount;
        public MotorConfig()
        {
            this.commandcount = 0;
            this.filename = "";
            commands = new ArrayList();// Command[8];
            //readconfig(filename);
        }


        public Command findcommand(String cmdname)
        {
            foreach (Command cmd in commands)
            {
                if (cmd.name.Equals(cmdname))
                    return cmd;

            }
            return null;
        }
        public void readconfig(String newFilename)
        {
            this.filename = newFilename;

            this.commands.Clear();

            int counter = 0;

            string line;
            Command cmd=null;

            // Read the file and display it line by line.
            System.IO.StreamReader file = new System.IO.StreamReader(this.filename);

            while ((line = file.ReadLine()) != null)
            {
                Console.WriteLine(line);
                counter++;
                if (line[0] == '[')
                {
                    cmd = new Command(line);

                    continue;
                }


                // Grabbing the port
                string[] words = line.Split(',');

                NXTOutputPort port = NXTOutputPort.PortA;
                int direction = Convert.ToInt16(words[1]);
                int power = Convert.ToInt16(words[2]);

                if (words[0].Equals("0"))
                {
                    port = NXTOutputPort.PortA;
                }
                else if (words[0].Equals("1"))
                {
                    port = NXTOutputPort.PortB;
                }
                else if (words[0].Equals("2"))
                {
                    port = NXTOutputPort.PortC;
                }

                cmd.motors[(int)port].port = port;
                cmd.motors[(int)port].direction = direction;
                cmd.motors[(int)port].power = power;

                //After last motor add command to list
                if (port == NXTOutputPort.PortC)
                {
                    addcommand(cmd);
                }
            }


            file.Close();

            // Suspend the screen.
            Console.ReadLine();
        }
        public void addcommand(Command cmd)
        {
            
            commands.Add(cmd); 
        
        }
        public void saveconfig(String newFilename)
        {
            this.filename = newFilename;

            // create a writer and open the file
            TextWriter tw = new StreamWriter(this.filename);
            
            foreach (Command cmd in commands)
            {
                if (cmd == null)
                    continue;

                tw.WriteLine(cmd.name);

                //Add the Key Bindings
                String line = "";
                //for (int i = 0; i < cmd.keys1.Length; i++)
                //{
                //    if (cmd.keys1[i] != null)
                //    {
               //         line = Enum.GetName(typeof(Keys),cmd.keys1[i]) + " ";
               //     }
               // }

                //Remove trailing space
                //line = line.Substring(0, line.Length - 2);

                //tw.WriteLine(line);

                line = "";

                //Add each motors configuration
                foreach (Motor motor in cmd.motors)
                {
                    if (motor == null)
                        continue;
                    
                    line = (byte)motor.port + "," + motor.direction.ToString() + "," + motor.power.ToString();
                    tw.WriteLine(line);
                }

            }
          
           

            // close the stream
            tw.Close();
        
        }
    }
}
