using System.Net.Http;
using trakit.objects;

namespace trakit.commands {
	/// <summary>
	/// The types of subscriptions available using <see cref="subscribe"/>/<see cref="unsubscribe"/>.
	/// Each type has a different synchronization messages and objects.
	/// </summary>
	public class ReqSubscriptionRemove : ReqSubscriptionMerge {

		public override string socketCommand => "unsubscribe";
	}
}