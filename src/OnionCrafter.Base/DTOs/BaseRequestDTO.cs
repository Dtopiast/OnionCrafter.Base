using OnionCrafter.Base.Wrappers.Requests;

namespace OnionCrafter.Base.DTOs
{
    /// <summary>
    /// Abstract base class for a request Data Transfer Object (DTO).
    /// </summary>
    public abstract class BaseRequestDTO :
        BaseDTO, IRequestData
    {
    }
}