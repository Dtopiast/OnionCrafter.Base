namespace OnionCrafter.Base.Wrappers.Responses.Paged
{
    /// <summary>
    /// Represents a base implementation of a paged response schema. Inherits from <see cref="BaseResponseSchema{TKey, TResponseData}"/> and implements <see cref="IPagedResponseSchema{TKey, TResponseData}"/>.
    /// </summary>
    /// <typeparam name="TKey">The type of the response schema key.</typeparam>
    /// <typeparam name="TResponseData">The type of the response data.</typeparam>
    public abstract class BasePagedResponseSchema<TKey, TResponseData> :
        BaseResponseSchema<TKey, TResponseData>,
        IPagedResponseSchema<TKey, TResponseData>
        where TResponseData : IResponseData
        where TKey : notnull, IEquatable<TKey>, IComparable<TKey>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BasePagedResponseSchema{TKey, TResponseData}"/> class with the specified page number and page size.
        /// </summary>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        protected BasePagedResponseSchema(int pageNumber, int pageSize)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;
        }

        /// <summary>
        /// Gets or sets the URI of the first page.
        /// </summary>
        public Uri? FirstPage { get; set; }

        /// <summary>
        /// Gets or sets the URI of the last page.
        /// </summary>
        public Uri? LastPage { get; set; }

        /// <summary>
        /// Gets or sets the URI of the next page.
        /// </summary>
        public Uri? NextPage { get; set; }

        /// <summary>
        /// Gets or sets the page number of the paged response.
        /// </summary>
        public int PageNumber { get; set; }

        /// <summary>
        /// Gets or sets the page size of the paged response.
        /// </summary>
        public int PageSize { get; set; }

        /// <summary>
        /// Gets or sets the URI of the previous page.
        /// </summary>
        public Uri? PreviousPage { get; set; }

        /// <summary>
        /// Gets or sets the total number of pages.
        /// </summary>
        public int TotalPages { get; set; }

        /// <summary>
        /// Gets or sets the total number of records.
        /// </summary>
        public int TotalRecords { get; set; }
    }
}