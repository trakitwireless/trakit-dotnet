﻿using System.Net.Http;
using trakit.objects;

namespace trakit.commands {
	/// <summary>
	/// A container class used to house the login identifying a <see cref="User"/>.
	/// Used specifically to get session details.
	/// </summary>
	public class ReqLogin : Request {
		/// <summary>
		/// The <see cref="User"/>'s login.
		/// </summary>
		public string username;
		/// <summary>
		/// The <see cref="User"/>'s password.
		/// </summary>
		public string password;
		/// <summary>
		/// A string to identify the User-Agent of the login request.
		/// </summary>
		public string userAgent;

		public override HttpMethod httpVerb => HttpMethod.Post;

		public override string httpRoute => "self/login";

		public override string socketCommand => "login";
	}
}