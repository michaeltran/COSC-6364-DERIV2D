using DERIV2D.Data_Structures;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace DERIV2D
{
    public class DERIV2D
    {
		List<Coordinate> oCoordinates;
		List<Derivative> oDerivatives;

		public DERIV2D(string aSourcePath)
		{
			oCoordinates = new List<Coordinate>();
			oDerivatives = new List<Derivative>();

			using (StreamReader oReader = new StreamReader(aSourcePath))
			{
				while (!oReader.EndOfStream)
				{
					string line = oReader.ReadLine();
					string[] values = line.Split(',');

					oCoordinates.Add(new Coordinate(Convert.ToDouble(values[0]), Convert.ToDouble(values[1])));
				}
			}
		}

		public void RunAlgorithm()
		{
			for (int i = 0; i < oCoordinates.Count - 1; i++)
			{
				oDerivatives.Add(GetDerivative(oCoordinates[i], oCoordinates[i + 1]));
			}
		}

		private Derivative GetDerivative(Coordinate aStart, Coordinate aEnd)
		{
			double x;
			double y;

			x = aEnd.x - aStart.x;
			y = aEnd.y - aStart.y;

			Derivative oDerivative = new Derivative(x, y);
			return oDerivative;
		}
    }
}
