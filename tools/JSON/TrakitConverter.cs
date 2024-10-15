using System;
using Newtonsoft.Json;
using trakit.objects;

namespace trakit.tools {
	/// <summary>
	/// 
	/// </summary>
	/// <remarks>
	/// Inspiration for this approach was taken from https://github.com/JamesNK/Newtonsoft.Json/issues/719#issuecomment-2103805140
	/// Which was itself inspired by https://stackoverflow.com/questions/16085805/recursively-call-jsonserializer-in-a-jsonconverter/76705937#76705937
	/// </remarks>
	public abstract class TrakitConverter<T> : JsonConverter /*where T : Component*/ {
		/// <summary>
		/// 
		/// </summary>
		[ThreadStatic]
		static bool _isReading;
		/// <summary>
		/// 
		/// </summary>
		[ThreadStatic]
		static bool _isWriting;

		/// <summary>
		/// 
		/// </summary>
		protected Serializer owner;
		public override bool CanConvert(Type objectType) => typeof(T).IsAssignableFrom(objectType);
		/// <summary>
		/// 
		/// </summary>
		public override bool CanRead => !_isReading && base.CanRead;
		/// <summary>
		/// 
		/// </summary>
		public override bool CanWrite => !_isWriting && base.CanWrite;

		public TrakitConverter(Serializer owner) {
			this.owner = owner;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="reader"></param>
		/// <param name="type"></param>
		/// <param name="value"></param>
		/// <param name="existing"></param>
		/// <param name="serializer"></param>
		/// <returns></returns>
		/// <exception cref="InvalidOperationException"></exception>
		public override sealed object ReadJson(
			JsonReader reader,
			Type type,
			object value,
			JsonSerializer serializer
		) {
			if (_isReading) {
				// Protect against any changes to Newtonsoft that somehow cause concurrent access in the same thread recursively
				throw new InvalidOperationException($"Concurrent read detected on {nameof(TrakitConverter<T>)}");
			}
			_isReading = true;
			try {
				return this.deconvert(reader, type, (T)value, false, serializer);
			} finally {
				_isReading = false;
			}
		}
		/// <summary>
		/// 
		/// </summary>
		/// <param name="writer"></param>
		/// <param name="value"></param>
		/// <param name="serializer"></param>
		/// <exception cref="InvalidOperationException"></exception>
		public override sealed void WriteJson(
			JsonWriter writer,
			object value,
			JsonSerializer serializer
		) {
			if (_isReading) {
				// Protect against any changes to Newtonsoft that somehow cause concurrent access in the same thread recursively
				throw new InvalidOperationException($"Concurrent write detected on {nameof(TrakitConverter<T>)}");
			}
			_isWriting = true;
			try {
				this.convert(writer, (T)value, serializer);
			} finally {
				_isWriting = false;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="reader"></param>
		/// <param name="type"></param>
		/// <param name="value"></param>
		/// <param name="existing"></param>
		/// <param name="serializer"></param>
		/// <returns></returns>
		public abstract T deconvert(
			JsonReader reader,
			Type type,
			T value,
			bool existing,
			JsonSerializer serializer
		);
		/// <summary>
		/// 
		/// </summary>
		/// <param name="writer"></param>
		/// <param name="value"></param>
		/// <param name="serializer"></param>
		public abstract void convert(
			JsonWriter writer,
			T value,
			JsonSerializer serializer
		);
	}
}