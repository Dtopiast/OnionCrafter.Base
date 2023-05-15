namespace OnionCrafter.Base.Wrappers.Responses
{
    /// <summary>
    /// Represents a paged response schema. Implements the <see cref="IResponseSchema{TKey, TResponseData}"/> interface.
    /// </summary>
    /// <typeparam name="TKey">The type of the response schema key.</typeparam>
    /// <typeparam name="TResponseData">The type of the response data.</typeparam>
    public interface IPagedResponseSchema<TKey, TResponseData> : IResponseSchema<TKey, TResponseData>
        where TResponseData : IResponseData
    {
        /// <summary>
        /// Gets or sets the URI of the first page.
        /// </summary>
        Uri? FirstPage { get; set; }

        /// <summary>
        /// Gets or sets the URI of the last page.
        /// </summary>
        Uri? LastPage { get; set; }

        /// <summary>
        /// Gets or sets the URI of the next page.
        /// </summary>
        Uri? NextPage { get; set; }

        /// <summary>
        /// Gets or sets the page number.
        /// </summary>
        int PageNumber { get; set; }

        /// <summary>
        /// Gets or sets the page size.
        /// </summary>
        int PageSize { get; set; }

        /// <summary>
        /// Gets or sets the URI of the previous page.
        /// </summary>
        Uri? PreviousPage { get; set; }

        /// <summary>
        /// Gets or sets the total number of pages.
        /// </summary>
        int TotalPages { get; set; }

        /// <summary>
        /// Gets or sets the total number of records.
        /// </summary>
        int TotalRecords { get; set; }
    }
}