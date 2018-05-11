using DERIV2D.Data_Structures;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace DERIV2D
{
	// DERIV2D Algorithm Class
    public class DERIV2D
    {
		// Coordinates from graph A
		List<Coordinate> myCoordinatesA;
		// Derivatives from graph A
		List<Derivative> myDerivativesA;
		// Derivatives from graph B
		List<Derivative> myDerivativesB;

		// Directory to output to
		string myOutputDirectory;

		/// <summary>
		/// Constructor - Loads coordinates for function A and derivatives for function B
		/// </summary>
		/// <param name="aSourcePathA">Source path of function A</param>
		/// <param name="aSourcePathB">Source path of function B</param>
		/// <param name=aOutputDirectory">Directory to output files</param>
		public DERIV2D(string aSourcePathA, string aSourcePathB, string aOutputDirectory)
		{
			myOutputDirectory = aOutputDirectory.TrimEnd('\\') + @"\";
			myCoordinatesA = new List<Coordinate>();
			myDerivativesA = new List<Derivative>();
			myDerivativesB = new List<Derivative>();

			// Loads function A
			using (StreamReader oReader = new StreamReader(aSourcePathA))
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

			// Loads function B
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

		/// <summary>
		/// Calcualtes the derivative of Function A
		/// </summary>
		public void RunDerivativeAlgorithm()
		{
			// Loop and calculate the derivative values
			for (int i = 0; i < myCoordinatesA.Count - 1; i++)
			{
				myDerivativesA.Add(GetDerivative(myCoordinatesA[i + 1], myCoordinatesA[i]));
			}

			OutputDerivativeToFile(@"DERIV_A.csv", myDerivativesA);
		}

		/// <summary>
		/// Normalizes the data in Function A and Function B
		/// </summary>
		public void RunNormalization()
		{
			double maxValue;
			double maxOfA = 0;
			double maxOfB = 0;

			maxOfA = GetMaxValue(myDerivativesA);
			maxOfB = GetMaxValue(myDerivativesB);

			// Determines which one is the maximum and stores that value into maxValue
			if (maxOfA > maxOfB)
			{
				maxValue = maxOfA;
			}
			else
			{
				maxValue = maxOfB;
			}

			NormalizeValues(myDerivativesA, maxValue);
			NormalizeValues(myDerivativesB, maxValue);

			OutputDerivativeToFile(@"DERIV_A_NORMALIZED.csv", myDerivativesA);
		}

		/// <summary>
		/// Gets and returns the maximum value of a derivative
		/// </summary>
		/// <param name="aDerivatives">The derivative to determine max value of</param>
		/// <returns></returns>
		private double GetMaxValue(List<Derivative> aDerivatives)
		{
			double maxValue = 0;

			// Loop through derivative and return the max value
			for (int i = 0; i < aDerivatives.Count; i++)
			{
				double xValue = Math.Abs(aDerivatives[i].Values[0]);
				double yValue = Math.Abs(aDerivatives[i].Values[1]);

				// Determines if X or Y is larger
				if (xValue > yValue)
				{
					// If X is larger than current max, set current max to X
					if (xValue > maxValue)
					{
						maxValue = xValue;
					}
				}
				else // (xValue <= yValue)
				{
					// If Y is larger than current max, set current max to Y
					if (yValue > maxValue)
					{
						maxValue = yValue;
					}
				}
			}

			return maxValue;
		}

		/// <summary>
		/// Normalizes all values of a derivative
		/// </summary>
		/// <param name="aDerivatives">The derivative to normalize</param>
		/// <param name="aMaxValue">The maximum value to normalize by</param>
		private void NormalizeValues(List<Derivative> aDerivatives, double aMaxValue)
		{
			// Loops through derivative and normalizes
			for (int i = 0; i < aDerivatives.Count; i++)
			{
				aDerivatives[i].Values[0] = aDerivatives[i].Values[0] / aMaxValue;
				aDerivatives[i].Values[1] = aDerivatives[i].Values[1] / aMaxValue;
			}
		}

		/// <summary>
		/// SSM1 Method - Compares a point in A to the average of points in B
		/// </summary>
		public void CompareDerivativesStaticSteps1()
		{
			WriteLog("Start - Comparing function A and B using static step method 1");

			List<Derivative> AvgAs = new List<Derivative>();
			List<Derivative> AvgBs = new List<Derivative>();

			int stepsInB = Convert.ToInt32(Math.Floor((double)myDerivativesB.Count / myDerivativesA.Count));
			int currentStepInB = 0;

			// Loops through Function A to get the comparison with Function B
			for (int currentStepInA = 0; currentStepInA < myDerivativesA.Count; currentStepInA++)
			{
				List<double> sumsA = new List<double>()
				{
					myDerivativesA[currentStepInA].Values[0],
					myDerivativesA[currentStepInA].Values[1]
				};

				List<double> sumsB = new List<double>() { 0, 0 };

				// Loops through Function B by number of steps to get the sum
				for (int it = 0; it < stepsInB; it++)
				{
					sumsB[0] += myDerivativesB[currentStepInB].Values[0];
					sumsB[1] += myDerivativesB[currentStepInB].Values[1];
					currentStepInB++;
				}

				// Loops through the sums and generates the average
				for (int i = 0; i < sumsB.Count; i++)
				{
					sumsB[i] = sumsB[i] / stepsInB;
				}

				AvgAs.Add(new Derivative(sumsA));
				AvgBs.Add(new Derivative(sumsB));
			}

			OutputDerivativeToFile(@"COMPARE_DERIV_A_STATIC_1.csv", AvgAs);
			OutputDerivativeToFile(@"COMPARE_DERIV_B_STATIC_1.csv", AvgBs);

			WriteLog(string.Format("Done  - Skipped {0} coordinates in B", myDerivativesB.Count - currentStepInB));
		}

		/// <summary>
		/// SSM2 Method - Compares average of two points in A to the average of points in B
		/// </summary>
		public void CompareDerivativesStaticSteps2()
		{
			WriteLog("Start - Comparing function A and B using static step method 2");

			List<Derivative> AvgAs = new List<Derivative>();
			List<Derivative> AvgBs = new List<Derivative>();

			int stepsInB = Convert.ToInt32(Math.Floor((double)myDerivativesB.Count / myDerivativesA.Count));
			int currentStepInB = 0;

			// Loops through Function A to get the comparison with Function B
			for (int currentStepInA = 0; currentStepInA < myDerivativesA.Count - 1; currentStepInA++)
			{
				List<double> sumsA = new List<double>()
				{
					(myDerivativesA[currentStepInA].Values[0] + myDerivativesA[currentStepInA + 1].Values[0]) / 2,
					(myDerivativesA[currentStepInA].Values[1] + myDerivativesA[currentStepInA + 1].Values[1]) / 2
				};

				List<double> sumsB = new List<double>() { 0, 0 };

				// Loops through Function B by number of steps to get the sum
				for (int it = 0; it < stepsInB; it++)
				{
					sumsB[0] += myDerivativesB[currentStepInB].Values[0];
					sumsB[1] += myDerivativesB[currentStepInB].Values[1];
					currentStepInB++;
				}

				// Loops through the sums and generates the average
				for (int i = 0; i < sumsB.Count; i++)
				{
					sumsB[i] = sumsB[i] / stepsInB;
				}

				AvgAs.Add(new Derivative(sumsA));
				AvgBs.Add(new Derivative(sumsB));
			}

			OutputDerivativeToFile(@"COMPARE_DERIV_A_STATIC_2.csv", AvgAs);
			OutputDerivativeToFile(@"COMPARE_DERIV_B_STATIC_2.csv", AvgBs);

			WriteLog(string.Format("Done  - Skipped {0} coordinates in B", myDerivativesB.Count - currentStepInB));
		}

		/// <summary>
		/// DSM1 Method - Compares a point in A to the average of points in B
		/// </summary>
		public void CompareDerivativesDynamicSteps1()
		{
			WriteLog("Start - Comparing function A and B using dynamic step method 1");

			List<Derivative> AvgAs = new List<Derivative>();
			List<Derivative> AvgBs = new List<Derivative>();

			double stepsInB = (double)myDerivativesB.Count / myDerivativesA.Count;
			double dynamicStepCounter = 0;
			int currentStepInB = 0;

			// Loops through Function A to get the comparison with Function B
			for (int currentStepInA = 0; currentStepInA < myDerivativesA.Count; currentStepInA++)
			{
				dynamicStepCounter += stepsInB;
				int stepsToTakeInB = Convert.ToInt32(Math.Floor(dynamicStepCounter));
				dynamicStepCounter -= stepsToTakeInB;

				List<double> sumsA = new List<double>()
				{
					myDerivativesA[currentStepInA].Values[0],
					myDerivativesA[currentStepInA].Values[1]
				};

				List<double> sumsB = new List<double>() { 0, 0 };

				// Loops through Function B by number of steps to get the sum
				for (int it = 0; it < stepsToTakeInB; it++)
				{
					sumsB[0] += myDerivativesB[currentStepInB].Values[0];
					sumsB[1] += myDerivativesB[currentStepInB].Values[1];
					currentStepInB++;
				}

				// Loops through the sums and generates the average
				for (int i = 0; i < sumsB.Count; i++)
				{
					sumsB[i] = sumsB[i] / stepsToTakeInB;
				}

				AvgAs.Add(new Derivative(sumsA));
				AvgBs.Add(new Derivative(sumsB));
			}

			OutputDerivativeToFile(@"COMPARE_DERIV_A_DYNAMIC_1.csv", AvgAs);
			OutputDerivativeToFile(@"COMPARE_DERIV_B_DYNAMIC_1.csv", AvgBs);

			WriteLog(string.Format("Done  - Skipped {0} coordinates in B", myDerivativesB.Count - currentStepInB));
		}

		/// <summary>
		/// DSM2 Method - Compares average of two points in A to the average of points in B
		/// </summary>
		public void CompareDerivativesDynamicSteps2()
		{
			WriteLog("Start - Comparing function A and B using dynamic step method 2");

			List<Derivative> AvgAs = new List<Derivative>();
			List<Derivative> AvgBs = new List<Derivative>();

			double stepsInB = (double)myDerivativesB.Count / myDerivativesA.Count;
			stepsInB += stepsInB / myDerivativesA.Count;
			double dynamicStepCounter = 0;
			int currentStepInB = 0;

			// Loops through Function A to get the comparison with Function B
			for (int currentStepInA = 0; currentStepInA < myDerivativesA.Count - 1; currentStepInA++)
			{
				dynamicStepCounter += stepsInB;
				int stepsToTakeInB = 0;
				if (currentStepInA == myDerivativesA.Count - 2)
				{
					stepsToTakeInB = Convert.ToInt32(Math.Ceiling(dynamicStepCounter));
				}
				else
				{
					stepsToTakeInB = Convert.ToInt32(Math.Floor(dynamicStepCounter));
				}
				dynamicStepCounter -= stepsToTakeInB;

				List<double> sumsA = new List<double>()
				{
					(myDerivativesA[currentStepInA].Values[0] + myDerivativesA[currentStepInA + 1].Values[0]) / 2,
					(myDerivativesA[currentStepInA].Values[1] + myDerivativesA[currentStepInA + 1].Values[1]) / 2
				};

				List<double> sumsB = new List<double>() { 0, 0 };

				// Loops through Function B by number of steps to get the sum
				for (int it = 0; it < stepsToTakeInB; it++)
				{
					sumsB[0] += myDerivativesB[currentStepInB].Values[0];
					sumsB[1] += myDerivativesB[currentStepInB].Values[1];
					currentStepInB++;
				}

				// Loops through the sums and generates the average
				for (int i = 0; i < sumsB.Count; i++)
				{
					sumsB[i] = sumsB[i] / stepsToTakeInB;
				}

				AvgAs.Add(new Derivative(sumsA));
				AvgBs.Add(new Derivative(sumsB));
			}

			OutputDerivativeToFile(@"COMPARE_DERIV_A_DYNAMIC_2.csv", AvgAs);
			OutputDerivativeToFile(@"COMPARE_DERIV_B_DYNAMIC_2.csv", AvgBs);

			WriteLog(string.Format("Done  - Skipped {0} coordinates in B", myDerivativesB.Count - currentStepInB));
		}

		/// <summary>
		/// Gets the derivative values from a start and end coordinate
		/// </summary>
		/// <param name="aEnd">The end coordinate</param>
		/// <param name="aStart">The start coordinate</param>
		/// <returns>The derivative</returns>
		private Derivative GetDerivative(Coordinate aEnd, Coordinate aStart)
		{
			List<double> oValues = new List<double>();

			// Loop through the number of axises and get the derivative
			for (int i = 0; i < aEnd.Values.Count; i++)
			{
				oValues.Add(aEnd.Values[i] - aStart.Values[i]);
			}

			Derivative oDerivative = new Derivative(oValues);
			return oDerivative;
		}

		/// <summary>
		/// Ouputs the derivative to a file
		/// </summary>
		/// <param name="aPath">The path to output the result</param>
		/// <param name="aDerivatives">The derivative to output</param>
		public void OutputDerivativeToFile(string aPath, List<Derivative> aDerivatives)
		{
			aPath = myOutputDirectory + aPath;

			using (System.IO.StreamWriter output = new System.IO.StreamWriter(aPath))
			{
				output.WriteLine("X,Y");

				// Loop through each derivative and output it
				foreach (Derivative oDerivative in aDerivatives)
				{
					StringBuilder sb = new StringBuilder(String.Empty);

					// Loop through each axis and output it
					foreach (double value in oDerivative.Values)
					{
						sb.Append(value + ",");
					}

					output.WriteLine(sb.ToString().TrimEnd(','));
				}
			}
		}

		/// <summary>
		/// Writes a log line to the command line
		/// </summary>
		/// <param name="aLog">The string to log</param>
		private void WriteLog(string aLog)
		{
			Console.WriteLine(String.Format("{0} - {1}", DateTime.Now, aLog));
		}
	}
}
