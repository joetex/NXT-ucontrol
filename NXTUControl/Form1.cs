using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Net;
using System.IO;
using System.Net.Sockets;
using System.Management;
using System.Collections;
using System.Runtime.InteropServices;


using InTheHand.Net.Sockets;
using InTheHand.Net.Bluetooth;
using InTheHand.Net;



namespace RoboticsChallenge
{
    
    
    public partial class Form1 : Form
    {

        public const int MAX_MESSAGE_SIZE = 128;


        public delegate void AddDevicesDelegate();
        public AddDevicesDelegate addDeviceDelegate;

        public delegate void UpdateDistanceDelegate(byte iPort, byte distance);
        public UpdateDistanceDelegate updateDistanceDelegate;

        public BluetoothClient btClient;
        public BluetoothListener btListener;
        public Guid ServiceName = new Guid("{ACEF1FC4-A4DF-4BEB-B0E7-F22732B296BE}");

        public ArrayList nxtDevices = new ArrayList();

        public String szIncomingMsg = "";
        public bool bListening = false;

        private object sync = new object();

        public String szCurrentCommand = "";


        public Motor[] runningMotors = new Motor[3];

        public Form1()
        {
            InitializeComponent();

            if (Variables.config == null)
            {
                Variables.config = new MotorConfig();
                Variables.config.readconfig("config.txt");
            }
            //System.Threading.Thread t1 = new System.Threading.Thread( receiveLoop );
           // t1.Start();
          
            //Create delegate to change Form inputs
            addDeviceDelegate = new AddDevicesDelegate(AddDevicesMethod);
        }

        /// <summary>
        /// Locates all Bluetooth Devices in range and grabs their COM port, and saves to list.
        /// </summary>
        public void FindDevices()
        {
            BluetoothDeviceInfo[] bdi;
            try
            {
                //Get a list of Discovered Devices
                btClient = new BluetoothClient();
                bdi = (BluetoothDeviceInfo[])btClient.DiscoverDevices();
            }
            catch (Exception e)
            {
                this.Invoke(addDeviceDelegate);
                return;
            }
            //Compare discovered Bluetooth Devices with COM ports, and create new RoboticsDeviceInfo
            foreach (BluetoothDeviceInfo di in bdi)
            {
                //Add device to nxtDevices list
                RoboticsDeviceInfo rdi = new RoboticsDeviceInfo(di);
                        
                lock (nxtDevices)
                {
                    bool bAdd = true;
                    foreach (RoboticsDeviceInfo nxtdi in nxtDevices)
                    {
                        if (nxtdi.DeviceName.Equals(rdi.DeviceName))
                        {
                            bAdd = false;
                            break;
                        }
                    }
                    if( bAdd )
                        nxtDevices.Add(rdi);
                }
            }

            //Update our ComboBox and the FindDevices button state
            this.Invoke(addDeviceDelegate);
        }

        /// <summary>
        /// Delegate to update form inputs after devices have been located.
        /// </summary>
        public void AddDevicesMethod()
        {
            lstDevices.Items.Clear();
            foreach (RoboticsDeviceInfo rdi in nxtDevices)
            {
                lstDevices.Items.Add(rdi);
            }
            lstDevices.DisplayMember = "DeviceName";

            btnFindDevices.Text = "Find Devices";
            btnFindDevices.Enabled = true;
             
        }


        public void ConnectToDevice()
        {
            try
            {
                btnConnect.Enabled = false;
                btnFindDevices.Enabled = false;
                lstDevices.Enabled = false;
                RoboticsDeviceInfo rdi = (RoboticsDeviceInfo)lstDevices.SelectedItem;
                rdi.Connect();
            }
            catch (Exception e)
            {
                btnConnect.Enabled = true;
                btnFindDevices.Enabled = true;
                lstDevices.Enabled = true;
            }
        }


        /// <summary>
        /// Begin finding all Bluetooth devices in range
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnFindDevices_Click(object sender, EventArgs e)
        {
            btnFindDevices.Text = "Finding...";
            btnFindDevices.Enabled = false;

            System.Threading.Thread t1 = new System.Threading.Thread(FindDevices);
            t1.Start();
        }



        /// <summary>
        /// Attempt to pair with Bluetooth device
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConnect_Click(object sender, EventArgs e)
        {
            //Pair with device
            //RoboticsDeviceInfo rdi = (RoboticsDeviceInfo)lstDevices.SelectedItem;
            //BluetoothDeviceInfo bdi = rdi.Device;
            //bool bPassed = BluetoothSecurity.PairRequest(bdi.DeviceAddress, "1234");
            //if (bPassed)
            //{
                ConnectToDevice();
            //}
        }


        private void btnBeep_Click(object sender, EventArgs e)
        {
            RoboticsDeviceInfo rdi = (RoboticsDeviceInfo)lstDevices.SelectedItem;
            try
            {
                rdi.NXT.PlayTone(400, 100, false);
            }
            catch (Exception ex)
            {
            }
        }

        private void btnBattery_Click(object sender, EventArgs e)
        {
            RoboticsDeviceInfo rdi = (RoboticsDeviceInfo)lstDevices.SelectedItem;
            try
            {
                rdi.NXT.GetBatteryLevel();
            }
            catch (Exception ex)
            {
            }
        }

        private void btnVersion_Click(object sender, EventArgs e)
        {
            RoboticsDeviceInfo rdi = (RoboticsDeviceInfo)lstDevices.SelectedItem;
            try
            {
                rdi.NXT.GetVersion();
            }
            catch (Exception ex)
            {
            }
        }

        public void Log(string msg)
        {
            rtxtLog.Text += msg + "\r\n";
            rtxtLog.Select(rtxtLog.Text.Length, 1);
            rtxtLog.ScrollToCaret();
        }

        private void btnDisconnect_Click(object sender, EventArgs e)
        {
            RoboticsDeviceInfo rdi = (RoboticsDeviceInfo)lstDevices.SelectedItem;
            rdi.Disconnect();

            lstDevices.Enabled = true;
            btnConnect.Enabled = true;
            btnFindDevices.Enabled = true;
        }

        private void btnDistance_Click(object sender, EventArgs e)
        {
            RoboticsDeviceInfo rdi = (RoboticsDeviceInfo)lstDevices.SelectedItem;
            try
            {
                rdi.NXT.SetInputMode(NXTInputPort.Port4, NXTSensorType.LOWSPEED_9V, NXTSensorMode.RAWMODE);
            }
            catch (Exception ex)
            {
            }

            timer1.Enabled = !timer1.Enabled;
        }


      
        private void btnUpdatePort1_Click(object sender, EventArgs e)
        {
            RoboticsDeviceInfo rdi = (RoboticsDeviceInfo)lstDevices.SelectedItem;
            rdi.GetUltrasonicValue(NXTInputPort.Port1);
        }

      

        [DllImport("user32.dll")]
        public static extern int GetKeyboardState(byte[] keystate);





        protected override bool ProcessKeyPreview(ref Message msg)//, Keys keyData)
        {

            RoboticsDeviceInfo rdi = (RoboticsDeviceInfo)lstDevices.SelectedItem;

            byte[] keys = new byte[255];
            GetKeyboardState(keys);

            bool passed = false;

            //Check double keys first
            foreach (Command cmd in Variables.config.commands)
            {
                if (cmd.keys1Count < 2)
                    continue;

                passed = true;
                foreach (int iKey in cmd.keys1)
                {
                    if ((keys[iKey] & 128) == 0)
                    {
                        passed = false;
                        break;
                    }
                }

                if (passed)
                {
                    int motorcnt = 0;
                    foreach (Motor mtr in cmd.motors)
                    {
                        if (mtr.power > 0)
                        {
                            runningMotors[motorcnt] = mtr;
                        }
                        else
                        {
                            runningMotors[motorcnt] = null;
                        }
                        motorcnt++;
                    }
                    szCurrentCommand = cmd.name;
                    break;
                }
            }

            //Check single keys 
            //if (!passed)
            {
                foreach (Command cmd in Variables.config.commands)
                {
                    if (cmd.keys1Count >= 2)
                        continue;

                    passed = true;
                    foreach (int iKey in cmd.keys1)
                    {
                        if ((keys[iKey] & 128) == 0)
                        {
                            passed = false;
                            break;
                        }
                    }

                    if (passed)
                    {
                        szCurrentCommand = cmd.name;
                        int motorcnt = 0;
                        foreach (Motor mtr in cmd.motors)
                        {
                            if (runningMotors[motorcnt] == null && mtr.power > 0)
                            {
                                runningMotors[motorcnt] = mtr;
                            }

                            motorcnt++;
                        }
                        break;
                    }
                }
            }


            /*
            int UP = keys[(int)Keys.Up];
            int LEFT = keys[(int)Keys.Left];
            int RIGHT = keys[(int)Keys.Right];
            int DOWN = keys[(int)Keys.Down];

            sbyte power = 100;
            sbyte turn = 100;
            ulong tacho = 200;
            //Port A- - - Positive= forward
            //Port B- - - Positive= Reverse
            //Port C- - - Positive= Forward
            //String cmdname = "";

            if ((UP & 128) > 0 && (LEFT & 128) > 0)
            {
                szCurrentCommand = "[UPLEFT]";
            }
            else if ((UP & 128) > 0 && (RIGHT & 128) > 0)
            {
                szCurrentCommand = "[UPRIGHT]";
            }
            else if ((DOWN & 128) > 0 && (LEFT & 128) > 0)
            {
                szCurrentCommand = "[DOWNLEFT]";
            }
            else if ((DOWN & 128) > 0 && (RIGHT & 128) > 0)
            {
                szCurrentCommand = "[DOWNRIGHT]";
            }
            else if ((UP & 128) > 0)
            {
                szCurrentCommand = "[UP]";
            }
            else if ((DOWN & 128) > 0)
            {
                szCurrentCommand = "[DOWN]";
            }
            else if ((LEFT & 128) > 0)
            {
                szCurrentCommand = "[LEFT]";
            }
            else if ((RIGHT & 128) > 0)
            {
                szCurrentCommand = "[RIGHT]";
            }
            else
             */
            if (!passed)
            {
                for (int i = 0; i < runningMotors.Length; i++)
                {
                    runningMotors[i] = null;
                }
                szCurrentCommand = "";
                RunMotors();
                //    timer1.Enabled = false;
            }

            //if ((UP & 128) > 0)
            //{

            this.rtxtLog.Focus();
            //this.rtxtLog.Text = "Message = " + msg.Msg + "\nUP = " + keys[(int)Keys.Up] + "\nDOWN = " + keys[(int)Keys.Down] + "\nLEFT = " + keys[(int)Keys.Left] + "\nRight = " + keys[(int)Keys.Right];
            //   return true;
            //   return false;
            //}

            if (szCurrentCommand.Length > 0)
            {
                //this.rtxtLog.Text = "Key = " + szCurrentCommand + "\n";

                timer1.Enabled = true;
                return false;
            }


            return base.ProcessKeyPreview(ref msg);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            RunMotors();
        }

        public void RunMotors()
        {
            RoboticsDeviceInfo rdi = (RoboticsDeviceInfo)lstDevices.SelectedItem;
            if (rdi == null || rdi.NXT == null)
                return;

            sbyte turn = 0;
            ulong tacho = 0;

            int motorcnt = 0;
            foreach (Motor mtr in runningMotors)
            {
                if (mtr == null || mtr.power == 0)
                {
                    rdi.NXT.SetOutputState((NXTOutputPort)motorcnt, 0, NXTOutputMode.NONE, NXTOutputRegulationMode.REGULATION_MODE_IDLE, 0, NXTOutputRunState.MOTOR_RUN_STATE_IDLE, tacho);
                }
                else
                {
                    rdi.NXT.SetOutputState(mtr.port, (sbyte)(mtr.power * mtr.direction), NXTOutputMode.MOTORON, NXTOutputRegulationMode.REGULATION_MODE_MOTOR_SPEED, turn, NXTOutputRunState.MOTOR_RUN_STATE_RUNNING, tacho);
                }
                motorcnt++;
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            System.Threading.Thread t = new System.Threading.Thread(new System.Threading.ThreadStart(ThreadProc));
            t.SetApartmentState(ApartmentState.STA);
            t.Start();
        }


        public static void ThreadProc()
        {
            Application.Run(new Form2());
        }

        



       
    }

}
