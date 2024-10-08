﻿using System.Collections.Generic;
using trakit.objects;

namespace trakit.commands {
	/// <summary>
	/// Gets the list of current subscriptions for your current session.
	/// </summary>
	public class RespSubscriptionList : ResponseType {
		/// <summary>
		/// Contains a <see cref="Company.id"/> and an array of <see cref="SubscriptionType"/>s for each <see cref="Company"/>.
		/// </summary>
		public class Subscription {
			/// <summary>
			/// The company relevant to the subscription types you want to receive.
			/// </summary>
			/// <seealso cref="Company.id"/>
			public ulong company;
			/// <summary>
			/// List of subscription types for the company.
			/// </summary>
			public List<SubscriptionType> subscriptionTypes;
		}

		/// <summary>
		/// The list of your current subscription types.
		/// </summary>
		public List<Subscription> subscriptions;
	}
}