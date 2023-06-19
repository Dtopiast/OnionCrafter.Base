namespace OnionCrafter.Base.Commons
{
    /// <summary>
    /// Interface for logging actions.
    /// </summary>
    public interface ILogAction
    {
        /// <summary>
        /// Logs an action with the specified result, action type, and arguments.
        /// </summary>
        /// <typeparam name="TActions">The type of the action.</typeparam>
        /// <param name="actionResult">The result of the action.</param>
        /// <param name="action">The action type.</param>
        /// <param name="args">The arguments for the action.</param>
        /// <remarks>
        /// This method logs the specified action with its result and additional arguments.
        /// The action type must be an enum.
        /// </remarks>
        abstract void LogAction<TActions>(bool actionResult, TActions action, params object?[] args)
            where TActions : struct, Enum;
    }
}