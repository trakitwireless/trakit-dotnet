using System;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using trakit.objects;

namespace trakit.tools {
	/// <summary>
	/// 
	/// </summary>
	public class ConvertUser : TrakitConverter<User> {
		public ConvertUser(Serializer owner) : base(owner) { }

		public override User deconvert(JsonReader reader, Type type, User user, bool existing, JsonSerializer serializer) {
			var obj = JObject.Load(reader);
			user = new User() {
				general = obj.ToObject<UserGeneral>(this.owner.newton),
				advanced = obj.ToObject<UserAdvanced>(this.owner.newton),
			};
			user.v = obj["v"].Select(p => (int)p).ToArray();
			return user;
		}
		public override void convert(JsonWriter writer, User value, JsonSerializer serializer) => throw new NotImplementedException();
	}
}