namespace OnionCrafter.Base.Wrappers.Responses
{
    public abstract class BasePagedResponseSchema<TKey, TResponseData> :
        BaseResponseSchema<TKey, TResponseData>,
        IPagedResponseSchema<TKey, TResponseData>
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

        protected BasePagedResponseSchema(int pageNumber, int pageSize)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;
        }
    }
}