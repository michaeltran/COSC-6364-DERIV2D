using DERIV2D.Data_Structures;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace DERIV2D
{
    public class DERIV2D
    {
		List<Coordinate> oCoordinatesG;
		List<Derivative> oDerivativesG;
		List<Derivative> oDerivativesB;

		public DERIV2D(string aSourcePathG, string aSourcePathB)
		{
			oCoordinatesG = new List<Coordinate>();
			oDerivativesG = new List<Derivative>();
			oDerivativesB = new List<Derivative>();

			using (StreamReader oReader = new StreamReader(aSourcePathG))
			{
				while (!oReader.EndOfStream)
				{
					string line = oReader.ReadLine();
					string[] values = line.Split(',');

					List<double> oValues = new List<double>();
					foreach(string value in values)
					{
						oValues.Add(Convert.ToDouble(value));
					}

					oCoordinatesG.Add(new Coordinate(oValues));
				}
			}

			using (StreamReader oReader = new StreamReader(aSourcePathB))
			{
				while (!oReader.EndOfStream)
				{
					string line = oReader.ReadLine();
					string[] values = line.Split(',');

					List<double> oValues = new List<double>();
					foreach (string value in values)
					{
						oValues.Add(Convert.ToDouble(value));
					}

					oDerivativesB.Add(new Derivative(oValues));
				}
			}
		}

		public void RunAlgorithm()
		{
			for (int i = 0; i < oCoordinatesG.Count - 1; i++)
			{
				oDerivativesG.Add(GetDerivative(oCoordinatesG[i + 1], oCoordinatesG[i]));
			}

			CompareDerivatives();
		}

		public void CompareDerivatives()
		{
			// Compare derivatives B and G now

			List<double> AvgGs = new List<double>();
			List<double> AvgBs = new List<double>();

			int temp = Convert.ToInt32(Math.Floor((double)oDerivativesB.Count / oDerivativesG.Count));

			int j = 0;

			for (int i = 0; i < oDerivativesG.Count; i++)
			{
				//double avgG = (oDerivativesG[i].Values[0] + oDerivativesG[i+1].Values[0]) / 2;
				double avgG = oDerivativesG[i].Values[0];

				double sum = 0;

				for (int it = 0; it < temp; it++)
				{
					sum += oDerivativesB[j].Values[0];
					j++;
				}

				double avgB = sum / temp;

				AvgGs.Add(avgG);
				AvgBs.Add(avgB);
			}
		}

		private Derivative GetDerivative(Coordinate aEnd, Coordinate aStart)
		{
			List<double> oValues = new List<double>();

			for (int i = 0; i < aEnd.Values.Count; i++)
			{
				oValues.Add(aEnd.Values[i] - aStart.Values[i]);
			}

			Derivative oDerivative = new Derivative(oValues);
			return oDerivative;
		}
    }
}
