namespace _485_test
{
    partial class Form1
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置 Managed 資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.button1 = new System.Windows.Forms.Button();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.button2 = new System.Windows.Forms.Button();
            this.PortName = new System.Windows.Forms.ComboBox();
            this.SendData = new System.Windows.Forms.TextBox();
            this.RecallData = new System.Windows.Forms.TextBox();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.buttonCW = new System.Windows.Forms.Button();
            this.buttonCCW = new System.Windows.Forms.Button();
            this.motorOn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonStatus = new System.Windows.Forms.Button();
            this.motorOff = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.multiplierTextbox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.runTimebox = new System.Windows.Forms.TextBox();
            this.expTimebox = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.intervalBox = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.paraBox2 = new System.Windows.Forms.TextBox();
            this.paraBox1 = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.button10 = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.label16 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.trackBar3 = new System.Windows.Forms.TrackBar();
            this.trackBar2 = new System.Windows.Forms.TrackBar();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.buttonStRequest = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.button6 = new System.Windows.Forms.Button();
            this.encoderPort = new System.Windows.Forms.ComboBox();
            this.connectEncoder = new System.Windows.Forms.Button();
            this.disconnectEncoder = new System.Windows.Forms.Button();
            this.serialPort2 = new System.IO.Ports.SerialPort(this.components);
            this.Encoder_Timer = new System.Windows.Forms.Timer(this.components);
            this.encoderLabel = new System.Windows.Forms.Label();
            this.setZP = new System.Windows.Forms.Button();
            this.encoderTime = new System.Windows.Forms.Label();
            this.Status_Timer = new System.Windows.Forms.Timer(this.components);
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button1.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(128, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(119, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Serial Connect";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // serialPort1
            // 
            this.serialPort1.BaudRate = 115200;
            this.serialPort1.DtrEnable = true;
            this.serialPort1.PortName = "COM3";
            this.serialPort1.RtsEnable = true;
            // 
            // button2
            // 
            this.button2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button2.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(253, 41);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(91, 23);
            this.button2.TabIndex = 1;
            this.button2.Text = "Send";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // PortName
            // 
            this.PortName.FormattingEnabled = true;
            this.PortName.Location = new System.Drawing.Point(12, 12);
            this.PortName.Name = "PortName";
            this.PortName.Size = new System.Drawing.Size(110, 20);
            this.PortName.TabIndex = 2;
            this.PortName.SelectedIndexChanged += new System.EventHandler(this.PortName_SelectedIndexChanged);
            // 
            // SendData
            // 
            this.SendData.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.SendData.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SendData.ForeColor = System.Drawing.Color.Cyan;
            this.SendData.Location = new System.Drawing.Point(12, 42);
            this.SendData.Name = "SendData";
            this.SendData.Size = new System.Drawing.Size(235, 23);
            this.SendData.TabIndex = 3;
            this.SendData.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SendData_KeyDown);
            // 
            // RecallData
            // 
            this.RecallData.BackColor = System.Drawing.SystemColors.MenuText;
            this.RecallData.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RecallData.ForeColor = System.Drawing.Color.Lime;
            this.RecallData.Location = new System.Drawing.Point(12, 72);
            this.RecallData.Multiline = true;
            this.RecallData.Name = "RecallData";
            this.RecallData.ReadOnly = true;
            this.RecallData.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.RecallData.Size = new System.Drawing.Size(332, 437);
            this.RecallData.TabIndex = 4;
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.Firebrick;
            this.button3.FlatAppearance.BorderSize = 0;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button3.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.ForeColor = System.Drawing.Color.White;
            this.button3.Location = new System.Drawing.Point(27, 257);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(125, 33);
            this.button3.TabIndex = 5;
            this.button3.Text = "CLEAR CSV";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button4.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.button4.FlatAppearance.BorderSize = 0;
            this.button4.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button4.Location = new System.Drawing.Point(253, 12);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(91, 23);
            this.button4.TabIndex = 6;
            this.button4.Text = "Disconnect";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button5
            // 
            this.button5.BackColor = System.Drawing.Color.DarkGreen;
            this.button5.FlatAppearance.BorderSize = 0;
            this.button5.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button5.Font = new System.Drawing.Font("Consolas", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button5.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.button5.Location = new System.Drawing.Point(28, 218);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(124, 33);
            this.button5.TabIndex = 7;
            this.button5.Text = "START";
            this.button5.UseVisualStyleBackColor = false;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // buttonCW
            // 
            this.buttonCW.BackColor = System.Drawing.Color.Gold;
            this.buttonCW.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonCW.BackgroundImage")));
            this.buttonCW.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.buttonCW.FlatAppearance.BorderSize = 0;
            this.buttonCW.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonCW.ForeColor = System.Drawing.SystemColors.ControlText;
            this.buttonCW.Location = new System.Drawing.Point(97, 120);
            this.buttonCW.Name = "buttonCW";
            this.buttonCW.Size = new System.Drawing.Size(62, 61);
            this.buttonCW.TabIndex = 8;
            this.buttonCW.UseVisualStyleBackColor = false;
            this.buttonCW.Click += new System.EventHandler(this.buttonCW_Click);
            // 
            // buttonCCW
            // 
            this.buttonCCW.BackColor = System.Drawing.Color.Gold;
            this.buttonCCW.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonCCW.BackgroundImage")));
            this.buttonCCW.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.buttonCCW.FlatAppearance.BorderSize = 0;
            this.buttonCCW.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonCCW.Location = new System.Drawing.Point(97, 23);
            this.buttonCCW.Name = "buttonCCW";
            this.buttonCCW.Size = new System.Drawing.Size(62, 61);
            this.buttonCCW.TabIndex = 9;
            this.buttonCCW.UseVisualStyleBackColor = false;
            this.buttonCCW.Click += new System.EventHandler(this.buttonCCW_Click);
            // 
            // motorOn
            // 
            this.motorOn.BackColor = System.Drawing.Color.ForestGreen;
            this.motorOn.FlatAppearance.BorderSize = 0;
            this.motorOn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.motorOn.Font = new System.Drawing.Font("Consolas", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.motorOn.ForeColor = System.Drawing.Color.White;
            this.motorOn.Location = new System.Drawing.Point(24, 23);
            this.motorOn.Name = "motorOn";
            this.motorOn.Size = new System.Drawing.Size(56, 49);
            this.motorOn.TabIndex = 10;
            this.motorOn.Text = "ON";
            this.motorOn.UseVisualStyleBackColor = false;
            this.motorOn.Click += new System.EventHandler(this.motorOn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(31, 62);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 15);
            this.label1.TabIndex = 11;
            this.label1.Visible = false;
            // 
            // buttonStatus
            // 
            this.buttonStatus.BackColor = System.Drawing.Color.BurlyWood;
            this.buttonStatus.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonStatus.Location = new System.Drawing.Point(33, 39);
            this.buttonStatus.Name = "buttonStatus";
            this.buttonStatus.Size = new System.Drawing.Size(137, 22);
            this.buttonStatus.TabIndex = 12;
            this.buttonStatus.Text = "UPDATE STATUS";
            this.buttonStatus.UseVisualStyleBackColor = false;
            this.buttonStatus.Click += new System.EventHandler(this.buttonStatus_Click);
            // 
            // motorOff
            // 
            this.motorOff.BackColor = System.Drawing.Color.Red;
            this.motorOff.FlatAppearance.BorderSize = 0;
            this.motorOff.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.motorOff.Font = new System.Drawing.Font("Consolas", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.motorOff.ForeColor = System.Drawing.Color.Transparent;
            this.motorOff.Location = new System.Drawing.Point(24, 78);
            this.motorOff.Name = "motorOff";
            this.motorOff.Size = new System.Drawing.Size(56, 49);
            this.motorOff.TabIndex = 13;
            this.motorOff.Text = "OFF";
            this.motorOff.UseVisualStyleBackColor = false;
            this.motorOff.Click += new System.EventHandler(this.motorOff_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(142, 95);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(24, 18);
            this.label3.TabIndex = 16;
            this.label3.Text = "mm";
            // 
            // multiplierTextbox
            // 
            this.multiplierTextbox.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.multiplierTextbox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.multiplierTextbox.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.multiplierTextbox.ForeColor = System.Drawing.Color.Lime;
            this.multiplierTextbox.Location = new System.Drawing.Point(97, 91);
            this.multiplierTextbox.Name = "multiplierTextbox";
            this.multiplierTextbox.Size = new System.Drawing.Size(43, 19);
            this.multiplierTextbox.TabIndex = 17;
            this.multiplierTextbox.Text = "1";
            this.multiplierTextbox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(34, 23);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(105, 14);
            this.label4.TabIndex = 18;
            this.label4.Text = "1st Parameter:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(34, 67);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(105, 14);
            this.label5.TabIndex = 19;
            this.label5.Text = "2nd Parameter:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(12, 166);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(84, 14);
            this.label6.TabIndex = 20;
            this.label6.Text = "Run Times :";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(12, 194);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(84, 14);
            this.label7.TabIndex = 21;
            this.label7.Text = "Exp Times :";
            // 
            // runTimebox
            // 
            this.runTimebox.BackColor = System.Drawing.Color.Black;
            this.runTimebox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.runTimebox.ForeColor = System.Drawing.Color.Lime;
            this.runTimebox.Location = new System.Drawing.Point(97, 162);
            this.runTimebox.Name = "runTimebox";
            this.runTimebox.Size = new System.Drawing.Size(55, 19);
            this.runTimebox.TabIndex = 22;
            this.runTimebox.Text = "30";
            this.runTimebox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // expTimebox
            // 
            this.expTimebox.BackColor = System.Drawing.Color.Black;
            this.expTimebox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.expTimebox.ForeColor = System.Drawing.Color.Lime;
            this.expTimebox.Location = new System.Drawing.Point(97, 191);
            this.expTimebox.Name = "expTimebox";
            this.expTimebox.Size = new System.Drawing.Size(55, 19);
            this.expTimebox.TabIndex = 23;
            this.expTimebox.Text = "0";
            this.expTimebox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.SeaGreen;
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.intervalBox);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.paraBox2);
            this.groupBox1.Controls.Add(this.paraBox1);
            this.groupBox1.Controls.Add(this.button5);
            this.groupBox1.Controls.Add(this.expTimebox);
            this.groupBox1.Controls.Add(this.button3);
            this.groupBox1.Controls.Add(this.runTimebox);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Enabled = false;
            this.groupBox1.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.Gold;
            this.groupBox1.Location = new System.Drawing.Point(607, 204);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(177, 303);
            this.groupBox1.TabIndex = 24;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Test Mode";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(33, 112);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(105, 14);
            this.label12.TabIndex = 29;
            this.label12.Text = "Interval Time:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(129, 132);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(24, 18);
            this.label9.TabIndex = 28;
            this.label9.Text = "ms";
            // 
            // intervalBox
            // 
            this.intervalBox.BackColor = System.Drawing.Color.Black;
            this.intervalBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.intervalBox.ForeColor = System.Drawing.Color.Lime;
            this.intervalBox.Location = new System.Drawing.Point(33, 131);
            this.intervalBox.Name = "intervalBox";
            this.intervalBox.Size = new System.Drawing.Size(94, 19);
            this.intervalBox.TabIndex = 27;
            this.intervalBox.Text = "300";
            this.intervalBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(129, 89);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(24, 18);
            this.label8.TabIndex = 26;
            this.label8.Text = "mm";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(129, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(24, 18);
            this.label2.TabIndex = 18;
            this.label2.Text = "mm";
            // 
            // paraBox2
            // 
            this.paraBox2.BackColor = System.Drawing.Color.Black;
            this.paraBox2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.paraBox2.ForeColor = System.Drawing.Color.Lime;
            this.paraBox2.Location = new System.Drawing.Point(33, 87);
            this.paraBox2.Name = "paraBox2";
            this.paraBox2.Size = new System.Drawing.Size(94, 19);
            this.paraBox2.TabIndex = 25;
            this.paraBox2.Text = "0.5";
            this.paraBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // paraBox1
            // 
            this.paraBox1.BackColor = System.Drawing.Color.Black;
            this.paraBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.paraBox1.ForeColor = System.Drawing.Color.Lime;
            this.paraBox1.Location = new System.Drawing.Point(33, 41);
            this.paraBox1.Name = "paraBox1";
            this.paraBox1.Size = new System.Drawing.Size(94, 19);
            this.paraBox1.TabIndex = 24;
            this.paraBox1.Text = "-0.5";
            this.paraBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.PeachPuff;
            this.groupBox2.Controls.Add(this.label17);
            this.groupBox2.Controls.Add(this.button10);
            this.groupBox2.Controls.Add(this.button9);
            this.groupBox2.Controls.Add(this.button8);
            this.groupBox2.Controls.Add(this.button7);
            this.groupBox2.Controls.Add(this.label16);
            this.groupBox2.Controls.Add(this.label15);
            this.groupBox2.Controls.Add(this.trackBar3);
            this.groupBox2.Controls.Add(this.trackBar2);
            this.groupBox2.Controls.Add(this.trackBar1);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.buttonCW);
            this.groupBox2.Controls.Add(this.buttonCCW);
            this.groupBox2.Controls.Add(this.multiplierTextbox);
            this.groupBox2.Controls.Add(this.motorOn);
            this.groupBox2.Controls.Add(this.motorOff);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.groupBox2.Location = new System.Drawing.Point(350, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(434, 193);
            this.groupBox2.TabIndex = 25;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Motor Configuration";
            // 
            // button10
            // 
            this.button10.BackColor = System.Drawing.Color.RoyalBlue;
            this.button10.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button10.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button10.ForeColor = System.Drawing.Color.Transparent;
            this.button10.Location = new System.Drawing.Point(24, 133);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(56, 48);
            this.button10.TabIndex = 42;
            this.button10.Text = "HOME";
            this.button10.UseVisualStyleBackColor = false;
            this.button10.Click += new System.EventHandler(this.button10_Click);
            // 
            // button9
            // 
            this.button9.BackColor = System.Drawing.Color.Transparent;
            this.button9.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button9.BackgroundImage")));
            this.button9.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button9.FlatAppearance.BorderSize = 0;
            this.button9.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.button9.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Maroon;
            this.button9.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button9.Location = new System.Drawing.Point(300, 130);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(52, 48);
            this.button9.TabIndex = 41;
            this.button9.UseVisualStyleBackColor = false;
            this.button9.Click += new System.EventHandler(this.button9_Click);
            // 
            // button8
            // 
            this.button8.BackColor = System.Drawing.Color.Transparent;
            this.button8.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button8.BackgroundImage")));
            this.button8.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button8.FlatAppearance.BorderSize = 0;
            this.button8.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.button8.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Maroon;
            this.button8.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button8.Location = new System.Drawing.Point(300, 76);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(52, 48);
            this.button8.TabIndex = 40;
            this.button8.UseVisualStyleBackColor = false;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // button7
            // 
            this.button7.BackColor = System.Drawing.Color.Transparent;
            this.button7.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button7.BackgroundImage")));
            this.button7.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button7.FlatAppearance.BorderColor = System.Drawing.Color.Gold;
            this.button7.FlatAppearance.BorderSize = 0;
            this.button7.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.button7.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Maroon;
            this.button7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button7.Location = new System.Drawing.Point(300, 22);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(52, 50);
            this.button7.TabIndex = 39;
            this.button7.UseVisualStyleBackColor = false;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Consolas", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label16.Location = new System.Drawing.Point(364, 19);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(51, 28);
            this.label16.TabIndex = 38;
            this.label16.Text = "JOG";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label15.Location = new System.Drawing.Point(361, 161);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(56, 18);
            this.label15.TabIndex = 37;
            this.label15.Text = "VC:180";
            // 
            // trackBar3
            // 
            this.trackBar3.Cursor = System.Windows.Forms.Cursors.HSplit;
            this.trackBar3.Enabled = false;
            this.trackBar3.Location = new System.Drawing.Point(376, 41);
            this.trackBar3.Maximum = 254;
            this.trackBar3.Minimum = 2;
            this.trackBar3.Name = "trackBar3";
            this.trackBar3.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.trackBar3.Size = new System.Drawing.Size(45, 117);
            this.trackBar3.TabIndex = 36;
            this.trackBar3.Value = 180;
            this.trackBar3.Scroll += new System.EventHandler(this.trackBar3_Scroll);
            // 
            // trackBar2
            // 
            this.trackBar2.Cursor = System.Windows.Forms.Cursors.HSplit;
            this.trackBar2.Location = new System.Drawing.Point(244, 38);
            this.trackBar2.Maximum = 7;
            this.trackBar2.Name = "trackBar2";
            this.trackBar2.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.trackBar2.Size = new System.Drawing.Size(45, 121);
            this.trackBar2.TabIndex = 35;
            this.trackBar2.Scroll += new System.EventHandler(this.trackBar2_Scroll);
            // 
            // trackBar1
            // 
            this.trackBar1.Cursor = System.Windows.Forms.Cursors.HSplit;
            this.trackBar1.Location = new System.Drawing.Point(194, 38);
            this.trackBar1.Maximum = 254;
            this.trackBar1.Minimum = 2;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.trackBar1.Size = new System.Drawing.Size(45, 121);
            this.trackBar1.TabIndex = 34;
            this.trackBar1.Value = 2;
            this.trackBar1.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label11.Location = new System.Drawing.Point(235, 162);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(40, 18);
            this.label11.TabIndex = 33;
            this.label11.Text = "AC:0";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label10.Location = new System.Drawing.Point(182, 162);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(40, 18);
            this.label10.TabIndex = 32;
            this.label10.Text = "VC:2";
            // 
            // buttonStRequest
            // 
            this.buttonStRequest.BackColor = System.Drawing.Color.BurlyWood;
            this.buttonStRequest.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonStRequest.Location = new System.Drawing.Point(33, 14);
            this.buttonStRequest.Name = "buttonStRequest";
            this.buttonStRequest.Size = new System.Drawing.Size(137, 23);
            this.buttonStRequest.TabIndex = 26;
            this.buttonStRequest.Text = "Status Request";
            this.buttonStRequest.UseVisualStyleBackColor = false;
            this.buttonStRequest.Click += new System.EventHandler(this.buttonStRequest_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.Color.Salmon;
            this.groupBox3.Controls.Add(this.button6);
            this.groupBox3.Controls.Add(this.buttonStatus);
            this.groupBox3.Controls.Add(this.buttonStRequest);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.groupBox3.Location = new System.Drawing.Point(349, 204);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(260, 187);
            this.groupBox3.TabIndex = 27;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Motor Status";
            // 
            // button6
            // 
            this.button6.BackColor = System.Drawing.Color.BurlyWood;
            this.button6.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button6.Location = new System.Drawing.Point(175, 15);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(57, 46);
            this.button6.TabIndex = 27;
            this.button6.Text = "TIMER";
            this.button6.UseVisualStyleBackColor = false;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // encoderPort
            // 
            this.encoderPort.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.encoderPort.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.encoderPort.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.encoderPort.ForeColor = System.Drawing.Color.Lime;
            this.encoderPort.FormattingEnabled = true;
            this.encoderPort.Location = new System.Drawing.Point(178, 22);
            this.encoderPort.Name = "encoderPort";
            this.encoderPort.Size = new System.Drawing.Size(79, 22);
            this.encoderPort.TabIndex = 28;
            // 
            // connectEncoder
            // 
            this.connectEncoder.BackColor = System.Drawing.Color.Lime;
            this.connectEncoder.FlatAppearance.BorderSize = 0;
            this.connectEncoder.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.connectEncoder.ForeColor = System.Drawing.Color.Black;
            this.connectEncoder.Location = new System.Drawing.Point(14, 91);
            this.connectEncoder.Name = "connectEncoder";
            this.connectEncoder.Size = new System.Drawing.Size(65, 20);
            this.connectEncoder.TabIndex = 29;
            this.connectEncoder.Text = "Connect";
            this.connectEncoder.UseVisualStyleBackColor = false;
            this.connectEncoder.Click += new System.EventHandler(this.connectEncoder_Click);
            // 
            // disconnectEncoder
            // 
            this.disconnectEncoder.BackColor = System.Drawing.Color.Lime;
            this.disconnectEncoder.FlatAppearance.BorderSize = 0;
            this.disconnectEncoder.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.disconnectEncoder.ForeColor = System.Drawing.Color.Black;
            this.disconnectEncoder.Location = new System.Drawing.Point(87, 91);
            this.disconnectEncoder.Name = "disconnectEncoder";
            this.disconnectEncoder.Size = new System.Drawing.Size(85, 20);
            this.disconnectEncoder.TabIndex = 30;
            this.disconnectEncoder.Text = "Disconnect";
            this.disconnectEncoder.UseVisualStyleBackColor = false;
            this.disconnectEncoder.Click += new System.EventHandler(this.disconnectEncoder_Click);
            // 
            // serialPort2
            // 
            this.serialPort2.DtrEnable = true;
            this.serialPort2.PortName = "COM3";
            this.serialPort2.RtsEnable = true;
            // 
            // Encoder_Timer
            // 
            this.Encoder_Timer.Interval = 70;
            this.Encoder_Timer.Tick += new System.EventHandler(this.Encoder_Timer_Tick);
            // 
            // encoderLabel
            // 
            this.encoderLabel.AutoSize = true;
            this.encoderLabel.Font = new System.Drawing.Font("Consolas", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.encoderLabel.Location = new System.Drawing.Point(59, 15);
            this.encoderLabel.Name = "encoderLabel";
            this.encoderLabel.Size = new System.Drawing.Size(111, 34);
            this.encoderLabel.TabIndex = 31;
            this.encoderLabel.Text = "count ";
            // 
            // setZP
            // 
            this.setZP.BackColor = System.Drawing.Color.Lime;
            this.setZP.FlatAppearance.BorderSize = 0;
            this.setZP.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.setZP.ForeColor = System.Drawing.Color.Black;
            this.setZP.Location = new System.Drawing.Point(178, 91);
            this.setZP.Name = "setZP";
            this.setZP.Size = new System.Drawing.Size(76, 20);
            this.setZP.TabIndex = 32;
            this.setZP.Text = "Set ZP";
            this.setZP.UseVisualStyleBackColor = false;
            this.setZP.Click += new System.EventHandler(this.setZP_Click);
            // 
            // encoderTime
            // 
            this.encoderTime.AutoSize = true;
            this.encoderTime.Font = new System.Drawing.Font("Consolas", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.encoderTime.ForeColor = System.Drawing.Color.Lime;
            this.encoderTime.Location = new System.Drawing.Point(11, 51);
            this.encoderTime.Name = "encoderTime";
            this.encoderTime.Size = new System.Drawing.Size(79, 34);
            this.encoderTime.TabIndex = 33;
            this.encoderTime.Text = "time";
            // 
            // Status_Timer
            // 
            this.Status_Timer.Interval = 1;
            this.Status_Timer.Tick += new System.EventHandler(this.Status_Timer_Tick);
            // 
            // groupBox4
            // 
            this.groupBox4.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.groupBox4.Controls.Add(this.disconnectEncoder);
            this.groupBox4.Controls.Add(this.encoderTime);
            this.groupBox4.Controls.Add(this.encoderPort);
            this.groupBox4.Controls.Add(this.setZP);
            this.groupBox4.Controls.Add(this.connectEncoder);
            this.groupBox4.Controls.Add(this.label13);
            this.groupBox4.Controls.Add(this.label14);
            this.groupBox4.Controls.Add(this.encoderLabel);
            this.groupBox4.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox4.ForeColor = System.Drawing.Color.Lime;
            this.groupBox4.Location = new System.Drawing.Point(349, 385);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(260, 122);
            this.groupBox4.TabIndex = 34;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Encoder Configuration";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(3, 24);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(63, 19);
            this.label13.TabIndex = 34;
            this.label13.Text = "Count:";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Consolas", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.Color.Lime;
            this.label14.Location = new System.Drawing.Point(207, 51);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(47, 34);
            this.label14.TabIndex = 35;
            this.label14.Text = "μs";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label17.Location = new System.Drawing.Point(165, 22);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(126, 19);
            this.label17.TabIndex = 43;
            this.label17.Text = "Relative Move";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(788, 510);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.SendData);
            this.Controls.Add(this.PortName);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.RecallData);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Form1";
            this.Text = "Program";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ComboBox PortName;
        private System.Windows.Forms.TextBox SendData;
        private System.Windows.Forms.TextBox RecallData;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button buttonCW;
        private System.Windows.Forms.Button buttonCCW;
        private System.Windows.Forms.Button motorOn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonStatus;
        private System.Windows.Forms.Button motorOff;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox multiplierTextbox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox runTimebox;
        private System.Windows.Forms.TextBox expTimebox;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox paraBox2;
        private System.Windows.Forms.TextBox paraBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Button buttonStRequest;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ComboBox encoderPort;
        private System.Windows.Forms.Button connectEncoder;
        private System.Windows.Forms.Button disconnectEncoder;
        private System.IO.Ports.SerialPort serialPort2;
        private System.Windows.Forms.Timer Encoder_Timer;
        private System.Windows.Forms.Label encoderLabel;
        private System.Windows.Forms.Button setZP;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label encoderTime;
        private System.Windows.Forms.Timer Status_Timer;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.TextBox intervalBox;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TrackBar trackBar2;
        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TrackBar trackBar3;
        private System.Windows.Forms.Button button10;
        private System.Windows.Forms.Label label17;
    }
}

