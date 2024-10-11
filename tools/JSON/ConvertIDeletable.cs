using System;
using System.Linq;
using System.Reflection;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using trakit.objects;

namespace trakit.tools {
	/// <summary>
	/// 
	/// </summary>
	public class ConvertIDeletable : TrakitConverter<IDeletable> {
		public ConvertIDeletable(Serializer owner) : base(owner) { }
		public override bool CanRead => false;

		public override IDeletable ReadJson(JsonReader reader, Type type, IDeletable asset, bool existing, JsonSerializer serializer) {
			throw new NotImplementedException("IDeltable interface; cannot create objects");
		}
		public override void WriteJson(JsonWriter writer, IDeletable value, JsonSerializer serializer) {
			if (value?.deleted ?? false) {
				var obj = new JObject(
					new JProperty("deleted", true),
					new JProperty("since", value.since ?? DateTime.MinValue)
				);

				if (value is IIdUlong idUlong) {
					obj.Add(new JProperty("id", idUlong.id));
				} else if (value is ProviderGeneral provider) {
					obj.Add(new JProperty("id", provider.id));
					obj.Add(new JProperty("configuration", provider.configuration));
				} else if (value is ProviderRegistration registration) {
					obj.Add(new JProperty("code", registration.code));
					obj.Add(new JProperty("since", JToken.FromObject(registration.expires, serializer)));
				} else if (value is UserGeneral user) {
					obj.Add(new JProperty("login", user.login));
					obj.Add(new JProperty("nickname", user.nickname));
				} else if (value is Machine machine) {
					obj.Add(new JProperty("key", machine.key));
					obj.Add(new JProperty("nickname", machine.nickname));
				} else {
					throw new NotImplementedException("IDeletable not implemented for " + value.GetType().Name);
				}

				// add name, notes/instructions, icon, and labels
				if (value is DispatchJob job) {
					obj.Add(new JProperty("name", job.name));
					obj.Add(new JProperty("instructions", job.instructions));
				} else if (value is DispatchTask task) {
					obj.Add(new JProperty("name", task.name));
					obj.Add(new JProperty("instructions", task.instructions));
				} else if (value is INamed named) {
					obj.Add(new JProperty("name", named.name));
					obj.Add(new JProperty("notes", named.notes));
				}
				if (value is IIconic iconic) {
					obj.Add(new JProperty("icon", iconic.icon));
				}
				if (value is ILabelled labelled) {
					obj.Add(new JProperty("labels", labelled.labels));
				}

				// reflect out the kind attribute
				Type type = value.GetType();
				var kind = type.GetField("kind", BindingFlags.Public | BindingFlags.Instance)?.GetValue(value)
						?? type.GetProperty("kind", BindingFlags.Public | BindingFlags.Instance)?.GetValue(value);
				if (kind != null) obj.Add(new JProperty("kind", JToken.FromObject(kind, serializer)));

				// add company, parent, asset, and profile
				if (value is IBelongCompany companyObj) {
					obj.Add(new JProperty("company", companyObj.company));
				} else if (value is IAmCompany company) {
					obj.Add(new JProperty("parent", company.parent));
				}
				if (value is IBelongAsset assetObj) {
					obj.Add(new JProperty("asset", assetObj.asset));
				}
				if (value is IBelongBillingProfile profileObj) {
					obj.Add(new JProperty("profile", profileObj.profile));
				}

				obj.WriteTo(writer);
			} else {
				base.WriteJson(writer, value, serializer);
			}

		}
	}
}