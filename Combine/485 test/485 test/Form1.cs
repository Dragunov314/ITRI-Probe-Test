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

namespace _485_test
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();            
        }
        //declaring global variables
        private string receiveData="";
        private Thread eventThread;
        private int[] stepMotorStatus;

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

                System.Threading.Thread.Sleep(sleepFactor);                

                /* Data collecting function writes in here */
                /*Save data into csv format SAMPLE CODE*/

                string strFilePath = @".\runin.csv";
                string strSeperator = ",";
                StringBuilder sbOutput = new StringBuilder();
                
                string[] output = { "0", "0", "0", "0", "0", "0", "0" };

                DateTime localDate = DateTime.Now;
                output[0] = localDate.ToString(new CultureInfo("en-US"));
                
                if (i == 0)
                {
                    initial_time = Convert.ToDouble(encoderTime.Text);
                    output[1] = "0";
                }
                else
                {
                    output[1] = ((Convert.ToDouble(encoderTime.Text) - initial_time)/1e06).ToString();
                }                
                output[2] = encoderLabel.Text;
                
                sbOutput.AppendLine(string.Join(strSeperator, output));

                // Create and write the csv file if the file doesn't exist
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

                lock (serialPort1) { serialPort1.WriteLine("MI " + secondPara.ToString() + "\r"); } 

                System.Threading.Thread.Sleep(sleepFactor);                
            }

            for (int i = 0; i < expTimes; i++)
            {
                serialPort1.WriteLine("MI " + firstPara.ToString() + "\r");
                System.Threading.Thread.Sleep(sleepFactor);

                /* Data collecting function writes in here */

                /*Save data into csv format SAMPLE CODE*/

                string strFilePath = @".\fdrexp.csv";
                string strSeperator = ",";
                StringBuilder sbOutput = new StringBuilder();

                string[] output = { "0", "0", "0", "0", "0", "0", "0" };

                DateTime localDate = DateTime.Now;
                output[0] = localDate.ToString(new CultureInfo("en-US"));

                if (i == 0)
                {
                    initial_time = Convert.ToDouble(encoderTime.Text);
                    output[1] = "0";
                }
                else
                {
                    output[1] = ((Convert.ToDouble(encoderTime.Text) - initial_time) / 1e06).ToString();
                }
                output[2] = encoderLabel.Text;

                sbOutput.AppendLine(string.Join(strSeperator, output));

                // Create and write the csv file if the file doesn't exist
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

                serialPort1.WriteLine("MI " + secondPara.ToString() + "\r");
                System.Threading.Thread.Sleep(sleepFactor);
            }

            serialPort1.WriteLine("EN 0\r");
            System.Threading.Thread.Sleep(100);            
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
                if (control.GetType() == typeof(GroupBox))
                {
                    ((GroupBox)control).Enabled = !b1Status;                    
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
            string[] serialPorts = SerialPort.GetPortNames();

            foreach (string serialPort in serialPorts)
            {
                PortName.Items.Add(serialPort);
                if (PortName.Items.Count > 0)
                {
                    PortName.SelectedIndex = 0;
                }

                encoderPort.Items.Add(serialPort);
                if (encoderPort.Items.Count > 1)
                {
                    encoderPort.SelectedIndex = 1;
                }
            }

            stepMotorStatus = new int[] { 0, 0, 0, 0, 0, 0, 0, 0 };
            buttonMode("offline");
            Thread.CurrentThread.Name = "MainThread";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            /*Save data into csv format SAMPLE CODE*/
            string strFilePath = @".\runin.csv";
            string strFilePath2 = @".\fdrexp.csv";
            string strSeperator = ",";
            StringBuilder sbOutput = new StringBuilder();

            /* Using saveFile Dialog to setup file path */
            //saveFileDialog1.Filter = "CSV Files|*.csv|All Files|*.*";
            //saveFileDialog1.Title = "Save an CSV File";
            //saveFileDialog1.ShowDialog();

            //// If the file name is not an empty string open it for saving.  
            //if (saveFileDialog1.FileName != "")
            //{
            //    switch (saveFileDialog1.FilterIndex)
            //    {
            //        case 1:
            //            strFilePath = saveFileDialog1.FileName;
            //            break;

            //        case 2:
            //            strFilePath = saveFileDialog1.FileName;
            //            break;
            //    }
            //}



            //random data
            /*int[][] inaOutput = new int[][]{
                new int[]{1000, 2000, 3000, 4000, 5000,6,7},
                new int[]{6000, 7000, 8000, 9000, 10000,6,7},
                new int[]{11000, 12000, 13000, 14000, 15000,6,7}
            };
            /*-------------------------*/

            string[] colHeader = { "System time", "Test Time (sec)" , "Z Position (um)",
                "Over Drive (um)", "Force (gf)" , "Resistance (Ohm)" , "Real OD (um)"};

            //int ilength = inaOutput.GetLength(0);            
            sbOutput.AppendLine(string.Join(strSeperator, colHeader));
            //for (int i = 0; i < ilength; i++)
            //    sbOutput.AppendLine(string.Join(strSeperator, inaOutput[i]));

            // Create and write the csv file if the file doesn't exist
            File.WriteAllText(strFilePath, sbOutput.ToString());
            File.WriteAllText(strFilePath2, sbOutput.ToString());

            RecallData.AppendText(strFilePath + " and " + strFilePath2 + " CLEARED " + Environment.NewLine);
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
    }
}
