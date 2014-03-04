using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

using System.Threading;
using System.Net.Sockets;
using System.IO.Ports;

namespace RoboticsChallenge
{
    public enum NXTCommandType : byte
    {
        DIRECT_RESPONSE = 0,    //0x00
        SYSTEM_RESPONSE = 1,    //0x01
        REPLY = 2,    //0x02
        DIRECT_NORESPONSE = 128,  //0x80
        SYSTEM_NORESPONSE = 129   //0x81
    }
    public enum NXTCommandCode : byte
    {
        STARTPROGRAM = 0,    //0x00
        STOPPROGRAM = 1,    //0x01
        PLAYSOUNDFILE = 2,    //0x02
        PLAYTONE = 3,    //0x03
        SETOUTPUTSTATE = 4,    //0x04
        SETINPUTMODE = 5,    //0x05
        GETOUTPUTSTATE = 6,    //0x06
        GETINPUTVALUES = 7,    //0x07 
        RESETINPUTSCALEDVALUE = 8,    //0x08
        MESSAGEWRITE = 9,    //0x09
        RESETMOTORPOSITION = 10,   //0x0A
        GETBATTERYLEVEL = 11,   //0x0B
        STOPSOUNDPLAYBACK = 12,   //0x0C
        KEEPALIVE = 13,   //0x0D
        LSGETSTATUS = 14,   //0x0E
        LSWRITE = 15,   //0x0F
        LSREAD = 16,   //0x10
        GETCURRENTPROGRAMNAME = 17,   //0x11
        MESSAGEREAD = 19,   //0x13
        VERSION = 136   //0x88
    }
    public enum NXTOutputPort : byte
    {
        PortA = 0, PortB = 1, PortC = 2
    }
    public enum NXTOutputMode : byte
    {
        NONE                = 0,    //0x00
        MOTORON             = 1,    //0x01
        BRAKE               = 2,    //0x02
        REGULATED           = 4,    //0x04
    }
    public enum NXTOutputRegulationMode : byte
    {
        REGULATION_MODE_IDLE            = 0,    //0x00
        REGULATION_MODE_MOTOR_SPEED     = 1,    //0x01
        REGULATION_MODE_MOTOR_SYNC      = 2,    //0x02
    }
    public enum NXTOutputRunState : byte
    {
        MOTOR_RUN_STATE_IDLE        = 0,    //0x00
        MOTOR_RUN_STATE_RAMPUP      = 16,   //0x10
        MOTOR_RUN_STATE_RUNNING     = 32,   //0x20
        MOTOR_RUN_STATE_RAMPDOWN    = 64    //0x40
    }
    public enum NXTInputPort : byte
    {
        Port1 = 0, Port2 = 1, Port3 = 2, Port4 = 3
    }
    public enum NXTSensorType : byte
    {
        NO_SENSOR = 0,    //0x00
        SWITCH = 1,    //0x01
        TEMPERATURE = 2,    //0x02
        REFLECTION = 3,    //0x03
        ANGLE = 4,    //0x04
        LIGHT_ACTIVE = 5,    //0x05
        LIGHT_INACTIVE = 6,    //0x06
        SOUND_DB = 7,    //0x07
        SOUND_DBA = 8,    //0x08
        CUSTOM = 9,    //0x09
        LOWSPEED = 10,   //0x0A
        LOWSPEED_9V = 11,   //0x0B
        NO_OF_SENSOR_TYPES = 12,   //0x0C
    }
    public enum NXTSensorMode : byte
    {
        RAWMODE             = 0,    //0x00
        BOOLEANMODE         = 32,   //0x20
        TRANSITIONCNTMODE   = 64,   //0x40
        PERIODCOUNTERMODE   = 96,   //0x60
        PCTFULLSCALEMODE    = 128,   //0x80
        CELSIUSMODE         = 160,   //0xA0
        FAHRENHEITMODE      = 192,   //0xC0
        ANGLESTEPSMODE      = 224   //0xE0
        //SLOPEMASK           = 31,   //0x1F
        //MODEMASK            = 00    //0xE0
    }
    public enum NXTStreamType
    {
        STREAM_NONE = -1,
        STREAM_SOCKET = 0,
        STREAM_SERIALPORT = 1
    }

    public enum NXTWriteBytes : byte
    {
        STARTPROGRAM = 1,
        STOPPROGRAM = 0,
        PLAYSOUNDFILE = 2,
        PLAYTONE = 2,
        SETOUTPUTSTATE = 7,
        SETINPUTMODE = 3,
        GETOUTPUTSTATE = 1,
        GETINPUTVALUES = 1,
        RESETINPUTSCALEDVALUE = 1,
        MESSAGEWRITE = 3,
        RESETMOTORPOSITION = 2,
        GETBATTERYLEVEL = 0,
        STOPSOUNDPLAYBACK = 0,
        KEEPALIVE = 0,
        LSGETSTATUS = 1,
        LSWRITE = 4,
        LSREAD = 1,
        GETCURRENTPROGRAMNAME = 0,
        MESSAGEREAD = 3
    }
    public enum NXTReadBytes : byte
    {
        STARTPROGRAM = 1,
        STOPPROGRAM = 1,
        PLAYSOUNDFILE = 1,
        PLAYTONE = 1,
        SETOUTPUTSTATE = 1,
        SETINPUTMODE = 1,
        GETOUTPUTSTATE = 23,
        GETINPUTVALUES = 14,
        RESETINPUTSCALEDVALUE = 1,
        MESSAGEWRITE = 1,
        RESETMOTORPOSITION = 1,
        GETBATTERYLEVEL = 3,
        STOPSOUNDPLAYBACK = 1,
        KEEPALIVE = 5,
        LSGETSTATUS = 2,
        LSWRITE = 1,
        LSREAD = 18,
        GETCURRENTPROGRAMNAME = 21,
        MESSAGEREAD = 62
    }

    public class NXTException : System.Exception { public NXTException(string msg) : base(msg) { } }


    /// <summary>
    /// Class describing sensor's values received from NXT brick's sensor port.
    /// </summary>
    /// 
    public class SensorValues
    {
        /// <summary>
        /// Specifies if data value should be treated as valid data.
        /// </summary>
        public bool IsValid
        {
            get { return isValid; }
            internal set { isValid = value; }
        }
        private bool isValid;

        /// <summary>
        /// Specifies if calibration file was found and used for <see cref="Calibrated"/>
        /// field calculation.
        /// </summary>
        public bool IsCalibrated
        {
            get { return isCalibrated; }
            internal set { isCalibrated = value; }
        }
        private bool isCalibrated;

        /// <summary>
        /// Sensor type.
        /// </summary>
        public NXTSensorType SensorType
        {
            get { return sensorType; }
            internal set { sensorType = value; }
        }
        private NXTSensorType sensorType;

        /// <summary>
        /// Sensor mode.
        /// </summary>
        public NXTSensorMode SensorMode
        {
            get { return sensorMode; }
            internal set { sensorMode = value; }
        }
        private NXTSensorMode sensorMode;

        /// <summary>
        /// Raw A/D value (device dependent).
        /// </summary>
        public ushort Raw
        {
            get { return raw; }
            internal set { raw = value; }
        }
        private ushort raw;

        /// <summary>
        /// Normalized A/D value (sensor type dependent), [0, 1023].
        /// </summary>
        public ushort Normalized
        {
            get { return normalized; }
            internal set { normalized = value; }
        }
        private ushort normalized;

        /// <summary>
        /// Scaled value (sensor mode dependent).
        /// </summary>
        public short Scaled
        {
            get { return scaled; }
            internal set { scaled = value; }
        }
        private short scaled;

        /// <summary>
        /// Value scaled according to calibration.
        /// </summary>
        /// 
        /// <remarks><note>According to Lego notes the value is currently unused.</note></remarks>
        /// 
        public short Calibrated
        {
            get { return calibrated; }
            internal set { calibrated = value; }
        }
        private short calibrated;
    }


    /// <summary>
    /// Class describing motor's state.
    /// </summary>
    /// 
    public class MotorState
    {
        /// <summary>
        /// Power, [-100, 100].
        /// </summary>
        public int Power
        {
            get { return power; }
            set { power = Math.Min(Math.Max(-100, value), 100); }
        }
        private int power;

        /// <summary>
        /// Turn ratio, [-100, 100].
        /// </summary>
        public int TurnRatio
        {
            get { return turnRatio; }
            set { turnRatio = Math.Min(Math.Max(-100, value), 100); }
        }
        private int turnRatio;

        /// <summary>
        /// Mode (bit field).
        /// </summary>
        public NXTOutputMode Mode
        {
            get { return mode; }
            set { mode = value; }
        }
        private NXTOutputMode mode = NXTOutputMode.NONE;

        /// <summary>
        /// Regulation mode.
        /// </summary>
        public NXTOutputRegulationMode Regulation
        {
            get { return regulation; }
            set { regulation = value; }
        }
        private NXTOutputRegulationMode regulation = NXTOutputRegulationMode.REGULATION_MODE_IDLE;

        /// <summary>
        /// Run state.
        /// </summary>
        public NXTOutputRunState RunState
        {
            get { return runState; }
            set { runState = value; }
        }
        private NXTOutputRunState runState = NXTOutputRunState.MOTOR_RUN_STATE_IDLE;

        /// <summary>
        /// Tacho limit (0 - run forever).
        /// </summary>
        /// 
        /// <remarks>The value determines motor's run limit.</remarks>
        public int TachoLimit
        {
            get { return tachoLimit; }
            set { tachoLimit = Math.Max(0, value); }
        }
        private int tachoLimit;

        /// <summary>
        /// Number of counts since last reset of motor counter.
        /// </summary>
        /// 
        /// <remarks><note>The value is ignored when motor's state is set. The value is
        /// provided when motor's state is retrieved.</note></remarks>
        public int TachoCount
        {
            get { return tachoCount; }
            internal set { tachoCount = value; }
        }
        private int tachoCount;

        /// <summary>
        /// Current position relative to last programmed movement.
        /// </summary>
        /// 
        /// <remarks><note>The value is ignored when motor's state is set. The value is
        /// provided when motor's state is retrieved.</note></remarks>
        public int BlockTachoCount
        {
            get { return blockTachoCount; }
            internal set { blockTachoCount = value; }
        }
        private int blockTachoCount;

        /// <summary>
        /// Current position relative to last reset of motor's rotation sensor.
        /// </summary>
        /// 
        /// <remarks><note>The value is ignored when motor's state is set. The value is
        /// provided when motor's state is retrieved.</note></remarks>
        public int RotationCount
        {
            get { return rotationCount; }
            internal set { rotationCount = value; }
        }
        private int rotationCount;

        /// <summary>
        /// Initializes a new instance of the <see cref="MotorState"/> class.
        /// </summary>
        public MotorState() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="MotorState"/> class.
        /// </summary>
        /// 
        /// <param name="power">Power, [-100, 100].</param>
        /// <param name="turnRatio">Turn ratio, [-100, 100].</param>
        /// <param name="mode">Mode (bit field).</param>
        /// <param name="regulation">Regulation mode.</param>
        /// <param name="runState">Run state.</param>
        /// <param name="tachoLimit">The value determines motor's run limit.</param>
        /// 
        public MotorState(int power, int turnRatio, NXTOutputMode mode,
            NXTOutputRegulationMode regulation, NXTOutputRunState runState, int tachoLimit)
        {
            Power = power;
            TurnRatio = turnRatio;
            Mode = mode;
            Regulation = regulation;
            RunState = runState;
            TachoLimit = tachoLimit;

            TachoCount = 0;
            BlockTachoCount = 0;
            RotationCount = 0;
        }
    }

    public class NXTCommand
    {
        public byte[] command;
        public byte[] reply;

        public byte status;
        public String statusText;

        public byte commandType;
        public byte commandCode;

        public delegate void ReplyDelegate(NXTCommand cmd);
        public ReplyDelegate replyDelegate;

        public NXTCommand(byte[] c, byte[] r, ReplyDelegate del = null)
        {
            command = c;// new byte[c.Length];
            reply = r;// new byte[r.Length];

            commandType = command[0];
            commandCode = command[1];

            replyDelegate = del;
            ///Array.Copy(c, this.command, c.Length);
            //Array.Copy(r, this.reply, r.Length);
        }

        public bool UpdateStatus()
        {
            status = reply[2];
            statusText = NXTProtocol.GetError(status);

            if (command[0] == (byte)NXTCommandType.DIRECT_NORESPONSE || 
                command[0] == (byte)NXTCommandType.SYSTEM_NORESPONSE)
                return false;

            return true;
        }
        public void UpdateReply()
        {
            if (this.replyDelegate != null)
            {
                object[] args = new object[1];
                args[0] = this;
                Program.form1.Invoke(this.replyDelegate);
            }
        }
    }

    public class NXTProtocol
    {
        private object sync = new object();

        object stream;
        NXTStreamType streamType = NXTStreamType.STREAM_NONE;

        ArrayList cmdQueue = new ArrayList();
        ArrayList cmdArchive = new ArrayList(1000);
        Thread cmdThread;

        public delegate void LSGetStatusDelegate(byte bytesReady);
        public LSGetStatusDelegate lsGetStatusDelegate;

        public delegate void LSReadDelegate(byte[] readValues);
        public LSReadDelegate lsReadDelegate;

        public delegate void UltrasonicDelegate(byte[] msg);
        public UltrasonicDelegate ultrasonicDelegate;

        public delegate void BatteryLevelDelegate(double voltage);
        public BatteryLevelDelegate batteryLevelDelegate;

        public delegate void GetVersionDelegate(String firmware, String protocol);
        public GetVersionDelegate getVersionDelegate;

        public delegate void GetOutputDelegate(MotorState state);
        public GetOutputDelegate getOutputDelegate;

        public delegate void GetInputDelegate(SensorValues sensor);
        public GetInputDelegate getInputDelegate;

        public delegate void MessageReadDelegate();
        public MessageReadDelegate messageReadDelegate;

        public delegate void KeepAliveDelegate(long sleepTime);
        public KeepAliveDelegate keepAliveDelegate;

        public NXTProtocol(object s, NXTStreamType stype) 
        {
            stream = s;
            streamType = stype;

            cmdThread = new Thread(CommandWorker);

            lsGetStatusDelegate = null;
            lsReadDelegate = null;
            ultrasonicDelegate = null;
            batteryLevelDelegate = null;
            getVersionDelegate = null;
            getOutputDelegate = null;
            getInputDelegate = null;
            messageReadDelegate = null;
            keepAliveDelegate = null;
        }

        protected bool SendCommand(byte[] command, byte[] reply)
        {
            NXTCommand cmd = new NXTCommand(command, reply);

            lock (sync)
            {
                cmdQueue.Add(cmd);

                if (cmdThread == null || !cmdThread.IsAlive)
                {
                    cmdThread = new Thread(CommandWorker);
                    cmdThread.Start();
                }
            }
            return true;
        }

        private void CommandWorker()
        {
            //lock (sync)
            {
                while (cmdQueue.Count > 0)
                {
                    NXTCommand cmd = (NXTCommand)cmdQueue[0];

                    if (!SocketSend(cmd.command))
                    {
                        cmdArchive.Add(cmd);
                        cmdQueue.RemoveAt(0);
                        cmdQueue.TrimToSize();
                        continue;
                    }

                    if (cmd.UpdateStatus())
                        SocketReceive(cmd.reply);

                    ProcessReply(cmd);

                    cmdArchive.Add(cmd);
                    cmdQueue.RemoveAt(0);
                    cmdQueue.TrimToSize();

                    /*
                    byte nError = cmd.reply[2];
                    if (nError > 0)
                        throw new NXTException(GetError(nError));
                     */
                }
            }
        }

        protected bool SocketSend(byte[] command)
        {
            //Create NXT Header
            byte[] headerData = new byte[2];
            byte nLen = (byte)(command.Length & 0x3f);  //<= 64 byte packet
            headerData[0] = nLen;
            headerData[1] = 0;

            //Send Header and Command
            NetworkStream s = (NetworkStream)stream;
            try
            {
                s.Write(headerData, 0, headerData.Length);
                s.Write(command, 0, command.Length);
            }
            catch (Exception e)
            {
                return false;
            }
            return true;
        }

        protected void SocketReceive(byte[] reply)
        {
            NetworkStream s = (NetworkStream)stream;
            if (s == null) return;
            int numberOfBytesRead = 0;
            bool didReadHeader = false;
            int replyReadLen = 0;

            while (s != null)
            {
                if (s.CanRead && s.DataAvailable)
                {
                    if (!didReadHeader)
                    {
                        //Read the NXT Header
                        byte[] nxtHeader = new byte[2];
                        numberOfBytesRead = s.Read(nxtHeader, 0, 2);

                        //Header read, prepare to read the Data
                        if (numberOfBytesRead == 2)
                        {
                            replyReadLen = nxtHeader[0] + 256 * nxtHeader[1];
                            didReadHeader = true;
                            numberOfBytesRead = 0;

                            if (replyReadLen != reply.Length)
                            {
                                byte[] dump = new byte[replyReadLen];
                                s.Read(dump, 0, replyReadLen);
                                break;
                            }
                        }
                    }

                    if (didReadHeader)
                    {
                        //Loop until we've read all the data from the header.
                        if (replyReadLen > numberOfBytesRead)
                        {
                            int datasize = replyReadLen - numberOfBytesRead;
                            int offset = replyReadLen - datasize;
                            numberOfBytesRead += s.Read(reply, offset, datasize);

                            //If we received all data, output it and reset.
                            if (numberOfBytesRead >= replyReadLen)
                            {
                                break;
                            }
                        }
                    }
                }
                //Thread.Sleep(25);
            }
        }
      
        public void StartProgram(String file, bool sendResponse = true)
        {
            byte[] command = new byte[18];
            byte[] reply = new byte[3];

            command[0] = sendResponse ? (byte)NXTCommandType.DIRECT_RESPONSE : (byte)NXTCommandType.DIRECT_NORESPONSE;
            command[1] = (byte)NXTCommandCode.PLAYSOUNDFILE;
            System.Text.ASCIIEncoding.ASCII.GetBytes(file, 0, Math.Min(file.Length, 14), command, 2);

            SendCommand(command, reply);
        }
        public void StopProgram(bool sendResponse = true)
        {
            byte[] command = new byte[2];
            byte[] reply = new byte[3];

            command[0] = sendResponse ? (byte)NXTCommandType.DIRECT_RESPONSE : (byte)NXTCommandType.DIRECT_NORESPONSE;
            command[1] = (byte)NXTCommandCode.STOPPROGRAM;

            SendCommand(command, reply);
        }
        public void PlaySoundFile(bool shouldLoop, String file, bool sendResponse = true)
        {
            byte[] command = new byte[23];
            byte[] reply = new byte[3];

            command[0] = sendResponse ? (byte)NXTCommandType.DIRECT_RESPONSE : (byte)NXTCommandType.DIRECT_NORESPONSE;
            command[1] = (byte)NXTCommandCode.PLAYSOUNDFILE;
            command[2] = shouldLoop ? (byte)1 : (byte)0;
            int len = System.Text.ASCIIEncoding.ASCII.GetBytes(file, 0, Math.Min(file.Length, 14), command, 3);
            command[len + 4] = 0; //null terminator;

            SendCommand(command, reply);
        }
        public void PlayTone(int frequency, int timeInMiliseconds, bool sendResponse = true)
        {
            byte[] command = new byte[6];
            byte[] reply = new byte[3];

            command[0] = sendResponse ? (byte)NXTCommandType.DIRECT_RESPONSE : (byte)NXTCommandType.DIRECT_NORESPONSE;
            command[1] = (byte)NXTCommandCode.PLAYTONE;
            command[2] = (byte)(frequency & 0xff);
            command[3] = (byte)(frequency >> 8);
            command[4] = (byte)(timeInMiliseconds & 0xff);
            command[5] = (byte)(timeInMiliseconds >> 8);

            SendCommand(command, reply);
        }
        public void SetOutputState(NXTOutputPort outputPort, sbyte powerSet, NXTOutputMode mode, NXTOutputRegulationMode regMode, sbyte turnRatio, NXTOutputRunState runState, ulong tachoLimit, bool sendResponse=false)
        {
            byte[] command = new byte[13];
            byte[] reply = new byte[3];

            command[0] = sendResponse ? (byte)NXTCommandType.DIRECT_RESPONSE : (byte)NXTCommandType.DIRECT_NORESPONSE;
            command[1] = (byte)NXTCommandCode.SETOUTPUTSTATE;
            command[2] = (byte)outputPort;
            command[3] = (byte)powerSet;
            command[4] = (byte)mode;
            command[5] = (byte)regMode;
            command[6] = (byte)turnRatio;
            command[7] = (byte)runState;
            command[8] = (byte)(tachoLimit);
            command[9] = (byte)(tachoLimit >> 8);
            command[10] = (byte)(tachoLimit >> 16);
            command[11] = (byte)(tachoLimit >> 24);
            command[12] = (byte)(tachoLimit >> 32);

            SendCommand(command, reply);
        }
        public void SetInputMode(NXTInputPort inputPort, NXTSensorType sensorType, NXTSensorMode sensorMode, bool sendResponse = true)
        {
            byte[] command = new byte[5];
            byte[] reply = new byte[3];

            command[0] = sendResponse ? (byte)NXTCommandType.DIRECT_RESPONSE : (byte)NXTCommandType.DIRECT_NORESPONSE;
            command[1] = (byte)NXTCommandCode.SETINPUTMODE;
            command[2] = (byte)inputPort;
            command[3] = (byte)sensorType;
            command[4] = (byte)sensorMode;

            SendCommand(command, reply);
        }
        public void GetOutputState(NXTOutputPort outputPort, bool sendResponse = true)
        {
            byte[] command = new byte[3];
            byte[] reply = new byte[25];

            command[0] = sendResponse ? (byte)NXTCommandType.DIRECT_RESPONSE : (byte)NXTCommandType.DIRECT_NORESPONSE;
            command[1] = (byte)NXTCommandCode.GETOUTPUTSTATE;
            command[2] = (byte)outputPort;

            SendCommand(command, reply);

            if (!sendResponse) return;
        }
        public void GetInputValues(NXTInputPort inputPort, bool sendResponse = true)
        {
            byte[] command = new byte[3];
            byte[] reply = new byte[16];
            
            command[0] = sendResponse ? (byte)NXTCommandType.DIRECT_RESPONSE : (byte)NXTCommandType.DIRECT_NORESPONSE;
            command[1] = (byte)NXTCommandCode.GETINPUTVALUES;
            command[2] = (byte)inputPort;

            SendCommand(command, reply);

            if (!sendResponse) return;
        }
        public void ResetInputScaledValue(NXTInputPort inputPort, bool sendResponse = true)
        {
            byte[] command = new byte[3];
            byte[] reply = new byte[3];

            command[0] = sendResponse ? (byte)NXTCommandType.DIRECT_RESPONSE : (byte)NXTCommandType.DIRECT_NORESPONSE;
            command[1] = (byte)NXTCommandCode.RESETINPUTSCALEDVALUE;
            command[2] = (byte)inputPort;

            SendCommand(command, reply);
        }
        public void MessageWrite(byte inboxNumber, byte[] messageData, bool sendResponse = true )
        {
            byte[] command = new byte[5 + messageData.Length];
            byte[] reply = new byte[3];

            command[0] = sendResponse ? (byte)NXTCommandType.DIRECT_RESPONSE : (byte)NXTCommandType.DIRECT_NORESPONSE;
            command[1] = (byte)NXTCommandCode.MESSAGEWRITE;
            command[2] = inboxNumber;
            command[3] = (byte)messageData.Length;
            Array.Copy(messageData, 0, command, 4, messageData.Length);
            command[5 + messageData.Length] = 0; //null terminator

            SendCommand(command, reply);
        }
        public void ResetMotorPosition(NXTOutputPort outputPort, bool relativeToLastMovement, bool sendResponse = true)
        {
            byte[] command = new byte[4];
            byte[] reply = new byte[3];

            command[0] = sendResponse ? (byte)NXTCommandType.DIRECT_RESPONSE : (byte)NXTCommandType.DIRECT_NORESPONSE;
            command[1] = (byte)NXTCommandCode.RESETMOTORPOSITION;
            command[2] = (byte)outputPort;
            command[3] = (byte)(relativeToLastMovement ? 1 : 0);

            SendCommand(command, reply);
        }
        public void GetBatteryLevel(bool sendResponse = true)
        {
            byte[] command = new byte[2];
            byte[] reply = new byte[5];

            command[0] = sendResponse ? (byte)NXTCommandType.DIRECT_RESPONSE : (byte)NXTCommandType.DIRECT_NORESPONSE;
            command[1] = (byte)NXTCommandCode.GETBATTERYLEVEL;

            SendCommand(command, reply);

            if (!sendResponse) return;
        }
        public void StopSoundPlayback(bool sendResponse = true)
        {
            byte[] command = new byte[2];
            byte[] reply = new byte[3];

            command[0] = sendResponse ? (byte)NXTCommandType.DIRECT_RESPONSE : (byte)NXTCommandType.DIRECT_NORESPONSE;
            command[1] = (byte)NXTCommandCode.STOPSOUNDPLAYBACK;

            SendCommand(command, reply);
        }
        public void KeepAlive(bool sendResponse = true)
        {
            byte[] command = new byte[2];
            byte[] reply = new byte[7];
            
            command[0] = sendResponse ? (byte)NXTCommandType.DIRECT_RESPONSE : (byte)NXTCommandType.DIRECT_NORESPONSE;
            command[1] = (byte)NXTCommandCode.KEEPALIVE;

            SendCommand(command, reply);
        }
        public void LSGetStatus(NXTInputPort inputPort, bool sendResponse = true)
        {
            byte[] command = new byte[3];
            byte[] reply = new byte[4];

            command[0] = sendResponse ? (byte)NXTCommandType.DIRECT_RESPONSE : (byte)NXTCommandType.DIRECT_NORESPONSE;
            command[1] = (byte)NXTCommandCode.LSGETSTATUS;
            command[2] = (byte)inputPort;

            SendCommand(command, reply);
        }
        public void LSWrite(NXTInputPort inputPort, byte[] transmitData, byte receiveLen, bool sendResponse = true)
        {
            byte[] command = new byte[5 + transmitData.Length];
            byte[] reply = new byte[3];

            command[0] = sendResponse ? (byte)NXTCommandType.DIRECT_RESPONSE : (byte)NXTCommandType.DIRECT_NORESPONSE;
            command[1] = (byte)NXTCommandCode.LSWRITE;
            command[2] = (byte)inputPort;
            command[3] = (byte)transmitData.Length;
            command[4] = (byte)receiveLen;
            Array.Copy(transmitData, 0, command, 5, transmitData.Length);

            SendCommand(command, reply);
        }
        public void LSRead(NXTInputPort inputPort, bool sendResponse = true)
        {
            byte[] command = new byte[3];
            byte[] reply = new byte[20];

            command[0] = sendResponse ? (byte)NXTCommandType.DIRECT_RESPONSE : (byte)NXTCommandType.DIRECT_NORESPONSE;
            command[1] = (byte)NXTCommandCode.LSREAD;
            command[2] = (byte)inputPort;

            SendCommand(command, reply);
        }
        public void GetCurrentProgramName(bool sendResponse = true)
        {
            byte[] command = new byte[2];
            byte[] reply = new byte[3];

            command[0] = sendResponse ? (byte)NXTCommandType.DIRECT_RESPONSE : (byte)NXTCommandType.DIRECT_NORESPONSE;
            command[1] = (byte)NXTCommandCode.GETCURRENTPROGRAMNAME;

            SendCommand(command, reply);
        }
        public void MessageRead(byte remoteInbox, byte localInbox, bool shouldRemove, bool sendResponse = true)
        {
            byte[] command = new byte[5];
            byte[] reply = new byte[64];

            command[0] = sendResponse ? (byte)NXTCommandType.DIRECT_RESPONSE : (byte)NXTCommandType.DIRECT_NORESPONSE;
            command[1] = (byte)NXTCommandCode.MESSAGEREAD;
            command[2] = remoteInbox;
            command[3] = localInbox;
            command[4] = (byte)(shouldRemove ? 1 : 0);

            SendCommand(command, reply);
        }
        public void GetVersion(bool sendResponse = true)
        {
            byte[] command = new byte[2];
            byte[] reply = new byte[7];
            
            command[0] = sendResponse ? (byte)NXTCommandType.SYSTEM_RESPONSE : (byte)NXTCommandType.SYSTEM_NORESPONSE;
            command[1] = (byte)NXTCommandCode.VERSION;

            SendCommand(command, reply);
        }
        public void GetUltrasonicValue(NXTInputPort inputPort, byte currentStep = 0, bool sendResponse = true)
        {
            if (currentStep == 0)
            {
                byte[] transmitData = new byte[2] { 0x02, 0x42 };
                LSWrite(inputPort, transmitData, 1);
                LSGetStatus(inputPort);
                LSRead(inputPort);
            }
            else if (currentStep == 1)
            {
                LSGetStatus(inputPort);
            }
            else if (currentStep == 2)
            {
                LSRead(inputPort);
            }
        }
        public void GetUltrasonicValue_Step2(NXTInputPort inputPort)
        {

        }

        public void Process_GetOutputState(byte[] reply )
        {
            if (getOutputDelegate == null) return;

            MotorState state = new MotorState();
            state.Power = (sbyte)reply[4];
            state.Mode = (NXTOutputMode)reply[5];
            state.Regulation = (NXTOutputRegulationMode)reply[6];
            state.TurnRatio = (sbyte)reply[7];
            state.RunState = (NXTOutputRunState)reply[8];

            // tacho limit
            state.TachoLimit = reply[9] | (reply[10] << 8) |
                    (reply[11] << 16) | (reply[12] << 24);
            // tacho count
            state.TachoCount = reply[13] | (reply[14] << 8) |
                    (reply[15] << 16) | (reply[16] << 24);
            // block tacho count
            state.BlockTachoCount = reply[17] | (reply[18] << 8) |
                    (reply[19] << 16) | (reply[20] << 24);
            // rotation count
            state.RotationCount = reply[21] | (reply[22] << 8) |
                    (reply[23] << 16) | (reply[24] << 24);

            object[] args = new object[1];
            args[0] = state;
            Program.form1.Invoke(getOutputDelegate, args);
        }
        public void Process_GetInputValues(byte[] reply )
        {
            if (getInputDelegate == null) return;

            SensorValues sensor = new SensorValues();
            sensor.IsValid = (reply[4] != 0);
            sensor.IsCalibrated = (reply[5] != 0);
            sensor.SensorType = (NXTSensorType)reply[6];
            sensor.SensorMode = (NXTSensorMode)reply[7];
            sensor.Raw = (ushort)(reply[8] | (reply[9] << 8));
            sensor.Normalized = (ushort)(reply[10] | (reply[11] << 8));
            sensor.Scaled = (short)(reply[12] | (reply[13] << 8));
            sensor.Calibrated = (short)(reply[14] | (reply[15] << 8));

            object[] args = new object[1];
            args[0] = sensor;
            Program.form1.Invoke(getInputDelegate, args);
        }
        public void Process_GetBatteryLevel(byte[] reply )
        {
            if (batteryLevelDelegate == null) return;

            double voltage = (double)Buffer2Word(reply, 3) / 1000.0f;

            object[] args = new object[1];
            args[0] = voltage;
            Program.form1.Invoke(batteryLevelDelegate, args);
        }
        public void Process_KeepAlive(byte[] reply)
        {
            if (keepAliveDelegate == null) return;

            long timeInMilliseconds = Buffer2Long(reply, 3);

            object[] args = new object[1];
            args[0] = timeInMilliseconds;
            Program.form1.Invoke(keepAliveDelegate, args);
        }
        public void Process_LSGetStatus(byte[] reply)
        {
            if (lsGetStatusDelegate == null) return;

            byte bytesReady = reply[3];

            object[] args = new object[1];
            args[0] = bytesReady;
            Program.form1.Invoke(lsGetStatusDelegate, args);
        }
        public void Process_LSRead(byte[] reply)
        {
            if (lsGetStatusDelegate == null) return;

            byte readLen = reply[3];
            byte[] readValues = new byte[readLen];
            Array.Copy(reply, 4, readValues, 0, Math.Min(readValues.Length, readLen));

            object[] args = new object[1];
            args[0] = readValues;
            Program.form1.Invoke(getInputDelegate, args);
        }
        public void Process_MessageRead(byte[] reply)
        {
            if (messageReadDelegate == null) return;

            byte replyLocalInbox = reply[3];
            byte msgLen = reply[4];
            byte[] msg = new byte[msgLen];
            Array.Copy(reply, 5, msg, 0, msgLen);

            object[] args = new object[1];
            args[0] = msg;
            Program.form1.Invoke(messageReadDelegate, args);
        }
        public void Process_GetVersion(byte[] reply)
        {
            if (getVersionDelegate == null) return;

            String firmware = reply[6].ToString() + "." + reply[5].ToString();
            String protocol = reply[4].ToString() + "." + reply[3].ToString();

            object[] args = new object[2];
            args[0] = firmware;
            args[1] = protocol;
            Program.form1.Invoke(getVersionDelegate, args);
        }

        public void ProcessReply(NXTCommand cmd)
        {
            switch ((NXTCommandCode)cmd.commandCode)
            {
                
                case NXTCommandCode.GETOUTPUTSTATE:
                    break;
                case NXTCommandCode.GETINPUTVALUES:
                    break;
                case NXTCommandCode.GETBATTERYLEVEL:
                    Process_GetBatteryLevel(cmd.reply); 
                    break;
                case NXTCommandCode.KEEPALIVE:
                    Process_KeepAlive(cmd.reply);
                    break;
                case NXTCommandCode.LSGETSTATUS:
                    Process_LSGetStatus(cmd.reply);
                    break;
                case NXTCommandCode.LSWRITE:
                    break;
                case NXTCommandCode.LSREAD:
                    Process_LSRead(cmd.reply);
                    break;
                case NXTCommandCode.GETCURRENTPROGRAMNAME:
                    break;
                case NXTCommandCode.MESSAGEREAD:
                    Process_MessageRead(cmd.reply);
                    break;
                case NXTCommandCode.VERSION:
                    Process_GetVersion(cmd.reply);
                    break;
            }
        }

        private static int Buffer2Word(byte[] buffer, byte nIndex)
        {
            return buffer[nIndex] + 256 * buffer[nIndex + 1];
        }
        private static long Buffer2Long(byte[] buffer, byte nIndex)
        {
            long n = 0;
            for (int i = 0; i < 4; i++)
                n += (1 << i * 8) * (long)buffer[nIndex++];

            return n;
        }
        private static long Buffer2SignedLong(byte[] buffer, byte nIndex)
        {
            long n = Buffer2Long(buffer, nIndex);
            if (n < 0x8000)
                return n;
            else
                return n - 0x100000000;
        }

        public static string GetError(byte nError)
        {
            switch (nError)
            {
                case 0x20:
                    return "Pending communication transaction in progress.";
                case 0x40:
                    return "Specified mailbox queue is empty.";
                case 0xBD:
                    return "Request failed (i.e. specific file not found).";
                case 0xBE:
                    return "Unknown command opcode";
                case 0xBF:
                    return "Insane packet";
                case 0xD0:
                    return "Data contains out-of-range values";
                case 0xDD:
                    return "Communication bus error";
                case 0xDE:
                    return "No free memory in communication buffer";
                case 0xDF:
                    return "Specified channel/connection is not valid";
                case 0xE0:
                    return "Specified channel/connection not configured or busy";
                case 0xEC:
                    return "No active program";
                case 0xED:
                    return "Illegal size specified";
                case 0xEE:
                    return "Illegal mailbox queue ID specified";
                case 0xEF:
                    return "Attempted to access invalid field of a structure";
                case 0xF0:
                    return "Bad input or output specified";
                case 0xFB:
                    return "Insufficient memory available";
                case 0xFF:
                    return "Bad arguments";
            }
            return "No error";
        }
        public static string GetCommandName(NXTCommandCode nCommand)
        {
            switch (nCommand)
            {
                case NXTCommandCode.STARTPROGRAM:
                    return "STARTPROGRAM";
                case NXTCommandCode.STOPPROGRAM:
                    return "STOPPROGRAM";
                case NXTCommandCode.PLAYSOUNDFILE:
                    return "PLAYSOUNDFILE";
                case NXTCommandCode.PLAYTONE:
                    return "PLAYTONE";
                case NXTCommandCode.SETOUTPUTSTATE:
                    return "SETOUTPUTSTATE";
                case NXTCommandCode.SETINPUTMODE:
                    return "SETINPUTMODE";
                case NXTCommandCode.GETOUTPUTSTATE:
                    return "GetOutputState";
                case NXTCommandCode.GETINPUTVALUES:
                    return "GetInputValues";
                case NXTCommandCode.RESETINPUTSCALEDVALUE:
                    return "RESETINPUTSCALEDVALUE";
                case NXTCommandCode.MESSAGEWRITE:
                    return "MESSAGEWRITE";
                case NXTCommandCode.RESETMOTORPOSITION:
                    return "RESETMOTORPOSITION";
                case NXTCommandCode.GETBATTERYLEVEL:
                    return "GetBatteryLevel";
                case NXTCommandCode.STOPSOUNDPLAYBACK:
                    return "STOPSOUNDPLAYBACK";
                case NXTCommandCode.KEEPALIVE:
                    return "KeepAlive";
                case NXTCommandCode.LSGETSTATUS:
                    return "LGGetStatus";
                case NXTCommandCode.LSWRITE:
                    return "LSWRITE";
                case NXTCommandCode.LSREAD:
                    return "LSRead";
                case NXTCommandCode.GETCURRENTPROGRAMNAME:
                    return "GetCurrentProgramName";
                case NXTCommandCode.MESSAGEREAD:
                    return "MessageRead";
                case NXTCommandCode.VERSION:
                    return "Version";
            }
            return "No Name";
        }

    }
}
