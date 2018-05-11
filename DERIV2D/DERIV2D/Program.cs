using System;

namespace DERIV2D
{
    class Program
    {
        static void Main(string[] args)
        {
			string inputFunctionA;
			string inputFunctionB;
			string outputDirectory;

			// Determine if arguments were suplied
			if (args.Length == 3)
			{
				inputFunctionA = args[0];
				inputFunctionB = args[1];
				outputDirectory = args[2];
			}
			else // Use default arguments
			{
				inputFunctionA = @"./DERIV2D_functionA_XY.csv";
				inputFunctionB = @"./DERIV2D_functionB_XY.csv";
				outputDirectory = @"..\..\..\..\..\..\R\";
			}

			// This part will run the DERIV2D algorithm
			DERIV2D algorithm = new DERIV2D(inputFunctionA, inputFunctionB, outputDirectory);
			algorithm.RunDerivativeAlgorithm();
			algorithm.RunNormalization();
			algorithm.CompareDerivativesStaticSteps1();
			algorithm.CompareDerivativesStaticSteps2();
			algorithm.CompareDerivativesDynamicSteps1();
			algorithm.CompareDerivativesDynamicSteps2();

			Console.WriteLine("Press any key to continue...");
			Console.ReadKey();
		}
	}
}
