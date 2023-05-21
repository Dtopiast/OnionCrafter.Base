namespace OnionCrafter.Base.DataAccess
{
    /// <summary>
    /// Specifies the level of data access privileges.
    /// </summary>
    public enum DataAccesssPrivilegesLevel
    {
        /// <summary>
        /// No data access privileges.
        /// </summary>
        None = 0,

        /// <summary>
        /// Read data access privileges.
        /// </summary>
        Read,

        /// <summary>
        /// Write data access privileges.
        /// </summary>
        Write,

        /// <summary>
        /// Complete data access privileges.
        /// </summary>
        Complete
    }

    /// <summary>
    /// Specifies the origin of the data context.
    /// </summary>
    public enum DataContextOrigin
    {
        /// <summary>
        /// No specific origin.
        /// </summary>
        None = 0,

        /// <summary>
        /// Database origin.
        /// </summary>
        Database,

        /// <summary>
        /// File origin.
        /// </summary>
        File,

        /// <summary>
        /// Memory origin.
        /// </summary>
        Memory,

        /// <summary>
        /// API origin.
        /// </summary>
        Api,
    }

    /// <summary>
    /// Represents the details of data access.
    /// </summary>
    public interface IDataAccessDetails
    {
        /// <summary>
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