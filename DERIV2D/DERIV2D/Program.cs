using System;

namespace DERIV2D
{
    class Program
    {
        static void Main(string[] args)
        {
			DERIV2D algorithm = new DERIV2D(@"./DERIV2D_functionA_XY.csv", "./DERIV2D_functionB_XY.csv");
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
