namespace OnionCrafter.Base.Commons
{
    /// <summary>
    /// Interface for defining a template method pattern.
    /// </summary>
    public interface ITemplateMethod
    {
        /// <summary>
        /// Abstract method to be executed before the task is executed.
        /// </summary>
        abstract Task OnBeforeExecuteAsync();

        /// <summary>
        /// Represents an asynchronous method that is called after the execution of a task.
        /// </summary>
        abstract Task OnAfterExecuteAsync();
    }
}