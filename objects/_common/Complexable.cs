using System.Linq;

namespace trakit.objects {
	/// <summary>
	/// Some objects are made up of the pieces of many objects.
	/// </summary>
	/// <seealso cref="Asset"/>
	/// <seealso cref="Company"/>
	/// <seealso cref="Provider"/>
	/// <seealso cref="Company"/>
	public abstract class Complexable : Subscribable {
		/// <summary>
		/// A list of individually subscribable objects that make up the complex object.
		/// </summary>
		protected abstract Subscribable[] pieces { get; }

		/// <summary>
		/// Complex objects have multiple <see cref="v"/> values; one for each part of the object.
		/// </summary>
		public override int[] v {
			get => this.pieces.Select(p => p?.v[0] ?? -1).ToArray();
			set {
				for (int i = 0; i < value.Length; i++) {
					if (this.pieces[i] != null) {
						this.pieces[i].v[0] = value[i];
					}
				}
			}
		}
	}
}