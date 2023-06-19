using System.Text.Json;

namespace OnionCrafter.Base.Utils
{
    /// <summary>
    /// This static class provides extension methods for working with JSON objects.
    /// </summary>
    public static class JsonExtensions
    {
        /// <summary>
        /// Serializes the specified value to a JSON string using the specified options.
        /// </summary>
        /// <typeparam name="TObject">The type of the object to serialize.</typeparam>
        /// <param name="value">The object to serialize.</param>
        /// <param name="options">The JSON serializer options.</param>
        /// <returns>A JSON string representation of the object.</returns>
        public static string ToJson<TObject>(this TObject value, JsonSerializerOptions? options = null) where TObject : class
        {
            return JsonSerializer.Serialize(value, options);
        }

        /// <summary>
        /// Deserializes the specified JSON string into an object of type TObject.
        /// </summary>
        /// <typeparam name="TObject">The type of the object to deserialize.</typeparam>
        /// <param name="value">The JSON string to deserialize.</param>
        /// <param name="options">The JsonSerializerOptions to use when deserializing.</param>
        /// <returns>The deserialized object of type TObject.</returns>
        public static TObject? ToObject<TObject>(this string value, JsonSerializerOptions? options = null) where TObject : class
        {
            return JsonSerializer.Deserialize<TObject>(value, options) ?? default;
        }
    }
}