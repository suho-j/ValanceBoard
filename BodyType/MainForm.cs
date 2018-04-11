using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using ZedGraph;
using AForge;
using AForge.Imaging;
using AForge.Imaging.Filters;
using AForge.Math.Geometry;
using System.Diagnostics;
using System.Text.RegularExpressions;
using Microsoft.Win32;
using System.Management;
using InTheHand.Net.Sockets;
using InTheHand.Net;
using InTheHand.Net.Bluetooth;

namespace BodyType
{
    public partial class MainForm : Form
    {
        #region field
        //차트 관련
        private Series S1;
        private Series S2;
        private Series S3;
        private Series S4;

        private List<PointF> cirPoints;
        private List<IntPoint> sqPoints;
        private List<IntPoint> resultPoints;
        private List<int> listIndex;

        /// <summary>
        /// txtReadWrite 객체
        /// </summary>
        private txtReadWrite txtRW;
        /// <summary>
        /// PointController 객체
        /// </summary>
        private PointController pointControll;
        /// <summary>
        /// 히스토그램을 위한 List
        /// </summary>
        private List<PointXY> histPoints;
        /// <summary>
        /// Convex Hull을 위한 List
        /// </summary>
        private List<IntPoint> points;
        /// <summary>
        /// 10초간 측정을 위한 변수
        /// </summary>
        private Stopwatch sw;
        /// <summary>
        /// 10초간 측정을 위한 변수
        /// </summary>
        private TimeSpan ts;
        /// <summary>
        /// 블루투스 포트
        /// </summary>
        private string port;
        /// <summary>
        /// ZedGraph Y축 변수
        /// </summary>
        private double zedCnt;
        /// <summary>
        /// w1: Top /
        /// w2: Bottom /
        /// w3: Left /
        /// w4: Right 
        /// </summary>
        private float w1, w2, w3, w4;
        #endregion

        #region field bool
        /// <summary>
        /// true: 시리얼 오픈, false: 시리얼 클로즈
        /// </summary>
        private bool portFlag;
        /// <summary>
        /// true: 수동 측정 중지, false: 수동 측정 시작
        /// </summary>
        private bool StartEndFlag;
        /// <summary>
        /// true: 리플레이 중단, false: 리플레이 재생
        /// </summary>
        private bool stopFlag;
        /// <summary>
        /// true: 경로 그리기, false: 경로 그리지 않기
        /// </summary>
        private bool lineFlag;
        /// <summary>
        /// true: 오토, false: 수동
        /// </summary>
        private bool autoStart;
        /// <summary>
        /// true: 초기화x, false: 보드 완전 초기화
        /// 시연 시나리오에 따라서 추가된 변수
        /// </summary>
        private bool initFlag;
        /// <summary>
        /// true: zeroset, false: zeroSet x
        /// </summary>
        private bool zeroSetFlag;
        #endregion

        #region field const
        /// <summary>
        /// 경로 라인 보정 값
        /// </summary>
        private const int lineXY = 20;
        /// <summary>
        /// 값이 클수록 작아짐
        /// </summary>
        private const int circleSize = 35;
        /// <summary>
        /// 스크린 해상도에 따른 보정 값
        /// </summary>
        private const int screen = 5;
        /// <summary>
        /// 자동측정 라인의 컬러 변화 정도
        /// </summary>
        private const int lineColor = 5;
        /// <summary>
        /// 경로 라인의 굵기
        /// </summary>
        private const int lineWidth = 1;
        #endregion

        #region Init
        public MainForm()
        {
            InitializeComponent();
            
            Init();
        }

        /// <summary>
        /// 초기화 함수
        /// </summary>
        private void Init()
        {
            S1 = chart1.Series[0];

            S1.ChartType = SeriesChartType.Polar;
            S1.Color = Color.Red;

            S2 = chart1.Series[1];
            S2.ChartType = SeriesChartType.Polar;
            S2.MarkerStyle = MarkerStyle.Circle;
            S2.MarkerSize = 40;

            S3 = chart1.Series[2];
            S3.ChartType = SeriesChartType.Polar;
            S3.Color = Color.Yellow;

            S4 = chart1.Series[3];
            S4.ChartType = SeriesChartType.Polar;

            txtRW = new txtReadWrite();
            pointControll = new PointController();
            points = new List<IntPoint>();
            histPoints = new List<PointXY>();
            cirPoints = new List<PointF>();
            sqPoints = new List<IntPoint>();
            listIndex = new List<int>();

            zedInit(zedTop, Color.Red, "TOP");
            zedInit(zedBottom, Color.Yellow, "BOTTOM");
            zedInit(zedLeft, Color.SpringGreen, "LEFT");
            zedInit(zedRight, Color.HotPink, "RIGHT");
            
            zedCnt = 0;
            lblBottom.Text = "0";
            lblLeft.Text = "0";
            lblRight.Text = "0";
            lblTop.Text = "0";

            sw = new Stopwatch();
            ts = sw.Elapsed;

            lblRound.Visible = false;
            StartEndFlag = false;
            autoStart = false;
            initFlag = false;
            portClose();

            S1.Points.Clear();
            S2.Points.Clear();
            S3.Points.Clear();
            S4.Points.Clear();
        }
        #endregion

        #region Event
        /// <summary>
        /// 폼 종료 이벤트
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            //포트 종료 및 강제 프로세스 종료
            portClose();
            System.Diagnostics.Process[] mProcess = System.Diagnostics.Process.GetProcessesByName(Application.ProductName);
            foreach (System.Diagnostics.Process p in mProcess)
                p.Kill();
        }

        /// <summary>
        /// 시리얼 포트에서 데이터가 들어올때 발생하는 이벤트
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void serialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            if (portFlag)
            {
                string serialRead = serialPort.ReadLine();

                //수동 측정일때
                if (serialPort.IsOpen && !autoStart)
                {
                    drawBodyType(serialRead);

                    //라인을 그릴때는 데이터를 저장
                    if (lineFlag)
                        txtRW.saveStr(serialRead);
                }
                //오토 측정일때
                else if (autoStart)
                {
                    //시간 측정 시작
                    sw.Start();

                    drawBodyType(serialRead);
                    txtRW.saveStr(serialRead);

                    //10초간 측정
                    if (sw.Elapsed.Seconds > 10)
                    {
                        if (serialPort.IsOpen)
                        {
                            portClose();
                            sw.Stop();
                            MessageBox.Show("자동 측정이 완료되었습니다.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        txtRW.txtWriter(txtName.Text);
                    }
                }
            }
        }

        /// <summary>
        /// 초기화 버튼
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClear_Click(object sender, EventArgs e)
        {
            Init();
        }

        /// <summary>
        /// 불러오기 이벤트
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRead_Click(object sender, EventArgs e)
        {
            //파일 읽어오기위한 변수
            List<string> txtRead = null;
            lineFlag = true;

            DialogResult dr = MessageBox.Show("기존 데이터가 초기화됩니다. 진행하시겠습니까?", "Info", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (dr == DialogResult.Yes)
            {
                Init();

                OpenFileDialog ofd = new OpenFileDialog();
                ofd.Filter = "Text|*.txt";
                ofd.InitialDirectory = Application.StartupPath + @"\Data";
                ofd.ShowDialog();

                if (ofd.FileName != "")
                {
                    if (!txtRW.txtReader(ofd.FileName))
                    {
                        MessageBox.Show("파일 읽어오기 오류", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    txtRead = txtRW.getList();

                    //리플레이 중단 버튼 보이게
                    btnStop.Visible = true;

                    foreach (string data in txtRead)
                    {
                        drawBodyType(data);
                        if (stopFlag)
                        {
                            //리플레이 중단 버튼 안보이게
                            btnStop.Visible = false;
                            stopFlag = false;
                            return;
                        }
                        Delay(100);
                    }
                    //리플레이 중단 버튼 안보이게
                    btnStop.Visible = false;
                }
            }
        }        

        /// <summary>
        /// 리플레이 중단 버튼 이벤트
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnStop_Click(object sender, EventArgs e)
        {
            stopFlag = true;
            btnStop.Visible = false;
        }

        /// <summary>
        /// 시리얼 연결 버튼 이벤트
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOpen_Click(object sender, EventArgs e)
        {
            if (!serialPort.IsOpen)
            {
                S1.Points.Clear();
                initFlag = false;
                
                portOpen();
                //경로를 그리지 않고 중심만 잡기위함.
                lineFlag = false;
            }
            else
            {
                portClose();
            }
        }

        /// <summary>
        /// 자동 측정 버튼 이벤트
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAutoStartEnd_Click(object sender, EventArgs e)
        {
            if (!serialPort.IsOpen)
            {
                Init();     //초기화
                S1.Points.Clear();
                
                portOpen();     //시리얼 오픈
            }
            S1.Points.Clear();
            autoStart = true;
            lineFlag = true;
        }

        /// <summary>
        /// 수동측정 버튼 이벤트
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnStartEnd_Click(object sender, EventArgs e)
        {
            if (!StartEndFlag)       //START
            {
                if (!serialPort.IsOpen)
                {
                    initFlag = true;
                    
                    portOpen();
                }
                S1.Points.Clear();
                autoStart = false;
                lineFlag = true;
                StartEndFlag = true;
            }
            else                   //END
            {
                if (serialPort.IsOpen)
                {
                    portClose();
                }
                StartEndFlag = false;

                DialogResult dr = MessageBox.Show("저장하시겠습니까?", "SAVE", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (dr == DialogResult.Yes)
                {
                    txtRW.txtWriter(txtName.Text);
                }
            }
        }

        /// <summary>
        /// 분석 버튼 이벤트
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAnalysis_Click(object sender, EventArgs e)
        {
            if(sqPoints.Count() <= 0)
                transfer();

            if (sqPoints.Count() > 2)
            {
                // Convex Hull 라이브러리
                IConvexHullAlgorithm hullFinder = new GrahamConvexHull();
                resultPoints = hullFinder.FindHull(sqPoints);

                IntPoint[] ip = resultPoints.ToArray();
                PointF[] pointf = new PointF[ip.Count<IntPoint>()];

                for (int i = 0; i < ip.Length; i++)
                {
                    pointf[i].X = ip[i].X;
                    pointf[i].Y = ip[i].Y;
                }

                for (int i = 0; i < resultPoints.Count; i++)
                {
                    for (int j = 0; j < sqPoints.Count; j++)
                    {
                        if (sqPoints[j] == resultPoints[i])
                        {
                            listIndex.Add(j);
                        }
                    }
                }

                //Convex Hull 둘레 측정
                double round = getRound(ip);
                int x = panel1.Size.Width / 2;
                int y = panel1.Size.Height / 2;
                System.Drawing.Point p = new System.Drawing.Point(x, y);
                lblRound.Location = p;
                lblRound.Visible = true;
                lblRound.Text = round.ToString("##.##");

                foreach (int t in listIndex)
                {
                    S3.Points.AddXY(cirPoints[t].X, cirPoints[t].Y);
                }
                S1.Points.Clear();
                S2.Points.Clear();
                S4.Points.Clear();
                S3.Points.AddXY(cirPoints[listIndex[0]].X, cirPoints[listIndex[0]].Y);
            }
            else
                MessageBox.Show("데이터가 부족합니다.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        
        /// <summary>
        /// 히스토그램 버튼 이벤트
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnHist_Click(object sender, EventArgs e)
        {
            if(sqPoints.Count() <= 0)
                transfer();

            if (sqPoints.Count() > 2)
            {
                HistForm histForm = new HistForm(histPoints);
                histForm.ShowDialog();
            }
            else
                MessageBox.Show("데이터가 부족합니다.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        #endregion

        #region private ZedGraph method
        /// <summary>
        /// ZedGraph 초기화
        /// </summary>
        /// <param name="zed">ZedGraphControl</param>
        /// <param name="lineColor">Color</param>
        /// <param name="title">title</param>
        private void zedInit(ZedGraphControl zed, Color lineColor, string title)
        {
            zed.GraphPane.CurveList.Clear();
            zed.GraphPane.GraphObjList.Clear();
            zed.Refresh();

            GraphPane myPane = zed.GraphPane;
            myPane.Title.Text = title;
            myPane.XAxis.Title.Text = "count";
            myPane.YAxis.Title.Text = "weight";
            myPane.XAxis.Title.IsVisible = false;
            myPane.YAxis.Title.IsVisible = false;
            myPane.XAxis.Scale.FontSpec.FontColor = Color.White;
            myPane.YAxis.Scale.FontSpec.FontColor = Color.White;
            myPane.Title.FontSpec.FontColor = Color.White;
            myPane.Border.Color = Color.White;
            myPane.Chart.Border.Color = Color.White;
            myPane.Fill = new Fill(Color.FromArgb(43, 30, 30));
            myPane.Chart.Fill = new Fill(Color.FromArgb(43, 30, 30));

            RollingPointPairList list = new RollingPointPairList(60000);

            LineItem curve = myPane.AddCurve(title, list, lineColor, SymbolType.None);

            myPane.XAxis.Scale.Min = 0;
            myPane.XAxis.Scale.Max = 30;
            myPane.XAxis.Scale.MinorStep = 1;
            myPane.XAxis.Scale.MajorStep = 5;

            zed.AxisChange();
        }

        /// <summary>
        /// ZedGraph 드로잉(X가 30이상이면 Shifting)
        /// </summary>
        /// <param name="zed">ZedGraphControl</param>
        /// <param name="current">X값</param>
        private void drawZed(ZedGraphControl zed, double current)
        {
            if (zed.GraphPane.CurveList.Count <= 0)
                return;

            LineItem curve = zed.GraphPane.CurveList[0] as LineItem;

            if (curve == null)
                return;

            IPointListEdit list = curve.Points as IPointListEdit;

            if (list == null)
                return;

            list.Add(zedCnt, current);

            Scale xScale = zed.GraphPane.XAxis.Scale;

            if (zedCnt > xScale.Max - xScale.MajorStep)
            {
                xScale.Max = zedCnt + xScale.MajorStep;
                xScale.Min = xScale.Max - 30.0;
            }

            zed.AxisChange();
            zed.Invalidate();
        }
        #endregion

        #region private method
 
        private double getRound(IntPoint[] ip)
        {
            double x1 = 0, x2 = 0, y1 = 0, y2 = 0;
            double result1 = 0, result2 = 0, sum = 0;

            for (int i = 0; i < ip.Count<IntPoint>(); i++)
            {
                //반복문이 마지막일 경우에, 마지막 선의 좌표를 저장
                if (i == ip.Count<IntPoint>() - 1)
                {
                    x1 = ip[0].X;
                    x2 = ip[i].X;
                    y1 = ip[0].Y;
                    y2 = ip[i].Y;
                }
                //반복문이 마지막이 아닐 경우
                else
                {
                    x1 = ip[i].X;
                    x2 = ip[i + 1].X;
                    y1 = ip[i].Y;
                    y2 = ip[i + 1].Y;
                }

                //둘레 계산 Math함수
                result1 = Math.Pow((x1 - x2), 2);
                result2 = Math.Pow((y1 - y2), 2);
                result2 = Math.Sqrt(result1 + result2);

                sum += result2;
            }

            return sum;
        }

        /// <summary>
        /// 원좌표를 XY좌표로 전환
        /// </summary>
        private void transfer()
        {
            double x = 0, y = 0;
            double deg = Math.PI / 180;
            int i = 0;

            for (i = 0; i < cirPoints.Count; i++)
            {
                if (cirPoints[i].X >= 0 && cirPoints[i].X < 90)
                {
                    x = cirPoints[i].Y * (Math.Cos((90 - cirPoints[i].X) * deg));
                    y = cirPoints[i].Y * (Math.Sin((90 - cirPoints[i].X) * deg));
                }
                else if (cirPoints[i].X >= 90 && cirPoints[i].X < 180)
                {
                    x = cirPoints[i].Y * (Math.Cos((cirPoints[i].X - 90) * deg));
                    y = -1 * (cirPoints[i].Y * (Math.Sin((cirPoints[i].X - 90) * deg)));
                }
                else if (cirPoints[i].X >= 180 && cirPoints[i].X < 270)
                {
                    x = -1 * (cirPoints[i].Y * (Math.Cos((270 - cirPoints[i].X) * deg)));
                    y = -1 * (cirPoints[i].Y * (Math.Sin((270 - cirPoints[i].X) * deg)));
                }
                else if (cirPoints[i].X >= 270 && cirPoints[i].X < 360)
                {
                    x = -1 * (cirPoints[i].Y * (Math.Cos((cirPoints[i].X - 270) * deg)));
                    y = cirPoints[i].Y * (Math.Sin((cirPoints[i].X - 270) * deg));
                }

                sqPoints.Add(new IntPoint((int)x, (int)y));
                histPoints.Add(new PointXY((float)x, (float)y));
            }
        }

        /// <summary>
        /// readLine을 자르고 드로잉 함수에 전달
        /// </summary>
        /// <param name="readLine">시리얼포트 ReadLine 데이터</param>
        private void drawBodyType(string readLine)
        {
            string[] ary = readLine.Split(',');

            try
            {
                w1 = float.Parse(ary[0]);
                w2 = float.Parse(ary[1]);
                w3 = float.Parse(ary[2]);
                w4 = float.Parse(ary[3]);
            }
            catch (Exception) {}

            //드로잉 부분 Main Thread로 인계
            this.Invoke(new EventHandler(delegate
            {
                try
                {
                    drawChart(w1, w2, w3, w4);
                    setPoint(w1, w2, w3, w4);
                }
                catch (Exception) { }
            }));
        }

        /// <summary>
        /// Chart를 그리는 함수
        /// </summary>
        /// <param name="w1">Top</param>
        /// <param name="w2">Bottom</param>
        /// <param name="w3">Left</param>
        /// <param name="w4">Right</param>
        private void drawChart(float w1, float w2, float w3, float w4)
        {
            drawZed(zedTop, w1);
            drawZed(zedBottom, w2);
            drawZed(zedLeft, w3);
            drawZed(zedRight, w4);
            zedCnt++;
        }

        /// <summary>
        /// x에 대한 비율을 계산
        /// </summary>
        /// <param name="x">몸무게x</param>
        /// <param name="y">몸무게y</param>
        /// <returns>x에 대한 비율을 반환</returns>
        private float ratio(float x, float y)
        {
            return x / (x + y) * 100;
        }

        /// <summary>
        /// Point 좌표 계산 함수
        /// </summary>
        /// <param name="w1">Top</param>
        /// <param name="w2">Bottom</param>
        /// <param name="w3">Left</param>
        /// <param name="w4">Right</param>
        private void setPoint(float w1, float w2, float w3, float w4)
        {
            List<float> temp = new List<float>();
            float result1 = ratio(w1, w2);
            float result2 = ratio(w2, w1);
            float result3 = ratio(w3, w4);
            float result4 = ratio(w4, w3);
            /* float max, twoMax, angle;*/

            //X 좌표의 비율을 서로 비교(아래같이 생김)
            //          result1
            //    result3     result4
            //          result2.
            //ratio의 결과값을 좌표로 출력하기 위해 50을 뺌

            //소수 2째자리까지 표현
            lblTop.Text = result1.ToString("##.##");
            lblBottom.Text = result2.ToString("##.##");
            lblLeft.Text = result3.ToString("##.##");
            lblRight.Text = result4.ToString("##.##");

            temp.Add(result1);
            temp.Add(result2);
            temp.Add(result3);
            temp.Add(result4);
            
            drawCircle(temp, result1, result2, result3, result4);
        }

        private void drawCircle(List<float> temp, float result1, float result2, float result3, float result4)
        {
            float max, twoMax, maxAngle, tmaxAngle, tt, resultAng;

            temp.Sort();

            max = temp[3];
            twoMax = temp[2];

            maxAngle = getAngle(max, result1, result2, result3, result4);
            tmaxAngle = getAngle(twoMax, result1, result2, result3, result4);

            max = map(max, 50, 100, 0, 100);
            twoMax = map(twoMax, 50, 100, 0, 100);


            if (maxAngle > tmaxAngle)
            {
                if (maxAngle == 270 && tmaxAngle == 0)
                {
                    tt = twoMax / (twoMax + max) * 90;
                    resultAng = maxAngle + tt;
                }
                else
                {
                    tt = max / (max + twoMax) * 90;
                    resultAng = tmaxAngle + tt;
                }
            }
            else
            {
                if (maxAngle == 0 && tmaxAngle == 270)
                {
                    tt = max / (max + twoMax) * 90;
                    resultAng = tmaxAngle + tt;
                }
                else
                {
                    tt = twoMax / (twoMax + max) * 90;
                    resultAng = maxAngle + tt;
                }
            }

            if (temp[2] == temp[1])
            {
                resultAng = maxAngle;
            }
            if (lineFlag)
            {
                S2.Points.Clear();
                S1.Points.AddXY(resultAng, max);
                S2.Color = getColor(max);
                S2.Points.AddXY(resultAng, max);
                cirPoints.Add(new PointF(resultAng, max));
            }
            else
            {
                S1.Points.AddXY(0, 80);
                S2.Points.Clear();
                S2.Color = getColor(max);
                S2.Points.AddXY(resultAng, max);
            }
        }

        private float map(float x, float inMin, float inMax, float outMin, float outMax)
        {
            return (x - inMin) * (outMax - outMin) / (inMax - inMin) + outMin;
        }

        private float getAngle(float value, float result1, float result2, float result3, float result4)
        {
            float angle = 0;

            if (value == result1)
            {
                angle = 0;
            }
            else if (value == result2)
            {
                angle = 180;
            }
            else if (value == result3)
            {
                angle = 270;
            }
            else if (value == result4)
            {
                angle = 90;
            }

            return angle;
        }
        
        /// <summary>
        /// 해당 좌표의 Color값을 반환함
        /// </summary>
        /// <param name="centerX">센터 X좌표</param>
        /// <param name="centerY">센터 Y좌표</param>
        /// <param name="x">현재 X좌표</param>
        /// <param name="y">현재 Y좌표</param>
        /// <returns></returns>
        private Color getColor(float y)
        {
            Color color;

            if (y <= 20)
                color = Color.Blue;
            else if (y <= 50)
                color = Color.Yellow;
            else if (y <= 70)
                color = Color.Orange;
            else
                color = Color.Red;

            return color;
        }

        /// <summary>
        /// 딜레이 함수(쓰레드 딜레이랑 다른 함수)
        /// </summary>
        /// <param name="MS">Micro Second</param>
        /// <returns></returns>
        private DateTime Delay(int MS)
        {
            DateTime ThisMoment = DateTime.Now;
            TimeSpan duration = new TimeSpan(0, 0, 0, 0, MS);
            DateTime AfterWards = ThisMoment.Add(duration);
            while (AfterWards >= ThisMoment)
            {
                System.Windows.Forms.Application.DoEvents();
                ThisMoment = DateTime.Now;
            }
            return DateTime.Now;
        }

        /// <summary>
        /// 시리얼 포트 열기(예외처리 적용)
        /// </summary>
        private void portOpen()
        {
            portFlag = false;
            serialPort.DataReceived += serialPort_DataReceived;
            Delay(100);
            port = getBluetoothPort();

            if (port != null)
            {
                MessageBox.Show("블루투스 연결 중 잠시만 기다려주세요.", "정보", MessageBoxButtons.OK, MessageBoxIcon.Information);
                serialPort.PortName = port;
                serialPort.Open();
            }
            else
            {
                MessageBox.Show("블루투스 연결 실패.\n블루투스 연결을 해주세요.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!initFlag)
            {
                serialPort.DiscardInBuffer();
                serialPort.Write("1");
                serialPort.DiscardInBuffer();
                Delay(2000);
                serialPort.DiscardInBuffer();
                portFlag = true;
            }
            else
                portFlag = true;
        }

        /// <summary>
        /// 시리얼 포트 닫기(예외처리 적용)
        /// </summary>
        private void portClose()
        {
            portFlag = false;
            serialPort.DataReceived -= serialPort_DataReceived;
            Delay(100);
            serialPort.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            S1.Points.Clear();
            S2.Points.Clear();
            S3.Points.Clear();
            lblRound.Visible = false;

            if (cirPoints.Count() > 0)
            {
                foreach (PointF t in cirPoints)
                {
                    S4.Points.AddXY(t.X, t.Y);
                }
            }
        }

        public string[] GetBluetoothPort()
        {
            Regex regexPortName = new Regex(@"(COM\d+)");

            List<string> portList = new List<string>();

            ManagementObjectSearcher searchSerial = new ManagementObjectSearcher("SELECT * FROM Win32_PnPEntity");

            foreach (ManagementObject obj in searchSerial.Get())
            {
                string name = obj["Name"] as string;
                string classGuid = obj["ClassGuid"] as string;
                string deviceID = obj["DeviceID"] as string;

                if (classGuid != null && deviceID != null)
                {
                    if (String.Equals(classGuid, "{4d36e978-e325-11ce-bfc1-08002be10318}", StringComparison.InvariantCulture))
                    {
                        string[] tokens = deviceID.Split('&');

                        if (tokens.Length >= 4)
                        {
                            string[] addressToken = tokens[4].Split('_');
                            string bluetoothAddress = addressToken[0];

                            Match m = regexPortName.Match(name);
                            string comPortNumber = "";
                            if (m.Success)
                            {
                                comPortNumber = m.Groups[1].ToString();
                            }

                            if (Convert.ToUInt64(bluetoothAddress, 16) > 0)
                            {
                                string bluetoothName = GetBluetoothRegistryName(bluetoothAddress);
                                portList.Add(String.Format("{0},{1}", bluetoothName, comPortNumber));
                            }
                        }
                    }
                }
            }

            return portList.ToArray();
        }

        private string GetBluetoothRegistryName(string address)
        {
            string deviceName = "";

            string registryPath = @"SYSTEM\CurrentControlSet\Services\BTHPORT\Parameters\Devices";
            string devicePath = String.Format(@"{0}\{1}", registryPath, address);

            using (RegistryKey key = Registry.LocalMachine.OpenSubKey(devicePath))
            {
                if (key != null)
                {
                    Object o = key.GetValue("Name");

                    byte[] raw = o as byte[];

                    if (raw != null)
                    {
                        deviceName = Encoding.ASCII.GetString(raw);
                    }
                }
            }

            return deviceName;
        }

        private string getBluetoothPort()
        {
            string[] ports;
            string[] tempStrAry;
            char[] tempChrAry;
            string resultPort = null;

            ports = GetBluetoothPort();

            foreach (string port in ports)
            {
                tempStrAry = port.Split(',');
                tempChrAry = tempStrAry[0].ToCharArray();

                if (tempChrAry.Length == 0)
                    continue;

                if (tempChrAry[0] == 'H' && tempChrAry[1] == 'C')
                {
                    resultPort = tempStrAry[1];
                }
            }

            return resultPort;
        }
        #endregion
    }
}