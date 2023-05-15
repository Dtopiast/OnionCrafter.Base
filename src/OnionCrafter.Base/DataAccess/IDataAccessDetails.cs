namespace OnionCrafter.Base.DataAccess
{
    /// <summary>
    /// Specifies the level of data access privileges.
    /// </summary>
    public enum DataAccesssPrivilegesLevel
    {
        None = 0,
        Read,
        Write,
        Complete
    }

    /// <summary>
    /// Specifies the origin of the data context.
    /// </summary>
    public enum DataContextOrigin
    {
        None = 0,
        Database,
        File,
        Memory,
        Api,
    }

    /// <summary>
    /// Represents the details of data access.
    /// </summary>
    public interface IDataAccessDetails
    {
        // <summary>
        /// Gets the level of data access privileges.
        /// </summary>
        public DataAccesssPrivilegesLevel DataAccesssPrivilegesLevel { get; }

        /// <summary>
        /// Gets the origin of the data context.
        /// </summary>
        public DataContextOrigin DataContextOrigin { get; }

        /// <summary>
        /// Gets the name associated with the data access details.
        /// </summary>
        public string Name { get; }
    }
}