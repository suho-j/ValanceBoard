namespace BodyType
{
    partial class MainForm
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series5 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series6 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series7 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series8 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.serialPort = new System.IO.Ports.SerialPort(this.components);
            this.txtName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.lblBottom = new System.Windows.Forms.Label();
            this.lblRight = new System.Windows.Forms.Label();
            this.lblLeft = new System.Windows.Forms.Label();
            this.lblTop = new System.Windows.Forms.Label();
            this.lblRound = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.zedTop = new ZedGraph.ZedGraphControl();
            this.zedBottom = new ZedGraph.ZedGraphControl();
            this.zedRight = new ZedGraph.ZedGraphControl();
            this.zedLeft = new ZedGraph.ZedGraphControl();
            this.btnHist = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnStop = new System.Windows.Forms.Button();
            this.btnRead = new System.Windows.Forms.Button();
            this.btnAnalysis = new System.Windows.Forms.Button();
            this.btnAutoStartEnd = new System.Windows.Forms.Button();
            this.btnStartEnd = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.btnOpen = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // serialPort
            // 
            this.serialPort.BaudRate = 38400;
            this.serialPort.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.serialPort_DataReceived);
            // 
            // txtName
            // 
            this.txtName.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtName.Location = new System.Drawing.Point(1233, 59);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(142, 21);
            this.txtName.TabIndex = 54;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.Font = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(1241, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(125, 28);
            this.label2.TabIndex = 55;
            this.label2.Text = "사용자 명";
            // 
            // chart1
            // 
            this.chart1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.chart1.BorderlineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid;
            this.chart1.BorderSkin.BackColor = System.Drawing.Color.White;
            this.chart1.BorderSkin.BorderColor = System.Drawing.Color.White;
            chartArea2.AxisX.LabelStyle.ForeColor = System.Drawing.Color.White;
            chartArea2.AxisX.MajorGrid.LineColor = System.Drawing.Color.White;
            chartArea2.AxisX.MajorTickMark.LineColor = System.Drawing.Color.White;
            chartArea2.AxisX.MinorGrid.LineColor = System.Drawing.Color.White;
            chartArea2.AxisX.MinorTickMark.LineColor = System.Drawing.Color.White;
            chartArea2.AxisX2.MajorGrid.LineColor = System.Drawing.Color.White;
            chartArea2.AxisX2.MajorTickMark.LineColor = System.Drawing.Color.White;
            chartArea2.AxisX2.MinorGrid.LineColor = System.Drawing.Color.White;
            chartArea2.AxisX2.MinorTickMark.LineColor = System.Drawing.Color.White;
            chartArea2.AxisY.LabelStyle.ForeColor = System.Drawing.Color.White;
            chartArea2.AxisY.LineColor = System.Drawing.Color.White;
            chartArea2.AxisY.MajorGrid.LineColor = System.Drawing.Color.White;
            chartArea2.AxisY.MajorTickMark.LineColor = System.Drawing.Color.White;
            chartArea2.AxisY.MinorGrid.LineColor = System.Drawing.Color.White;
            chartArea2.AxisY.MinorTickMark.LineColor = System.Drawing.Color.White;
            chartArea2.AxisY2.MajorGrid.LineColor = System.Drawing.Color.White;
            chartArea2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            chartArea2.BackSecondaryColor = System.Drawing.Color.White;
            chartArea2.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea2);
            this.chart1.Dock = System.Windows.Forms.DockStyle.Fill;
            legend2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            legend2.Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Top;
            legend2.Enabled = false;
            legend2.ForeColor = System.Drawing.Color.White;
            legend2.Name = "Legend1";
            this.chart1.Legends.Add(legend2);
            this.chart1.Location = new System.Drawing.Point(0, 0);
            this.chart1.Name = "chart1";
            series5.ChartArea = "ChartArea1";
            series5.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Polar;
            series5.Color = System.Drawing.Color.Red;
            series5.LabelBackColor = System.Drawing.Color.White;
            series5.LabelBorderColor = System.Drawing.Color.White;
            series5.LabelForeColor = System.Drawing.Color.White;
            series5.Legend = "Legend1";
            series5.Name = "line";
            series6.ChartArea = "ChartArea1";
            series6.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Polar;
            series6.Color = System.Drawing.Color.Blue;
            series6.Legend = "Legend1";
            series6.Name = "point";
            series7.BorderWidth = 3;
            series7.ChartArea = "ChartArea1";
            series7.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Polar;
            series7.LabelBorderWidth = 3;
            series7.Legend = "Legend1";
            series7.MarkerBorderWidth = 3;
            series7.Name = "round";
            series8.BorderDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dot;
            series8.ChartArea = "ChartArea1";
            series8.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Polar;
            series8.Color = System.Drawing.Color.Transparent;
            series8.Legend = "Legend1";
            series8.MarkerBorderColor = System.Drawing.Color.Lime;
            series8.MarkerColor = System.Drawing.Color.Lime;
            series8.MarkerImageTransparentColor = System.Drawing.Color.Transparent;
            series8.MarkerSize = 10;
            series8.MarkerStyle = System.Windows.Forms.DataVisualization.Charting.MarkerStyle.Circle;
            series8.Name = "spot";
            series8.ShadowColor = System.Drawing.Color.Transparent;
            series8.YValuesPerPoint = 2;
            this.chart1.Series.Add(series5);
            this.chart1.Series.Add(series6);
            this.chart1.Series.Add(series7);
            this.chart1.Series.Add(series8);
            this.chart1.Size = new System.Drawing.Size(682, 666);
            this.chart1.TabIndex = 58;
            this.chart1.Text = "chart1";
            // 
            // lblBottom
            // 
            this.lblBottom.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblBottom.AutoSize = true;
            this.lblBottom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.lblBottom.Font = new System.Drawing.Font("굴림", 13F);
            this.lblBottom.ForeColor = System.Drawing.Color.White;
            this.lblBottom.Location = new System.Drawing.Point(393, 735);
            this.lblBottom.Name = "lblBottom";
            this.lblBottom.Size = new System.Drawing.Size(18, 18);
            this.lblBottom.TabIndex = 43;
            this.lblBottom.Text = "0";
            // 
            // lblRight
            // 
            this.lblRight.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblRight.AutoSize = true;
            this.lblRight.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.lblRight.Font = new System.Drawing.Font("굴림", 13F);
            this.lblRight.ForeColor = System.Drawing.Color.White;
            this.lblRight.Location = new System.Drawing.Point(749, 383);
            this.lblRight.Name = "lblRight";
            this.tableLayoutPanel1.SetRowSpan(this.lblRight, 12);
            this.lblRight.Size = new System.Drawing.Size(18, 18);
            this.lblRight.TabIndex = 45;
            this.lblRight.Text = "0";
            // 
            // lblLeft
            // 
            this.lblLeft.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblLeft.AutoSize = true;
            this.lblLeft.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.lblLeft.Font = new System.Drawing.Font("굴림", 13F);
            this.lblLeft.ForeColor = System.Drawing.Color.White;
            this.lblLeft.Location = new System.Drawing.Point(3, 383);
            this.lblLeft.Name = "lblLeft";
            this.tableLayoutPanel1.SetRowSpan(this.lblLeft, 12);
            this.lblLeft.Size = new System.Drawing.Size(18, 18);
            this.lblLeft.TabIndex = 44;
            this.lblLeft.Text = "0";
            // 
            // lblTop
            // 
            this.lblTop.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblTop.AutoSize = true;
            this.lblTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.lblTop.Font = new System.Drawing.Font("굴림", 13F);
            this.lblTop.ForeColor = System.Drawing.Color.White;
            this.lblTop.Location = new System.Drawing.Point(393, 33);
            this.lblTop.Name = "lblTop";
            this.lblTop.Size = new System.Drawing.Size(18, 18);
            this.lblTop.TabIndex = 42;
            this.lblTop.Text = "0";
            // 
            // lblRound
            // 
            this.lblRound.AutoSize = true;
            this.lblRound.Font = new System.Drawing.Font("굴림", 25F, System.Drawing.FontStyle.Bold);
            this.lblRound.ForeColor = System.Drawing.Color.Yellow;
            this.lblRound.Location = new System.Drawing.Point(0, 0);
            this.lblRound.Name = "lblRound";
            this.lblRound.Size = new System.Drawing.Size(36, 34);
            this.lblRound.TabIndex = 59;
            this.lblRound.Text = "0";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblRound);
            this.panel1.Controls.Add(this.chart1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(61, 59);
            this.panel1.Name = "panel1";
            this.tableLayoutPanel1.SetRowSpan(this.panel1, 12);
            this.panel1.Size = new System.Drawing.Size(682, 666);
            this.panel1.TabIndex = 60;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 5;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 4.709576F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 55.88697F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 4.866562F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 34.53689F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 146F));
            this.tableLayoutPanel1.Controls.Add(this.lblRight, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.lblTop, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblLeft, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.zedTop, 3, 2);
            this.tableLayoutPanel1.Controls.Add(this.zedBottom, 3, 8);
            this.tableLayoutPanel1.Controls.Add(this.lblBottom, 1, 14);
            this.tableLayoutPanel1.Controls.Add(this.zedRight, 3, 12);
            this.tableLayoutPanel1.Controls.Add(this.zedLeft, 3, 10);
            this.tableLayoutPanel1.Controls.Add(this.btnHist, 4, 11);
            this.tableLayoutPanel1.Controls.Add(this.btnClear, 4, 12);
            this.tableLayoutPanel1.Controls.Add(this.panel2, 4, 13);
            this.tableLayoutPanel1.Controls.Add(this.btnAnalysis, 4, 10);
            this.tableLayoutPanel1.Controls.Add(this.txtName, 4, 2);
            this.tableLayoutPanel1.Controls.Add(this.label2, 4, 1);
            this.tableLayoutPanel1.Controls.Add(this.btnAutoStartEnd, 4, 7);
            this.tableLayoutPanel1.Controls.Add(this.btnStartEnd, 4, 8);
            this.tableLayoutPanel1.Controls.Add(this.button1, 4, 9);
            this.tableLayoutPanel1.Controls.Add(this.btnOpen, 4, 3);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 15;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 3.896104F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 3.896104F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 3.896104F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 22F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 1.754386F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 1.217862F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.006766F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.96076F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.23139F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.90798F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.82544F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.38961F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.38961F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.38961F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 3.896104F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1378, 761);
            this.tableLayoutPanel1.TabIndex = 60;
            // 
            // zedTop
            // 
            this.zedTop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.zedTop.Enabled = false;
            this.zedTop.ForeColor = System.Drawing.Color.Black;
            this.zedTop.Location = new System.Drawing.Point(808, 59);
            this.zedTop.Name = "zedTop";
            this.tableLayoutPanel1.SetRowSpan(this.zedTop, 6);
            this.zedTop.ScrollGrace = 0D;
            this.zedTop.ScrollMaxX = 0D;
            this.zedTop.ScrollMaxY = 0D;
            this.zedTop.ScrollMaxY2 = 0D;
            this.zedTop.ScrollMinX = 0D;
            this.zedTop.ScrollMinY = 0D;
            this.zedTop.ScrollMinY2 = 0D;
            this.zedTop.Size = new System.Drawing.Size(419, 184);
            this.zedTop.TabIndex = 48;
            // 
            // zedBottom
            // 
            this.zedBottom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.zedBottom.Enabled = false;
            this.zedBottom.Location = new System.Drawing.Point(808, 249);
            this.zedBottom.Name = "zedBottom";
            this.tableLayoutPanel1.SetRowSpan(this.zedBottom, 2);
            this.zedBottom.ScrollGrace = 0D;
            this.zedBottom.ScrollMaxX = 0D;
            this.zedBottom.ScrollMaxY = 0D;
            this.zedBottom.ScrollMaxY2 = 0D;
            this.zedBottom.ScrollMinX = 0D;
            this.zedBottom.ScrollMinY = 0D;
            this.zedBottom.ScrollMinY2 = 0D;
            this.zedBottom.Size = new System.Drawing.Size(419, 165);
            this.zedBottom.TabIndex = 49;
            // 
            // zedRight
            // 
            this.zedRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.zedRight.Enabled = false;
            this.zedRight.Location = new System.Drawing.Point(808, 577);
            this.zedRight.Name = "zedRight";
            this.tableLayoutPanel1.SetRowSpan(this.zedRight, 2);
            this.zedRight.ScrollGrace = 0D;
            this.zedRight.ScrollMaxX = 0D;
            this.zedRight.ScrollMaxY = 0D;
            this.zedRight.ScrollMaxY2 = 0D;
            this.zedRight.ScrollMinX = 0D;
            this.zedRight.ScrollMinY = 0D;
            this.zedRight.ScrollMinY2 = 0D;
            this.zedRight.Size = new System.Drawing.Size(419, 148);
            this.zedRight.TabIndex = 51;
            // 
            // zedLeft
            // 
            this.zedLeft.Dock = System.Windows.Forms.DockStyle.Fill;
            this.zedLeft.Enabled = false;
            this.zedLeft.Location = new System.Drawing.Point(808, 420);
            this.zedLeft.Name = "zedLeft";
            this.tableLayoutPanel1.SetRowSpan(this.zedLeft, 2);
            this.zedLeft.ScrollGrace = 0D;
            this.zedLeft.ScrollMaxX = 0D;
            this.zedLeft.ScrollMaxY = 0D;
            this.zedLeft.ScrollMaxY2 = 0D;
            this.zedLeft.ScrollMinX = 0D;
            this.zedLeft.ScrollMinY = 0D;
            this.zedLeft.ScrollMinY2 = 0D;
            this.zedLeft.Size = new System.Drawing.Size(419, 151);
            this.zedLeft.TabIndex = 50;
            // 
            // btnHist
            // 
            this.btnHist.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnHist.Image = ((System.Drawing.Image)(resources.GetObject("btnHist.Image")));
            this.btnHist.Location = new System.Drawing.Point(1257, 504);
            this.btnHist.Name = "btnHist";
            this.btnHist.Size = new System.Drawing.Size(93, 62);
            this.btnHist.TabIndex = 57;
            this.btnHist.UseVisualStyleBackColor = true;
            this.btnHist.Click += new System.EventHandler(this.btnHist_Click);
            // 
            // btnClear
            // 
            this.btnClear.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnClear.Image = ((System.Drawing.Image)(resources.GetObject("btnClear.Image")));
            this.btnClear.Location = new System.Drawing.Point(1257, 581);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(93, 62);
            this.btnClear.TabIndex = 38;
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnStop);
            this.panel2.Controls.Add(this.btnRead);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(1233, 654);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(142, 71);
            this.panel2.TabIndex = 61;
            // 
            // btnStop
            // 
            this.btnStop.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnStop.Image = ((System.Drawing.Image)(resources.GetObject("btnStop.Image")));
            this.btnStop.Location = new System.Drawing.Point(26, 4);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(93, 62);
            this.btnStop.TabIndex = 52;
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Visible = false;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // btnRead
            // 
            this.btnRead.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnRead.Image = ((System.Drawing.Image)(resources.GetObject("btnRead.Image")));
            this.btnRead.Location = new System.Drawing.Point(26, 3);
            this.btnRead.Name = "btnRead";
            this.btnRead.Size = new System.Drawing.Size(93, 62);
            this.btnRead.TabIndex = 39;
            this.btnRead.UseVisualStyleBackColor = true;
            this.btnRead.Click += new System.EventHandler(this.btnRead_Click);
            // 
            // btnAnalysis
            // 
            this.btnAnalysis.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnAnalysis.Image = ((System.Drawing.Image)(resources.GetObject("btnAnalysis.Image")));
            this.btnAnalysis.Location = new System.Drawing.Point(1257, 426);
            this.btnAnalysis.Name = "btnAnalysis";
            this.btnAnalysis.Size = new System.Drawing.Size(93, 62);
            this.btnAnalysis.TabIndex = 40;
            this.btnAnalysis.UseVisualStyleBackColor = true;
            this.btnAnalysis.Click += new System.EventHandler(this.btnAnalysis_Click);
            // 
            // btnAutoStartEnd
            // 
            this.btnAutoStartEnd.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnAutoStartEnd.Image = ((System.Drawing.Image)(resources.GetObject("btnAutoStartEnd.Image")));
            this.btnAutoStartEnd.Location = new System.Drawing.Point(1257, 174);
            this.btnAutoStartEnd.Name = "btnAutoStartEnd";
            this.btnAutoStartEnd.Size = new System.Drawing.Size(93, 63);
            this.btnAutoStartEnd.TabIndex = 56;
            this.btnAutoStartEnd.UseVisualStyleBackColor = true;
            this.btnAutoStartEnd.Click += new System.EventHandler(this.btnAutoStartEnd_Click);
            // 
            // btnStartEnd
            // 
            this.btnStartEnd.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnStartEnd.Image = ((System.Drawing.Image)(resources.GetObject("btnStartEnd.Image")));
            this.btnStartEnd.Location = new System.Drawing.Point(1257, 256);
            this.btnStartEnd.Name = "btnStartEnd";
            this.btnStartEnd.Size = new System.Drawing.Size(93, 63);
            this.btnStartEnd.TabIndex = 37;
            this.btnStartEnd.UseVisualStyleBackColor = true;
            this.btnStartEnd.Click += new System.EventHandler(this.btnStartEnd_Click);
            // 
            // button1
            // 
            this.button1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button1.Image = global::BodyType.Properties.Resources.분포도;
            this.button1.Location = new System.Drawing.Point(1257, 341);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(93, 63);
            this.button1.TabIndex = 62;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnOpen
            // 
            this.btnOpen.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnOpen.Image = ((System.Drawing.Image)(resources.GetObject("btnOpen.Image")));
            this.btnOpen.Location = new System.Drawing.Point(1257, 93);
            this.btnOpen.Name = "btnOpen";
            this.tableLayoutPanel1.SetRowSpan(this.btnOpen, 4);
            this.btnOpen.Size = new System.Drawing.Size(93, 63);
            this.btnOpen.TabIndex = 53;
            this.btnOpen.UseVisualStyleBackColor = true;
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.ClientSize = new System.Drawing.Size(1378, 761);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "MainForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Body type analysis";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnStartEnd;
        private System.Windows.Forms.Button btnAnalysis;
        private System.Windows.Forms.Button btnRead;
        private System.IO.Ports.SerialPort serialPort;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Button btnOpen;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnAutoStartEnd;
        private System.Windows.Forms.Button btnHist;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.Label lblBottom;
        private System.Windows.Forms.Label lblRight;
        private System.Windows.Forms.Label lblLeft;
        private System.Windows.Forms.Label lblTop;
        private System.Windows.Forms.Label lblRound;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel2;
        private ZedGraph.ZedGraphControl zedTop;
        private ZedGraph.ZedGraphControl zedBottom;
        private ZedGraph.ZedGraphControl zedLeft;
        private ZedGraph.ZedGraphControl zedRight;
        private System.Windows.Forms.Button button1;
    }
}

