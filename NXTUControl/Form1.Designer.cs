namespace RoboticsChallenge
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }

            foreach (RoboticsDeviceInfo di in nxtDevices)
            {
                di.Disconnect();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.btnFindDevices = new System.Windows.Forms.Button();
            this.btnConnect = new System.Windows.Forms.Button();
            this.btnVersion = new System.Windows.Forms.Button();
            this.btnBeep = new System.Windows.Forms.Button();
            this.btnBattery = new System.Windows.Forms.Button();
            this.btnDisconnect = new System.Windows.Forms.Button();
            this.lstDevices = new System.Windows.Forms.ListBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.rtxtLog = new System.Windows.Forms.RichTextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnFindDevices
            // 
            this.btnFindDevices.Location = new System.Drawing.Point(12, 12);
            this.btnFindDevices.Name = "btnFindDevices";
            this.btnFindDevices.Size = new System.Drawing.Size(135, 23);
            this.btnFindDevices.TabIndex = 0;
            this.btnFindDevices.Text = "Find Devices";
            this.btnFindDevices.UseVisualStyleBackColor = true;
            this.btnFindDevices.Click += new System.EventHandler(this.btnFindDevices_Click);
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(12, 166);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(57, 23);
            this.btnConnect.TabIndex = 3;
            this.btnConnect.Text = "Connect";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // btnVersion
            // 
            this.btnVersion.Location = new System.Drawing.Point(35, 253);
            this.btnVersion.Name = "btnVersion";
            this.btnVersion.Size = new System.Drawing.Size(75, 23);
            this.btnVersion.TabIndex = 4;
            this.btnVersion.Text = "Version";
            this.btnVersion.UseVisualStyleBackColor = true;
            this.btnVersion.Click += new System.EventHandler(this.btnVersion_Click);
            // 
            // btnBeep
            // 
            this.btnBeep.Location = new System.Drawing.Point(35, 195);
            this.btnBeep.Name = "btnBeep";
            this.btnBeep.Size = new System.Drawing.Size(75, 23);
            this.btnBeep.TabIndex = 5;
            this.btnBeep.Text = "Beep";
            this.btnBeep.UseVisualStyleBackColor = true;
            this.btnBeep.Click += new System.EventHandler(this.btnBeep_Click);
            // 
            // btnBattery
            // 
            this.btnBattery.Location = new System.Drawing.Point(35, 224);
            this.btnBattery.Name = "btnBattery";
            this.btnBattery.Size = new System.Drawing.Size(75, 23);
            this.btnBattery.TabIndex = 6;
            this.btnBattery.Text = "Battery Life";
            this.btnBattery.UseVisualStyleBackColor = true;
            this.btnBattery.Click += new System.EventHandler(this.btnBattery_Click);
            // 
            // btnDisconnect
            // 
            this.btnDisconnect.Location = new System.Drawing.Point(75, 166);
            this.btnDisconnect.Name = "btnDisconnect";
            this.btnDisconnect.Size = new System.Drawing.Size(72, 23);
            this.btnDisconnect.TabIndex = 7;
            this.btnDisconnect.Text = "Disconnect";
            this.btnDisconnect.UseVisualStyleBackColor = true;
            this.btnDisconnect.Click += new System.EventHandler(this.btnDisconnect_Click);
            // 
            // lstDevices
            // 
            this.lstDevices.FormattingEnabled = true;
            this.lstDevices.Location = new System.Drawing.Point(12, 39);
            this.lstDevices.Name = "lstDevices";
            this.lstDevices.Size = new System.Drawing.Size(135, 121);
            this.lstDevices.TabIndex = 9;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // timer2
            // 
            this.timer2.Interval = 200;
            // 
            // rtxtLog
            // 
            this.rtxtLog.Location = new System.Drawing.Point(214, 42);
            this.rtxtLog.Name = "rtxtLog";
            this.rtxtLog.ReadOnly = true;
            this.rtxtLog.Size = new System.Drawing.Size(289, 121);
            this.rtxtLog.TabIndex = 2;
            this.rtxtLog.Text = "";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(35, 282);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 10;
            this.button1.Text = "Key Config";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(659, 352);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.lstDevices);
            this.Controls.Add(this.btnDisconnect);
            this.Controls.Add(this.btnBattery);
            this.Controls.Add(this.btnBeep);
            this.Controls.Add(this.btnVersion);
            this.Controls.Add(this.btnConnect);
            this.Controls.Add(this.rtxtLog);
            this.Controls.Add(this.btnFindDevices);
            this.KeyPreview = true;
            this.Name = "Form1";
            this.Text = "Robotics Challenge 2011";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnFindDevices;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.Button btnVersion;
        private System.Windows.Forms.Button btnBeep;
        private System.Windows.Forms.Button btnBattery;
        private System.Windows.Forms.Button btnDisconnect;
        private System.Windows.Forms.ListBox lstDevices;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.RichTextBox rtxtLog;
        private System.Windows.Forms.Button button1;
    }
}

