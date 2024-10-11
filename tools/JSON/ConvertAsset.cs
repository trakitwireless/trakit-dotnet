using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using trakit.objects;

namespace trakit.tools {
	/// <summary>
	/// 
	/// </summary>
	public class ConvertAsset : TrakitConverter<Asset> {
		public ConvertAsset(Serializer owner) : base(owner) { }

		public override Asset ReadJson(JsonReader reader, Type type, Asset asset, bool existing, JsonSerializer serializer) {
			var obj = JObject.Load(reader);
			if (!Enum.TryParse(obj["kind"].ToString(), true, out AssetType kind)) throw new JsonException();

			switch (kind) {
				case AssetType.person:
					asset = new Person() {
						general = obj.ToObject<PersonGeneral>(this.owner.newton),
						advanced = obj.ToObject<AssetAdvanced>(this.owner.newton),
						dispatch = obj["dispatch"].ToObject<AssetDispatch>(this.owner.newton)
					};
					break;
				case AssetType.vehicle:
					asset = new Vehicle() {
						general = obj.ToObject<VehicleGeneral>(this.owner.newton),
						advanced = obj.ToObject<VehicleAdvanced>(this.owner.newton),
						dispatch = obj["dispatch"].ToObject<AssetDispatch>(this.owner.newton)
					};
					break;
				case AssetType.trailer:
					asset = new Trailer() {
						general = obj.ToObject<TrailerGeneral>(this.owner.newton),
						advanced = obj.ToObject<AssetAdvanced>(this.owner.newton),
						dispatch = obj["dispatch"].ToObject<AssetDispatch>(this.owner.newton)
					};
					break;
				case AssetType.asset:
					asset = new Asset() {
						general = obj.ToObject<AssetGeneral>(this.owner.newton),
						advanced = obj.ToObject<AssetAdvanced>(this.owner.newton),
						dispatch = obj["dispatch"].ToObject<AssetDispatch>(this.owner.newton)
					};
					break;
			}
			asset.dispatch.id = asset.id;
			asset.dispatch.company = asset.company;
			asset.v = obj["v"].Select(p => (int)p).ToArray();
			return asset;
		}
		public override void WriteJson(JsonWriter writer, Asset asset, JsonSerializer serializer) {
			var obj = new JObject(
				new JProperty("id", asset.id),
				new JProperty("company", asset.company),
				new JProperty("v", asset.v)
			);

			// general
			if (asset.general != null) {
				foreach (var prop in JObject.FromObject(asset.general, serializer).Properties().Where(p => _valid(p))) {
					obj.Add(prop);
				}
			}
			// advanced
			if (asset.advanced != null) {
				foreach (var prop in JObject.FromObject(asset.advanced, serializer).Properties().Where(p => _valid(p))) {
					obj.Add(prop);
				}
			}
			// dispatch, jobs, and tasks
			if (asset.dispatch != null) {
				var dispatch = new JObject();
				foreach (var prop in JObject.FromObject(asset.dispatch, serializer).Properties().Where(p => _valid(p))) {
					dispatch.Add(prop);
				}
				obj.Add(new JProperty("dispatch", dispatch));
			}

			obj.WriteTo(writer);
		}

	}
}