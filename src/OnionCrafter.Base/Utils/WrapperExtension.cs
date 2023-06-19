using OnionCrafter.Base.DTOs;
using OnionCrafter.Base.Wrappers.Responses;

namespace OnionCrafter.Base.Utils
{
    /// <summary>
    /// This static class provides extension methods for working with wrappers for requests and responses.
    /// </summary>
    public static class WrapperExtension
    {
        /// <summary>
        /// Creates a void response with the specified result status and returns the response schema instance.
        /// </summary>
        /// <typeparam name="TResponseSchema">The response schema type.</typeparam>
        /// <typeparam name="TKey">The key of the response schema.</typeparam>
        /// <param name="responseSchema">The response schema instance.</param>
        /// <param name="result">The result status of the response.</param>
        /// <returns>The response schema instance.</returns>
        public static TResponseSchema CreateVoidResponse<TKey, TResponseSchema>(this TResponseSchema responseSchema, bool result)
            where TResponseSchema : IResponseSchema<TKey, VoidDTO>
            where TKey : notnull, IComparable<TKey>, IEquatable<TKey>
        {
            responseSchema.SetResponseData(new VoidDTO());
            if (result)
                responseSchema.SetSuccessfullyResult();

            return responseSchema;
        }
    }
}