using System.Collections.Generic;

namespace trakit.objects {
	/// <summary>
	/// The layers of the map used to visualize the icon.
	/// </summary>
	/// <category>File Hosting</category>
	public enum IconLayer : byte {
		/// <summary>
		/// An SVG only layer just above the roads used for solid Places and accuracy radius fill.
		/// </summary>
		fills,
		/// <summary>
		/// An HTML only layer intended for use by an icon's drop-shadow.
		/// </summary>
		shadows,
		/// <summary>
		/// An SVG only layer intended for use by shape and accuracy radius outlines.
		/// </summary>
		outlines,
		/// <summary>
		/// An HTML only layer intended for use by an icon's main images.
		/// </summary>
		markers,
		/// <summary>
		/// An HTML only layer intended for use by an icon's label.
		/// </summary>
		labels,
		/// <summary>
		/// An SVG only layer for special drawing controls.  Icons should not use this layer.
		/// </summary>
		drawings,
		/// <summary>
		/// An HTML only layer for special drawing controls.  Icons should not use this layer.
		/// </summary>
		edits,
	};

	/// <summary>
	/// A visual representation of a thing on a map or in a list.
	/// </summary>
	/// <category>File Hosting</category>
	public class Icon : Subscribable, IIdUlong, INamed, IBelongCompany, IGlobal {
		/// <summary>
		/// Unique identifier of this icon.
		/// </summary>
		public ulong id { get; set; }
		/// <summary>
		/// The company to which this icon belongs.
		/// </summary>
		/// <seealso cref="Company.id" />
		public ulong company { get; set; }

		/// <summary>
		/// A noun to describe the type of thing represented.  Like Truck, Car, Trailer, Hot-Air Balloon, etc...
		/// </summary>
		/// <override max-length="100" />
		public string category;
		/// <summary>
		/// A specific adjective to describe the thing.  Like Blue, Red, Empty, Full, etc...
		/// </summary>
		/// <override max-length="100" />
		public string name { get; set; }
		/// <summary>
		/// Notes.
		/// </summary>
		public string notes { get; set; }
		/// <summary>
		/// Indicates whether this icon is available to child companies.
		/// </summary>
		public bool global { get; set; }
		/// <summary>
		/// A list of things that this icon can be used to represent.  Like asset, place, user, etc...
		/// </summary>
		public List<string> usage;
		/// <summary>
		/// Definition for the name bubble above the icon on a map.
		/// </summary>
		public IconLabel label;
		/// <summary>
		/// Where the notification will appear for a mapped icon.
		/// Such as the number of dispatches an asset is working on, or the number of dispatches at a place.
		/// </summary>
		public IconLabel badge;
		/// <summary>
		/// The images used to show the detail of this icon.
		/// </summary>
		public List<IconGlyph> glyphs;
	}

	/// <summary>
	/// Definition for the name bubble above the icon on a map.
	/// </summary>
	/// <category>File Hosting</category>
	public class IconLabel {
		/// <summary>
		/// The offset from the lat/long in pixels.
		/// </summary>
		public Point anchor;
		/// <summary>
		/// Determines which corner of the label is attached to the anchor.
		/// </summary>
		public string align;
		/// <summary>
		/// Background colour of the label.
		/// </summary>
		public string colour;
	}
	/// <summary>
	/// The image source and defined status tags which need to be applied to an asset in order to show the image.
	/// </summary>
	/// <category>File Hosting</category>
	public class IconGlyph {
		/// <summary>
		/// A list of codified status tag names.  Any of the tags must be applied to the asset for the image to appear.
		/// </summary>
		/// <override>
		/// <values format="codified">
		/// <seealso cref="LabelStyle.code" />
		/// </values>
		/// </override>
		public List<string> tags;
		/// <summary>
		/// Path to the image.
		/// </summary>
		public string src;
		/// <summary>
		/// Size of the glyph in pixels.
		/// </summary>
		public Size size;
		/// <summary>
		/// The offset from the lat/long in pixels.
		/// </summary>
		public Point anchor;
		/// <summary>
		/// The layer on which this glyph is displayed.
		/// </summary>
		public IconLayer layer;
		/// <summary>
		/// The z-order of this glyph compared to other glyphs on the same layer.
		/// </summary>
		public ushort zIndex;
		/// <summary>
		/// Indicates that this glyph rotate based on GPS bearing.
		/// </summary>
		public bool rotates;
	}
}