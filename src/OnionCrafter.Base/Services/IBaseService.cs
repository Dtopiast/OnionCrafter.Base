using OnionCrafter.Base.Commons;

namespace OnionCrafter.Base.Services
{
    /// <summary>
    /// Base interface for a service.
    /// </summary>
    public interface IBaseService : IAsyncDisposable, IClonable<IService>
    {
    }
}