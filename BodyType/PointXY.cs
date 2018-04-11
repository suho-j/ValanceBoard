using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BodyType
{
    public class PointXY
    {
        #region field
        public float pointX { get; }
        public float pointY { get; }
        #endregion

        #region method
        public PointXY(float pointX, float pointY)
        {
            this.pointX = pointX;
            this.pointY = pointY;
        }
        #endregion
    }
}
