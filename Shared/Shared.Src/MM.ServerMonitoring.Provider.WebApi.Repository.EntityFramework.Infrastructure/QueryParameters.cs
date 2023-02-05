namespace MM.ServerMonitoring.Repository.EntityFramework.Infrastructure;

public class QueryParameters
{
    public string Query { get; set; }
    public int PageIndex { get; set; }
    public int PageSize { get; set; }
}