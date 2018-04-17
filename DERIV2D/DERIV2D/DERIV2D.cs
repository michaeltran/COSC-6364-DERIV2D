using DERIV2D.Data_Structures;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace DERIV2D
{
    public class DERIV2D
    {
		List<Coordinate> myCoordinatesA;
		List<Derivative> myDerivativesA;
		List<Derivative> myDerivativesB;

		public DERIV2D(string aSourcePathG, string aSourcePathB)
		{
			myCoordinatesA = new List<Coordinate>();
			myDerivativesA = new List<Derivative>();
			myDerivativesB = new List<Derivative>();

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

					myCoordinatesA.Add(new Coordinate(oValues));
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

					myDerivativesB.Add(new Derivative(oValues));
				}
			}
		}

		public void RunAlgorithm()
		{
			for (int i = 0; i < myCoordinatesA.Count - 1; i++)
			{
				myDerivativesA.Add(GetDerivative(myCoordinatesA[i + 1], myCoordinatesA[i]));
			}

			OutputDerivativeToFile(@".\DERIV_A.csv", myDerivativesA);
		}

		public void CompareDerivativesStaticSteps()
		{
			// Compare derivatives B and A now

			List<Derivative> AvgAs = new List<Derivative>();
			List<Derivative> AvgBs = new List<Derivative>();

			int steps = Convert.ToInt32(Math.Floor((double)myDerivativesB.Count / myDerivativesA.Count));

			int currentStepInB = 0;

			for (int currentStepInA = 0; currentStepInA < myDerivativesA.Count; currentStepInA++)
			{
				List<double> sumsA = new List<double>()
					{ myDerivativesA[currentStepInA].Values[0], myDerivativesA[currentStepInA].Values[1] };

				List<double> sumsB = new List<double>() { 0, 0 };

				for (int it = 0; it < steps; it++)
				{
					sumsB[0] += myDerivativesB[currentStepInB].Values[0];
					sumsB[1] += myDerivativesB[currentStepInB].Values[1];
					currentStepInB++;
				}

				for (int i = 0; i < sumsB.Count; i++)
				{
					sumsB[i] = sumsB[i] / steps;
				}

				AvgAs.Add(new Derivative(sumsA));
				AvgBs.Add(new Derivative(sumsB));
			}

			OutputDerivativeToFile(@".\COMPARE_DERIV_A.csv", AvgAs);
			OutputDerivativeToFile(@".\COMPARE_DERIV_B.csv", AvgBs);
		}

		public void OutputDerivativeToFile(string aPath, List<Derivative> aDerivatives)
		{
			using (System.IO.StreamWriter output = new System.IO.StreamWriter(aPath))
			{
				foreach (Derivative oDerivative in aDerivatives)
				{
					StringBuilder sb = new StringBuilder(String.Empty);

					foreach (double value in oDerivative.Values)
					{
						sb.Append(value + ",");
					}

					output.WriteLine(sb.ToString().TrimEnd(','));
				}
			}
		}

		//public void CompareDerivativesDynamicSteps()
		//{
		//	// Compare derivatives B and A now

		//	List<double> AvgAs = new List<double>();
		//	List<double> AvgBs = new List<double>();

		//	int floorSteps = Convert.ToInt32(Math.Floor((double)myDerivativesB.Count / myDerivativesA.Count));
		//	double steps = (double)myDerivativesB.Count / myDerivativesA.Count;

		//	int currentStepInB = 0;

		//	for (int currentStepInA = 0; currentStepInA < myDerivativesA.Count; currentStepInA++)
		//	{
		//		//double avgA = (myDerivativesA[i].Values[0] + myDerivativesA[i+1].Values[0]) / 2;
		//		double avgA = myDerivativesA[currentStepInA].Values[0];

		//		double sum = 0;

		//		for (int it = 0; it < steps; it++)
		//		{
		//			sum += myDerivativesB[currentStepInB].Values[0];
		//			currentStepInB++;
		//		}

		//		double avgB = sum / steps;

		//		AvgAs.Add(avgA);
		//		AvgBs.Add(avgB);
		//	}
		//}

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
