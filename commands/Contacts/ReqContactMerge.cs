﻿using System.Collections.Generic;
using System;
using trakit.objects;
using System.Net.Http;

namespace trakit.commands {
	/// <summary>
	/// Gets details of the specified <see cref="contact"/>.
	/// </summary>
	public class ReqContactMerge : Request {
		public class Content {
			/// <summary>
			/// The unique identifier of the <see cref="Contact"/> you want to update.
			/// Leave this as <c>null</c> when creating a new <see cref="Contact"/>.
			/// </summary>
			public ulong? id;
			/// <summary>
			/// The <see cref="Company"/> to which this <see cref="Contact"/> belongs.
			/// After creation, this value is read-only.
			/// </summary>
			public ulong? company;
			/// <summary>
			/// Name for the <see cref="Contact"/>.
			/// </summary>
			public string name;
			/// <summary>
			/// Notes for the <see cref="Contact"/>.
			/// </summary>
			public string notes;
			/// <summary>
			/// A collection of other names this person might go by.
			/// Use the object key like a name identifier.
			/// Example keys: Initials, Nickname, Maiden Name, etc.
			/// </summary>
			public Dictionary<string, string> otherNames;
			/// <summary>
			/// Email addresses
			/// Use the object key like a name of the address.
			/// Example keys: Home, Work, Support, Old, etc.
			/// </summary>
			public Dictionary<string, string> emails;
			/// <summary>
			/// Phone numbers.
			/// Use the object key like a name of the phone number.
			/// Example keys: Mobile, Fax, Home, Office, etc.
			/// </summary>
			public Dictionary<string, ulong?> phones;
			/// <summary>
			/// Mailing addresses
			/// Use the object key like a name of the address.
			/// Example keys: Home, Work, Park, etc.
			/// </summary>
			public Dictionary<string, string> addresses;
			/// <summary>
			/// Websites and other online resources
			/// Use the object key like a name of the address.
			/// Example keys: Downloads, Support, FTP, etc.
			/// </summary>
			public Dictionary<string, Uri> urls;
			/// <summary>
			/// Date information
			/// Use the object key like a name of the date.
			/// Example keys: Birthday, Started Date, Retired On, etc.
			/// </summary>
			public Dictionary<string, DateTime?> dates;
			/// <summary>
			/// Uncategorized information
			/// Use the object keys and values however you'd like.
			/// </summary>
			public Dictionary<string, string> options;
			/// <summary>
			/// A list of roles they play in the <see cref="Company"/>.
			/// </summary>
			public List<string> roles;
			/// <summary>
			/// <see cref="Picture"/>s of this <see cref="Contact"/>.
			/// </summary>
			public List<ulong> pictures;
		}
		/// <summary>
		/// An object to contain the "id" of the <see cref="Contact"/>.
		/// </summary>
		public Content contact { get; set; }
	}
}