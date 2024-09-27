﻿using System.Collections.Generic;
using System.Text;
using System;
using trakit.objects;

namespace trakit.tools {
	/// <summary>
	/// 
	/// </summary>
	public static class polyline {
		/// <summary>
		/// A C# implementation to encode a polyline using Google's Encoded Polyline algorithm.
		/// </summary>
		/// <param name="latlngs"></param>
		/// <param name="precision"></param>
		/// <returns>Encoded string</returns>
		public static string encode(IEnumerable<LatLng> latlngs, byte precision = 5) {
			var encodedPoints = new StringBuilder();
			Action<int> encode = (diff) => {
				int shifted = diff << 1;
				if (diff < 0) shifted = ~shifted;
				while (shifted >= 0x20) {
					encodedPoints.Append((char)((0x20 | (shifted & 0x1f)) + 63));
					shifted >>= 5;
				}
				encodedPoints.Append((char)(shifted + 63));
			};
			int factor = (int)Math.Pow(10, precision),
				lastLat = 0,
				lastLng = 0;
			foreach (var latlng in latlngs) {
				int currentLat = (int)Math.Round(latlng.lat * factor),
					currentLng = (int)Math.Round(latlng.lng * factor);
				encode(currentLat - lastLat);
				encode(currentLng - lastLng);
				lastLat = currentLat;
				lastLng = currentLng;
			}
			return encodedPoints.ToString();
		}
		/// <summary>
		/// A C# implementation to decode a polyline using Google's Encoded Polyline algorithm.
		/// </summary>
		/// <param name="encodedPoints"></param>
		/// <param name="precision"></param>
		/// <returns></returns>
		public static IEnumerable<LatLng> decode(string encodedPoints, byte precision = 5) {
			if (string.IsNullOrEmpty(encodedPoints)) throw new ArgumentNullException("encodedPoints");

			var polylineChars = encodedPoints.ToCharArray();
			int index = 0,
				currentLat = 0,
				currentLng = 0,
				factor = (int)Math.Pow(10, precision);

			while (index < polylineChars.Length) {
				// calculate next latitude
				int sum = 0,
					shifter = 0,
					next5bits;
				do {
					next5bits = (int)polylineChars[index++] - 63;
					sum |= (next5bits & 31) << shifter;
					shifter += 5;
				} while (next5bits >= 32 && index < polylineChars.Length);

				if (index >= polylineChars.Length) break;

				currentLat += (sum & 1) == 1
						? ~(sum >> 1)
						: (sum >> 1);

				//calculate next longitude
				sum = 0;
				shifter = 0;
				do {
					next5bits = (int)polylineChars[index++] - 63;
					sum |= (next5bits & 31) << shifter;
					shifter += 5;
				} while (next5bits >= 32 && index < polylineChars.Length);

				if (index >= polylineChars.Length && next5bits >= 32)
					break;

				currentLng += (sum & 1) == 1
						? ~(sum >> 1)
						: (sum >> 1);

				yield return new LatLng(
					Convert.ToDouble(currentLat) / factor,
					Convert.ToDouble(currentLng) / factor
				);
			}
		}
	}
}