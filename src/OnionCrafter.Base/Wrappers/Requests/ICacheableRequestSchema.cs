namespace OnionCrafter.Base.Wrappers.Requests.Query
{
    public interface ICacheableRequestSchema
    {
        public bool BypassCache { get; }
        public abstract string CacheKey { get; }
        public TimeSpan? SlidingExpiration { get; }
    }
}