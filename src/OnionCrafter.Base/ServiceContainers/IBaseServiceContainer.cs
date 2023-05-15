using OnionCrafter.Base.DataAccess;

namespace OnionCrafter.Base.ServiceContainers
{
    /// <summary>
    /// Interface representing a base service container that implements <see cref="IDataAccessDetails"/> and <see cref="IAsyncDisposable"/>.
    /// </summary>
    public interface BaseServiceContainer : IDataAccessDetails, IAsyncDisposable
    {
    }
}