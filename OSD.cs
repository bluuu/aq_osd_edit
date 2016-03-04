using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.IO.Ports;
using System.IO;
using ArdupilotMega;
using System.Xml;
using System.Globalization;
using System.Diagnostics;

namespace OSD
{
    public partial class OSD : Form
    {
        //max 7456 datasheet pg 10
        //pal  = 16r 30 char
        //ntsc = 13r 30 char
        Int16 panel_number = 0;
        const Int16 npanel = 2;
        const Int16 toggle_offset = 3;
        Size basesize = new Size(30, 16);
        /// <summary>
        /// the un-scaled font render image
        /// </summary>
        //Bitmap[] screen = new Bitmap[npanel];

        Bitmap[] screen = new Bitmap[npanel];
        //Bitmap screen2 = new Bitmap(30 * 12, 16 * 18);
        /// <summary>
        /// the scaled to size background control
        /// </summary>
        Bitmap image = new Bitmap(30 * 12, 16 * 18);
        /// <summary>
        /// Bitmaps of all the chars created from the mcm
        /// </summary>
        Bitmap[] chars;
        /// <summary>
        /// record of what panel is using what squares
        /// </summary>
        string[][] usedPostion = new string[30][];
        /// <summary>
        /// used to track currently selected panel across calls
        /// </summary>
        string[] currentlyselected = new string[npanel];
        /// <summary>
        /// used to track current processing panel across calls (because i maintained the original code for panel drawing)
        /// </summary>
        string processingpanel = "";
        /// <summary>
        /// use to draw the red outline box is currentlyselected matchs
        /// </summary>
        bool selectedrectangle = false;
        /// <summary>
        /// use to as a invalidator
        /// </summary>
        bool startup = false;
        /// <summary>
        /// 328 eeprom memory
        /// </summary>
        byte[] eeprom = new byte[1024];
        /// <summary>
        /// background image
        /// </summary>
        Image bgpicture;

        bool[] mousedown = new bool[npanel];
        //bool mousedown1 = false;
        //bool mousedown2 = false;

        string programmer;

        SerialPort comPort = new SerialPort();

        Panels pan;
        int nosdfunctions=0;
        Tuple<string, Func<int, int, int>, int, int, int, int, int>[] panelItems = new Tuple<string, Func<int, int, int>, int, int, int, int, int>[32];
        Tuple<string, Func<int, int, int>, int, int, int, int, int>[] panelItems_default = new Tuple<string, Func<int, int, int>, int, int, int, int, int>[32];
        Tuple<string, Func<int, int, int>, int, int, int, int, int>[] panelItems2 = new Tuple<string, Func<int, int, int>, int, int, int, int, int>[32];
        Tuple<string, Func<int, int, int>, int, int, int, int, int>[] panelItems2_default = new Tuple<string, Func<int, int, int>, int, int, int, int, int>[32];

        Graphics[] gr = new Graphics[npanel];
        //Graphics gr2;
        // in pixels
        int[] x = new int[npanel];
        int[] y = new int[npanel];
        //int x2 = 0, y2 = 0;

        public OSD()
        {
            InitializeComponent();

            // load default font
            chars = mcm.readMCM("aq_charset_v1.mcm");
            // load default bg picture
            try
            {
                bgpicture = Image.FromFile("vlcsnap-2012-01-28-07h46m04s95.png");
            }
            catch { }
            for(int i = 0; i < npanel;i++) {
                screen[i] = new Bitmap(30 * 12, 16 * 18);
                gr[i] = Graphics.FromImage(screen[i]);
                mousedown[i] = false;
                x[i] = 0;
                y[i] = 0;
                currentlyselected[i] = "";
            }

            pan = new Panels(this);

            // setup all panel options
            setupFunctions(); //setup panel item box
        }

        void changeToPal(bool pal)
        {
            if (pal)
            {
                basesize = new Size(30, 16);
                for(int i = 0; i < npanel;i++){
                    screen[i] = new Bitmap(30 * 12, 16 * 18);
                }
                image = new Bitmap(30 * 12, 16 * 18);

                NUM_X.Maximum = 29;
                NUM_Y.Maximum = 15;
            }
            else
            {
                basesize = new Size(30, 13);
                for (int i = 0; i < npanel; i++)
                {
                    screen[i] = new Bitmap(30 * 12, 13 * 18);
                }
                image = new Bitmap(30 * 12, 13 * 18);

                NUM_X.Maximum = 29;
                NUM_Y.Maximum = 15;
            }

            
        }
        //Set item boxes
        void setupFunctions()
        {
            //currentlyselected1 = "";
            //currentlyselected2 = "";
            processingpanel = "";


            int a = 0;

            for (a = 0; a < usedPostion.Length; a++)
            {
                usedPostion[a] = new string[16];
            }

            a = 0;

            // Display name,printfunction,X,Y,ENaddress,Xaddress,Yaddress
            panelItems[a++] = new Tuple<string, Func<int, int, int>, int, int, int, int, int>("Battery", pan.panBatt_A, 0, 0, panBatt_A_en_ADDR, panBatt_A_x_ADDR, panBatt_A_y_ADDR);
            panelItems[a++] = new Tuple<string, Func<int, int, int>, int, int, int, int, int>("Video voltage", pan.vidVol, 0, 1, vidVol_en_ADDR, vidVol_x_ADDR, vidVol_y_ADDR);
            panelItems[a++] = new Tuple<string, Func<int, int, int>, int, int, int, int, int>("GPS", pan.panGPS, 15, 0, panGPS_en_ADDR, panGPS_x_ADDR, panGPS_y_ADDR);
            panelItems[a++] = new Tuple<string, Func<int, int, int>, int, int, int, int, int>("Home Distance", pan.panHomeDis, 0, 14, panHomeDis_en_ADDR, panHomeDis_x_ADDR, panHomeDis_y_ADDR);
            panelItems[a++] = new Tuple<string, Func<int, int, int>, int, int, int, int, int>("Altitude", pan.panAlt, 0, 2, panAlt_en_ADDR, panAlt_x_ADDR, panAlt_y_ADDR);
            panelItems[a++] = new Tuple<string, Func<int, int, int>, int, int, int, int, int>("Home Altitude", pan.panHomeAlt, 0, 3, panHomeAlt_en_ADDR, panHomeAlt_x_ADDR, panHomeAlt_y_ADDR);
            panelItems[a++] = new Tuple<string, Func<int, int, int>, int, int, int, int, int>("Velocity", pan.panVel, 24, 13, panVel_en_ADDR, panVel_x_ADDR, panVel_y_ADDR);
            panelItems[a++] = new Tuple<string, Func<int, int, int>, int, int, int, int, int>("Flight Mode", pan.panFlightMode, 0, 15, panFMod_en_ADDR, panFMod_x_ADDR, panFMod_y_ADDR);
            panelItems[a++] = new Tuple<string, Func<int, int, int>, int, int, int, int, int>("Horizon", pan.panHorizon, 8, 4, panHorizon_en_ADDR, panHorizon_x_ADDR, panHorizon_y_ADDR);
            panelItems[a++] = new Tuple<string, Func<int, int, int>, int, int, int, int, int>("Time", pan.panTime, 24, 14, panTime_en_ADDR, panTime_x_ADDR, panTime_y_ADDR);
            panelItems[a++] = new Tuple<string, Func<int, int, int>, int, int, int, int, int>("Clock", pan.panClock, 24, 15, panClock_en_ADDR, panClock_x_ADDR, panClock_y_ADDR);
            panelItems[a++] = new Tuple<string, Func<int, int, int>, int, int, int, int, int>("RSSI", pan.panRSSI, 0, 13, panRSSI_en_ADDR, panRSSI_x_ADDR, panRSSI_y_ADDR);

            nosdfunctions = a;
            //make backup in case EEPROM needs reset to deualt
            panelItems_default = panelItems;

            //Fill List of items in tabe number 1
            LIST_items.Items.Clear();

            startup = true;
            foreach (var thing in panelItems)
            {
                if (thing != null)
                {
                  LIST_items.Items.Add(thing.Item1, true);
                }
            }

            startup = false;
            a = 0;
            startup = false;

            osdDraw1();

            //Setup configuration panel
            if (pan.converts == 0)
            {
                UNITS_combo.SelectedIndex = 0; //decimal
            }
            else if (pan.converts == 1)
            {
                UNITS_combo.SelectedIndex = 1; //minutes
            }

            CHK_pal.Checked = Convert.ToBoolean(pan.pal_ntsc);
            radioButton1.Checked = Convert.ToBoolean(pan.rssiMode);

            numericUpDown1.Value = 0;
            pan.rssiMinCalibVal = 0;
            numericUpDown2.Value = 1;
            pan.rssiMaxCalibVal = 1;
            numericUpDown3.Value = 1;
            pan.videoCalibVal = 1;

            radioButton1.Checked = true;
            pan.rssiMode = true;
            radioButton2.Checked = false;

            this.CHK_pal_CheckedChanged(EventArgs.Empty, EventArgs.Empty);
            this.pALToolStripMenuItem_CheckStateChanged(EventArgs.Empty, EventArgs.Empty);
            this.nTSCToolStripMenuItem_CheckStateChanged(EventArgs.Empty, EventArgs.Empty);

            timeshiftw.Value = 0;

            CMB_ComPort.Text = "COM1";
        }          

        private string[] GetPortNames()
        {
            string[] devs = new string[0];

            if (Directory.Exists("/dev/"))
                devs = Directory.GetFiles("/dev/", "*ACM*");

            string[] ports = SerialPort.GetPortNames();

            string[] all = new string[devs.Length + ports.Length];

            devs.CopyTo(all, 0);
            ports.CopyTo(all, devs.Length);

            return all;
        }

        public void setPanel(int x, int y)
        {
            this.x[panel_number] = x * 12;
            this.y[panel_number] = y * 18;
        }

        public void openPanel()
        {
            d[panel_number] = 0;
            r[panel_number] = 0;
        }

        public void openSingle(int x, int y)
        {
            setPanel(x, y);
            openPanel();
        }

        public int getCenter()
        {
            if (CHK_pal.Checked)
                return 8;
            return 6;
        }

        // used for printf tracking line and row
        int[] d = new int[npanel];
        int[] r = new int[npanel];

        public void printf(string format, params object[] args)
        {
            StringBuilder sb = new StringBuilder();

            sb = new StringBuilder(AT.MIN.Tools.sprintf(format, args));

            foreach (char ch in sb.ToString().ToCharArray())
            {
                if (ch == '|')
                {
                    d[panel_number] += 1;
                    r[panel_number] = 0;
                    continue;
                }

                try
                {
                    // draw red boxs
                    if (selectedrectangle)
                    {
                        gr[panel_number].DrawRectangle(Pens.Red, (this.x[panel_number] + r[panel_number] * 12) % screen[panel_number].Width, (this.y[panel_number] + d[panel_number] * 18), 12, 18);
                    }

                    int w1 = (this.x[panel_number] / 12 + r[panel_number]) % basesize.Width;
                    int h1 = (this.y[panel_number] / 18 + d[panel_number]);

                    if (w1 < basesize.Width && h1 < basesize.Height)
                    {
                        // check if this box has bene used
                        if (usedPostion[w1][h1] != null)
                        {
                            //System.Diagnostics.Debug.WriteLine("'" + used[this.x / 12 + r * 12 / 12][this.y / 18 + d * 18 / 18] + "'");
                        }
                        else
                        {
                            gr[panel_number].DrawImage(chars[ch], (this.x[panel_number] + r[panel_number] * 12) % screen[panel_number].Width, (this.y[panel_number] + d[panel_number] * 18), 12, 18);
                        }

                        usedPostion[w1][h1] = processingpanel;
                    }
                }
                catch { System.Diagnostics.Debug.WriteLine("printf exception"); }
                r[panel_number]++;
            }

        }
            

        string getMouseOverItem(int x, int y)
        {
            int ansW, ansH;

            getCharLoc(x, y, out ansW, out ansH);

            if (usedPostion[ansW][ansH] != null && usedPostion[ansW][ansH] != "")
            {
                LIST_items.SelectedIndex = LIST_items.Items.IndexOf(usedPostion[ansW][ansH]);
                return usedPostion[ansW][ansH];
            }

            return "";
        }

        void getCharLoc(int x, int y, out int xpos, out int ypos)
        {

            x = Constrain(x, 0, pictureBox1.Width - 1);
            y = Constrain(y, 0, pictureBox1.Height - 1);

            float scaleW = pictureBox1.Width / (float)screen[panel_number].Width;
            float scaleH = pictureBox1.Height / (float)screen[panel_number].Height;

            int ansW = (int)((x / scaleW / 12) % 30);
            int ansH = 0;
            if (CHK_pal.Checked)
            {
                ansH = (int)((y / scaleH / 18) % 16);
            }
            else
            {
                ansH = (int)((y / scaleH / 18) % 13);
            }

            xpos = Constrain(ansW, 0, 30 - 1);
            ypos = Constrain(ansH, 0, 16 - 1);
        }
        
        public void printf_P(string format, params object[] args)
        {
            printf(format, args);
        }

        public void closePanel()
        {
            x[panel_number] = 0;
            y[panel_number] = 0;
        }
        // draw image and characters overlay
        void osdDraw1()
        {
            panel_number = 0;
            if (startup)
                return;

            for (int b = 0; b < usedPostion.Length; b++)
            {
                usedPostion[b] = new string[16];
            }

            image = new Bitmap(pictureBox1.Width, pictureBox1.Height);

            float scaleW = pictureBox1.Width / (float)screen[panel_number].Width;
            float scaleH = pictureBox1.Height / (float)screen[panel_number].Height;

            screen[panel_number] = new Bitmap(screen[panel_number].Width, screen[panel_number].Height);

            gr[panel_number] = Graphics.FromImage(screen[panel_number]);

            image = new Bitmap(image.Width, image.Height);

            Graphics grfull = Graphics.FromImage(image);

            try
            {
                grfull.DrawImage(bgpicture, 0, 0, pictureBox1.Width, pictureBox1.Height);
            }
            catch { }

            if (checkBox1.Checked)
            {
                for (int b = 1; b < 16; b++)
                {
                    for (int a = 1; a < 30; a++)
                    {
                        grfull.DrawLine(new Pen(Color.Gray, 1), a * 12 * scaleW, 0, a * 12 * scaleW, pictureBox1.Height);
                        grfull.DrawLine(new Pen(Color.Gray, 1), 0, b * 18 * scaleH, pictureBox1.Width, b * 18 * scaleH);
                    }
                }
            }

            pan.setHeadingPatern();

            List<string> list = new List<string>();

            foreach (string it in LIST_items.CheckedItems)
            {
                list.Add(it);
            }

            list.Reverse();

            foreach (string it in list)
            {
                foreach (var thing in panelItems)
                {
                    selectedrectangle = false;
                    if (thing != null)
                    {
                        if (thing.Item1 == it)
                        {
                            if (thing.Item1 == currentlyselected[0])
                            {
                                selectedrectangle = true;
                            }

                            processingpanel = thing.Item1;

                            // ntsc and below the middle line
                            if (thing.Item4 >= getCenter() && !CHK_pal.Checked)
                            {
                                thing.Item2(thing.Item3, thing.Item4 - 3);
                            }
                            else // pal and no change
                            {
                                thing.Item2(thing.Item3, thing.Item4);
                            }

                        }
                    }
                }
            }

            grfull.DrawImage(screen[panel_number], 0, 0, image.Width, image.Height);

            pictureBox1.Image = image;
        }

        int Constrain(double value, double min, double max)
        {
            if (value < min)
                return (int)min;
            if (value > max)
                return (int)max;

            return (int)value;
        }

        private void OSD_Load(object sender, EventArgs e)
        {
            CMB_ComPort.Items.AddRange(GetPortNames());

            if (CMB_ComPort.Items.Count > 0)
                CMB_ComPort.SelectedIndex = 0;

            xmlconfig(false);

            osdDraw1();
        }


        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string item = ((CheckedListBox)sender).SelectedItem.ToString();

            currentlyselected[0] = item;

            osdDraw1();

            foreach (var thing in panelItems)
            {
                if (thing != null && thing.Item1 == item)
                {
                        NUM_X.Value = Constrain(thing.Item3,0,basesize.Width -1);
                        NUM_Y.Value = Constrain(thing.Item4,0,16 -1);
                }
            }
        }

        private void checkedListBox1_SelectedValueChanged(object sender, EventArgs e)
        {
        }

        private void checkedListBox2_SelectedValueChanged(object sender, EventArgs e)
        {
        }


        private void checkedListBox1_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            // add a delay to this so it runs after the control value has been defined.
            if (this.IsHandleCreated)
                this.BeginInvoke((MethodInvoker)delegate { osdDraw1(); });
        }

             private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            string item;
            try
            {
                item = LIST_items.SelectedItem.ToString();
            }
            catch { return; }

            for (int a = 0; a < panelItems.Length; a++)
            {
                if (panelItems[a] != null && panelItems[a].Item1 == item)
                {
                    panelItems[a] = new Tuple<string, Func<int, int, int>, int, int, int, int, int>(panelItems[a].Item1, panelItems[a].Item2, (int)NUM_X.Value, panelItems[a].Item4, panelItems[a].Item5, panelItems[a].Item6, panelItems[a].Item7);
                }
            }

            osdDraw1();
        }


        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            string item;
            try
            {
                item = LIST_items.SelectedItem.ToString();
            }
            catch { return; }

            for (int a = 0; a < panelItems.Length; a++)
            {
                if (panelItems[a] != null && panelItems[a].Item1 == item)
                {
                    panelItems[a] = new Tuple<string, Func<int, int, int>, int, int, int, int, int>(panelItems[a].Item1, panelItems[a].Item2, panelItems[a].Item3, (int)NUM_Y.Value, panelItems[a].Item5, panelItems[a].Item6, panelItems[a].Item7);

                }
            }

            osdDraw1();
        }

        //Write data to MinimOSD EPPROM
        private void BUT_WriteOSD_Click(object sender, EventArgs e)
        {   
         
            TabPage current = PANEL_tabs.SelectedTab;
            foreach (string str in this.LIST_items.Items)
            {
                foreach (var tuple in this.panelItems)
                {
                    if ((tuple != null) && ((tuple.Item1 == str)) && tuple.Item5 != -1)
                    {
                        eeprom[tuple.Item5] = (byte)(this.LIST_items.CheckedItems.Contains(str) ? 1 : 0);
                        eeprom[tuple.Item6] = (byte)tuple.Item3; // x
                        eeprom[tuple.Item7] = (byte)tuple.Item4; // y
                    }
                }
            }
   
            eeprom[PAL_NTSC_ADDR] = pan.pal_ntsc;
            eeprom[RSSI_MODE_ADDR] = Convert.ToByte(pan.rssiMode);
            eeprom[GPS_MODE_ADDR] = Convert.ToByte(pan.gpsMode);

            byte[] tmpByteArray = BitConverter.GetBytes(pan.rssiMinCalibVal);
            for(int i = 0; i < 4; ++i)
                eeprom[RSSI_MIN_CAL_ADDR + i] = tmpByteArray[i];

            tmpByteArray = BitConverter.GetBytes(pan.rssiMaxCalibVal);
            for (int i = 0; i < 4; ++i)
                eeprom[RSSI_MAX_CAL_ADDR + i] = tmpByteArray[i];

            tmpByteArray = BitConverter.GetBytes(pan.videoCalibVal);
            for (int i = 0; i < 4; ++i)
                eeprom[VIDEO_CAL_ADDR + i] = tmpByteArray[i];

            eeprom[TIMESHIFT] = (byte)((int)timeshiftw.Value & 0xFF);
            
            toolStripStatusLabel1.Text = "Busy";

            ArduinoSTK sp;

            try
            {
                if (comPort.IsOpen)
                    comPort.Close();

                sp = new ArduinoSTK();
                sp.PortName = CMB_ComPort.Text;
                sp.BaudRate = 57600;// 115200;// 19200;//57600;
                sp.DataBits = 8;
                sp.StopBits = StopBits.One;
                sp.Parity = Parity.None;
                sp.DtrEnable = false;
                sp.RtsEnable = false; //added

                sp.Open();
            }
            catch { MessageBox.Show("Error opening com port", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }

            if (sp.connectAP())
            {
                try
                {
                    bool spupload_flag = false;

                    for (int i = 0; i < 10; i++)
                    { //try to upload two times if it fail
                        spupload_flag = sp.upload(eeprom, (short)0, (short)OffsetBITpanel, (short)0);
                        if (!spupload_flag)
                        {
                            if (sp.keepalive()) Console.WriteLine("keepalive successful (iter " + i + ")");
                            else Console.WriteLine("keepalive fail (iter " + i + ")");
                        }
                        else break;
                    }
                    if (spupload_flag) MessageBox.Show("Done writing Panel data!");
                    else MessageBox.Show("Failed to upload new Panel data");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Failed to talk to bootloader");
            }

            sp.Close();
            toolStripStatusLabel1.Text = "Ready";
        }

        //Write data to MinimOSD EPPROM
        private void BUT_ResetOSD_EEPROM()
        {
            foreach (string str in this.LIST_items.Items)
            {
                foreach (var tuple in this.panelItems_default)
                {
                    if ((tuple != null) && ((tuple.Item1 == str)) && tuple.Item5 != -1)
                    {
                        eeprom[tuple.Item5] = 1;
                        eeprom[tuple.Item6] = (byte)tuple.Item3; // x
                        eeprom[tuple.Item7] = (byte)tuple.Item4; // y
                    }
                }
            }
            //Setup configuration panel
            eeprom[PAL_NTSC_ADDR] = pan.pal_ntsc;
            eeprom[RSSI_MODE_ADDR] = Convert.ToByte(pan.rssiMode);
            eeprom[GPS_MODE_ADDR] = Convert.ToByte(pan.gpsMode);
        }
       
        private void comboBox1_Click(object sender, EventArgs e)
        {
            CMB_ComPort.Items.Clear();
            CMB_ComPort.Items.AddRange(GetPortNames());
        }

        const int VER = 76;
        // EEPROM Storage addresses
        const int OffsetBITpanel = 250;
        // First of 8 panels
        
        const int panBatt_A_en_ADDR = 0xe;
        const int panBatt_A_x_ADDR = 0xc;
        const int panBatt_A_y_ADDR = 0xd;
        const int vidVol_en_ADDR = 0x11;
        const int vidVol_x_ADDR = 0xf;
        const int vidVol_y_ADDR = 0x10;
       
        const int panGPS_en_ADDR = 0x17;
        const int panGPS_x_ADDR = 0x15;
        const int panGPS_y_ADDR = 0x16;

        // Second set of 8 panels
 
        const int panHomeDir_en_ADDR = 66;
        const int panHomeDir_x_ADDR = 68;
        const int panHomeDir_y_ADDR = 70;
        const int panHomeDis_en_ADDR = 0x29;
        const int panHomeDis_x_ADDR = 0x27;
        const int panHomeDis_y_ADDR = 0x28;
      
        const int panRSSI_en_ADDR = 0x14;
        const int panRSSI_x_ADDR = 0x12;
        const int panRSSI_y_ADDR = 0x13;


        // Third set of 8 panels
   
        const int panAlt_en_ADDR = 0x20;
        const int panAlt_x_ADDR = 0x1e;
        const int panAlt_y_ADDR = 0x1f;
        const int panVel_en_ADDR = 0x2c;
        const int panVel_x_ADDR = 0x2a;
        const int panVel_y_ADDR = 0x2b;

        const int panFMod_en_ADDR = 0x53;
        const int panFMod_x_ADDR = 0x51;
        const int panFMod_y_ADDR = 0x52;
        const int panHorizon_en_ADDR = 0x26;
        const int panHorizon_x_ADDR = 0x24;
        const int panHorizon_y_ADDR = 0x25;
        const int panHomeAlt_en_ADDR = 0x23;
        const int panHomeAlt_x_ADDR = 0x21;
        const int panHomeAlt_y_ADDR = 0x22;
        const int gpsMode = 0x37;


        const int panTime_en_ADDR = 0x1d;
        const int panTime_x_ADDR = 0x1b;
        const int panTime_y_ADDR = 0x1c;
        const int panClock_en_ADDR = 0x1a;
        const int panClock_x_ADDR = 0x18;
        const int panClock_y_ADDR = 0x19;

        const int PAL_NTSC_ADDR = 0x2;

        const int RSSI_MODE_ADDR = 0x50;
        const int GPS_MODE_ADDR = 0x37; //gps scale

        const int RSSI_MIN_CAL_ADDR = 0x46;
        const int RSSI_MAX_CAL_ADDR = 0x42;
        const int VIDEO_CAL_ADDR = 0x38;

        const int TIMESHIFT = 0x55;

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            osdDraw1();
        }

        private void OSD_Resize(object sender, EventArgs e)
        {
            try
            {
                osdDraw1();
            }
            catch { }
        }

        private void BUT_ReadOSD_Click(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Busy";

            ArduinoSTK sp;

            try
            {
                if (comPort.IsOpen)
                    comPort.Close();

                sp = new ArduinoSTK();
                sp.PortName = CMB_ComPort.Text;
                sp.BaudRate = 57600;// 115200;// 19200;
                sp.DtrEnable = true;

                sp.Open();
            }
            catch { MessageBox.Show("Error opening com port", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }

            if (sp.connectAP())
            {
                try
                {
                    for (int i = 0; i < 5; i++)
                    { //try to download two times if it fail
                        eeprom = sp.download(1024);
                        if (!sp.down_flag)
                        {
                            if (sp.keepalive()) Console.WriteLine("keepalive successful (iter " + i + ")");
                            else Console.WriteLine("keepalive fail (iter " + i + ")");
                        }
                        else break;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Failed to talk to bootloader");
                //fail = true;
                sp.Close();
                toolStripStatusLabel1.Text = "Ready";
                return;
            }

            sp.Close();
            
            for (int a = 0; a < panelItems.Length; a++)
                {
                    if (panelItems[a] != null)
                    {
                        if (panelItems[a].Item5 >= 0)
                            LIST_items.SetItemCheckState(a, eeprom[panelItems[a].Item5] == 0 ? CheckState.Unchecked : CheckState.Checked);

                        if (panelItems[a].Item7 >= 0 || panelItems[a].Item6 >= 0)
                            panelItems[a] = new Tuple<string, Func<int, int, int>, int, int, int, int, int>(panelItems[a].Item1, panelItems[a].Item2, eeprom[panelItems[a].Item6], eeprom[panelItems[a].Item7], panelItems[a].Item5, panelItems[a].Item6, panelItems[a].Item7);
                    }
                }

            if (eeprom[RSSI_MODE_ADDR] != 0)
            {
                pan.rssiMode = true;
                radioButton1.Checked = true;
                radioButton2.Checked = false;
            }
            else
            {
                pan.rssiMode = false;
                radioButton1.Checked = false;
                radioButton2.Checked = true; 
            }

            if (eeprom[GPS_MODE_ADDR] != 0)
            {
                pan.gpsMode = true;
                UNITS_combo.SelectedIndex = 1;
            }
            else
            {
                pan.gpsMode = false;
                UNITS_combo.SelectedIndex = 0;
            }

            if (eeprom[TIMESHIFT] >= 0xF5)
            {
                timeshiftw.Value = eeprom[TIMESHIFT] - 256;
            }
            else if (eeprom[TIMESHIFT] <= 12)
            {
                timeshiftw.Value = eeprom[TIMESHIFT];
            }

            try
            {
                pan.rssiMinCalibVal = BitConverter.ToSingle(eeprom, RSSI_MIN_CAL_ADDR);
                numericUpDown1.Value = (decimal)pan.rssiMinCalibVal;
            }
            catch { }
            try
            {
                pan.rssiMaxCalibVal = BitConverter.ToSingle(eeprom, RSSI_MAX_CAL_ADDR);
                numericUpDown2.Value = (decimal)pan.rssiMaxCalibVal;
            }
            catch { }
            try
            {
                pan.videoCalibVal = BitConverter.ToSingle(eeprom, VIDEO_CAL_ADDR);
                numericUpDown3.Value = (decimal)pan.videoCalibVal;
            }
            catch { }

            pan.pal_ntsc = eeprom[PAL_NTSC_ADDR];
            CHK_pal.Checked = Convert.ToBoolean(pan.pal_ntsc);

            this.pALToolStripMenuItem_CheckStateChanged(EventArgs.Empty, EventArgs.Empty);
            this.nTSCToolStripMenuItem_CheckStateChanged(EventArgs.Empty, EventArgs.Empty);
            this.CHK_pal_CheckedChanged(EventArgs.Empty, EventArgs.Empty);

            osdDraw1();

            toolStripStatusLabel1.Text = "Ready";
              }


        byte[] readIntelHEXv2(StreamReader sr)
        {
            byte[] FLASH = new byte[1024 * 1024];

            int optionoffset = 0;
            int total = 0;
            bool hitend = false;

            while (!sr.EndOfStream)
            {
                string line = sr.ReadLine();

                if (line.StartsWith(":"))
                {
                    int length = Convert.ToInt32(line.Substring(1, 2), 16);
                    int address = Convert.ToInt32(line.Substring(3, 4), 16);
                    int option = Convert.ToInt32(line.Substring(7, 2), 16);
                    Console.WriteLine("len {0} add {1} opt {2}", length, address, option);

                    if (option == 0)
                    {
                        string data = line.Substring(9, length * 2);
                        for (int i = 0; i < length; i++)
                        {
                            byte byte1 = Convert.ToByte(data.Substring(i * 2, 2), 16);
                            FLASH[optionoffset + address] = byte1;
                            address++;
                            if ((optionoffset + address) > total)
                                total = optionoffset + address;
                        }
                    }
                    else if (option == 2)
                    {
                        optionoffset = (int)Convert.ToUInt16(line.Substring(9, 4), 16) << 4;
                    }
                    else if (option == 1)
                    {
                        hitend = true;
                    }
                    int checksum = Convert.ToInt32(line.Substring(line.Length - 2, 2), 16);

                    byte checksumact = 0;
                    for (int z = 0; z < ((line.Length - 1 - 2) / 2); z++) // minus 1 for : then mins 2 for checksum itself
                    {
                        checksumact += Convert.ToByte(line.Substring(z * 2 + 1, 2), 16);
                    }
                    checksumact = (byte)(0x100 - checksumact);

                    if (checksumact != checksum)
                    {
                        MessageBox.Show("The hex file loaded is invalid, please try again.");
                        throw new Exception("Checksum Failed - Invalid Hex");
                    }
                }
                //Regex regex = new Regex(@"^:(..)(....)(..)(.*)(..)$"); // length - address - option - data - checksum
            }

            if (!hitend)
            {
                MessageBox.Show("The hex file did no contain an end flag. aborting");
                throw new Exception("No end flag in file");
            }

            Array.Resize<byte>(ref FLASH, total);

            return FLASH;
        }

        private void CHK_pal_CheckedChanged(object sender, EventArgs e)
        {
            changeToPal(CHK_pal.Checked);
            osdDraw1();
        }

        private void pALToolStripMenuItem_CheckStateChanged(object sender, EventArgs e)
        {
            CHK_ntsc.Checked = !CHK_pal.Checked;
        }

        private void nTSCToolStripMenuItem_CheckStateChanged(object sender, EventArgs e)
        {
            CHK_pal.Checked = !CHK_ntsc.Checked;
        }

        private void saveToFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog() { Filter = "*.osd|*.osd" };

            sfd.ShowDialog();

            if (sfd.FileName != "")
            {
                try
                {
                    using (StreamWriter sw = new StreamWriter(sfd.OpenFile()))
                    //Write
                    {
                        //Panel
                        sw.WriteLine("{0}", "Panel");
                        foreach (var item in panelItems)
                        {
                            if (item != null)
                                sw.WriteLine("{0}\t{1}\t{2}\t{3}", item.Item1, item.Item3, item.Item4, LIST_items.GetItemChecked(LIST_items.Items.IndexOf(item.Item1)).ToString());
                        }
                        //Config 
                        sw.WriteLine("{0}", "Configuration");
                        sw.WriteLine("{0}\t{1}", "GPS Mode", pan.gpsMode);
                        sw.WriteLine("{0}\t{1}", "RSSI Mode", pan.rssiMode);
                        sw.WriteLine("{0}\t{1}", "RSSI Calib Min", pan.rssiMinCalibVal);
                        sw.WriteLine("{0}\t{1}", "RSSI Calib Max", pan.rssiMaxCalibVal);
                        sw.WriteLine("{0}\t{1}", "Video Calib", pan.videoCalibVal);
                        sw.WriteLine("{0}\t{1}", "Video Mode", pan.pal_ntsc);
                        sw.WriteLine("{0}\t{1}", "Timeshift", (int)timeshiftw.Value);
                                                
                        sw.Close();
                    }
                }
                catch
                {
                    MessageBox.Show("Error writing file");
                }
            }
        }

        private void loadFromFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog() { Filter = "*.osd|*.osd" };
            //const int nosdfunctions = 29;
            ofd.ShowDialog();

            if (ofd.FileName != "")
            {
                try
                {
                    using (StreamReader sr = new StreamReader(ofd.OpenFile()))
                    {
                        //Panel
                        string stringh = sr.ReadLine(); //
                        //while (!sr.EndOfStream)
                        for( int i = 0; i < nosdfunctions; i++)
                        {
                            string[] strings = sr.ReadLine().Split(new char[] {'\t'},StringSplitOptions.RemoveEmptyEntries);
                            for (int a = 0; a < panelItems.Length ; a++)
                            {
                                if (panelItems[a] != null && panelItems[a].Item1 == strings[0])
                                {
                                    // incase there is an invalid line number or to shore
                                    try
                                    {
                                        panelItems[a] = new Tuple<string, Func<int, int, int>, int, int, int, int, int>(panelItems[a].Item1, panelItems[a].Item2, int.Parse(strings[1]), int.Parse(strings[2]), panelItems[a].Item5, panelItems[a].Item6, panelItems[a].Item7);

                                        LIST_items.SetItemChecked(a, strings[3] == "True");
                                    }
                                    catch { }
                                }
                            }
                        }
                        //Config 
                        stringh = sr.ReadLine(); //
                        while (!sr.EndOfStream)
                        {
                            string[] strings = sr.ReadLine().Split(new char[] { '\t' }, StringSplitOptions.RemoveEmptyEntries);
                            if (strings[0] == "GPS Mode")
                            {
                                if (strings[1] == "True")
                                    pan.gpsMode = true;
                                else
                                    pan.gpsMode = false;
                            }
                            else if (strings[0] == "RSSI Mode")
                            {
                                if (strings[1] == "True")
                                    pan.rssiMode = true;
                                else
                                    pan.rssiMode = false;
                            }
                            else if (strings[0] == "RSSI Calib Min") pan.rssiMinCalibVal = Convert.ToSingle(strings[1]);
                            else if (strings[0] == "RSSI Calib Max") pan.rssiMaxCalibVal = Convert.ToSingle(strings[1]);
                            else if (strings[0] == "Video Calib") pan.videoCalibVal = Convert.ToSingle(strings[1]);
                            else if (strings[0] == "Video Mode") pan.pal_ntsc = byte.Parse(strings[1]);
                            else if (strings[0] == "Timeshift") timeshiftw.Value = int.Parse(strings[1]);
                        }

                        //Modify units
                        UNITS_combo.SelectedIndex = Convert.ToInt32(pan.gpsMode);

                        numericUpDown1.Value = Convert.ToDecimal(pan.rssiMinCalibVal);
                        numericUpDown2.Value = Convert.ToDecimal(pan.rssiMaxCalibVal);
                        numericUpDown3.Value = Convert.ToDecimal(pan.videoCalibVal);
                        
                        CHK_pal.Checked = Convert.ToBoolean(pan.pal_ntsc);
                        radioButton1.Checked = Convert.ToBoolean(pan.rssiMode);
                        radioButton2.Checked = Convert.ToBoolean(!pan.rssiMode);

                        this.CHK_pal_CheckedChanged(EventArgs.Empty, EventArgs.Empty);
                        this.pALToolStripMenuItem_CheckStateChanged(EventArgs.Empty, EventArgs.Empty);
                        this.nTSCToolStripMenuItem_CheckStateChanged(EventArgs.Empty, EventArgs.Empty);

                    }
                }
                catch
                {
                    MessageBox.Show("Error Reading file");
                }
            }

            osdDraw1();
        }

        private void loadDefaultsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            setupFunctions();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            getMouseOverItem(e.X, e.Y);

            mousedown[0] = false;
        }
        
        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left && mousedown[0] == true)
            {
                int ansW, ansH;
                getCharLoc(e.X, e.Y, out ansW, out ansH);
                if (ansH >= getCenter() && !CHK_pal.Checked)
                {
                    ansH += 3;
                }

                NUM_X.Value = Constrain(ansW, 0, basesize.Width - 1);
                NUM_Y.Value = Constrain(ansH, 0, 16 - 1);

                pictureBox1.Focus();
            }
            else
            {
                mousedown[0] = false;
            }
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            currentlyselected[0] = getMouseOverItem(e.X, e.Y);

            mousedown[0] = true;
        }

        private void updateFirmwareToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "*.hex|*.hex";

            ofd.ShowDialog();

            if (ofd.FileName != "")
            {
                toolStripStatusLabel1.Text = "Busy";

                byte[] FLASH;
                bool spuploadflash_flag = false;
                try
                {
                    toolStripStatusLabel1.Text = "Reading Hex File";

                    statusStrip1.Refresh();

                    FLASH = readIntelHEXv2(new StreamReader(ofd.FileName));
                }
                catch { MessageBox.Show("Bad Hex File"); return; }

                ArduinoSTK sp;

                try
                {
                    if (comPort.IsOpen)
                        comPort.Close();

                    sp = new ArduinoSTK();
                    sp.PortName = CMB_ComPort.Text;
                    sp.BaudRate = 57600;//115200;//57600;
                    sp.DataBits = 8;
                    sp.StopBits = StopBits.One;
                    sp.Parity = Parity.None;
                    sp.DtrEnable = false;
                    sp.RtsEnable = false; //added

                    sp.Open();
                }
                catch { MessageBox.Show("Error opening com port", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }

                if (sp.connectAP())
                {
                    try
                    {
                        for (int i = 0; i < 3; i++) //try to upload 3 times
                        { //try to upload n times if it fail
                            spuploadflash_flag = sp.uploadflash(FLASH, 0, FLASH.Length, 0);
                            if (!spuploadflash_flag)
                            {
                                if (sp.keepalive()) Console.WriteLine("keepalive successful (iter " + i + ")");
                                else Console.WriteLine("keepalive fail (iter " + i + ")");
                            }
                            else break;
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
                else
                {
                    MessageBox.Show("Failed to talk to bootloader");
                }

                sp.Close();

                toolStripStatusLabel1.Text = "Ready";
            }
        }

        private void customBGPictureToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "jpg or bmp|*.jpg;*.bmp";

            ofd.ShowDialog();

            if (ofd.FileName != "")
            {
                try
                {
                    bgpicture = Image.FromFile(ofd.FileName);

                }
                catch { MessageBox.Show("Bad Image"); }

                osdDraw1();                
            }
        }

        private void OSD_FormClosed(object sender, FormClosedEventArgs e)
        {
            xmlconfig(true);
        }

        private void xmlconfig(bool write)
        {
            if (write || !File.Exists(Path.GetDirectoryName(Application.ExecutablePath) + Path.DirectorySeparatorChar + @"config.xml"))
            {
                try
                {
                    XmlTextWriter xmlwriter = new XmlTextWriter(Path.GetDirectoryName(Application.ExecutablePath) + Path.DirectorySeparatorChar + @"config.xml", Encoding.ASCII);
                    xmlwriter.Formatting = Formatting.Indented;

                    xmlwriter.WriteStartDocument();

                    xmlwriter.WriteStartElement("Config");

                    xmlwriter.WriteElementString("comport", CMB_ComPort.Text);

                    xmlwriter.WriteElementString("Pal", CHK_pal.Checked.ToString());

                    xmlwriter.WriteEndElement();

                    xmlwriter.WriteEndDocument();
                    xmlwriter.Close();
                }
                catch (Exception ex) { MessageBox.Show(ex.ToString()); }
            }
            else
            {
                try
                {
                    using (XmlTextReader xmlreader = new XmlTextReader(Path.GetDirectoryName(Application.ExecutablePath) + Path.DirectorySeparatorChar + @"config.xml"))
                    {
                        while (xmlreader.Read())
                        {
                            xmlreader.MoveToElement();
                            try
                            {
                                switch (xmlreader.Name)
                                {
                                    case "comport":
                                        string temp = xmlreader.ReadString();
                                        CMB_ComPort.Text = temp;
                                        break;
                                    case "Pal":
                                        string temp2 = xmlreader.ReadString();
                                        break;
                                    case "Config":
                                        break;
                                    case "xml":
                                        break;
                                    default:
                                        if (xmlreader.Name == "") // line feeds
                                            break;
                                        break;
                                }
                            }
                            catch (Exception ee) { Console.WriteLine(ee.Message); } // silent fail on bad entry
                        }
                    }
                }
                catch (Exception ex) { Console.WriteLine("Bad Config File: " + ex.ToString()); } // bad config file
            }
        }

        private void updateFontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "mcm|*.mcm";

            ofd.ShowDialog();
     
            if (ofd.FileName != "")
            {
                toolStripStatusLabel1.Text = "Busy";
                if (comPort.IsOpen)
                    comPort.Close();

                try
                {

                    comPort.PortName = CMB_ComPort.Text;
                    comPort.BaudRate = 115200;

                    comPort.Open();

                    comPort.DtrEnable = false;
                    comPort.RtsEnable = false;

                    comPort.DtrEnable = true;
                    comPort.RtsEnable = true;

                    System.Threading.Thread.Sleep(7000);

                    comPort.ReadExisting();

                    comPort.WriteLine("");
                    comPort.WriteLine("");
                    comPort.WriteLine("");
                    comPort.WriteLine("");
                    comPort.WriteLine("");

                    int timeout = 0;

                    while (comPort.BytesToRead == 0)
                    {
                        System.Threading.Thread.Sleep(500);
                        Console.WriteLine("Waiting...");
                        timeout++;

                        if (timeout > 6)
                        {
                            MessageBox.Show("Error entering font mode - No Data");
                            comPort.Close();
                            return;
                        }
                    }

                    if (!comPort.ReadLine().Contains("Ready for Font"))
                    {
                        MessageBox.Show("Error entering CharSet upload mode - invalid data");
                        comPort.Close();
                        return;
                    }
                }
                catch { MessageBox.Show("Error opening com port", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }

                using (var stream = ofd.OpenFile())
                {

                    BinaryReader br = new BinaryReader(stream);
                    StreamReader sr2 = new StreamReader(br.BaseStream);

                    string device = sr2.ReadLine();

                    if (device != "MAX7456")
                    {
                        MessageBox.Show("Invalid MCM");
                        comPort.Close();
                        return;
                    }

                    br.BaseStream.Seek(0, SeekOrigin.Begin);

                    long length = br.BaseStream.Length;

                    while (br.BaseStream.Position < br.BaseStream.Length && !this.IsDisposed)
                    {
                        try
                        {       
                            int read = 256 * 3;// 163847 / 256 + 1; // 163,847 font file
                            if ((br.BaseStream.Position + read) > br.BaseStream.Length)
                            {
                                read = (int)(br.BaseStream.Length - br.BaseStream.Position);
                            }
                            length -= read;

                            byte[] buffer = br.ReadBytes(read);

                            comPort.Write(buffer, 0, buffer.Length);

                            int timeout = 0;

                            while (comPort.BytesToRead == 0 && read == 768)
                            {
                                System.Threading.Thread.Sleep(10);
                                timeout++;

                                if (timeout > 10)
                                {
                                    MessageBox.Show("CharSet upload failed - no response");
                                    comPort.Close();
                                    return;
                                }
                            }

                            Console.WriteLine(comPort.ReadExisting());

                        }
                        catch { break; }

                        Application.DoEvents();
                    }

                    comPort.WriteLine("\n\n\n\n\n\n\n\n\n\n\n\n\n\n");

                    comPort.DtrEnable = false;
                    comPort.RtsEnable = false;

                    System.Threading.Thread.Sleep(50);

                    comPort.DtrEnable = true;
                    comPort.RtsEnable = true;

                    System.Threading.Thread.Sleep(50);

                    comPort.Close();

                    comPort.DtrEnable = false;
                    comPort.RtsEnable = false;

                    toolStripStatusLabel1.Text = "Ready";
                }
            }
        }


      
        private void UNITS_combo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(UNITS_combo.SelectedIndex == 0) {                
                pan.gpsMode = false; //decimal
            }
            else if (UNITS_combo.SelectedIndex == 1){
                pan.gpsMode = true; //minutes
            }
            eeprom[gpsMode] = Convert.ToByte(pan.gpsMode);
            osdDraw1();
        }

        private void CHK_pal_Click(object sender, EventArgs e)
        {
            pan.pal_ntsc = 1;
        }

        private void CHK_ntsc_Click(object sender, EventArgs e)
        {
            pan.pal_ntsc = 0;
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("Author: Michael Oborne \nCo-authors: Pedro Santos \n Zoltán Gábor", "About ArduCAM OSD Config", MessageBoxButtons.OK, MessageBoxIcon.Information);
            AboutBox1 about = new AboutBox1();
            about.Show();
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void CMB_ComPort_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void numericUpDown2_ValueChanged_1(object sender, EventArgs e)
        {
            pan.rssiMaxCalibVal = Convert.ToSingle(numericUpDown2.Value);
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void numericUpDown1_ValueChanged_1(object sender, EventArgs e)
        {
            pan.rssiMinCalibVal = Convert.ToSingle(numericUpDown1.Value);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void numericUpDown3_ValueChanged(object sender, EventArgs e)
        {
            pan.videoCalibVal = Convert.ToSingle(numericUpDown3.Value);
        }

        private void label7_Click_1(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            pan.rssiMode = true;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            pan.rssiMode = false;
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click_1(object sender, EventArgs e)
        {

        }

        private void tabPageConfig2_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click_1(object sender, EventArgs e)
        {

        }

        private void numericUpDown4_ValueChanged(object sender, EventArgs e)
        {

        }

   }
}