using OnionCrafter.Base.DTOs.General;
using OnionCrafter.Base.Wrappers.Responses.General;

namespace OnionCrafter.Base.DTOs
{
    /// <summary>
    /// Abstract base class for a Response Data Transfer Object (DTO).
    /// </summary>
    public abstract class BaseResponseDTO :
        BaseDTO, IResponseData
    {
    }
}