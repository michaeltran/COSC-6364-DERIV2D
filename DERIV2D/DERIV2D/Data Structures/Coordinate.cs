using System;
using System.Collections.Generic;
using System.Text;

namespace DERIV2D.Data_Structures
{
	// This class is used to store the coordinates of a graph
	public class Coordinate
    {
		// List of coordinate values (x, y, z...)
		public List<double> Values;

		/// <summary>
		/// Constructor for Coordinate class
		/// </summary>
		/// <param name="aValues">List of coordinate values</param>
		public Coordinate(List<double> aValues)
		{
			this.Values = aValues;
		}
    }
}
