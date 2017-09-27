namespace ScannerCalibration
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.FitOrder = new System.Windows.Forms.NumericUpDown();
            this.Oldfile = new System.Windows.Forms.TextBox();
            this.Newname = new System.Windows.Forms.TextBox();
            this.NewCal = new System.Windows.Forms.NumericUpDown();
            this.Tolerance = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.Matrix = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.ExpandX = new System.Windows.Forms.NumericUpDown();
            this.OffsetX = new System.Windows.Forms.NumericUpDown();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.Dat_btn = new System.Windows.Forms.Button();
            this.label = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.Length = new System.Windows.Forms.NumericUpDown();
            this.OffsetY = new System.Windows.Forms.NumericUpDown();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.ExpandY = new System.Windows.Forms.NumericUpDown();
            this.label18 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.Matrix2 = new System.Windows.Forms.NumericUpDown();
            this.label20 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.Correxion_btn = new System.Windows.Forms.Button();
            this.CheckL = new System.Windows.Forms.CheckBox();
            this.Limitvalue = new System.Windows.Forms.NumericUpDown();
            this.CheckPL = new System.Windows.Forms.CheckBox();
            this.Plimitvalue = new System.Windows.Forms.NumericUpDown();
            this.label28 = new System.Windows.Forms.Label();
            this.Rotation_angle = new System.Windows.Forms.NumericUpDown();
            this.label27 = new System.Windows.Forms.Label();
            this.toolstrip1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.StatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripComboBox1 = new System.Windows.Forms.ToolStripComboBox();
            this.Direction_combo = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.FitOrder)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NewCal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Tolerance)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Matrix)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ExpandX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.OffsetX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Length)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.OffsetY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ExpandY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Matrix2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Limitvalue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Plimitvalue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Rotation_angle)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.toolStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // FitOrder
            // 
            this.FitOrder.Location = new System.Drawing.Point(565, 186);
            this.FitOrder.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.FitOrder.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.FitOrder.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.FitOrder.Name = "FitOrder";
            this.FitOrder.Size = new System.Drawing.Size(120, 29);
            this.FitOrder.TabIndex = 0;
            this.FitOrder.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // Oldfile
            // 
            this.Oldfile.Location = new System.Drawing.Point(130, 66);
            this.Oldfile.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Oldfile.Name = "Oldfile";
            this.Oldfile.Size = new System.Drawing.Size(180, 29);
            this.Oldfile.TabIndex = 1;
            this.Oldfile.Text = "D3_1386";
            // 
            // Newname
            // 
            this.Newname.Location = new System.Drawing.Point(130, 122);
            this.Newname.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Newname.Name = "Newname";
            this.Newname.Size = new System.Drawing.Size(180, 29);
            this.Newname.TabIndex = 2;
            this.Newname.Text = "xxxx";
            // 
            // NewCal
            // 
            this.NewCal.Location = new System.Drawing.Point(565, 122);
            this.NewCal.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.NewCal.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.NewCal.Name = "NewCal";
            this.NewCal.Size = new System.Drawing.Size(120, 29);
            this.NewCal.TabIndex = 3;
            this.NewCal.Value = new decimal(new int[] {
            3120,
            0,
            0,
            0});
            // 
            // Tolerance
            // 
            this.Tolerance.Location = new System.Drawing.Point(565, 66);
            this.Tolerance.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Tolerance.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.Tolerance.Name = "Tolerance";
            this.Tolerance.Size = new System.Drawing.Size(120, 29);
            this.Tolerance.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 262);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 18);
            this.label1.TabIndex = 5;
            this.label1.Text = "Matrix";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(448, 190);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 18);
            this.label2.TabIndex = 6;
            this.label2.Text = "FitOrder";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(448, 128);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 18);
            this.label3.TabIndex = 7;
            this.label3.Text = "NewCal";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(448, 68);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 18);
            this.label4.TabIndex = 8;
            this.label4.Text = "Tolerance";
            // 
            // Matrix
            // 
            this.Matrix.Increment = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.Matrix.Location = new System.Drawing.Point(130, 260);
            this.Matrix.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Matrix.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.Matrix.Name = "Matrix";
            this.Matrix.Size = new System.Drawing.Size(78, 29);
            this.Matrix.TabIndex = 10;
            this.Matrix.Value = new decimal(new int[] {
            25,
            0,
            0,
            0});
            this.Matrix.ValueChanged += new System.EventHandler(this.Matrix_ValueChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(22, 131);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(88, 18);
            this.label6.TabIndex = 11;
            this.label6.Text = "NewCTFile";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(22, 68);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(81, 18);
            this.label7.TabIndex = 12;
            this.label7.Text = "OldCTFile";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(448, 338);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(95, 18);
            this.label8.TabIndex = 13;
            this.label8.Text = "Expansion X";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Cursor = System.Windows.Forms.Cursors.Default;
            this.label9.Location = new System.Drawing.Point(22, 338);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(71, 18);
            this.label9.TabIndex = 14;
            this.label9.Text = "X OffSet";
            // 
            // ExpandX
            // 
            this.ExpandX.DecimalPlaces = 3;
            this.ExpandX.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.ExpandX.Location = new System.Drawing.Point(565, 336);
            this.ExpandX.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ExpandX.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.ExpandX.Name = "ExpandX";
            this.ExpandX.Size = new System.Drawing.Size(120, 29);
            this.ExpandX.TabIndex = 15;
            // 
            // OffsetX
            // 
            this.OffsetX.DecimalPlaces = 3;
            this.OffsetX.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.OffsetX.Location = new System.Drawing.Point(130, 336);
            this.OffsetX.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.OffsetX.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.OffsetX.Name = "OffsetX";
            this.OffsetX.Size = new System.Drawing.Size(120, 29);
            this.OffsetX.TabIndex = 16;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(711, 338);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(34, 18);
            this.label10.TabIndex = 17;
            this.label10.Text = "mm";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(277, 338);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(34, 18);
            this.label11.TabIndex = 18;
            this.label11.Text = "mm";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(701, 130);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(57, 18);
            this.label12.TabIndex = 19;
            this.label12.Text = "bit/mm";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(701, 68);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(29, 18);
            this.label13.TabIndex = 20;
            this.label13.Text = "um";
            // 
            // Dat_btn
            // 
            this.Dat_btn.BackColor = System.Drawing.SystemColors.Control;
            this.Dat_btn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Dat_btn.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Dat_btn.Location = new System.Drawing.Point(6, 23);
            this.Dat_btn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Dat_btn.Name = "Dat_btn";
            this.Dat_btn.Size = new System.Drawing.Size(170, 40);
            this.Dat_btn.TabIndex = 21;
            this.Dat_btn.Text = "Creat Dat File";
            this.Dat_btn.UseVisualStyleBackColor = false;
            this.Dat_btn.Click += new System.EventHandler(this.Dat_btn_Click);
            // 
            // label
            // 
            this.label.AutoSize = true;
            this.label.Location = new System.Drawing.Point(22, 188);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(55, 18);
            this.label.TabIndex = 22;
            this.label.Text = "Length";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(277, 191);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(34, 18);
            this.label14.TabIndex = 24;
            this.label14.Text = "mm";
            // 
            // Length
            // 
            this.Length.Location = new System.Drawing.Point(130, 186);
            this.Length.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Length.Maximum = new decimal(new int[] {
            336081,
            0,
            0,
            196608});
            this.Length.Name = "Length";
            this.Length.Size = new System.Drawing.Size(120, 29);
            this.Length.TabIndex = 25;
            this.Length.Value = new decimal(new int[] {
            240,
            0,
            0,
            0});
            // 
            // OffsetY
            // 
            this.OffsetY.DecimalPlaces = 3;
            this.OffsetY.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.OffsetY.Location = new System.Drawing.Point(130, 398);
            this.OffsetY.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.OffsetY.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.OffsetY.Name = "OffsetY";
            this.OffsetY.Size = new System.Drawing.Size(120, 29);
            this.OffsetY.TabIndex = 26;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(277, 401);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(34, 18);
            this.label15.TabIndex = 27;
            this.label15.Text = "mm";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(22, 401);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(69, 18);
            this.label16.TabIndex = 28;
            this.label16.Text = "Y Offset";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(711, 404);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(34, 18);
            this.label17.TabIndex = 29;
            this.label17.Text = "mm";
            // 
            // ExpandY
            // 
            this.ExpandY.DecimalPlaces = 3;
            this.ExpandY.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.ExpandY.Location = new System.Drawing.Point(565, 401);
            this.ExpandY.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ExpandY.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.ExpandY.Name = "ExpandY";
            this.ExpandY.Size = new System.Drawing.Size(120, 29);
            this.ExpandY.TabIndex = 30;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(448, 404);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(95, 18);
            this.label18.TabIndex = 31;
            this.label18.Text = "Expansion Y";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(350, 264);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(49, 18);
            this.label19.TabIndex = 32;
            this.label19.Text = "points";
            // 
            // Matrix2
            // 
            this.Matrix2.Enabled = false;
            this.Matrix2.Location = new System.Drawing.Point(256, 262);
            this.Matrix2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Matrix2.Name = "Matrix2";
            this.Matrix2.Size = new System.Drawing.Size(78, 29);
            this.Matrix2.TabIndex = 33;
            this.Matrix2.Value = new decimal(new int[] {
            25,
            0,
            0,
            0});
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(224, 264);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(16, 18);
            this.label20.TabIndex = 34;
            this.label20.Text = "x";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(320, 126);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(33, 18);
            this.label21.TabIndex = 35;
            this.label21.Text = ".ct5";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(320, 68);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(33, 18);
            this.label22.TabIndex = 36;
            this.label22.Text = ".ct5";
            // 
            // Correxion_btn
            // 
            this.Correxion_btn.BackColor = System.Drawing.SystemColors.Control;
            this.Correxion_btn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Correxion_btn.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Correxion_btn.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Correxion_btn.Location = new System.Drawing.Point(6, 23);
            this.Correxion_btn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Correxion_btn.Name = "Correxion_btn";
            this.Correxion_btn.Size = new System.Drawing.Size(170, 40);
            this.Correxion_btn.TabIndex = 37;
            this.Correxion_btn.Text = "Correxion Pro";
            this.Correxion_btn.UseVisualStyleBackColor = false;
            this.Correxion_btn.Click += new System.EventHandler(this.Correxion_btn_Click);
            // 
            // CheckL
            // 
            this.CheckL.AutoSize = true;
            this.CheckL.Location = new System.Drawing.Point(446, 251);
            this.CheckL.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.CheckL.Name = "CheckL";
            this.CheckL.Size = new System.Drawing.Size(79, 22);
            this.CheckL.TabIndex = 39;
            this.CheckL.Text = "Limits";
            this.CheckL.UseVisualStyleBackColor = true;
            // 
            // Limitvalue
            // 
            this.Limitvalue.Location = new System.Drawing.Point(565, 248);
            this.Limitvalue.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Limitvalue.Name = "Limitvalue";
            this.Limitvalue.Size = new System.Drawing.Size(120, 29);
            this.Limitvalue.TabIndex = 40;
            // 
            // CheckPL
            // 
            this.CheckPL.AutoSize = true;
            this.CheckPL.Location = new System.Drawing.Point(446, 278);
            this.CheckPL.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.CheckPL.Name = "CheckPL";
            this.CheckPL.Size = new System.Drawing.Size(74, 22);
            this.CheckPL.TabIndex = 41;
            this.CheckPL.Text = "PolyL";
            this.CheckPL.UseVisualStyleBackColor = true;
            // 
            // Plimitvalue
            // 
            this.Plimitvalue.Location = new System.Drawing.Point(565, 278);
            this.Plimitvalue.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Plimitvalue.Name = "Plimitvalue";
            this.Plimitvalue.Size = new System.Drawing.Size(120, 29);
            this.Plimitvalue.TabIndex = 50;
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Location = new System.Drawing.Point(22, 463);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(66, 18);
            this.label28.TabIndex = 52;
            this.label28.Text = "Rotation";
            // 
            // Rotation_angle
            // 
            this.Rotation_angle.DecimalPlaces = 4;
            this.Rotation_angle.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.Rotation_angle.Location = new System.Drawing.Point(130, 460);
            this.Rotation_angle.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Rotation_angle.Maximum = new decimal(new int[] {
            360,
            0,
            0,
            0});
            this.Rotation_angle.Minimum = new decimal(new int[] {
            360,
            0,
            0,
            -2147483648});
            this.Rotation_angle.Name = "Rotation_angle";
            this.Rotation_angle.Size = new System.Drawing.Size(120, 29);
            this.Rotation_angle.TabIndex = 53;
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Location = new System.Drawing.Point(277, 463);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(54, 18);
            this.label27.TabIndex = 54;
            this.label27.Text = "degree";
            // 
            // toolstrip1
            // 
            this.toolstrip1.Name = "toolstrip1";
            this.toolstrip1.Size = new System.Drawing.Size(77, 23);
            this.toolstrip1.Text = "Waiting";
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolstrip1,
            this.toolStripStatusLabel3,
            this.toolStripStatusLabel2,
            this.toolStripStatusLabel1,
            this.StatusLabel2});
            this.statusStrip1.Location = new System.Drawing.Point(0, 572);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(812, 28);
            this.statusStrip1.TabIndex = 43;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel3
            // 
            this.toolStripStatusLabel3.Name = "toolStripStatusLabel3";
            this.toolStripStatusLabel3.Size = new System.Drawing.Size(295, 23);
            this.toolStripStatusLabel3.Text = "                                                         ";
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(171, 23);
            this.toolStripStatusLabel2.Text = "Scanner Direction :";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(0, 23);
            // 
            // StatusLabel2
            // 
            this.StatusLabel2.Name = "StatusLabel2";
            this.StatusLabel2.Size = new System.Drawing.Size(0, 23);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.Dat_btn);
            this.groupBox1.Location = new System.Drawing.Point(413, 492);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Size = new System.Drawing.Size(186, 72);
            this.groupBox1.TabIndex = 56;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Dat File";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.Correxion_btn);
            this.groupBox2.Location = new System.Drawing.Point(614, 492);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox2.Size = new System.Drawing.Size(186, 72);
            this.groupBox2.TabIndex = 57;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Correxion Pro";
            // 
            // toolStrip2
            // 
            this.toolStrip2.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1,
            this.toolStripComboBox1});
            this.toolStrip2.Location = new System.Drawing.Point(0, 0);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(812, 31);
            this.toolStrip2.TabIndex = 58;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(104, 28);
            this.toolStripLabel1.Text = "AMP Type :";
            // 
            // toolStripComboBox1
            // 
            this.toolStripComboBox1.Items.AddRange(new object[] {
            "AMP-160",
            "AMP-250",
            "AMP-500"});
            this.toolStripComboBox1.Name = "toolStripComboBox1";
            this.toolStripComboBox1.Size = new System.Drawing.Size(136, 31);
            this.toolStripComboBox1.TextChanged += new System.EventHandler(this.toolStripComboBox1_Click);
            // 
            // Direction_combo
            // 
            this.Direction_combo.FormattingEnabled = true;
            this.Direction_combo.Items.AddRange(new object[] {
            "Right (AMP-250)",
            "Back (AMP-160)",
            "Left"});
            this.Direction_combo.Location = new System.Drawing.Point(161, 521);
            this.Direction_combo.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Direction_combo.Name = "Direction_combo";
            this.Direction_combo.Size = new System.Drawing.Size(212, 26);
            this.Direction_combo.TabIndex = 62;
            this.Direction_combo.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(22, 524);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(129, 18);
            this.label5.TabIndex = 63;
            this.label5.Text = "Scanner direction";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoSize = true;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(812, 600);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.Direction_combo);
            this.Controls.Add(this.toolStrip2);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label27);
            this.Controls.Add(this.Rotation_angle);
            this.Controls.Add(this.label28);
            this.Controls.Add(this.Plimitvalue);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.CheckPL);
            this.Controls.Add(this.Limitvalue);
            this.Controls.Add(this.CheckL);
            this.Controls.Add(this.label22);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.Matrix2);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.ExpandY);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.OffsetY);
            this.Controls.Add(this.Length);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.OffsetX);
            this.Controls.Add(this.ExpandX);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.Matrix);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Tolerance);
            this.Controls.Add(this.NewCal);
            this.Controls.Add(this.Newname);
            this.Controls.Add(this.Oldfile);
            this.Controls.Add(this.FitOrder);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.DoubleBuffered = true;
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.HelpButton = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximumSize = new System.Drawing.Size(838, 660);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "ScannerCalibration";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.FitOrder)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NewCal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Tolerance)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Matrix)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ExpandX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.OffsetX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Length)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.OffsetY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ExpandY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Matrix2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Limitvalue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Plimitvalue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Rotation_angle)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown FitOrder;
        private System.Windows.Forms.TextBox Oldfile;
        private System.Windows.Forms.TextBox Newname;
        private System.Windows.Forms.NumericUpDown NewCal;
        private System.Windows.Forms.NumericUpDown Tolerance;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown Matrix;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.NumericUpDown ExpandX;
        private System.Windows.Forms.NumericUpDown OffsetX;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Button Dat_btn;
        private System.Windows.Forms.Label label;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.NumericUpDown Length;
        private System.Windows.Forms.NumericUpDown OffsetY;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.NumericUpDown ExpandY;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.NumericUpDown Matrix2;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Button Correxion_btn;
        private System.Windows.Forms.CheckBox CheckL;
        private System.Windows.Forms.NumericUpDown Limitvalue;
        private System.Windows.Forms.CheckBox CheckPL;
        private System.Windows.Forms.NumericUpDown Plimitvalue;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.NumericUpDown Rotation_angle;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.ToolStripStatusLabel toolstrip1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ComboBox Direction_combo;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel StatusLabel2;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel3;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripComboBox toolStripComboBox1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
    }
}

