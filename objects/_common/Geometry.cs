using System;
using System.Xml.Linq;

namespace trakit.objects {
	/// <summary>
	/// A coordinate on a flat surface
	/// </summary>
	/// <category>API Definitions</category>
	public class Point {
		/// <summary>
		/// Horizontal coordinate
		/// </summary>
		public double x;
		/// <summary>
		/// Vertical coordinate
		/// </summary>
		public double y;
	}

	/// <summary>
	/// A boundary on a flat surface
	/// </summary>
	/// <category>API Definitions</category>
	public class Square {
		/// <summary>
		/// Highest vertical coordinate
		/// </summary>
		public double top;
		/// <summary>
		/// Right-most horizontal coordinate
		/// </summary>
		public double right;
		/// <summary>
		/// Lowest vertical coordinate
		/// </summary>
		public double bottom;
		/// <summary>
		/// Left-most horizontal coordinate
		/// </summary>
		public double left;
		/// <summary>
		/// Width
		/// </summary>
		public double width => this.right - this.left;
		/// <summary>
		/// Height
		/// </summary>
		public double height => this.bottom - this.top;
	}

	/// <summary>
	/// Dimensions on a flat surface
	/// </summary>
	/// <category>API Definitions</category>
	public class Size {
		/// <summary>
		/// Width
		/// </summary>
		public double width;
		/// <summary>
		/// Height
		/// </summary>
		public double height;
	}
}