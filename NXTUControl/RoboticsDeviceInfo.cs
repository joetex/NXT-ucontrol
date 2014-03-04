using System;
using System.Net.Sockets;
using System.Threading;
using System.IO.Ports;
using System.Text;
using System.Windows.Forms;
using System.Xml;

using InTheHand.Net.Sockets;
using InTheHand.Net.Bluetooth;
using InTheHand.Net;
using InTheHand.Net.Bluetooth.Widcomm;
using InTheHand.Net.Bluetooth.AttributeIds;

namespace RoboticsChallenge
{
    public class RoboticsDeviceInfo
    {
        public BluetoothDeviceInfo      Device { get; set; }

        public String                   DeviceName { get; set; }
        public BluetoothAddress         DeviceAddress { get; set; }

        public BluetoothClient          BTClient { get; set; }
        public BluetoothEndPoint        BTEndPoint { get; set; }
        public NetworkStream            BTStream { get; set; }

        public NXTProtocol              NXT { get; set; }
        public bool                     IsConnected { get; set; }
        public bool                     ActiveConnection { get; set; }
        public bool                     ShouldKeepAlive { get; set; }

        private object sync = new object();

        public delegate void ConnectedDelegate();
        public ConnectedDelegate connectedDelegate;

        public NXTInputPort currentPort = NXTInputPort.Port1;

        public RoboticsDeviceInfo(BluetoothDeviceInfo di)
        {
            this.Device = di;
            this.DeviceName = di.DeviceName;
            this.DeviceAddress = di.DeviceAddress;

            BTEndPoint = new BluetoothEndPoint(this.DeviceAddress, BluetoothService.SerialPort);

            connectedDelegate = this.Connected;
        }

        public void Connect()
        {
            Thread t1 = new Thread(ConnectThread);
            t1.Start();
        }
        public void ConnectThread()
        {
            lock (sync)
            {
                try
                {
                    if (BTClient == null)
                        BTClient = new BluetoothClient();

                    BTClient.Connect(BTEndPoint);
                    this.BTStream = BTClient.GetStream();

                    this.NXT = new NXTProtocol(this.BTStream, NXTStreamType.STREAM_SOCKET);

                    this.NXT.batteryLevelDelegate = BatteryLevel;
                    this.NXT.getVersionDelegate = Version;
                    this.NXT.lsReadDelegate = LSRead;
                    this.NXT.lsGetStatusDelegate = LSGetStatus;
                    this.NXT.keepAliveDelegate = KeepAlive;

                    this.IsConnected = true;
                    Program.form1.Invoke(connectedDelegate);
                }
                catch (Exception e)
                {
                    this.IsConnected = false;
                    this.Log("Failed to connect to " + this.DeviceName + ":");
                    this.Log("-- " + e.Message);
                }
            }
        }

        public bool Disconnect()
        {
            try
            {
                BTClient.Close();
                this.IsConnected = false;
                this.Log("Disconnected from " + this.DeviceName);
            }
            catch (Exception e)
            {
                this.IsConnected = false;
                this.Log("Error disconnecting from " + this.DeviceName + ":");
                this.Log("-- " + e.Message);
            }

            return this.IsConnected;
        }

        public void Connected()
        {
            if (this.IsConnected)
            {
                Log("Connected to " + this.DeviceName);
            }
        }
       
        

        public void OutputState(NXTOutputPort outputPort, sbyte powerSet, NXTOutputMode mode, NXTOutputRegulationMode regMode, sbyte turnRatio, NXTOutputRunState runState, ulong tachoLimit)
        {
            Log("--------- Output State ----------------");
            Log("Output Port\t= " + outputPort.ToString());
            Log("Power Set\t= " + powerSet.ToString());
            Log("Output Mode\t= " + mode.ToString());
            Log("Regulation Mode\t= " + regMode.ToString());
            Log("Turn State\t= " + turnRatio.ToString());
            Log("Run State\t= " + runState.ToString());
            Log("Tacho Limit\t= " + tachoLimit.ToString());
            Log("---------------------------------------");
        }
        public void InputState(NXTInputPort inputPort, bool isValid, bool isCalibrated, NXTSensorType sensorType, NXTSensorMode sensorMode, long rawValue, long normalizedValue, long scaleValue, long calibratedValue)
        {
            Log("--------- Input State ----------------");
            Log("Input Port\t= " + inputPort.ToString());
            Log("Is Valid\t= " + isValid.ToString());
            Log("Is Calibrated\t= " + isCalibrated.ToString());
            Log("Sensor Type\t= " + sensorType.ToString());
            Log("Sensor Mode\t= " + sensorMode.ToString());
            Log("Raw Value\t= " + rawValue.ToString());
            Log("Normalized Value\t= " + normalizedValue.ToString());
            Log("Scaled Value\t= " + scaleValue.ToString());
            Log("Calibrated Value\t= " + calibratedValue.ToString());
            Log("---------------------------------------");
        }
        public void BatteryLevel(double voltage)
        {
            Log("--------- Battery Level ---------------");
            Log("Voltage\t= " + voltage.ToString());
            Log("---------------------------------------");
        }
        public void KeepAlive(long sleepTime)
        {
            Log("--------- Keep Alive-------------------");
            Log("Sleep Time in Milliseconds\t= " + sleepTime.ToString());
            Log("---------------------------------------");
        }

        public void Version(String firmwareVersion, String protocolVersion)
        {
            Log("--------- Version Info-----------------");
            Log("Firmware\t= " + firmwareVersion);
            Log("Protocol\t= " + protocolVersion);
            Log("---------------------------------------");
        }


        public void Status(String commandName, String statusInfo)
        {
            Log("--------- Status Info-----------------");
            Log("Command\t= " + commandName);
            Log("Status\t= " + statusInfo);
            Log("---------------------------------------");
        }

        public void GetUltrasonicValue(NXTInputPort inputPort)
        {
            currentPort = inputPort;
            NXT.GetUltrasonicValue(inputPort, 0);
        }
        public void LSGetStatus(byte bytesRead)
        {
            //if (bytesRead == 0)
            //    NXT.GetUltrasonicValue(currentPort, 1);
            //else
            //    NXT.GetUltrasonicValue(currentPort, 2);

        }

        public void LSRead(byte[] data)
        {
            Log("--------- LS Read ---------------------");
            for(int a=0;a<data.Length;a++)
                if( data[a] != 0 )
                    Log("data["+a+"]\t= " + data[a]);
            Log("---------------------------------------");
        }
        

        public void Log(String msg)
        {
            Program.form1.Log(msg);
        }

    }
}
