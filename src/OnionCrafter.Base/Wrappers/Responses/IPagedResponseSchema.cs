namespace OnionCrafter.Base.Wrappers.Responses
{
    public interface IPagedResponseSchema<TKey, TResponseData>
        : IResponseSchema<TKey, TResponseData>
        where TResponseData : IResponseData
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public Uri? FirstPage { get; set; }
        public Uri? LastPage { get; set; }
        public int TotalPages { get; set; }
        public int TotalRecords { get; set; }
        public Uri? NextPage { get; set; }
        public Uri? PreviousPage { get; set; }
    }
}