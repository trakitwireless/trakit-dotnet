using System;
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
		public override bool CanWrite => false;

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
			throw new NotImplementedException();
		}
	}
}