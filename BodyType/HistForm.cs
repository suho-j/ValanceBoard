using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace BodyType
{
    public partial class HistForm : Form
    {
        #region field
        private Histogram hist;
        private List<PointXY> points;

        private double[] histDataX;
        private double[] histDataY;
        #endregion

        #region Init
        public HistForm(List<PointXY> points)
        {
            InitializeComponent();

            this.points = points;

            Init();
        }

        private void Init()
        {
            hist = new Histogram();
            
            hist.setHistData(points);
            
            histDataX = hist.getHistDataX();
            histDataY = hist.getHistDataY();

            // 디폴트 범례 제거
            histX.Series.Clear();
            histY.Series.Clear();

            Series s1 = histX.Series.Add("X");
            Series s2 = histY.Series.Add("Y");

            s2.Color = Color.Red;
            s1.Color = Color.Yellow;
                        
            for (int i = 0; i < histDataX.Length; i++)
            {
                if (i == 9)
                {
                    s1.Points.AddXY(i, 0);
                    s2.Points.AddXY(10, 0);
                    continue;
                }

                s1.Points.AddXY(i, histDataX[i]);
                if(i != 10)
                    s2.Points.AddXY(i, histDataY[i]);
            }
        }
        #endregion
    }
}
