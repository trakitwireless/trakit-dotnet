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
		public override bool CanWrite => false;
		public ConvertCompany(Serializer owner) : base(owner) { }

		public override Company deconvert(JsonReader reader, Type type, Company company, bool existing, JsonSerializer serializer) {
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
		public override void convert(JsonWriter writer, Company value, JsonSerializer serializer) => throw new NotImplementedException();
	}
}