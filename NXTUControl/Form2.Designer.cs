namespace RoboticsChallenge
{
    partial class Form2
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
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.textpowerA = new System.Windows.Forms.TextBox();
            this.radioforwardA = new System.Windows.Forms.RadioButton();
            this.radioreverseA = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.radioreverseB = new System.Windows.Forms.RadioButton();
            this.radioforwardB = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            this.textpowerB = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.radioreverseC = new System.Windows.Forms.RadioButton();
            this.radioforwardC = new System.Windows.Forms.RadioButton();
            this.label5 = new System.Windows.Forms.Label();
            this.textpowerC = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btnCreateKey = new System.Windows.Forms.Button();
            this.txtKeyBind1 = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.lblFilename = new System.Windows.Forms.Label();
            this.btnLoadConfig = new System.Windows.Forms.Button();
            this.txtFilename = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.button2 = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            this.SuspendLayout();
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(29, 103);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(155, 121);
            this.listBox1.TabIndex = 3;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // textpowerA
            // 
            this.textpowerA.Location = new System.Drawing.Point(7, 123);
            this.textpowerA.Name = "textpowerA";
            this.textpowerA.Size = new System.Drawing.Size(65, 20);
            this.textpowerA.TabIndex = 4;
            this.textpowerA.TextChanged += new System.EventHandler(this.textpowerA_TextChanged);
            this.textpowerA.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textpowerA_KeyPress);
            // 
            // radioforwardA
            // 
            this.radioforwardA.AutoSize = true;
            this.radioforwardA.Location = new System.Drawing.Point(7, 70);
            this.radioforwardA.Name = "radioforwardA";
            this.radioforwardA.Size = new System.Drawing.Size(63, 17);
            this.radioforwardA.TabIndex = 5;
            this.radioforwardA.TabStop = true;
            this.radioforwardA.Text = "Forward";
            this.radioforwardA.UseVisualStyleBackColor = true;
            this.radioforwardA.CheckedChanged += new System.EventHandler(this.radioforwardA_CheckedChanged);
            // 
            // radioreverseA
            // 
            this.radioreverseA.AutoSize = true;
            this.radioreverseA.Location = new System.Drawing.Point(7, 47);
            this.radioreverseA.Name = "radioreverseA";
            this.radioreverseA.Size = new System.Drawing.Size(65, 17);
            this.radioreverseA.TabIndex = 6;
            this.radioreverseA.TabStop = true;
            this.radioreverseA.Text = "Reverse";
            this.radioreverseA.UseVisualStyleBackColor = true;
            this.radioreverseA.CheckedChanged += new System.EventHandler(this.radioreverseA_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(2, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Direction";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(2, 107);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Power";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(289, 50);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 13;
            this.button1.Text = "Save Config";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioreverseA);
            this.groupBox1.Controls.Add(this.radioforwardA);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.textpowerA);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(57, 256);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(81, 160);
            this.groupBox1.TabIndex = 14;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Port A";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.radioreverseB);
            this.groupBox2.Controls.Add(this.radioforwardB);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.textpowerB);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Location = new System.Drawing.Point(163, 256);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(81, 160);
            this.groupBox2.TabIndex = 15;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Port B";
            // 
            // radioreverseB
            // 
            this.radioreverseB.AutoSize = true;
            this.radioreverseB.Location = new System.Drawing.Point(7, 47);
            this.radioreverseB.Name = "radioreverseB";
            this.radioreverseB.Size = new System.Drawing.Size(65, 17);
            this.radioreverseB.TabIndex = 6;
            this.radioreverseB.TabStop = true;
            this.radioreverseB.Text = "Reverse";
            this.radioreverseB.UseVisualStyleBackColor = true;
            this.radioreverseB.CheckedChanged += new System.EventHandler(this.radioreverseB_CheckedChanged);
            // 
            // radioforwardB
            // 
            this.radioforwardB.AutoSize = true;
            this.radioforwardB.Location = new System.Drawing.Point(7, 70);
            this.radioforwardB.Name = "radioforwardB";
            this.radioforwardB.Size = new System.Drawing.Size(63, 17);
            this.radioforwardB.TabIndex = 5;
            this.radioforwardB.TabStop = true;
            this.radioforwardB.Text = "Forward";
            this.radioforwardB.UseVisualStyleBackColor = true;
            this.radioforwardB.CheckedChanged += new System.EventHandler(this.radioforwardB_CheckedChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(2, 31);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Direction";
            // 
            // textpowerB
            // 
            this.textpowerB.Location = new System.Drawing.Point(7, 123);
            this.textpowerB.Name = "textpowerB";
            this.textpowerB.Size = new System.Drawing.Size(65, 20);
            this.textpowerB.TabIndex = 4;
            this.textpowerB.TextChanged += new System.EventHandler(this.textpowerB_TextChanged);
            this.textpowerB.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textpowerB_KeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(2, 107);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(37, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Power";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.radioreverseC);
            this.groupBox3.Controls.Add(this.radioforwardC);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.textpowerC);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Location = new System.Drawing.Point(270, 256);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(81, 160);
            this.groupBox3.TabIndex = 16;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Port C";
            // 
            // radioreverseC
            // 
            this.radioreverseC.AutoSize = true;
            this.radioreverseC.Location = new System.Drawing.Point(7, 47);
            this.radioreverseC.Name = "radioreverseC";
            this.radioreverseC.Size = new System.Drawing.Size(65, 17);
            this.radioreverseC.TabIndex = 6;
            this.radioreverseC.TabStop = true;
            this.radioreverseC.Text = "Reverse";
            this.radioreverseC.UseVisualStyleBackColor = true;
            this.radioreverseC.CheckedChanged += new System.EventHandler(this.radioreverseC_CheckedChanged);
            // 
            // radioforwardC
            // 
            this.radioforwardC.AutoSize = true;
            this.radioforwardC.Location = new System.Drawing.Point(7, 70);
            this.radioforwardC.Name = "radioforwardC";
            this.radioforwardC.Size = new System.Drawing.Size(63, 17);
            this.radioforwardC.TabIndex = 5;
            this.radioforwardC.TabStop = true;
            this.radioforwardC.Text = "Forward";
            this.radioforwardC.UseVisualStyleBackColor = true;
            this.radioforwardC.CheckedChanged += new System.EventHandler(this.radioforwardC_CheckedChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(2, 31);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(49, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "Direction";
            // 
            // textpowerC
            // 
            this.textpowerC.Location = new System.Drawing.Point(7, 123);
            this.textpowerC.Name = "textpowerC";
            this.textpowerC.Size = new System.Drawing.Size(65, 20);
            this.textpowerC.TabIndex = 4;
            this.textpowerC.TextChanged += new System.EventHandler(this.textpowerC_TextChanged);
            this.textpowerC.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textpowerC_KeyPress);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(2, 107);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(37, 13);
            this.label6.TabIndex = 8;
            this.label6.Text = "Power";
            // 
            // btnCreateKey
            // 
            this.btnCreateKey.Location = new System.Drawing.Point(28, 54);
            this.btnCreateKey.Name = "btnCreateKey";
            this.btnCreateKey.Size = new System.Drawing.Size(81, 23);
            this.btnCreateKey.TabIndex = 1;
            this.btnCreateKey.Text = "Create Bind";
            this.btnCreateKey.UseVisualStyleBackColor = true;
            this.btnCreateKey.Click += new System.EventHandler(this.btnCreateKey_Click);
            // 
            // txtKeyBind1
            // 
            this.txtKeyBind1.Location = new System.Drawing.Point(8, 28);
            this.txtKeyBind1.Name = "txtKeyBind1";
            this.txtKeyBind1.Size = new System.Drawing.Size(138, 20);
            this.txtKeyBind1.TabIndex = 0;
            this.txtKeyBind1.Text = "Click Here and Press Key";
            this.txtKeyBind1.TextChanged += new System.EventHandler(this.txtKeyBind1_TextChanged);
            this.txtKeyBind1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtKeyBind1_KeyDown);
            this.txtKeyBind1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtKeyBind1_KeyPress);
            this.txtKeyBind1.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtKeyBind1_KeyUp);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(32, 87);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(57, 13);
            this.label7.TabIndex = 18;
            this.label7.Text = "Key Binds:";
            this.label7.Click += new System.EventHandler(this.label7_Click);
            // 
            // lblFilename
            // 
            this.lblFilename.AutoSize = true;
            this.lblFilename.Location = new System.Drawing.Point(41, 193);
            this.lblFilename.Name = "lblFilename";
            this.lblFilename.Size = new System.Drawing.Size(0, 13);
            this.lblFilename.TabIndex = 19;
            // 
            // btnLoadConfig
            // 
            this.btnLoadConfig.Location = new System.Drawing.Point(14, 50);
            this.btnLoadConfig.Name = "btnLoadConfig";
            this.btnLoadConfig.Size = new System.Drawing.Size(75, 23);
            this.btnLoadConfig.TabIndex = 20;
            this.btnLoadConfig.Text = "Load Config";
            this.btnLoadConfig.UseVisualStyleBackColor = true;
            this.btnLoadConfig.Click += new System.EventHandler(this.btnLoadConfig_Click);
            // 
            // txtFilename
            // 
            this.txtFilename.Location = new System.Drawing.Point(14, 24);
            this.txtFilename.Name = "txtFilename";
            this.txtFilename.ReadOnly = true;
            this.txtFilename.Size = new System.Drawing.Size(350, 20);
            this.txtFilename.TabIndex = 21;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(14, 8);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(52, 13);
            this.label8.TabIndex = 22;
            this.label8.Text = "Filename:";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog1_FileOk);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(212, 201);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(60, 23);
            this.button2.TabIndex = 23;
            this.button2.Text = "Remove Bind";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.txtKeyBind1);
            this.groupBox4.Controls.Add(this.btnCreateKey);
            this.groupBox4.Location = new System.Drawing.Point(212, 97);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(152, 89);
            this.groupBox4.TabIndex = 24;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Custom Binds";
            // 
            // trackBar1
            // 
            this.trackBar1.Location = new System.Drawing.Point(289, 201);
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(104, 45);
            this.trackBar1.TabIndex = 25;
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(402, 434);
            this.Controls.Add(this.trackBar1);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtFilename);
            this.Controls.Add(this.btnLoadConfig);
            this.Controls.Add(this.lblFilename);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.listBox1);
            this.Name = "Form2";
            this.Text = "Form2";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.TextBox textpowerA;
        private System.Windows.Forms.RadioButton radioforwardA;
        private System.Windows.Forms.RadioButton radioreverseA;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton radioreverseB;
        private System.Windows.Forms.RadioButton radioforwardB;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textpowerB;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RadioButton radioreverseC;
        private System.Windows.Forms.RadioButton radioforwardC;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textpowerC;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtKeyBind1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnCreateKey;
        private System.Windows.Forms.Label lblFilename;
        private System.Windows.Forms.Button btnLoadConfig;
        private System.Windows.Forms.TextBox txtFilename;
        private System.Windows.Forms.Label label8;
        public System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.TrackBar trackBar1;
    }
}