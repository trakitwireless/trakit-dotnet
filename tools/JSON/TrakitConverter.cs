using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using trakit.objects;

namespace trakit.tools {
	/// <summary>
	/// 
	/// </summary>
	public abstract class TrakitConverter<T> : JsonConverter<T> where T : Component {
		/// <summary>
		/// 
		/// </summary>
		protected Serializer owner;

		internal TrakitConverter(Serializer owner) {
			this.owner = owner;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="prop"></param>
		/// <returns></returns>
		protected bool _valid(JProperty prop) {
			switch (prop.Name) {
				case "id":          // added at beginning
				case "login":       // added at beginning
				case "company":     // added at beginning
				case "parent":     // added at beginning
				case "v":           // added at the end
					return false;
				default:
					return true;
			}
		}
	}
}