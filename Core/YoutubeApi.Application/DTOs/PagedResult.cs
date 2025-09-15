namespace YoutubeApi.Application.DTOs;

public class PagedResult<T>
{
    public int Page { get; set; }
    public int PageSize { get; set; }
    public int TotalItems { get; set; }
    public int TotalPages { get; set; }
    public bool HasNextPage { get; set; }
    public bool HasPreviousPage { get; set; }
    public IList<T> Items { get; set; } = new List<T>();

    public PagedResult() { }

    public PagedResult(IList<T> items, int page, int pageSize, int totalItems)
    {
        Items = items;
        Page = page;
        PageSize = pageSize;
        TotalItems = totalItems;
        TotalPages = (int)Math.Ceiling((double)totalItems / pageSize);
        HasNextPage = page < TotalPages;
        HasPreviousPage = page > 1;
    }
}
