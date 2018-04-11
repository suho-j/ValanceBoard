using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BodyType
{
    public class PointController
    {
        #region field
        private List<PointXY> listPoint;
        private PointXY pXY;
        #endregion

        #region Init
        public PointController()
        {
            listPoint = new List<PointXY>();
        }
        #endregion

        #region public method

        /// <summary>
        /// X, Y 좌표를 저장하는 함수
        /// </summary>
        /// <param name="pointX">x입니다</param>
        /// <param name="pointY">y입니다</param>
        public void savePoint(float pointX, float pointY)
        {
            pXY = new PointXY(pointX, pointY);
            listPoint.Add(pXY);
        }

        /// <summary>
        /// List를 반환
        /// </summary>
        /// <returns>List<PointXY></returns>
        public List<PointXY> getListPoint()
        {
            return listPoint;
        }

        /// <summary>
        /// 리스트의 개수를 반환
        /// </summary>
        /// <returns>List<PointXY>를 반환</returns>
        public int getListCount()
        {
            return listPoint.Count();
        }

        /// <summary>
        /// 리스트를 초기화
        /// </summary>
        public void clearList()
        {
            listPoint.Clear();
        }

        #endregion
    }
}
