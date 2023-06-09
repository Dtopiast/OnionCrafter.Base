﻿using OnionCrafter.Base.DTOs.General.Auditable;
using OnionCrafter.Base.Wrappers.Responses.General;

namespace OnionCrafter.Base.DTOs
{
    /// <summary>
    /// Abstract base class for a Response Data Transfer Object (DTO) that includes audit information.
    /// </summary>
    public abstract class BaseResponseAuditableDTO :
        BaseAuditableDTO, IResponseData
    {
    }
}