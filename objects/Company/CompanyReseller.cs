﻿using System;
using System.Collections.Generic;

namespace trakit.objects {
	/// <summary>
	/// Defines the seller company's details for white-labelling.
	/// </summary>
	public class CompanyReseller : Subscribable, IIdUlong, IAmCompany, IDeletable {
		/// <summary>
		/// Unique identifier of the Company.
		/// </summary>
		/// <seealso cref="Company.id" />
		public ulong id { get; set; }
		/// <summary>
		/// The unique identifier of this company's parent organization.
		/// </summary>
		/// <seealso cref="Company.id" />
		public ulong parent { get; set; }
		/// <summary>
		/// A list of Contacts for company specific things like Technical Support, Billing, etc...
		/// </summary>
		/// <seealso cref="Contact.id" />
		/// <override>
		/// <keys max-count="100" />
		/// <values>
		/// <seealso cref="Contact.id" />
		/// </values>
		/// </override>
		public Dictionary<string, ulong> contactInfo;
		/// <summary>
		/// The name of the branded service being provided to the seller's customers.
		/// </summary>
		/// <override max-length="150" />
		public string serviceName;
		/// <summary>
		/// The name of the image uploaded as the logo (used for regular view).
		/// </summary>
		/// <override max-length="200" />
		public string logo;
		/// <summary>
		/// The name of the image uploaded as the logo (used for collapsed/mobile view).
		/// </summary>
		/// <override max-length="200" />
		public string icon;
		/// <summary>
		/// The name of the icon file used for browser bookmarks.
		/// </summary>
		/// <override max-length="200" />
		public string favourite;
		/// <summary>
		/// The URN and path to the instance of v4.
		/// It does not contain the protocol because all instances are required to be HTTPS.
		/// </summary>
		/// <override max-length="100" />
		public string domain;
		/// <summary>
		/// Themed colours used in the web-based UI.
		/// </summary>
		/// <override>
		/// <keys max-length="25" />
		/// <values max-length="22" format="colour" />
		/// </override>
		public Dictionary<string, string> website;
		/// <summary>
		/// A list of symbol names and their corresponding FontAwesome icon names.
		/// </summary>
		/// <override>
		/// <keys max-length="25" />
		/// <values max-length="30" format="codified" />
		/// </override>
		public Dictionary<string, string> graphics;
		/// <summary>
		/// A list of supported languages for your customers.
		/// </summary>
		/// <override>
		/// <values max-length="5" format="codified" />
		/// </override>
		public List<string> languages;
		/// <summary>
		/// Colours used as templates for status tags, labels, and places.
		/// </summary>
		/// <override>
		/// <keys max-length="25" />
		/// </override>
		public Dictionary<string, ColourStyle> gamut;
		/// <summary>
		/// The server used for notification and conversational email messages sent and received by the system.
		/// </summary>
		public NotificationServerEmail notifyEmail;
		/// <summary>
		/// Definition for load-balanced outbound SMS numbers for the reseller.
		/// </summary>
		public NotificationServerSms notifySms;
		/// <summary>
		/// A preamble to the general terms and conditions offered by Fleet Freedom.
		/// </summary>
		public string termsPreamble;
		/// <summary>
		/// The date and time when the terms were updated.
		/// This will promt users who are logging-in to re-agree to the new terms
		/// </summary>
		public DateTime termsUpdated;
		/// <summary>
		/// The subject of the email sent to a user requesting a password reset.
		/// </summary>
		/// <remarks>
		/// The following strings are replaced:
		///	- %SERVICE%   with {serviceName}
		///	- %URL%       with https://{URN}/recover
		///	- %NAME%      with user's nickname, contact name, or login
		///	- %GUID%      with the unique identifier of the reset request
		///	- %CLIENT%    with the client software's userAgent used to create the request
		///	- %IP%        with IP address used to create the request
		///	- %SERVER%    with the server software's userAgent or the software (Kraken, Medusa, Mindflayer)
		/// </remarks>
		public string recoverSubject;
		/// <summary>
		/// The body of the email sent to a user requesting a password reset.
		/// </summary>
		/// <remarks>
		/// <code>
		/// The following strings are replaced:
		///	- %SERVICE%   with {serviceName}
		///	- %URL%       with https://{URN}/recover
		///	- %NAME%      with user's nickname, contact name, or login
		///	- %GUID%      with the unique identifier of the reset request
		///	- %CLIENT%    with the client software's userAgent used to create the request
		///	- %IP%        with IP address used to create the request
		///	- %SERVER%    with the server software's userAgent or the software (Kraken, Medusa, Mindflayer)
		/// </code>
		/// </remarks>
		public string recoverBody;
		/// <summary>
		/// When true, sends the password reset email as an HTML email instead of plain text.
		/// </summary>
		/// <remarks>
		/// <code>
		/// When false, the following strings are replaced:
		///	- &reg;    with char 0174
		///	- &trade;  with char 8482
		///	- &copy;   with char 0169
		///	- &amp;    with "&"
		/// </code>
		/// </remarks>
		public bool recoverIsHtml;

		/// <summary>
		/// Indicates whether this object was deleted.
		/// </summary>
		public bool? deleted { get; set; }
		/// <summary>
		/// Timestamp from the action that deleted or suspended this object.
		/// </summary>
		public DateTime? since { get; set; }
	}

	/// <summary>
	/// The server used for notification and conversational email messages sent and received by the system.
	/// </summary>
	public class NotificationServerEmail {
		/// <summary>
		/// The type of incoming protocol to use (IMAP or POP3).
		/// </summary>
		public string incomingType;
		/// <summary>
		/// The domain or IP address of the incoming email server.
		/// </summary>
		public string incomingAddress;
		/// <summary>
		/// The port number of the incoming email server.
		/// </summary>
		public ushort incomingPort;
		/// <summary>
		/// The username used to login to the incoming email server.
		/// </summary>
		public string incomingLogin;
		/// <summary>
		/// Is the incoming email server using a secure SSL/TLS connection (it should).
		/// </summary>
		public bool incomingSecure;
		/// <summary>
		/// IMAP message sequence number so only recent messages are retrieved.
		/// </summary>
		public uint incomingMessageNumber;
		/// <summary>
		/// The type of outgoing protocol to use (only SMTP).
		/// </summary>
		public string outgoingType;
		/// <summary>
		/// The domain or IP address of the outgoing email server.
		/// </summary>
		public string outgoingAddress;
		/// <summary>
		/// The port number of the outgoing email server.
		/// </summary>
		public ushort outgoingPort;
		/// <summary>
		/// The username used to login to the outgoing email server.
		/// </summary>
		public string outgoingLogin;
		/// <summary>
		/// Is the outgoing email server using a secure SSL/TLS connection (it should).
		/// </summary>
		public bool outgoingSecure;
		/// <summary>
		/// An optional field which can be set as the "sent from" and/or "reply-to" address.
		/// </summary>
		/// <override format="email" />
		public string outgoingReplyTo;
	}
	/// <summary>
	/// Definition for load-balanced outbound SMS numbers for the White-labelling profile.
	/// </summary>
	public class NotificationServerSms {
		/// <summary>
		/// A per-number/per-day limit on the amount of Notifications sent.
		/// </summary>
		public ushort notifyLimit;
		/// <summary>
		/// All phone numbers listed by the country (using two-digit ISO 3166-1 alpha-2 country codes) they each serve.
		/// </summary>
		/// <override>
		/// <keys length="2" />
		/// <values>
		/// <values format="phone" />
		/// </values>
		/// </override>
		public Dictionary<string, List<ulong>> phoneNumbers;
	}
}