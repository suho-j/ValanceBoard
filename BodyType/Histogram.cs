using AForge;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// pictureBox Size 687, 627
// x: 0 ~ 687
// y: 0 ~ 627

namespace BodyType
{
    public class Histogram
    {
        #region field
        /// <summary>
        /// 히스토그램 X 데이터 저장 
        /// </summary>
        private double[] histDataX;
        /// <summary>
        /// 히스토그램 Y 데이터 저장 
        /// </summary>
        private double[] histDataY;
        #endregion

        #region const field
        /// <summary>
        /// picture box X 최대 사이즈 
        /// </summary>
        private const int picXSize = 687;
        /// <summary>
        /// picture box Y 최대 사이즈
        /// </summary>
        private const int picYSize = 627;
        #endregion

        #region Init
        public Histogram()
        {
            histDataX = new double[20];
            histDataY = new double[20];
        }
        #endregion

        #region Get Method
        public double[] getHistDataX()
        {
            return histDataX;
        }

        public double[] getHistDataY()
        {
            return histDataY;
        }

        /// <summary>
        /// b에 대한 a데이터의 퍼센트를 계산
        /// </summary>
        /// <param name="a">대상에 대한 비율을 계산할 데이터</param>
        /// <param name="b">대상</param>
        /// <returns>퍼센트</returns>
        private double getPercent(double a, double b)
        {
            return (a / b) * 100;
        }

        /// <summary>
        /// 퍼센트 결과에 따른 인덱스를 반환
        /// </summary>
        /// <param name="percent">퍼센트</param>
        /// <returns>인덱스 반환</returns>
        private int getIndex(double percent, bool flag)
        {
            if (flag)
            {
                if (percent <= 5)
                    return 0;
                else if (percent <= 10)
                    return 1;
                else if (percent <= 15)
                    return 2;
                else if (percent <= 20)
                    return 3;
                else if (percent <= 25)
                    return 4;
                else if (percent <= 30)
                    return 5;
                else if (percent <= 35)
                    return 6;
                else if (percent <= 40)
                    return 7;
                else if (percent <= 45)
                    return 8;
                else if (percent <= 50)
                    return 9;
                else if (percent <= 55)
                    return 10;
                else if (percent <= 60)
                    return 11;
                else if (percent <= 65)
                    return 12;
                else if (percent <= 70)
                    return 13;
                else if (percent <= 75)
                    return 14;
                else if (percent <= 80)
                    return 15;
                else if (percent <= 85)
                    return 16;
                else if (percent <= 90)
                    return 17;
                else if (percent <= 95)
                    return 18;
                else if (percent <= 100)
                    return 19;
            }
            else
            {
                if (percent <= 5)
                    return 19;
                else if (percent <= 10)
                    return 18;
                else if (percent <= 15)
                    return 17;
                else if (percent <= 20)
                    return 16;
                else if (percent <= 25)
                    return 15;
                else if (percent <= 30)
                    return 14;
                else if (percent <= 35)
                    return 13;
                else if (percent <= 40)
                    return 12;
                else if (percent <= 45)
                    return 11;
                else if (percent <= 50)
                    return 10;
                else if (percent <= 55)
                    return 9;
                else if (percent <= 60)
                    return 8;
                else if (percent <= 65)
                    return 7;
                else if (percent <= 70)
                    return 6;
                else if (percent <= 75)
                    return 5;
                else if (percent <= 80)
                    return 4;
                else if (percent <= 85)
                    return 3;
                else if (percent <= 90)
                    return 2;
                else if (percent <= 95)
                    return 1;
                else if (percent <= 100)
                    return 0;
            }

            return -1;
        }
        #endregion

        #region Set Method
        public void setHistData(List<PointXY> points)
        {
            double percentX = 0;
            double percentY = 0;
            
            foreach (PointXY point in points)
            {
                try
                {
                    percentX = ((point.pointX + 100) / 200) * 100;
                    percentY = ((point.pointY + 100) / 200) * 100;

                    histDataX[getIndex(percentX, true)]++;
                    histDataY[getIndex(percentY, false)]++;
                }
                catch (IndexOutOfRangeException) { }
            }
        }
        #endregion
    }
}
