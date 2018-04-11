using System;
using System.Collections.Generic;
using System.Text;

namespace DERIV2D.Data_Structures
{
    public class Coordinate
    {
		public List<double> axis;

		public double x;
		public double y;

		public Coordinate(double aX, double aY)
		{
			this.x = aX;
			this.y = aY;
		}
    }
}
