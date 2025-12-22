namespace LearnApiTraining2025_1.Server.Dtos.Common;

public class PagedResult<T>
{
    public int Page { get; set; }
    public int PageSize { get; set; }
    public int TotalCount { get; set; }

    public List<T> Items { get; set; } = new();
}
