using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Threading;
using System.Reflection;
using System.Globalization;
//***ivi
using Ivi.Dmm.Interop;
using Ivi.Visa.Interop;
using Ivi.Driver.Interop;
//***Excel
using Excel = Microsoft.Office.Interop.Excel;

namespace _485_test
{
    public partial class Form1 : Form
    {
        public class AutoControl
        {
            public double _start_output;//起使電流
            public double _end_output;//最大電流
            public double _step;//步進電流
            //public double _last_output;
            public double _current_output;//目前電流
            public double _elastic_force;
            public double _volt;
            public int _frist_wait_time;//持續時間
            public int _cooldownTime;//冷卻時間
            public string _format;
            public String _item;
            public String _nplc;
            public String _range;

            //Add new member
            public double _resistance;
            public string multimeter_mode;
        }

        //declaring global variables
        private string receiveData = "";
        private Thread eventThread;
        private int[] stepMotorStatus;
        private double record_initial_time;

        //***Power Supply
        private SerialPort port1 = new SerialPort();
        //***Force Sensor
        private SerialPort port2 = new SerialPort();
        //***???
        FormattedIO488Class ioDmm = null;
        FormattedIO488Class ioCurrentSrc = null;
        //***Power Supply Type
        //string PowerSrcType = "COM";
        //***Output Current
        private double outputAmpere = 0.0;
        private int waittime;
        public AutoControl auto = new AutoControl();
        public AutoControl monitor = new AutoControl();
        //***Output Data
        private DataTable tb = new DataTable();
        public AutoControl ctrl = new AutoControl();
        //***Running
        private bool isRunning;

        private bool isTimerRunning = false;

        public Form1()
        {
            InitializeComponent();
            //***initial DataGrid
            tb.Columns.Clear();
            for (int i = 0; i < dataGridView1.Columns.Count; i++)
            {
                tb.Columns.Add(new DataColumn(dataGridView1.Columns[i].DataPropertyName));
            }
            dataGridView1.DataSource = tb;           
            

            //***Initial COM Port  
            //port1.BaudRate = 9600;
            //port1.StopBits = StopBits.Two;
            //port1.Parity = Parity.None;
            //port1.DataBits = 8;
            //port2.BaudRate = 9600;
            //port2.StopBits = StopBits.Two;
            //port2.Parity = Parity.None;
            //port2.DataBits = 8;

            //AutoControl ctrl = (AutoControl)e.Argument;
            //***------------------------------------------------------------------
            //***Check Text Format & initial parameters
            ctrl._start_output = Convert.ToDouble(txtMinAmpere.Text);
            ctrl._frist_wait_time = Convert.ToInt32(txtTimeSpan.Text);
            ctrl._cooldownTime = Convert.ToInt32(txtCooldownTime.Text);
            ctrl._step = Convert.ToDouble(txtIncreAmpere.Text);
            ctrl._end_output = Convert.ToDouble(txtMaxAmpere.Text);

            ctrl._current_output = 0;
            ctrl._elastic_force = 0;
            

            if (txtMinAmpere.Text.Length == 4)
                ctrl._format = "{0:0.00}";
            else if (txtMinAmpere.Text.Length == 5)
                ctrl._format = "{0:0.000}";
            else
                ctrl._format = "{0:0.00}";


            //ctrl._current_output = 0;
            //SynchornizeText();

        }
        private void eventThreadMethod()
        {
            double firstPara = Convert.ToDouble(paraBox1.Text) * 6400;
            double secondPara = Convert.ToDouble(paraBox2.Text) * 6400;
            int runTimes = Convert.ToInt32(runTimebox.Text);
            int expTimes = Convert.ToInt32(expTimebox.Text);
            int sleepFactor = Convert.ToInt32(intervalBox.Text);
            double initial_time=0;

            serialPort1.WriteLine("EN 1\r");
            System.Threading.Thread.Sleep(500);
            int MF_bit = 0;

            
            for (int i = 0; i < runTimes; i++)
            {                
                lock (serialPort1) { serialPort1.WriteLine("MI " + firstPara.ToString() + "\r"); }
                
                delay(sleepFactor);

                lock (serialPort1) { serialPort1.WriteLine("MI " + secondPara.ToString() + "\r"); }
                     
                delay(sleepFactor);
            }

            recordTimer_Start();
            for (int i = 0; i < expTimes; i++)
            {
                serialPort1.WriteLine("MI " + firstPara.ToString() + "\r");
                //System.Threading.Thread.Sleep(sleepFactor);
                delay(sleepFactor);
                /* Data collecting function writes in here */

                /*Save data into csv format SAMPLE CODE*/

                //string strFilePath = @".\fdrexp.csv";
                //string strSeperator = ",";
                //StringBuilder sbOutput = new StringBuilder();

                //string[] output = { "0", "0", "0", "0", "0", "0", "0" };

                //DateTime localDate = DateTime.Now;
                //output[0] = localDate.ToString(new CultureInfo("en-US"));

                //if (i == 0)
                //{
                //    initial_time = Convert.ToDouble(encoderTime.Text);
                //    output[1] = "0";
                //}
                //else
                //{
                //    output[1] = ((Convert.ToDouble(encoderTime.Text) - initial_time) / 1e06).ToString();
                //}
                //output[2] = encoderLabel.Text;

                // Create and write the csv file if the file doesn't exist
                //sbOutput.AppendLine(string.Join(strSeperator, output));
                //try
                //{
                //    if (!File.Exists(strFilePath))
                //        File.WriteAllText(strFilePath, sbOutput.ToString());
                //    else
                //        File.AppendAllText(strFilePath, sbOutput.ToString());
                //}
                //catch
                //{
                //}
                /*-----------------------------------------*/

                serialPort1.WriteLine("MI " + secondPara.ToString() + "\r");
                //System.Threading.Thread.Sleep(sleepFactor);
                delay(sleepFactor);
            }
            recordTimer.Enabled = false;

            serialPort1.WriteLine("EN 0\r");
            System.Threading.Thread.Sleep(100);            
        }

        private void eventThreadMethod2()
        {
            double firstPara = Convert.ToDouble(intervalLength.Text) * 6400;
            double secondPara = Convert.ToDouble(totalLength.Text) * 6400;
            int runTimes = Convert.ToInt32(textBox5.Text);
            
            int sleepFactor = Convert.ToInt32(loopIntTime.Text);
            double initial_time = 0;

            serialPort1.WriteLine("EN 1\r");
            System.Threading.Thread.Sleep(500);
            int MF_bit = 0;

            //Leave the ground point
            serialPort1.WriteLine("MI " + (secondPara*0.1).ToString() + "\r");
            System.Threading.Thread.Sleep(sleepFactor);
            secondPara = secondPara * 1.1;

            for (int i = 0; i < runTimes; i++)
            {
                double tmp = 0;
                RecallData.AppendText("Run Time = " + i.ToString() + Environment.NewLine);
                while (tmp <= secondPara)
                {
                    string cmd = "MI -" + firstPara.ToString() + "\r";
                    lock (serialPort1) { serialPort1.WriteLine(cmd); }                    
                    System.Threading.Thread.Sleep(sleepFactor);

                    /* Data collecting function writes in here */
                    /*Save data into csv format SAMPLE CODE*/

                    string strFilePath = @".\runin.csv";
                    string strSeperator = ",";
                    StringBuilder sbOutput = new StringBuilder();

                    string[] output = { "0", "0", "0", "0", "0", "0", "0" };

                    DateTime localDate = DateTime.Now;
                    output[0] = localDate.ToString(new CultureInfo("en-US"));

                    if (tmp == 0)
                    {
                        initial_time = Convert.ToDouble(encoderTime.Text);
                        output[1] = "0";
                    }
                    else
                    {
                        output[1] = ((Convert.ToDouble(encoderTime.Text) - initial_time) / 1e06).ToString();
                    }
                    output[2] = encoderLabel.Text;

                    //***Read Load 
                    output[4] = String.Format("{0:0.0}", SendReadCmdToLoadcell());

                    output[5] = (Convert.ToDouble(this.readResFromMeter())).ToString();



                    // Create and write the csv file if the file doesn't exist
                    sbOutput.AppendLine(string.Join(strSeperator, output));
                    try
                    {
                        if (!File.Exists(strFilePath))
                            File.WriteAllText(strFilePath, sbOutput.ToString());
                        else
                            File.AppendAllText(strFilePath, sbOutput.ToString());
                    }
                    catch
                    {
                    }
                    /*-----------------------------------------*/

                    //SynchornizeText(output);

                    tmp += firstPara;
                }

                tmp = secondPara;
                while (tmp >= 0)
                {
                    string cmd = "MI " + firstPara.ToString() + "\r";
                    lock (serialPort1) { serialPort1.WriteLine(cmd); }
                    System.Threading.Thread.Sleep(sleepFactor);

                    /* Data collecting function writes in here */
                    /*Save data into csv format SAMPLE CODE*/

                    string strFilePath = @".\runin.csv";
                    string strSeperator = ",";
                    StringBuilder sbOutput = new StringBuilder();

                    string[] output = { "0", "0", "0", "0", "0", "0", "0" };

                    DateTime localDate = DateTime.Now;
                    output[0] = localDate.ToString(new CultureInfo("en-US"));
                    
                    output[1] = ((Convert.ToDouble(encoderTime.Text) - initial_time) / 1e06).ToString();
                    
                    output[2] = encoderLabel.Text;

                    //***Read Load 
                    output[4] = String.Format("{0:0.0}", SendReadCmdToLoadcell());

                    output[5] = (Convert.ToDouble(this.readResFromMeter())).ToString();



                    // Create and write the csv file if the file doesn't exist
                    sbOutput.AppendLine(string.Join(strSeperator, output));
                    try
                    {
                        if (!File.Exists(strFilePath))
                            File.WriteAllText(strFilePath, sbOutput.ToString());
                        else
                            File.AppendAllText(strFilePath, sbOutput.ToString());
                    }
                    catch
                    {
                    }
                    //To append more lines to the csv file

                    /*-----------------------------------------*/

                    //SynchornizeText(output);

                    tmp -= firstPara;
                }

            }

            serialPort1.WriteLine("EN 0\r");
            System.Threading.Thread.Sleep(100);
        }

        private void eventThreadMethod3()
        {
            
            sendMove2Motor(Convert.ToDouble(odValue.Text), 300);
            bool can_test_run = true;
            double fc = Convert.ToDouble(String.Format("{0:0.0}", SendReadCmdToLoadcell()));
            SetLabelText(initialForce, fc.ToString());
            SetLabelText(readOD, (Convert.ToDouble(encoderLabel.Text) / 1e04).ToString() + "mm");
            recordTimer_Start();

            if (checkBox1.Checked == true)
            {                
                double upper_limit = Convert.ToDouble(desireForce.Text) * (1 + Convert.ToDouble(errorPercentage.Text) * 0.01);
                double lower_limit = Convert.ToDouble(desireForce.Text) * (1 - Convert.ToDouble(errorPercentage.Text) * 0.01);
                if (fc <= upper_limit && fc >= lower_limit)
                    can_test_run = true;
                else
                {
                    can_test_run = false;
                    MessageBox.Show("Force not DESIRED!!");
                }
                    
            }

            if (can_test_run)
            {
                ctrl._start_output = Convert.ToDouble(initialCurrent.Text);
                ctrl._frist_wait_time = Convert.ToInt32(onTime.Text);
                ctrl._cooldownTime = Convert.ToInt32(coolDownTime.Text);
                ctrl._step = Convert.ToDouble(increCurrent.Text);
                ctrl._end_output = Convert.ToDouble(maxCurrent.Text);

                double current = ctrl._start_output;
                while (checkForce(current-ctrl._step) && current<=ctrl._end_output && recordTimer.Enabled==true)
                {
                    ctrl._current_output = current;
                    sendToPowerSupply(String.Format(ctrl._format, ctrl._current_output));
                    countDown(ctrl._frist_wait_time, "Output Current");//Wait for 2 minutes, record Timer continue running
                    if (ctrl._cooldownTime != 0)
                    {
                        ctrl._current_output = 0;
                        sendToPowerSupply(String.Format(ctrl._format, ctrl._current_output));
                        countDown(ctrl._cooldownTime, "Cooling ");
                    }                    
                    current += ctrl._step;
                }
                sendMove2Motor(-(Convert.ToDouble(odValue.Text))+Convert.ToDouble(returnLength.Text), 250);
            }

            recordTimer.Enabled = false;

        }

        private void countDown(int sec,string mes)
        {
            while (sec > 0)
            {
                //countDownLabel.Text = "Left time : " + sec.ToString() + " sec";
                SetLabelText(countDownLabel, mes +" leftover time : " + sec.ToString() + " sec");
                delay(1000);
                sec--;
            }
        }
        private bool checkForce(double current)
        {
            double fc = Convert.ToDouble(initialForce.Text);
            double cur_fc = Convert.ToDouble(String.Format("{0:0.0}", SendReadCmdToLoadcell()));
            double end_per = 1 - Convert.ToDouble(endConditionPer.Text)*0.01;
            double fail_per = 1 - Convert.ToDouble(failPercentage.Text) * 0.01;

            if (cur_fc < (fail_per * fc) && Convert.ToDouble(failCurrent.Text)==-1)
            {
                SetLabelText(failCurrent, current.ToString());              
            }

            if (cur_fc < end_per * fc)
                return true;
            else
                return true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!serialPort1.IsOpen)
            {
                serialPort1.PortName = PortName.SelectedItem.ToString();
                serialPort1.Open();
                if (serialPort1.IsOpen)
                {
                    serialPort1.DataReceived += new SerialDataReceivedEventHandler(serialPort1_DataReceived);
                    MessageBox.Show("serialPort is connect!! & Force listen to station 26");
                    buttonMode("online");
                    serialPort1.WriteLine("ST 26\r");
                    RecallData.Text = "";
                    connectEncoder.PerformClick();
                }
            }
            
        }
        delegate void Display(Byte[] buffer);

        void buttonMode(string mode)
        {
            bool b1Status = false;
            if (mode == "online")
            {
                b1Status = false;
                SendData.Enabled = !b1Status;
                SendData.Focus();
            }
            else if (mode == "offline")
            {
                b1Status = true;
                SendData.Enabled = !b1Status;
                button1.Focus();
            }

            List<Control> list = new List<Control>();

            GetAllControl(this, list);

            foreach (Control control in list)
            {
                if (control.GetType() == typeof(Button))
                {
                    Button tmp = (Button)control;
                    if (tmp.Name == "button1")
                    {
                        tmp.Enabled = b1Status;
                    }
                    else
                    {
                        tmp.Enabled = !b1Status;
                    }
                }
                //if (control.GetType() == typeof(GroupBox))
                //{
                //    ((GroupBox)control).Enabled = !b1Status;                    
                //}
                if (control.GetType() == typeof(TabControl))
                {
                    ((TabControl)control).Enabled = !b1Status;
                }
            }
        }

        private void GetAllControl(Control c, List<Control> list)
        {
            foreach (Control control in c.Controls)
            {
                list.Add(control);

                if (control.GetType() == typeof(Panel))
                    GetAllControl(control, list);
            }
        }
        void serialPort1_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {            
            readData();            
        }
        void readData() //Display on Text Box only
        {
            Byte[] buffer = new Byte[1024];
            Int32 length = 0;
            lock (serialPort1){ length = serialPort1.Read(buffer, 0, buffer.Length); }
            Array.Resize(ref buffer, length);
            //String data = serialPort1.ReadLine();

            Display d = new Display(DisplayText);
            this.Invoke(d, new Object[] { buffer }); //Modify objects outside the thread            
        }
             
        private void DisplayText(Byte[] buffer)
        {
            char[] tmp = new char[buffer.Length];
            for (int i = 0; i < buffer.Length; i++)
            {
                tmp[i] = Convert.ToChar(buffer[i]);
            }
            string buff = new string(tmp);
            RecallData.AppendText(buff);
            //RecallData.Text += buff;            
            receiveData = buff;
        }
        //使用ASCII字元集將位元組轉換為字元組(字串)
        private void button2_Click(object sender, EventArgs e)
        {
            string sss= SendData.Text;
            byte[] aaa = Encoding.UTF8.GetBytes(SendData.Text+"\r");
            //byte[] aaa2 = Encoding.UTF8.GetBytes(SendData.Text + "\r");            
            serialPort1.Write(aaa,0,aaa.Length);
            //serialPort1.WriteLine(SendData.Text + "\r");

            RecallData.AppendText(SendData.Text + Environment.NewLine); //AppendText will auto scroll to end
            //RecallData.Text += (SendData.Text + Environment.NewLine);
            SendData.Text = ""; //Clear send data           
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // 自動搜尋所有 COM port            
            InitComPort(PortName,0);
            InitComPort(encoderPort,2);
            InitComPort(PSport,1);
            InitComPort(FSport,3);

            stepMotorStatus = new int[] { 0, 0, 0, 0, 0, 0, 0, 0 };
            buttonMode("offline");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ///*Save data into csv format SAMPLE CODE*/
            //string strFilePath = @".\runin.csv";
            //string strFilePath2 = @".\fdrexp.csv";
            //string strSeperator = ",";
            //StringBuilder sbOutput = new StringBuilder();

            ///* Using saveFile Dialog to setup file path */
            ////saveFileDialog1.Filter = "CSV Files|*.csv|All Files|*.*";
            ////saveFileDialog1.Title = "Save an CSV File";
            ////saveFileDialog1.ShowDialog();

            ////// If the file name is not an empty string open it for saving.  
            ////if (saveFileDialog1.FileName != "")
            ////{
            ////    switch (saveFileDialog1.FilterIndex)
            ////    {
            ////        case 1:
            ////            strFilePath = saveFileDialog1.FileName;
            ////            break;

            ////        case 2:
            ////            strFilePath = saveFileDialog1.FileName;
            ////            break;
            ////    }
            ////}



            ////random data
            ///*int[][] inaOutput = new int[][]{
            //    new int[]{1000, 2000, 3000, 4000, 5000,6,7},
            //    new int[]{6000, 7000, 8000, 9000, 10000,6,7},
            //    new int[]{11000, 12000, 13000, 14000, 15000,6,7}
            //};
            ///*-------------------------*/

            //string[] colHeader = { "System time", "Test Time (sec)" , "Z Position (um)",
            //    "Over Drive (um)", "Force (gf)" , "Resistance (Ohm)" , "Real OD (um)"};

            //sbOutput.AppendLine(string.Join(strSeperator, colHeader));

            //// Create and write the csv file if the file doesn't exist
            //File.WriteAllText(strFilePath, sbOutput.ToString());
            //File.WriteAllText(strFilePath2, sbOutput.ToString());

            //RecallData.AppendText(strFilePath + " and " + strFilePath2 + " CLEARED " + Environment.NewLine);
            testGrid.Rows.Clear();
            testGrid.Refresh();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (serialPort1.IsOpen)
            {
                serialPort1.Close();
                if(!serialPort1.IsOpen)
                {
                    MessageBox.Show("serialPort is closed!!");
                    buttonMode("offline");
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            eventThread = new Thread(new ThreadStart(eventThreadMethod));
            ctrl.multimeter_mode ="resistance";
            eventThread.Start();
        }
        private byte[] BytesChange(string comm)
        {
            byte[] byteforcomm = Encoding.UTF8.GetBytes(comm);
            return byteforcomm;
        }

        private void PortName_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void SendData_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button2_Click(this, new EventArgs());
            }
        }        

        private async void buttonStatus_Click(object sender, EventArgs e)
        {
            label1.Visible = true;                      

            if (receiveData.IndexOf("\r") == 2 && receiveData.Substring(0, 2)!="ER") {
                string status = receiveData.Substring(0, 2);
                int s = Convert.ToInt32(status, 16); //Hex to dec
                string statusWord = "";
                string[] table ={ "MF_bit   (運動狀態)",
                                  "FAULT    (驅動警報)",
                                  "SVON     (致能狀態)",
                                  "DIR  (馬達運動方向)",
                                  "NL_trig(觸發負極限)",
                                  "PL_trig(觸發正極限)",
                                  "HOME (覆歸原點動作)",
                                  "DO_bit     (DO狀態)" };

                int hold = 1;
                for (int i = 0; i < 8; i++)
                {
                    if ((s & hold) == hold)
                    {
                        stepMotorStatus[i] = 1;
                        statusWord += (table[i] + " : " + "1\n");
                    }
                    else
                    {
                        stepMotorStatus[i] = 0;
                        statusWord += (table[i] + " : " + "0\n");
                    }
                        
                    hold = hold * 2;
                }
                label1.Text = statusWord;
            }            
        }

        private void motorOn_Click(object sender, EventArgs e)
        {
            byte[] aaa = Encoding.UTF8.GetBytes("EN 1\r");
            serialPort1.Write(aaa, 0, aaa.Length);
            RecallData.AppendText("EN 1\n");
        }

        private void motorOff_Click(object sender, EventArgs e)
        {
            byte[] aaa = Encoding.UTF8.GetBytes("EN 0\r");
            serialPort1.Write(aaa, 0, aaa.Length);
            RecallData.AppendText("EN 0\n");
        }

        private void buttonCCW_Click(object sender, EventArgs e)
        {
            //serialPort1.WriteLine("EN 1\r");
            //System.Threading.Thread.Sleep(100);
            double ans = Convert.ToDouble(multiplierTextbox.Text) * 6400;
            string cmd = "MI " + ans.ToString() + "\r";
            RecallData.AppendText(cmd + Environment.NewLine);
            serialPort1.WriteLine(cmd);
            //System.Threading.Thread.Sleep(1500);
            //serialPort1.WriteLine("EN 0\r");
        }

        private void buttonCW_Click(object sender, EventArgs e)
        {
            //serialPort1.WriteLine("EN 1\r");
            //System.Threading.Thread.Sleep(50);            
            double ans = Convert.ToDouble(multiplierTextbox.Text) * 6400;
            string cmd = "MI -" + ans.ToString() + "\r";
            RecallData.AppendText(cmd + Environment.NewLine);
            serialPort1.WriteLine(cmd);
            //System.Threading.Thread.Sleep(1500);
            //serialPort1.WriteLine("EN 0\r");
        }

        private void buttonStRequest_Click(object sender, EventArgs e)
        {
            string cmd = "RV 2\r";
            byte[] aaa = Encoding.UTF8.GetBytes(cmd);
            serialPort1.Write(aaa, 0, aaa.Length);
            RecallData.AppendText(cmd + Environment.NewLine);            
        }

        private void connectEncoder_Click(object sender, EventArgs e)
        {
            serialPort2.PortName = encoderPort.SelectedItem.ToString();
            if (!serialPort2.IsOpen)
            {
                serialPort2.Open();
            }
            if (serialPort2.IsOpen)
            {   
                Encoder_Timer.Start();
                serialPort2.DataReceived += new SerialDataReceivedEventHandler(EncoderDataReceivedHandler);
            }
            else
            {
                //Port.Text = "COM6 is close";
            }

            connectEncoder.Enabled = false;
            disconnectEncoder.Enabled = true;
        }

        private void Encoder_Timer_Tick(object sender, EventArgs e)
        {
            serialPort2.WriteLine("!");
        }

        private void EncoderDataReceivedHandler(object sender, SerialDataReceivedEventArgs e)
        {
            Byte[] buffer = new Byte[1024];
            Int32 length = 0;
            try
            {
                lock (serialPort2) { length = serialPort2.Read(buffer, 0, buffer.Length); }
            }
            catch { }
            
            double[] Encoder_Data = new double[100];
            string Str_Form_E201 = "";
            string aaa = System.Text.Encoding.Default.GetString(buffer);

            
            for (int i = 0; i < buffer.Length; i++)
            {
                if (System.Text.Encoding.Default.GetString(buffer, i, 1) == ":")
                {
                    Str_Form_E201 = System.Text.Encoding.Default.GetString(buffer, 0, i);
                    break;
                }
            }          

            try
            {

                Array.Resize(ref buffer, length);
                string text = "" + (Convert.ToDouble(Str_Form_E201.Replace("ERROR", "").Replace("\r", "")));
                string text2 = aaa;
                for (int i = 1; i <= 3; i++)
                {
                    text2 = text2.Substring(text2.IndexOf(":") + 1);
                }
                text2 = text2.Substring(1, text2.IndexOf("\r")-1);

                var chars = text.ToCharArray();
                SetText(text,text2);
            }
            catch { }
        }

        delegate void SetCallback(string text,string text2);
        private void SetText(string text, string text2)
        {
            try
            {
                if (this.encoderLabel.InvokeRequired)
                {
                    SetCallback d = new SetCallback(SetText);
                    this.Invoke(d, new object[] { text,text2 });
                }
                else
                {
                    this.encoderLabel.Text = text;
                    this.encoderTime.Text = text2;
                }

            }
            catch { }
        }

        private void setZP_Click(object sender, EventArgs e)
        {
            serialPort2.WriteLine("z");
        }

        private void disconnectEncoder_Click(object sender, EventArgs e)
        {
            if (serialPort2.IsOpen)
            {
                Encoder_Timer.Enabled = false;
                connectEncoder.Enabled = true;
                disconnectEncoder.Enabled = false;
                serialPort2.Close();
                if (!serialPort2.IsOpen)
                {
                    MessageBox.Show("Encoder Port is closed!!");                    
                }
            }
        }

        private void Status_Timer_Tick(object sender, EventArgs e)
        {
            buttonStRequest.PerformClick();
            buttonStatus.PerformClick();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Status_Timer.Enabled = !Status_Timer.Enabled;
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            label10.Text = "VC:" + trackBar1.Value.ToString();
            string cmd = "VA " + trackBar1.Value.ToString() + "\r";
            serialPort1.WriteLine(cmd);
            RecallData.AppendText(cmd + Environment.NewLine);
        }

        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            label11.Text = "AC:" + trackBar2.Value.ToString();
            string cmd = "AA " + trackBar2.Value.ToString() + "\r";
            serialPort1.WriteLine(cmd);
            RecallData.AppendText(cmd + Environment.NewLine);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            string cmd = "JP\r";
            serialPort1.WriteLine(cmd);
            RecallData.AppendText(cmd + Environment.NewLine);
            trackBar3.Enabled = true;
        }

        private void trackBar3_Scroll(object sender, EventArgs e)
        {
            label15.Text = "VC:" + trackBar3.Value.ToString();
            string cmd = "JC " + trackBar3.Value.ToString() + "\r";
            serialPort1.WriteLine(cmd);
            RecallData.AppendText(cmd + Environment.NewLine);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            string cmd = "JS\r";
            serialPort1.WriteLine(cmd);
            RecallData.AppendText(cmd + Environment.NewLine);
            trackBar3.Enabled = false;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            string cmd = "JN\r";
            serialPort1.WriteLine(cmd);
            RecallData.AppendText(cmd + Environment.NewLine);
            trackBar3.Enabled = true;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            string cmd = "HM\r";
            serialPort1.WriteLine(cmd);
            RecallData.AppendText(cmd + Environment.NewLine);
            trackBar3.Enabled = true;
        }

        private void InitComPort(ComboBox cbObj, int index)
        {
            //***-------------------
            String[] portList = SerialPort.GetPortNames();
            for (int i = 0; i < portList.Length; i++)
            {
                cbObj.Items.Add(portList[i]);
            }
            
            cbObj.SelectedIndex = index;
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            if (btnOpen.Text == "Close")
            {
                btnOpen.Text = "Open";
                serialPort3.Close(); // Power supply
                serialPort4.Close(); // Force sensor
                CloseMeter();
                if (timer1.Enabled) timer1.Enabled = false;
                return;
            }

            try
            {
                //***Power Supply COM Port initial
                if ((PSport.Text != "") && (PSport.Text != "Agilent B2912A"))
                {
                    serialPort3.PortName = PSport.Text;                   
                    serialPort3.Open();                    
                }
                //***Load Cell COM Port initial
                if (FSport.Text != "")
                {
                    serialPort4.PortName = FSport.Text;
                    serialPort4.Open();
                    serialPort4.DiscardInBuffer();       // RX
                    serialPort4.DiscardOutBuffer();      // TX
                    if (FSport.Text == "Transducer Tech")
                        serialPort4.WriteLine("*1A1\r"); // command mode
                }
                //***Picotest M3500A
                if (this.comboMeter.Text != "" && ConnectMeter())
                {
                    try
                    {
                        //ioDmm.WriteString("SYST:BEEP;:DISP:TEXT 'RD_TEST3'", true); //---commented by Artie
                        ioDmm.WriteString("SYST:BEEP", true);
                        //ioDmm.WriteString("DISP:WINDow1:TEXT CLear", true);
                        ioDmm.FlushRead();
                        ioDmm.FlushWrite(false);
                        ioDmm.WriteString("MEASure:RESistance?", true);
                        //ioDmm.WriteString("MEASure:CURRent:DC?", true);
                        //ioDmm.WriteString("DISP:TEXT ?", true); --command not work
                        //***
                        ioDmm.WriteString("MEAS:VOLT:DC? 1V", true);

                        this.txtCurrAmpere.Text = ioDmm.ReadString();
                    }
                    catch (SystemException ex)
                    {
                        MessageBox.Show("Open failed on " + comboMeter.Text + " " + ex.Source + "  " + ex.Message, "EZSample", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        ioDmm.IO = null;
                        // SetAccessForClosed();
                        return;
                    }
                    ioDmm.IO = null;
                }
                if (serialPort3.IsOpen || serialPort4.IsOpen)
                {
                    btnOpen.Text = "Close";
                    btnStart.Enabled = true;
                    btnStop.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //***Connect Picotest M3500A
        private bool ConnectMeter()
        {
            bool rs = false;
            try
            {
                if (ioDmm == null) ioDmm = new FormattedIO488Class();
                ResourceManager grm = new ResourceManager();
                //***Connect M3500A USB0::0x164e::0x0dad::TW00024291::0::INSTR
                if (comboMeter.Text == "Picotest M3500A")
                    ioDmm.IO = (IMessage)grm.Open("USB0::0x164e::0x0dad::TW00013629::0::INSTR", AccessMode.NO_LOCK, 2000, "");
                rs = true;
            }
            catch (Exception ex)
            {

            }
            return rs;
        }

        //***Close Picotest M3500A
        private bool CloseMeter()
        {
            bool rs = false;
            try
            {
                ioDmm.FlushRead();
                ioDmm.FlushRead();
                ioDmm.IO.Clear();
                ioDmm.IO.Close();
                ioDmm = null;
                rs = true;
            }
            catch (Exception ex)
            {

            }
            return rs;
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            /*
            //***確認Open鍵已開啟後，再確認Timer1是否有啟動，有則關掉後重啟；沒有則將其啟動；
            if (btnOpen.Text == "Close")
            {
                if (timer1.Enabled)
                {
                    timer1.Enabled = false;
                    timer1.Enabled = true;
                }
                else timer1.Enabled = true;
            }
            */
            //***啟動Tiumer1 
            //timer1.Enabled = true;

            //***------------------------------------------------
            //***Check Connecting is OK???
            if (serialPort3.IsOpen == false)
            {
                MessageBox.Show("請先連接Agilent E3633A");
                return;
            }
            if (serialPort4.IsOpen == false)
            {
                MessageBox.Show("請先連接Transducer Tech");
                return;
            }
            if (ConnectMeter() == false)
            {
                MessageBox.Show("無法偵測到 Multimeter!!!");
                return;
            }

            //***Botton Control
            btnStart.Enabled = false;
            btnStop.Enabled = true;

            //***------------------------------------------------------------------
            //***Check Text Format & initial parameters
            ctrl._start_output = Convert.ToDouble(txtMinAmpere.Text);
            ctrl._frist_wait_time = Convert.ToInt32(txtTimeSpan.Text);
            ctrl._cooldownTime = Convert.ToInt32(txtCooldownTime.Text);
            ctrl._step = Convert.ToDouble(txtIncreAmpere.Text);
            ctrl._end_output = Convert.ToDouble(txtMaxAmpere.Text);

            //***Clear DataGrid
            tb.Rows.Clear();
            //***initial Current 
            ctrl._current_output = 0;
            Monitor();
            //***Output Data to DataGrid
            SynchornizeText();
            //*** Running On
            isRunning = true;


            for (double i = ctrl._start_output; i < ctrl._end_output; i += ctrl._step)
            {

                //***for parameter into  auto._current_output
                ctrl._current_output = i;
                //auto._current_output = Convert.ToDouble(txtMinAmpere.Text);

                if (isRunning == false) break;
                //***---Step 1 Current On
                //***Output Current
                //auto._current_output = Convert.ToDouble(txtMinAmpere.Text);
                sendToPowerSupply(String.Format(ctrl._format, ctrl._current_output));

                if (isRunning == false) break;
                //***---Step 2 Holding Time
                //***Current On Holding Time (sec)
                waittime = ctrl._frist_wait_time;
                while (waittime > 0)
                {
                    waittime--;
                    //label17.Text = String.Format("等待倒數:{0}", waittime);
                    label17.Text = String.Format("通電倒數");
                    textBox1.Text = Convert.ToString(waittime);
                    Monitor();
                    delay(900);
                }

                //***Output Data to DataGrid
                SynchornizeText();

                if (isRunning == false) break;
                //***---Step 3 Current Off
                //***Output Current OFF
                ctrl._current_output = 0;
                sendToPowerSupply(String.Format(ctrl._format, ctrl._current_output));

                if (isRunning == false) break;
                //***---Step 4 Cooldown Time
                //***Current On Holding Time (sec)
                waittime = ctrl._cooldownTime;
                while (waittime > 0)
                {
                    waittime--;
                    label17.Text = String.Format("回溫倒數");
                    textBox1.Text = Convert.ToString(waittime);
                    Monitor();
                    delay(900);
                }

                //***Output Data to DataGrid
                SynchornizeText();
            }

            //***Botton Control
            btnStart.Enabled = true;
            btnStop.Enabled = false;
        }

        private void SynchornizeText()
        {
            DataRow row = null;            

            row = tb.NewRow();
            row[0] = DateTime.Now.ToString("HH:mm:ss");
            row[1] = String.Format(ctrl._format, ctrl._current_output);
            row[2] = String.Format(ctrl._format, monitor._volt);
            row[3] = String.Format(ctrl._format, monitor._volt / monitor._current_output);
            row[4] = String.Format(ctrl._format, monitor._elastic_force);
            tb.Rows.Add(row);
            testGrid.DataSource = tb;
        }

        private void SynchornizeText(string[] data, DataGridView dg)
        {
            
        }

        delegate void DGHandler(DataGridView dg, string[] data);
        private void SetDGData(DataGridView dg, string[] data)
        {
            try
            {
                if (dg.InvokeRequired)
                {
                    DGHandler ph = new DGHandler(SetDGData);
                    dg.Invoke(ph, dg, data);
                }
                else
                {
                    DataGridViewRow row = new DataGridViewRow();
                    row.CreateCells(dg);

                    for (int i = 0; i < data.Length; i++)
                        row.Cells[i].Value = data[i];

                    dg.Rows.Insert(dg.Rows.Count, row);
                    dg.FirstDisplayedScrollingRowIndex = dg.Rows.Count-10;
                }

            }
            catch { }
        }

        //***Monitor
        private void Monitor()
        {
            //***Monitor
            //***-------------------------------------------------------------------
            //***Read Load Cell
            monitor._elastic_force = SendReadCmdToLoadcell();
            //***Update UI(txtCurrEF.Text)
            txtCurrEF.Text = String.Format("{0:0.0}", monitor._elastic_force);
            
            //***Read Output Current
            monitor._current_output = ctrl._current_output;

            //***Update UI(txtCurrAmpere.Text)
            txtCurrAmpere.Text = String.Format("{0:0.000}", monitor._current_output);            
       
            //***Read Voltage From M3500A
            monitor._volt = Convert.ToDouble(this.readVoltFromMeter());
            //***Update UI(txtCurrAmpere.Text & txtResistant.Text)
            txtCurrVolt.Text = String.Format(ctrl._format, monitor._volt);
            
            //***Calculate Resistance
            monitor._resistance = Convert.ToDouble(this.readResFromMeter());
            //txtResistant.Text = String.Format(ctrl._format, monitor._volt / monitor._current_output);
            txtResistant.Text = monitor._resistance.ToString();
        }

        //***Time Delay
        private void delay(int delay_milliseconds)
        {
            DateTime time_before = DateTime.Now;
            while (((TimeSpan)(DateTime.Now - time_before)).TotalMilliseconds < delay_milliseconds)
            {
                Application.DoEvents();
            }
        }

        //***Output Current
        private void sendToPowerSupply(String dAmpare)
        {
            try
            {
                serialPort3.WriteLine(String.Format("CURR {0}", dAmpare));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //****Read Voltage From Multimeter
        private String readVoltFromMeter()
        {
            String rs = "0.0";
            double dNum = 0.0;
            try
            {
                //***Read nn From M3500A 
                ioDmm.WriteString("MEAS:VOLT:DC? 1V", true);
                dNum = (double)ioDmm.ReadNumber(IEEEASCIIType.ASCIIType_R8, true) * 1000;
            }
            catch (Exception e)
            {
                //***MessageBox.Show(e.Message);
            }
            rs = dNum.ToString();
            return rs;
        }

        //****Read resistance From Multimeter
        private String readResFromMeter()
        {
            String rs = "0.0";
            double dNum = 0.0;
            try
            {
                //***Read nn From M3500A 
                ioDmm.WriteString("MEASure:FRESistance? ", true);
                //delay(500);
                dNum = (double)ioDmm.ReadNumber(IEEEASCIIType.ASCIIType_R8, true) * 1000;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            rs = dNum.ToString();
            return rs;
        }

        private double SendReadCmdToLoadcell()
        {
            double current_value = 0.0;
            if (serialPort4.IsOpen)
            {
                serialPort4.WriteLine("*1B1\r");
                //System.Threading.Thread.Sleep(100);
                delay(100);
                string rs = serialPort4.ReadExisting().Trim();
                //double value = Convert.ToDouble(rs.Replace(".\r", ""));
                int i = rs.IndexOf("\r");
                if (i != -1)
                {
                    rs = rs.Substring(0, i);
                }
                double value = -1;
                try
                {
                    value = Convert.ToDouble(rs);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
                
                current_value = value;
            }
            return current_value;
        }

        private void button11_Click(object sender, EventArgs e)
        {
            //***Output Current OFF
            ctrl._current_output = 0;
            sendToPowerSupply(String.Format(ctrl._format, ctrl._current_output));
            Monitor();
            //CloseMeter();
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            //***Output Current OFF
            ctrl._current_output = 0;
            sendToPowerSupply(String.Format(ctrl._format, ctrl._current_output));
            //***Export Data
            if (!ExportDataGridview(dataGridView1, true))
                MessageBox.Show("資料表中没有數據，無法導出資料至Excel！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //***STOP Running
            isRunning = false;
            //***Timer1 Off
            if (timer1.Enabled) timer1.Enabled = false;
            //***Close Multimeter
            CloseMeter();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            if (!ExportDataGridview(dataGridView1, true))
                MessageBox.Show("資料表中没有數據，無法導出資料至Excel！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            //***Check Connecting is OK???
            if (port1.IsOpen == false)
            {
                MessageBox.Show("請先連接Agilent E3633A");
                return;
            }
            if (port2.IsOpen == false)
            {
                MessageBox.Show("請先連接Transducer Tech");
                return;
            }
            if (ConnectMeter() == false)
            {
                MessageBox.Show("無法偵測到 Multimeter!!!");
                return;
            }
            //***Botton Control
            btnStart.Enabled = false;
            btnStop.Enabled = true;

            //***------------------------------------------------------------------
            //***Check Text Format & initial parameters
            ctrl._start_output = Convert.ToDouble(txtMinAmpere.Text);
            ctrl._frist_wait_time = Convert.ToInt32(txtTimeSpan.Text);
            ctrl._cooldownTime = Convert.ToInt32(txtCooldownTime.Text);
            ctrl._step = Convert.ToDouble(txtIncreAmpere.Text);
            ctrl._end_output = Convert.ToDouble(txtMaxAmpere.Text);

            //***-------------------------------------------------------------------
            //***Read Load Cell
            ctrl._elastic_force = SendReadCmdToLoadcell();
            //***Update UI(txtCurrEF.Text)
            txtCurrEF.Text = String.Format("{0:0.0}", ctrl._elastic_force);
            //***-------------------------------------------------------------------
            //***Output Current
            ctrl._current_output = Convert.ToDouble(txtMinAmpere.Text);
            sendToPowerSupply(String.Format(ctrl._format, ctrl._current_output));
            //***Update UI(txtCurrAmpere.Text)
            txtCurrAmpere.Text = String.Format("{0:0.000}", ctrl._current_output);

            //***Current On Holding Time (sec)
            waittime = ctrl._frist_wait_time;
            while (waittime > 0)
            {
                waittime--;
                //UpdateUI4();
                label17.Text = String.Format("等待倒數:{0}", waittime);
                //System.Threading.Thread.Sleep(1000);
                delay(1000);
            }
            //***Read Voltage From M3500A
            ctrl._volt = Convert.ToDouble(this.readVoltFromMeter());
            //***Update UI(txtCurrAmpere.Text & txtResistant.Text)
            txtCurrVolt.Text = String.Format(ctrl._format, ctrl._volt);
            txtResistant.Text = String.Format(ctrl._format, ctrl._volt / ctrl._current_output);

            //***Output Current OFF
            ctrl._current_output = 0;
            sendToPowerSupply(String.Format(ctrl._format, ctrl._current_output));
            //***Update UI(txtCurrAmpere.Text)
            txtCurrAmpere.Text = String.Format("{0:0.000}", ctrl._current_output);

            //***Botton Control
            btnStart.Enabled = true;
            btnStop.Enabled = false;
        }

        private void btnTimer1On_Click(object sender, EventArgs e)
        {
            //***若已啟動，關閉Timer1
            if (timer1.Enabled) timer1.Enabled = false;

            //***Check Connecting is OK???
            if (serialPort3.IsOpen == false)
            {
                MessageBox.Show("請先連接Agilent E3633A");
                timer1.Enabled = false;
                return;
            }
            if (serialPort4.IsOpen == false)
            {
                MessageBox.Show("請先連接Transducer Tech");
                timer1.Enabled = false;
                return;
            }
            if (ConnectMeter() == false)
            {
                MessageBox.Show("無法偵測到 Multimeter!!!");
                return;
            }
            //***Timer1 On 
            timer1.Interval = 500;
            timer1.Enabled = true;
        }

        private void btnTimer1Off_Click(object sender, EventArgs e)
        {
            if (timer1.Enabled) timer1.Enabled = false;
        }

        public bool ExportDataGridview(DataGridView gridView, bool isShowExcel)
        {
            if (gridView.Rows.Count == 0)
                return false;
            //建立Excel对象
            Excel.Application excel = new Excel.Application();
            excel.Application.Workbooks.Add(true);
            excel.Visible = isShowExcel;
            //生成字段名称
            for (int i = 0; i < gridView.ColumnCount; i++)
            {
                excel.Cells[1, i + 1] = gridView.Columns[i].HeaderText;
            }
            //填充数据
            for (int i = 0; i < gridView.RowCount; i++)
            {
                for (int j = 0; j < gridView.ColumnCount; j++)
                {
                    if (gridView[j, i].ValueType == typeof(string))
                    {
                        try
                        {
                            excel.Cells[i + 2, j + 1] = gridView[j, i].Value.ToString();
                        }
                        catch (Exception e)
                        {
                            //***MessageBox.Show(e.Message);
                        }
                    }
                    else
                    {
                        try
                        {
                            excel.Cells[i + 2, j + 1] = gridView[j, i].Value.ToString();
                        }
                        catch (Exception e)
                        {
                            //***MessageBox.Show(e.Message);
                        }
                    }
                }
            }
            return true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (isTimerRunning)
                return;

            isTimerRunning = true;
            //***-------------------------------------------------------------------
            //***Read Load Cell
            //monitor._elastic_force = SendReadCmdToLoadcell();
            ////***Update UI(txtCurrEF.Text)
            //txtCurrEF.Text = String.Format("{0:0.0}", monitor._elastic_force);
            ////***-------------------------------------------------------------------
            ////***Read Output Current
            //ctrl._current_output = -1;
            //monitor._current_output = ctrl._current_output;
            ////***Update UI(txtCurrAmpere.Text)
            //txtCurrAmpere.Text = String.Format("{0:0.000}", monitor._current_output);
            ////***-------------------------------------------------------------------
            ////***Read Volt From M3500A
            //monitor._volt = Convert.ToDouble(this.readVoltFromMeter());
            ////***Update UI(txtCurrAmpere.Text & txtResistant.Text)
            //txtCurrVolt.Text = String.Format(ctrl._format, monitor._volt);
            //// txtCurrVolt.Update();
            ////***-------------------------------------------------------------------
            //string tmp = this.readResFromMeter();
            //monitor._resistance = Convert.ToDouble(tmp);
            ////txtResistant.Text = String.Format(ctrl._format, monitor._volt / monitor._current_output);
            //txtResistant.Text = monitor._resistance.ToString();
            Monitor();

            isTimerRunning = false;
        }

        private void button13_Click(object sender, EventArgs e)
        {
            //***Check Connecting is OK???
            if (serialPort3.IsOpen == false)
            {
                MessageBox.Show("請先連接Agilent E3633A");
                timer1.Enabled = false;
                return;
            }
            if (serialPort4.IsOpen == false)
            {
                MessageBox.Show("請先連接Transducer Tech");
                timer1.Enabled = false;
                return;
            }
            if (ConnectMeter() == false)
            {
                MessageBox.Show("無法偵測到 Multimeter!!!");
                return;
            }
            eventThread = new Thread(new ThreadStart(eventThreadMethod2));
            eventThread.Start();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            testGrid.Rows.Clear();
            testGrid.Refresh();
            //
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                forceBox.Enabled = true;
            }
            else {
                forceBox.Enabled = false;
            }
        }

        private void button15_Click(object sender, EventArgs e)
        {
            //***Check Connecting is OK???
            if (serialPort3.IsOpen == false)
            {
                MessageBox.Show("請先連接Agilent E3633A");
                timer1.Enabled = false;
                return;
            }
            if (serialPort4.IsOpen == false)
            {
                MessageBox.Show("請先連接Transducer Tech");
                timer1.Enabled = false;
                return;
            }
            if (ConnectMeter() == false)
            {
                MessageBox.Show("無法偵測到 Multimeter!!!");
                return;
            }
            ctrl.multimeter_mode = "voltage";
            eventThread = new Thread(new ThreadStart(eventThreadMethod3));
            eventThread.Start();
        }

        private void sendMove2Motor(double displacement, int sp)
        {
            string cmd = "MI " + (displacement*6400).ToString() + "\r"; //displacement unit is mm
            serialPort1.WriteLine(cmd);
            //RecallData.AppendText(cmd + Environment.NewLine);
            SetTextBoxText(RecallData, cmd + Environment.NewLine);
            delay(sp);
        }

        delegate void PrintHandler(TextBox t, string text);
        private void SetTextBoxText(TextBox t, string text)
        {
            try
            {
                if (t.InvokeRequired)
                {
                    PrintHandler ph = new PrintHandler(SetTextBoxText);
                    t.Invoke(ph, t, text);
                }
                else
                {
                    t.Text = text;
                }

            }
            catch { }
        }
        delegate void LabelHandler(Label t, string text);
        private void SetLabelText(Label t, string text)
        {
            try
            {
                if (t.InvokeRequired)
                {
                    LabelHandler ph = new LabelHandler(SetLabelText);
                    t.Invoke(ph, t, text);
                }
                else
                {
                    t.Text = text;
                }

            }
            catch { }
        }
        private void recordTimer_Start()
        {
            record_initial_time = Convert.ToDouble(encoderTime.Text);
            recordTimer.Enabled = true;
        }
        private void recordTimer_Tick(object sender, EventArgs e)
        {
            string[] output = { "0", "0", "0", "0", "0", "0" };
            
            DateTime localDate = DateTime.Now;
            output[0] = localDate.ToString(new CultureInfo("en-US"));

            output[1] = ((Convert.ToDouble(encoderTime.Text) - record_initial_time) / 1e06).ToString();
            
            //Z Position
            output[2] = encoderLabel.Text;

            //***Read Load 
            output[3] = String.Format("{0:0.0}", SendReadCmdToLoadcell());

            //Calculate resistance
            if(ctrl.multimeter_mode == "resistance")
                output[4] = (Convert.ToDouble(this.readResFromMeter())).ToString();
            else if(ctrl.multimeter_mode == "voltage")
                output[4] = (Convert.ToDouble(this.readVoltFromMeter())/ctrl._current_output).ToString();
            

            output[5] = ctrl._current_output.ToString();

            //SynchornizeText(output, testGrid);
            SetDGData(testGrid, output);
        }

        private void button16_Click(object sender, EventArgs e)
        {
            if (!ExportDataGridview(testGrid, true))
                MessageBox.Show("資料表中没有數據，無法導出資料至Excel！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button17_Click(object sender, EventArgs e)
        {
            ctrl._current_output = 0;
            sendToPowerSupply(String.Format(ctrl._format, ctrl._current_output));
            sendMove2Motor(-(Convert.ToDouble(odValue.Text)) + Convert.ToDouble(returnLength.Text), 250);
            recordTimer.Enabled = false;
            eventThread.Abort();
        }
    }
}
