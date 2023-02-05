namespace MM.ServerMonitoring.Repository.EntityFramework.Infrastructure;

public class Page<T>
{
    public IEnumerable<T> Items { get; set; }

    public int PageIndex { get; set; }

    public int PageCount { get; set; }
}