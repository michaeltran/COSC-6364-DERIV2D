using System;

namespace DERIV2D
{
    class Program
    {
        static void Main(string[] args)
        {
			DERIV2D obj = new DERIV2D(@"./DERIV2D_functionA_XY.csv", "./DERIV2D_functionB_XY.csv");
			obj.RunDerivativeAlgorithm();
			obj.RunNormalization();
			obj.CompareDerivativesStaticSteps1();
			obj.CompareDerivativesStaticSteps2();
			obj.CompareDerivativesDynamicSteps1();
			obj.CompareDerivativesDynamicSteps2();

			Console.WriteLine("Press any key to continue...");
			Console.ReadKey();
		}
	}
}
