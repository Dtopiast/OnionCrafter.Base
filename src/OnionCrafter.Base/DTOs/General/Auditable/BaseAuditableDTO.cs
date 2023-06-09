﻿namespace OnionCrafter.Base.DTOs.General.Auditable
{
    /// <summary>
    /// Abstract base class for an auditable Data Transfer Object (DTO).
    /// </summary>
    public abstract class BaseAuditableDTO :
        BaseDTO, IAuditableDTO
    {
        /// <summary>
        /// Gets or sets the created date and time.
        /// </summary>
        public DateTime Created { get; set; }

        /// <summary>
        /// Gets or sets the updated date and time.
        /// </summary>
        public DateTime Updated { get; set; }
    }
}