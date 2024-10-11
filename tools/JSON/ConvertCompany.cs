using System;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using trakit.objects;

namespace trakit.tools {
	/// <summary>
	/// 
	/// </summary>
	public class ConvertCompany : TrakitConverter<Company> {
		public ConvertCompany(Serializer owner) : base(owner) { }
		public override Company ReadJson(JsonReader reader, Type objectType, Company company, bool existing, JsonSerializer serializer) {
			var obj = JObject.Load(reader);
			company = new Company() {
				general = obj.ToObject<CompanyGeneral>(this.owner.newton),
				directory = obj.ToObject<CompanyDirectory>(this.owner.newton),
				policies = obj.ToObject<CompanyPolicies>(this.owner.newton),
				styles = obj.ToObject<CompanyStyles>(this.owner.newton),
			};
			if (obj["reseller"]?.Type == JTokenType.Object) {
				company.reseller = obj["reseller"].ToObject<CompanyReseller>(this.owner.newton);
			}
			company.v = obj["v"].Select(p => (int)p).ToArray();
			return company;
		}
		public override void WriteJson(JsonWriter writer, Company company, JsonSerializer serializer) {
			var obj = new JObject(
				new JProperty("id", company.id),
				new JProperty("parent", company.parent),
				new JProperty("v", company.v)
			);

			// general
			if (company.general != null) {
				foreach (var prop in JObject.FromObject(company.general, serializer).Properties().Where(p => _valid(p))) {
					obj.Add(prop);
				}
			}
			// directory
			if (company.directory != null) {
				foreach (var prop in JObject.FromObject(company.directory, serializer).Properties().Where(p => _valid(p))) {
					obj.Add(prop);
				}
			}
			// policies
			if (company.policies != null) {
				foreach (var prop in JObject.FromObject(company.policies, serializer).Properties().Where(p => _valid(p))) {
					obj.Add(prop);
				}
			}
			// styles
			if (company.styles != null) {
				foreach (var prop in JObject.FromObject(company.styles, serializer).Properties().Where(p => _valid(p))) {
					obj.Add(prop);
				}
			}
			// reseller
			if (company.reseller?.deleted ?? false) {
				var reseller = new JObject();
				foreach (var prop in JObject.FromObject(company.reseller, serializer).Properties().Where(p => _valid(p))) {
					reseller.Add(prop);
				}
				obj.Add(new JProperty("reseller", reseller));
			}

			obj.WriteTo(writer);
		}
	}
}