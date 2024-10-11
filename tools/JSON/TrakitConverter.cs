using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace trakit.tools {
	/// <summary>
	/// 
	/// </summary>
	public abstract class TrakitConverter<T> : JsonConverter<T> {
		/// <summary>
		/// 
		/// </summary>
		protected Serializer owner;
		/// <summary>
		/// 
		/// </summary>
		[ThreadStatic]
		protected static bool _reading;
		/// <summary>
		/// 
		/// </summary>
		[ThreadStatic]
		protected static bool _writing;


		public override bool CanRead => !_reading;
		public override bool CanWrite => !_writing;

		internal TrakitConverter(Serializer owner) {
			this.owner = owner;
		}

		public override T ReadJson(JsonReader reader, Type objectType, T value, bool existing, JsonSerializer serializer) {
			if (_reading) {
				// Protect against any changes to Newtonsoft that somehow cause concurrent access in the same thread recursively
				throw new InvalidOperationException($"Concurrent read detected on {nameof(TrakitConverter<T>)}");
			}
			_reading = true;
			try {
				return serializer.Deserialize<T>(reader);
			} finally {
				_reading = false;
			}
		}
		public override void WriteJson(JsonWriter writer, T value, JsonSerializer serializer) {
			if (_reading) {
				// Protect against any changes to Newtonsoft that somehow cause concurrent access in the same thread recursively
				throw new InvalidOperationException($"Concurrent write detected on {nameof(TrakitConverter<T>)}");
			}
			_writing = true;
			try {
				serializer.Serialize(writer, value);
			} finally {
				_writing = false;
			}
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