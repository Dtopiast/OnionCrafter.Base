﻿namespace OnionCrafter.Base.Commons
{
    /// <summary>
    /// Interface for tracing actions with a generic key.
    /// </summary>
    public interface IActionTrace<TKey>
        where TKey : notnull, IEquatable<TKey>, IComparable<TKey>
    {
        /// <summary>
        /// Set or get the tracing action Id
        /// </summary>
        public TKey ActionId { get; set; }
    }
}