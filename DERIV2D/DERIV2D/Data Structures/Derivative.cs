using System;
using System.Collections.Generic;
using System.Text;

namespace DERIV2D.Data_Structures
{
	// This class is used to store the derivative coordinates of a graph
	public class Derivative
    {
		// List of derivative values (x, y, z...)
		public List<double> Values;

		/// <summary>
		/// Constructor for Derivative class
		/// </summary>
		/// <param name="aValues">List of derivative values</param>
		public Derivative(List<double> aValues)
		{
			this.Values = aValues;
		}
	}
}
