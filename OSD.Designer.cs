namespace OSD
{
    partial class OSD
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OSD));
            this.LIST_items = new System.Windows.Forms.CheckedListBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.NUM_Y = new System.Windows.Forms.NumericUpDown();
            this.NUM_X = new System.Windows.Forms.NumericUpDown();
            this.BUT_WriteOSD = new System.Windows.Forms.Button();
            this.CMB_ComPort = new System.Windows.Forms.ComboBox();
            this.BUT_ReadOSD = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadFromFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.loadDefaultsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.videoModeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CHK_ntsc = new System.Windows.Forms.ToolStripMenuItem();
            this.CHK_pal = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.checkBox1 = new System.Windows.Forms.ToolStripMenuItem();
            this.updateFirmwareToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.customBGPictureToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.updateFontToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.PANEL_tabs = new System.Windows.Forms.TabControl();
            this.tabPageConfig = new System.Windows.Forms.TabPage();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.numericUpDown3 = new System.Windows.Forms.NumericUpDown();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.numericUpDown2 = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.UNITS_combo = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.timeshiftw = new System.Windows.Forms.NumericUpDown();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NUM_Y)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUM_X)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.PANEL_tabs.SuspendLayout();
            this.tabPageConfig.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown3)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.groupBox6.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.timeshiftw)).BeginInit();
            this.SuspendLayout();
            // 
            // LIST_items
            // 
            this.LIST_items.FormattingEnabled = true;
            this.LIST_items.Location = new System.Drawing.Point(3, 3);
            this.LIST_items.Name = "LIST_items";
            this.LIST_items.Size = new System.Drawing.Size(138, 259);
            this.LIST_items.TabIndex = 1;
            this.LIST_items.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.checkedListBox1_ItemCheck);
            this.LIST_items.SelectedIndexChanged += new System.EventHandler(this.checkedListBox1_SelectedIndexChanged);
            this.LIST_items.SelectedValueChanged += new System.EventHandler(this.checkedListBox1_SelectedValueChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.NUM_Y);
            this.groupBox1.Controls.Add(this.NUM_X);
            this.groupBox1.Location = new System.Drawing.Point(3, 285);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(138, 82);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(14, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Y";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(14, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "X";
            // 
            // NUM_Y
            // 
            this.NUM_Y.Location = new System.Drawing.Point(30, 46);
            this.NUM_Y.Maximum = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.NUM_Y.Name = "NUM_Y";
            this.NUM_Y.Size = new System.Drawing.Size(91, 20);
            this.NUM_Y.TabIndex = 1;
            this.NUM_Y.ValueChanged += new System.EventHandler(this.numericUpDown2_ValueChanged);
            // 
            // NUM_X
            // 
            this.NUM_X.Location = new System.Drawing.Point(30, 20);
            this.NUM_X.Maximum = new decimal(new int[] {
            29,
            0,
            0,
            0});
            this.NUM_X.Name = "NUM_X";
            this.NUM_X.Size = new System.Drawing.Size(91, 20);
            this.NUM_X.TabIndex = 0;
            this.NUM_X.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            // 
            // BUT_WriteOSD
            // 
            this.BUT_WriteOSD.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BUT_WriteOSD.Location = new System.Drawing.Point(512, 447);
            this.BUT_WriteOSD.MinimumSize = new System.Drawing.Size(150, 0);
            this.BUT_WriteOSD.Name = "BUT_WriteOSD";
            this.BUT_WriteOSD.Size = new System.Drawing.Size(152, 24);
            this.BUT_WriteOSD.TabIndex = 2;
            this.BUT_WriteOSD.Text = "Save current tab to OSD";
            this.BUT_WriteOSD.UseVisualStyleBackColor = true;
            this.BUT_WriteOSD.Click += new System.EventHandler(this.BUT_WriteOSD_Click);
            // 
            // CMB_ComPort
            // 
            this.CMB_ComPort.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.CMB_ComPort.FormattingEnabled = true;
            this.CMB_ComPort.Location = new System.Drawing.Point(290, 449);
            this.CMB_ComPort.Name = "CMB_ComPort";
            this.CMB_ComPort.Size = new System.Drawing.Size(98, 21);
            this.CMB_ComPort.TabIndex = 4;
            this.CMB_ComPort.SelectedIndexChanged += new System.EventHandler(this.CMB_ComPort_SelectedIndexChanged);
            this.CMB_ComPort.Click += new System.EventHandler(this.comboBox1_Click);
            // 
            // BUT_ReadOSD
            // 
            this.BUT_ReadOSD.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BUT_ReadOSD.Location = new System.Drawing.Point(396, 447);
            this.BUT_ReadOSD.Name = "BUT_ReadOSD";
            this.BUT_ReadOSD.Size = new System.Drawing.Size(108, 24);
            this.BUT_ReadOSD.TabIndex = 6;
            this.BUT_ReadOSD.Text = "Read From OSD";
            this.BUT_ReadOSD.UseVisualStyleBackColor = true;
            this.BUT_ReadOSD.Click += new System.EventHandler(this.BUT_ReadOSD_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 473);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(667, 22);
            this.statusStrip1.TabIndex = 8;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(39, 17);
            this.toolStripStatusLabel1.Text = "Ready";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.videoModeToolStripMenuItem,
            this.optionsToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(667, 24);
            this.menuStrip1.TabIndex = 10;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveToFileToolStripMenuItem,
            this.loadFromFileToolStripMenuItem,
            this.toolStripSeparator2,
            this.loadDefaultsToolStripMenuItem,
            this.toolStripSeparator1,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // saveToFileToolStripMenuItem
            // 
            this.saveToFileToolStripMenuItem.Image = global::OSD.Properties.Resources.saveHS;
            this.saveToFileToolStripMenuItem.Name = "saveToFileToolStripMenuItem";
            this.saveToFileToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.saveToFileToolStripMenuItem.Size = new System.Drawing.Size(202, 22);
            this.saveToFileToolStripMenuItem.Text = "Save OSD file...";
            this.saveToFileToolStripMenuItem.Click += new System.EventHandler(this.saveToFileToolStripMenuItem_Click);
            // 
            // loadFromFileToolStripMenuItem
            // 
            this.loadFromFileToolStripMenuItem.Image = global::OSD.Properties.Resources.openHS;
            this.loadFromFileToolStripMenuItem.Name = "loadFromFileToolStripMenuItem";
            this.loadFromFileToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.loadFromFileToolStripMenuItem.Size = new System.Drawing.Size(202, 22);
            this.loadFromFileToolStripMenuItem.Text = "Open OSD File...";
            this.loadFromFileToolStripMenuItem.Click += new System.EventHandler(this.loadFromFileToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(199, 6);
            // 
            // loadDefaultsToolStripMenuItem
            // 
            this.loadDefaultsToolStripMenuItem.Name = "loadDefaultsToolStripMenuItem";
            this.loadDefaultsToolStripMenuItem.Size = new System.Drawing.Size(202, 22);
            this.loadDefaultsToolStripMenuItem.Text = "Load Defaults";
            this.loadDefaultsToolStripMenuItem.Click += new System.EventHandler(this.loadDefaultsToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(199, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(202, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // videoModeToolStripMenuItem
            // 
            this.videoModeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CHK_ntsc,
            this.CHK_pal});
            this.videoModeToolStripMenuItem.Name = "videoModeToolStripMenuItem";
            this.videoModeToolStripMenuItem.Size = new System.Drawing.Size(83, 20);
            this.videoModeToolStripMenuItem.Text = "Video Mode";
            // 
            // CHK_ntsc
            // 
            this.CHK_ntsc.CheckOnClick = true;
            this.CHK_ntsc.Name = "CHK_ntsc";
            this.CHK_ntsc.Size = new System.Drawing.Size(104, 22);
            this.CHK_ntsc.Text = "PAL";
            this.CHK_ntsc.CheckStateChanged += new System.EventHandler(this.nTSCToolStripMenuItem_CheckStateChanged);
            this.CHK_ntsc.Click += new System.EventHandler(this.CHK_ntsc_Click);
            // 
            // CHK_pal
            // 
            this.CHK_pal.Checked = true;
            this.CHK_pal.CheckOnClick = true;
            this.CHK_pal.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CHK_pal.Name = "CHK_pal";
            this.CHK_pal.Size = new System.Drawing.Size(104, 22);
            this.CHK_pal.Text = "NTSC";
            this.CHK_pal.CheckedChanged += new System.EventHandler(this.CHK_pal_CheckedChanged);
            this.CHK_pal.CheckStateChanged += new System.EventHandler(this.pALToolStripMenuItem_CheckStateChanged);
            this.CHK_pal.Click += new System.EventHandler(this.CHK_pal_Click);
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.checkBox1,
            this.updateFirmwareToolStripMenuItem,
            this.customBGPictureToolStripMenuItem,
            this.updateFontToolStripMenuItem});
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.G)));
            this.optionsToolStripMenuItem.ShowShortcutKeys = false;
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.optionsToolStripMenuItem.Text = "Options";
            // 
            // checkBox1
            // 
            this.checkBox1.Checked = true;
            this.checkBox1.CheckOnClick = true;
            this.checkBox1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(183, 22);
            this.checkBox1.Text = "Show Grid";
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // updateFirmwareToolStripMenuItem
            // 
            this.updateFirmwareToolStripMenuItem.Name = "updateFirmwareToolStripMenuItem";
            this.updateFirmwareToolStripMenuItem.Size = new System.Drawing.Size(183, 22);
            this.updateFirmwareToolStripMenuItem.Text = "Update Firmware...";
            this.updateFirmwareToolStripMenuItem.ToolTipText = "Re-Flash the OSD with a new firmware image";
            this.updateFirmwareToolStripMenuItem.Click += new System.EventHandler(this.updateFirmwareToolStripMenuItem_Click);
            // 
            // customBGPictureToolStripMenuItem
            // 
            this.customBGPictureToolStripMenuItem.Name = "customBGPictureToolStripMenuItem";
            this.customBGPictureToolStripMenuItem.Size = new System.Drawing.Size(183, 22);
            this.customBGPictureToolStripMenuItem.Text = "Background Image...";
            this.customBGPictureToolStripMenuItem.Click += new System.EventHandler(this.customBGPictureToolStripMenuItem_Click);
            // 
            // updateFontToolStripMenuItem
            // 
            this.updateFontToolStripMenuItem.Name = "updateFontToolStripMenuItem";
            this.updateFontToolStripMenuItem.Size = new System.Drawing.Size(183, 22);
            this.updateFontToolStripMenuItem.Text = "Update CharSet...";
            this.updateFontToolStripMenuItem.ToolTipText = "Update the font file on the OSD";
            this.updateFontToolStripMenuItem.Click += new System.EventHandler(this.updateFontToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(110, 22);
            this.aboutToolStripMenuItem.Text = "About ";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.Location = new System.Drawing.Point(154, 14);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(497, 354);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            this.pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDown);
            this.pictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseMove);
            this.pictureBox1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseUp);
            // 
            // PANEL_tabs
            // 
            this.PANEL_tabs.Controls.Add(this.tabPageConfig);
            this.PANEL_tabs.Controls.Add(this.tabPage1);
            this.PANEL_tabs.Location = new System.Drawing.Point(0, 24);
            this.PANEL_tabs.Margin = new System.Windows.Forms.Padding(2);
            this.PANEL_tabs.Name = "PANEL_tabs";
            this.PANEL_tabs.SelectedIndex = 0;
            this.PANEL_tabs.Size = new System.Drawing.Size(667, 405);
            this.PANEL_tabs.TabIndex = 0;
            // 
            // tabPageConfig
            // 
            this.tabPageConfig.Controls.Add(this.groupBox5);
            this.tabPageConfig.Controls.Add(this.groupBox4);
            this.tabPageConfig.Controls.Add(this.groupBox3);
            this.tabPageConfig.Controls.Add(this.groupBox2);
            this.tabPageConfig.Controls.Add(this.groupBox6);
            this.tabPageConfig.Location = new System.Drawing.Point(4, 22);
            this.tabPageConfig.Margin = new System.Windows.Forms.Padding(2);
            this.tabPageConfig.Name = "tabPageConfig";
            this.tabPageConfig.Padding = new System.Windows.Forms.Padding(2);
            this.tabPageConfig.Size = new System.Drawing.Size(659, 379);
            this.tabPageConfig.TabIndex = 1;
            this.tabPageConfig.Text = "Config";
            this.tabPageConfig.UseVisualStyleBackColor = true;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.timeshiftw);
            this.groupBox5.Controls.Add(this.label3);
            this.groupBox5.Location = new System.Drawing.Point(192, 86);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(143, 97);
            this.groupBox5.TabIndex = 11;
            this.groupBox5.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 23);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Time shift";
            this.label3.Click += new System.EventHandler(this.label3_Click_1);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.label8);
            this.groupBox4.Controls.Add(this.radioButton2);
            this.groupBox4.Controls.Add(this.radioButton1);
            this.groupBox4.Location = new System.Drawing.Point(8, 205);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(178, 86);
            this.groupBox4.TabIndex = 10;
            this.groupBox4.TabStop = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(11, 16);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(61, 13);
            this.label8.TabIndex = 2;
            this.label8.Text = "RSSI mode";
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(14, 55);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(47, 17);
            this.radioButton2.TabIndex = 1;
            this.radioButton2.Text = "ADC";
            this.radioButton2.UseVisualStyleBackColor = true;
            this.radioButton2.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Checked = true;
            this.radioButton1.Location = new System.Drawing.Point(14, 32);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(62, 17);
            this.radioButton1.TabIndex = 0;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "Mavlink";
            this.radioButton1.UseVisualStyleBackColor = true;
            this.radioButton1.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.numericUpDown3);
            this.groupBox3.Location = new System.Drawing.Point(8, 125);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(178, 74);
            this.groupBox3.TabIndex = 9;
            this.groupBox3.TabStop = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(11, 22);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(114, 13);
            this.label7.TabIndex = 1;
            this.label7.Text = "Video calibration value";
            this.label7.Click += new System.EventHandler(this.label7_Click_1);
            // 
            // numericUpDown3
            // 
            this.numericUpDown3.DecimalPlaces = 2;
            this.numericUpDown3.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.numericUpDown3.Location = new System.Drawing.Point(14, 38);
            this.numericUpDown3.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericUpDown3.Name = "numericUpDown3";
            this.numericUpDown3.Size = new System.Drawing.Size(120, 20);
            this.numericUpDown3.TabIndex = 0;
            this.numericUpDown3.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown3.ValueChanged += new System.EventHandler(this.numericUpDown3_ValueChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.numericUpDown2);
            this.groupBox2.Controls.Add(this.numericUpDown1);
            this.groupBox2.Location = new System.Drawing.Point(8, 15);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(178, 104);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Enter += new System.EventHandler(this.groupBox2_Enter);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(11, 55);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(134, 13);
            this.label6.TabIndex = 14;
            this.label6.Text = "RSSI max calibration value";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(11, 16);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(131, 13);
            this.label5.TabIndex = 14;
            this.label5.Text = "RSSI min calibration value";
            // 
            // numericUpDown2
            // 
            this.numericUpDown2.DecimalPlaces = 2;
            this.numericUpDown2.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.numericUpDown2.Location = new System.Drawing.Point(14, 71);
            this.numericUpDown2.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericUpDown2.Name = "numericUpDown2";
            this.numericUpDown2.Size = new System.Drawing.Size(120, 20);
            this.numericUpDown2.TabIndex = 1;
            this.numericUpDown2.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown2.ValueChanged += new System.EventHandler(this.numericUpDown2_ValueChanged_1);
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.DecimalPlaces = 2;
            this.numericUpDown1.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.numericUpDown1.Location = new System.Drawing.Point(14, 32);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(120, 20);
            this.numericUpDown1.TabIndex = 0;
            this.numericUpDown1.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged_1);
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.UNITS_combo);
            this.groupBox6.Controls.Add(this.label10);
            this.groupBox6.Location = new System.Drawing.Point(192, 15);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(143, 63);
            this.groupBox6.TabIndex = 7;
            this.groupBox6.TabStop = false;
            // 
            // UNITS_combo
            // 
            this.UNITS_combo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.UNITS_combo.FormattingEnabled = true;
            this.UNITS_combo.Items.AddRange(new object[] {
            "Minute",
            "Decimal"});
            this.UNITS_combo.Location = new System.Drawing.Point(9, 36);
            this.UNITS_combo.Margin = new System.Windows.Forms.Padding(2);
            this.UNITS_combo.Name = "UNITS_combo";
            this.UNITS_combo.Size = new System.Drawing.Size(92, 21);
            this.UNITS_combo.TabIndex = 3;
            this.UNITS_combo.SelectedIndexChanged += new System.EventHandler(this.UNITS_combo_SelectedIndexChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(7, 20);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(56, 13);
            this.label10.TabIndex = 2;
            this.label10.Text = "GPS Units";
            this.label10.Click += new System.EventHandler(this.label10_Click);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.LIST_items);
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Controls.Add(this.pictureBox1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(2);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(659, 379);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Panel";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // timeshiftw
            // 
            this.timeshiftw.Location = new System.Drawing.Point(17, 39);
            this.timeshiftw.Maximum = new decimal(new int[] {
            12,
            0,
            0,
            0});
            this.timeshiftw.Minimum = new decimal(new int[] {
            11,
            0,
            0,
            -2147483648});
            this.timeshiftw.Name = "timeshiftw";
            this.timeshiftw.Size = new System.Drawing.Size(84, 20);
            this.timeshiftw.TabIndex = 5;
            this.timeshiftw.ValueChanged += new System.EventHandler(this.numericUpDown4_ValueChanged);
            // 
            // OSD
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(667, 495);
            this.Controls.Add(this.PANEL_tabs);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.BUT_ReadOSD);
            this.Controls.Add(this.CMB_ComPort);
            this.Controls.Add(this.BUT_WriteOSD);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "OSD";
            this.Text = "Bluuu OSD Configurator v1.0";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.OSD_FormClosed);
            this.Load += new System.EventHandler(this.OSD_Load);
            this.Resize += new System.EventHandler(this.OSD_Resize);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NUM_Y)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUM_X)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.PANEL_tabs.ResumeLayout(false);
            this.tabPageConfig.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown3)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.timeshiftw)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.CheckedListBox LIST_items;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.NumericUpDown NUM_Y;
        private System.Windows.Forms.NumericUpDown NUM_X;
        private System.Windows.Forms.Button BUT_WriteOSD;
        private System.Windows.Forms.ComboBox CMB_ComPort;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button BUT_ReadOSD;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem videoModeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem CHK_ntsc;
        private System.Windows.Forms.ToolStripMenuItem CHK_pal;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadFromFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadDefaultsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem checkBox1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem updateFirmwareToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem customBGPictureToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem updateFontToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.TabControl PANEL_tabs;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPageConfig;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.ComboBox UNITS_combo;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.NumericUpDown numericUpDown2;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.NumericUpDown numericUpDown3;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown timeshiftw;
    }
}

