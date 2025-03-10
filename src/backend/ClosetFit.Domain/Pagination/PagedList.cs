namespace ClosetFit.Domain.Pagination;
public class PagedList<TData> : ResponseModel<TData>
{
    public int CurrentPage { get; set; }
    public int TotalPage => (int)Math.Ceiling(TotalCount / (double)PageSize);
    public int PageSize { get; set; } = PagedConfiguration.DefaultPageSize;
    public int TotalCount { get; set; }

    [JsonConstructor]
    public PagedList(TData? data, int totalCount, int currentPage = 1, int pageSize = PagedConfiguration.DefaultPageSize) : base(data)
    {
        Data = data;
        TotalCount = totalCount;
        CurrentPage = currentPage;
        PageSize = pageSize;
    }
    public PagedList(TData? data, int code, string? message = null) : base(data, code, message){}

}
