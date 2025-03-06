namespace ClosetFit.Domain.Pagination;
public class PagedRequest
{
    public int pageNumber {get; set; } = PagedConfiguration.DefaultPageNumber;
    public int pageSize {get; set; } = PagedConfiguration.DefaultPageSize;
}
