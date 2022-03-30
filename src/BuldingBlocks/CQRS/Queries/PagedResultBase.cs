namespace BuildingBlocks.CQRS.Queries;

public abstract class PagedResultBase
{
    protected PagedResultBase()
    {
    }

    protected PagedResultBase(int currentPage, int resultsPerPage,
        int totalPages, long totalResults)
    {
        CurrentPage = currentPage > totalPages ? totalPages : currentPage;
        ResultsPerPage = resultsPerPage;
        TotalPages = totalPages;
        TotalResults = totalResults;
    }

    public int CurrentPage { get; }
    public int ResultsPerPage { get; }
    public int TotalPages { get; }
    public long TotalResults { get; }
}