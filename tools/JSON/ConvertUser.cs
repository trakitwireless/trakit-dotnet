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
		public override User ReadJson(JsonReader reader, Type objectType, User user, bool existing, JsonSerializer serializer) {
			var obj = JObject.Load(reader);
			user = new User() {
				general = obj.ToObject<UserGeneral>(this.owner.newton),
				advanced = obj.ToObject<UserAdvanced>(this.owner.newton),
			};
			user.v = obj["v"].Select(p => (int)p).ToArray();
			return user;
		}
		public override void WriteJson(JsonWriter writer, User user, JsonSerializer serializer) {
			var obj = new JObject(
				new JProperty("login", user.login),
				new JProperty("company", user.company),
				new JProperty("v", user.v)
			);

			// general
			if (user.general != null) {
				foreach (var prop in JObject.FromObject(user.general, serializer).Properties().Where(p => _valid(p))) {
					obj.Add(prop);
				}
			}
			// advanced
			if (user.advanced != null) {
				foreach (var prop in JObject.FromObject(user.advanced, serializer).Properties().Where(p => _valid(p))) {
					obj.Add(prop);
				}
			}

			obj.WriteTo(writer);
		}
	}
}