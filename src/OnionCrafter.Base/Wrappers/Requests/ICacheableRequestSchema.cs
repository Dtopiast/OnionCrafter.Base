namespace OnionCrafter.Base.Wrappers.Requests
{
    public interface ICacheableRequestSchema
    {
        public bool BypassCache { get; }
        public abstract string CacheKey { get; }
        public TimeSpan? SlidingExpiration { get; }
    }
}